using MyRESTServices.ClientMVC.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MyRESTServices.ClientMVC.Services
{
    public class CategoryService : ICategory
    {
        private HttpClient _client;
        private readonly IConfiguration _configuration;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(HttpClient client, IConfiguration configuration, ILogger<CategoryService> logger)
        {
            _client = client;
            _configuration = configuration;
            _logger = logger;
        }

        private string GetBaseUrl()
        {
            return _configuration["BaseUrl"] + "/api/Categories";
        }

        public async Task<IEnumerable<Category>> GetAll(string token)
        {
            _client.DefaultRequestHeaders.Authorization =
               new AuthenticationHeaderValue("Bearer", token);
            var httpResponse = await _client.GetAsync(GetBaseUrl());

            if (!httpResponse.IsSuccessStatusCode)
            {
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new Exception("Unauthorized");
                }
                throw new Exception("Cannot retrieve category");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            _logger.LogInformation("----------------------------------------->" + content);
            var categories = JsonSerializer.Deserialize<List<Category>>(content);
            return categories;
        }
    }
}
