using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.Common.Models.Ingredient;

namespace CookBook.Common.Models.Recipe;

    public record IngredientAmountModel
    {
        public Guid Id { get; set; }

        public IngredientListModel? Ingredient { get; set; }

        public RecipeListModel? Recipe { get; set; }

        public int Amount { get; set; }
    }

