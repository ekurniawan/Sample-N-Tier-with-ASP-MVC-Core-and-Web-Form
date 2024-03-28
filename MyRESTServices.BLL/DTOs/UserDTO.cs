namespace MyRESTServices.BLL.DTOs
{
    public class UserDTO
    {
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Telp { get; set; }

        public IEnumerable<RoleDTO>? Roles { get; set; }
    }
}
