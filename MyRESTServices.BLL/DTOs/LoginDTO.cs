namespace MyRESTServices.BLL.DTOs
{
    public class LoginDTO
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; } = string.Empty;
    }
}
