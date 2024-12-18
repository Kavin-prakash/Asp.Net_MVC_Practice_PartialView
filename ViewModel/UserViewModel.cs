using System.ComponentModel.DataAnnotations;

public class UserViewModel
{
    [Required]
    [EmailAddress]
    // [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    // [Display(Name = "Password")]
    public string Password { get; set; }
}
