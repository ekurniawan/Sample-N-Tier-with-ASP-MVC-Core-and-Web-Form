namespace MyRESTServices.BLL.DTOs
{
    public class UserCreateDTO
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Repassword { get; set; }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }


        public string Email { get; set; }


        public string Telp { get; set; }


        public string SecurityQuestion { get; set; }


        public string SecurityAnswer { get; set; }
    }
}
