namespace MyRESTServices.ClientMVC.Models
{
    public class UserWithTokenViewModel
    {
        public string Username { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public IEnumerable<string> Roles { get; set; }
    }
}
