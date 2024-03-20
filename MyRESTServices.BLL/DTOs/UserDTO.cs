using System.ComponentModel.DataAnnotations;

namespace MyRESTServices.BLL.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        [Display(Name = "Phone")]
        public string Telp { get; set; }

        public IEnumerable<RoleDTO> Roles { get; set; }
    }
}
