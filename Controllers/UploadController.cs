using Microsoft.AspNetCore.Mvc;
using Practice_User_Login.Data;
using Practice_User_Login.Models;
using System.IO;
// using OfficeOpenXml; // using EPPlus library for Excel file

using CsvHelper;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
public class UploadController : Controller
{

    private readonly PracticeLoginContext _context;

    public UploadController(PracticeLoginContext practiceLoginContext)
    {
        _context = practiceLoginContext;
    }
    // Index for Rendring View
    public ActionResult UploadView()
    {
        return View();
    }

    [HttpPost]
    public IActionResult UploadFile(IFormFile SingleFile)
    {
        try
        {
            string[] supportedtypes = ["txt", "pdf", "img", "jpg"];

            var fileExtension = Path.GetExtension(SingleFile.FileName).Substring(1);
            if (supportedtypes.Contains(fileExtension))
            {
                if (SingleFile != null || SingleFile.Length > 0)
                {
                    string filename = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UploadFiles", SingleFile.FileName);
                    // Using Buffering
                    using (var stream = new FileStream(filename, FileMode.Create))
                    {
                        SingleFile.CopyTo(stream);
                    }
                    return StatusCode(201);
                }
                else
                {
                    return StatusCode(500, "File is Empty");
                }
            }

            else
            {
                return StatusCode(400, "Invalid File Type Format");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }

    }

    [HttpPost]
    public IActionResult UploadProductDetails(IFormFile ProductFile)
    {
        try
        {
            string[] extensiontypes = ["txt", "xlsx", "csv"];

            string fileExtension = Path.GetExtension(ProductFile.FileName).Substring(1);

            if (extensiontypes.Contains(fileExtension))
            {
                if (fileExtension == "txt")
                {
                    using (var filereader = new StreamReader(ProductFile.OpenReadStream()))
                    {
                        var products = new List<Product>();
                        string line;

                        while ((line = filereader.ReadLine()) != null)
                        {
                            var fields = line.Split(','); // Split

                            var product = new Product
                            {
                                // ProductID = int.Parse(fields[0].Split(':')[1]),
                                ProductName = fields[1].Split(":")[1],
                                ProductCategory = fields[2].Split(":")[1],
                                ProductDescription = fields[3].Split(":")[1],
                                ProductPrice = decimal.Parse(fields[4].Split(":")[1]),
                            };

                            products.Add(product);
                        }

                        if (products.Any())
                        {
                            _context.Products.AddRange(products);
                            _context.SaveChanges();
                            return Ok("Products uploaded successfully");
                        }
                        else
                        {
                            return StatusCode(400, "No products to insert");
                        };
                    }
                }
                else
                {
                    using (var filereader = new StreamReader(ProductFile.OpenReadStream()))
                    {

                        using (var csv = new CsvReader(filereader, CultureInfo.InvariantCulture))
                        {
                            var records = csv.GetRecords<Product>().ToList();
                            // _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT  [dbo].Products ON");

                            foreach (var record in records)
                            {
                                record.ProductID = 0;// Set ProductID to 0 to allow SQL Server to auto-generate the ID
                            }
                            _context.Products.AddRange(records);
                            _context.SaveChanges();
                            // _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT  [dbo].Products OFF");
                        };

                    };
                    return Ok("Excel Data is Uploaded Successfully");
                }
            }
            else
            {
                return StatusCode(400, "Invalid File Format , Required Correct File Format");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }

}