using System.ComponentModel.DataAnnotations;

public class ProductVIew
{

    [Required]
    public string ProductName { get; set; }
    [Required]
    public string ProductCategory { get; set; }
    [Required]
    public string ProductDescription { get; set; }
    [Required]
    public decimal ProductPrice { get; set; }
}

