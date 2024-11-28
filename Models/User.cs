using System.ComponentModel.DataAnnotations;

namespace Practice_User_Login.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public long UserMobileNumber { get; set; }
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string UserPasswordHash { get; set; }
        [Required]
        public string Salt { get; set; }
        [Required]
        public DateTime UserRegisteredDateTime { get; set; }
        [Required]
        public DateTime UserLastActionDateTime { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}