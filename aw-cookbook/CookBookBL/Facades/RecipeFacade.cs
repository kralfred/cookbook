using AutoMapper;
using CookBook.Common.Models.Recipe;
using CookBook.DAL;
using CookBookBL.Facades.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CookBook.BL.Facades;

public class RecipeFacade : FacadeBase<RecipeEntity, RecipeListModel, RecipeDetailModel>, IRecipeFacade
{
    public RecipeFacade(IDbContextFactory<CookBookDbContext> dbContextFactory, IMapper mapper, ILogger<RecipeFacade> logger) : base(dbContextFactory, mapper, logger)
    {
    }
}
