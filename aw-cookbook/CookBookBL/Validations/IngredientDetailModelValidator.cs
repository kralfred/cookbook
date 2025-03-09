using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client.Extensibility;
using FluentValidation;
using CookBook.Common.Models.Ingredient;

namespace CookBook.BL.Validations;

public class IngredientDetailModelValidator : AbstractValidator<IngredientDetailModel>
{
    public IngredientDetailModelValidator()
    {
        RuleFor(model => model.Description)
            .NotNull()
            .NotEmpty()
            .MaximumLength(10)
            .WithMessage("Wrong input");

   
    }

}
