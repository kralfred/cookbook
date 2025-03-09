using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.BL.Facades.Interfaces;
using CookBook.Common.Models.Recipe;

namespace CookBookBL.Facades.Interfaces;

public interface IRecipeFacade : IFacade<RecipeListModel, RecipeDetailModel>
{
}
