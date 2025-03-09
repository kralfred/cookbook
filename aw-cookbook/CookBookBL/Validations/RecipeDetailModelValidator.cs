using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using CookBook.Common.Models.Recipe;

namespace CookBook.BL.Validations;

public class RecipeDetailModelValidator : AbstractValidator<RecipeDetailModel>
{
    public RecipeDetailModelValidator() {

        RuleFor(model => model.Id)
         .NotNull()
         .WithMessage("Id not created automaticaly");

        RuleFor(model => model.Name)
          .NotNull()
          .NotEmpty()
          .MinimumLength(2)
          .WithMessage("Name has to be at least 2 letters long");

        

    }
   

}
