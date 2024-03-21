using FluentValidation;

namespace MyRESTServices.BLL.DTOs.Validation
{
    public class ArticleCreateDTOValidator : AbstractValidator<ArticleCreateDTO>
    {
        public ArticleCreateDTOValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Details).NotEmpty().WithMessage("Details is required");
        }
    }
}
