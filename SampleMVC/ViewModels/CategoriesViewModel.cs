

using MyRESTServices.BLL.DTOs;

namespace SampleMVC.ViewModels
{
    public class CategoriesViewModel
    {
        public IEnumerable<CategoryDTO>? Categories { get; set; }
        public CategoryCreateDTO? CategoryCreateDTO { get; set; }
        public CategoryUpdateDTO? CategoryUpdateDTO { get; set; }
    }
}
