namespace MyRESTServices.ClientMVC.Models
{
    public class RoleVM
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }

    public class UserWithRoleVM
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Telp { get; set; }
        public List<RoleVM> Roles { get; set; }
    }
}
