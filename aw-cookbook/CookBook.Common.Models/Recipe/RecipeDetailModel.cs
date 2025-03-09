using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.Common.Models.Ingredient;

namespace CookBook.Common.Models.Recipe;

public record RecipeDetailModel : IModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TimeSpan? Duration { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public IList<IngredientAmountModel> IngredientAmounts { get; set; } = new List<IngredientAmountModel>();
    }

