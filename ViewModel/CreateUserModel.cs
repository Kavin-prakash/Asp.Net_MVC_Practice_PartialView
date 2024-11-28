using System.ComponentModel.DataAnnotations;

public class CreateUserModel
{
    // [Required(ErrorMessage = "UserName is Required")]
    public string UserName { get; set; }

    // [Required(ErrorMessage = "User Email is Required")]
    // [DataType(DataType.EmailAddress)]
    public string UserEmail { get; set; }

    // [Required(ErrorMessage = "User Password is Required")]
    // [DataType(DataType.Password)]
    // [Range(8, 14)]
    public string UserPassword { get; set; }

    public string ConfirmPassword { get; set; }

    // [Required(ErrorMessage = "User Mobilenumber is Required")]
    // [Range(10, 10)]
    public long UserMobileNumber { get; set; }
}