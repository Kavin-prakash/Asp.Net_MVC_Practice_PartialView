using System.ComponentModel.DataAnnotations;

namespace Practice_User_Login.Models;
public class Product
{
    [Key]
    public long ProductID { get; set; }
    [Required]
    public string ProductName { get; set; }
    [Required]
    public string ProductCategory { get; set; }
    [Required]
    public string ProductDescription { get; set; }
    [Required]
    public decimal ProductPrice { get; set; }
}

