using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.Common.Models.Ingredient;


namespace CookBook.BL.Facades.Interfaces;

public interface IIngredientFacade : IFacade<IngredientListModel, IngredientDetailModel>
{
    IngredientDetailModel Save(IngredientDetailModel ingredient);
}
