using System.Collections.Generic;

namespace MyWebFormApp.BO
{
    public class Role
    {
        public Role()
        {
            this.Users = new List<User>();
        }

        public int RoleID { get; set; }
        public string RoleName { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
