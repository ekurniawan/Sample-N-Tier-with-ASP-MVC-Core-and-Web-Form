using FluentValidation;

namespace MyRESTServices.BLL.DTOs.Validation
{
    public class ArticleUpdateDTOValidator : AbstractValidator<ArticleUpdateDTO>
    {
        public ArticleUpdateDTOValidator()
        {
            RuleFor(a => a.CategoryID).NotEmpty();
            RuleFor(a => a.Title).NotEmpty().MaximumLength(100);
            RuleFor(a => a.Details).NotEmpty().MaximumLength(500);
            RuleFor(a => a.IsApproved).NotEmpty();
            RuleFor(a => a.Pic).NotEmpty().MaximumLength(100);
        }
    }
}
