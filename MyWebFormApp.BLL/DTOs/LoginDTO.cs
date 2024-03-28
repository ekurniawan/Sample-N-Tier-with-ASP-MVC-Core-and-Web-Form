using System.ComponentModel.DataAnnotations;

namespace MyWebFormApp.BLL.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; } = string.Empty;
    }
}
