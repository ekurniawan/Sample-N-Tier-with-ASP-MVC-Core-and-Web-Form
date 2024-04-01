using System.ComponentModel.DataAnnotations;

namespace MyRESTServices.ClientMVC.Models
{
    public class LoginDTO
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
