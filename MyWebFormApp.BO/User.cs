using System;
using System.Collections.Generic;

namespace MyWebFormApp.BO
{
    public class User
    {
        public User()
        {
            this.Articles = new List<Article>();
            this.Roles = new List<Role>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
        public bool IsLocked { get; set; }
        public byte MaxAttempt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Telp { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }

        public IEnumerable<Article> Articles { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}
