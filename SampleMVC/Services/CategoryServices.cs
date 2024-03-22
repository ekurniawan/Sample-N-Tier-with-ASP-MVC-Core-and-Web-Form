using MyRESTServices.BLL.DTOs;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SampleMVC.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        private readonly ILogger<CategoryServices> _logger;

        public CategoryServices(HttpClient client, IConfiguration configuration, ILogger<CategoryServices> logger)
        {
            _client = client;
            _configuration = configuration;
            _logger = logger;
        }

        private string GetBaseUrl()
        {
            return _configuration["BaseUrl"] + "/Categories";
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InJlYWRlcnVzZXIiLCJyb2xlIjoicmVhZGVyIiwibmJmIjoxNzExMDkzOTQwLCJleHAiOjE3MTExODAzNDAsImlhdCI6MTcxMTA5Mzk0MH0.kvN1-_QYlSI-fT3ADJ94Dn6pURiK9wuEMblK-YPcWF4");
            _logger.LogInformation(GetBaseUrl());
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
            var categories = JsonSerializer.Deserialize<IEnumerable<CategoryDTO>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return categories;
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var httpResponse = await _client.GetAsync($"{GetBaseUrl()}/{id}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve category");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var category = JsonSerializer.Deserialize<CategoryDTO>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return category;
        }

        //post
        public async Task<CategoryDTO> Insert(CategoryCreateDTO categoryCreateDTO)
        {
            var json = JsonSerializer.Serialize(categoryCreateDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await _client.PostAsync(GetBaseUrl(), data);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot insert category");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var category = JsonSerializer.Deserialize<CategoryDTO>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return category;
        }

        //put
        public async Task Update(int id, CategoryUpdateDTO categoryUpdateDTO)
        {
            var json = JsonSerializer.Serialize(categoryUpdateDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await _client.PutAsync($"{GetBaseUrl()}/{id}", data);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot update category");
            }
        }

        //delete
        public async Task Delete(int id)
        {
            var httpResponse = await _client.DeleteAsync($"{GetBaseUrl()}/{id}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot delete category");
            }
        }

        public async Task<IEnumerable<CategoryDTO>> GetWithPaging(int pageNumber, int pageSize, string name)
        {

            var paramUrl = $"/GetWithPaging?pageNumber={pageNumber}&pageSize={pageSize}&name={name}";

            _logger.LogInformation($"{paramUrl}");
            var httpResponse = await _client.GetAsync(GetBaseUrl() + paramUrl);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve category");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var categories = JsonSerializer.Deserialize<IEnumerable<CategoryDTO>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return categories;
        }

        public async Task<int> GetCountCategories(string name)
        {
            var httpResponse = await _client.GetAsync($"{GetBaseUrl()}/GetCountCategories?name={name}");

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve category");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();

            return Convert.ToInt32(content);
        }
    }
}
