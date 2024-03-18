using FluentValidation;

namespace MyWebFormApp.BLL.DTOs
{
    public class CategoryCreateDTO
    {
        public string CategoryName { get; set; }
    }

    public class CategoryCreateDTOValidator : AbstractValidator<CategoryCreateDTO>
    {
        public CategoryCreateDTOValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category Name harus diisi");
            RuleFor(x => x.CategoryName).MaximumLength(100).WithMessage("Category Name maksimal 50 karakter");
        }
    }
}
