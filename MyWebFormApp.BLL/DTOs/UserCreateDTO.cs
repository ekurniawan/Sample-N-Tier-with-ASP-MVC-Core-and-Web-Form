using System.ComponentModel.DataAnnotations;

namespace MyWebFormApp.BLL.DTOs
{
    public class UserCreateDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string Repassword { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Telp { get; set; }

        [Required]
        public string SecurityQuestion { get; set; }

        [Required]
        public string SecurityAnswer { get; set; }
    }
}
