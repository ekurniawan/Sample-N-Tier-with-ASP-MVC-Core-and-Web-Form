using MyWebFormApp.BO;
using Newtonsoft.Json;

namespace SampleMVC.Services
{
    public class CategoryServices : ICategoryServices
    {
        private const string BaseUrl = "http://localhost:5272/api/v1/Categories";
        private readonly HttpClient _client;

        public CategoryServices(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var httpResponse = await _client.GetAsync(BaseUrl);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve category");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<Category>>(content);

            return categories;
        }
    }
}
