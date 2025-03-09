namespace CookBook.Web.Components.Pages.Ingredient;
using CookBook.Common.Models.Ingredient;
using FluentValidation;

public class IngredientValidator : AbstractValidator<IngredientDetailModel>
{
    public IngredientValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(200).WithMessage("Description cannot exceed 200 characters.");

        RuleFor(x => x.ImageUrl)
            .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
            .WithMessage("Invalid URL format.");
    }
}

