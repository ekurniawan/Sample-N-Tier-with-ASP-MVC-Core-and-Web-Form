using MyRESTServices.ClientMVC.Models;
using System.Text;
using System.Text.Json;

namespace MyRESTServices.ClientMVC.Services
{
    public class AccountService : IAccount
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AccountService> _logger;

        public AccountService(HttpClient client, IConfiguration configuration, ILogger<AccountService> logger)
        {
            _client = client;
            _configuration = configuration;
            _logger = logger;
        }

        private string GetBaseUrl()
        {
            return _configuration["BaseUrl"] + "/api/Users";
        }

        public async Task<UserWithTokenViewModel> Login(LoginDTO loginDTO)
        {
            var json = JsonSerializer.Serialize(loginDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await _client.PostAsync(GetBaseUrl() + "/login", data);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception($"Username / Password not match");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var userWithToken = JsonSerializer.Deserialize<UserWithTokenViewModel>(content);
            if (userWithToken == null)
            {
                throw new ArgumentException("failed retrieve token");
            }
            return userWithToken;
        }

        public async Task<IEnumerable<string>> GetRolesByUser(string username)
        {
            List<string> roles = new List<string>();
            var httpResponse = await _client.GetAsync(GetBaseUrl() + "/GetByUser");

            if (!httpResponse.IsSuccessStatusCode)
            {
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new Exception("Unauthorized");
                }
                throw new Exception("Cannot retrieve category");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var userWithRoles = JsonSerializer.Deserialize<UserWithRoleVM>(content);
            foreach (var role in userWithRoles.Roles)
            {
                roles.Add(role.RoleName);
            }
            return roles;
        }
    }
}
