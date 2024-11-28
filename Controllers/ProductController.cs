using Microsoft.AspNetCore.Mvc;
using Practice_User_Login.Data;
using Practice_User_Login.Models;

public class ProductController : Controller
{
    private readonly PracticeLoginContext _context;

    public ProductController(PracticeLoginContext practiceLoginContext)
    {
        _context = practiceLoginContext;
    }
    public ActionResult ProductIndex()
    {
        // List<Product> products = new List<Product>()
        //     {
        //         new Product { ProductID =1, ProductName ="Product 1", ProductCategory = "ProductCategory 1", ProductDescription ="ProductDescription 1", ProductPrice = 10m},
        //         new Product { ProductID =2, ProductName ="Product 2", ProductCategory = "ProductCategory 1", ProductDescription ="ProductDescription 2", ProductPrice = 20m},
        //         new Product { ProductID =3, ProductName ="Product 3", ProductCategory = "ProductCategory 1", ProductDescription ="ProductDescription 3", ProductPrice = 30m},
        //         new Product { ProductID =4, ProductName ="Product 4", ProductCategory = "ProductCategory 2", ProductDescription ="ProductDescription 4", ProductPrice = 40m},
        //         new Product { ProductID =5, ProductName ="Product 5", ProductCategory = "ProductCategory 2", ProductDescription ="ProductDescription 5", ProductPrice = 50m},
        //         new Product { ProductID =6, ProductName ="Product 6", ProductCategory = "ProductCategory 2", ProductDescription ="ProductDescription 6", ProductPrice = 50m}
        //     };
        // return View(products);

        return View();
    }

    [HttpGet]
    public ActionResult GetProductList()
    {
        var productlist = _context.Products.ToList();

        return Json(productlist);

    }
}