using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CookBook.BL.Facades.Interfaces;
using Microsoft.EntityFrameworkCore;
using CookBook.DAL;
using Microsoft.Extensions.Logging;
using CookBook.Common.Models.Ingredient;

namespace CookBook.BL.Facades;

public class IngredientFacade : FacadeBase<IngredientEntity, IngredientListModel, IngredientDetailModel>, IIngredientFacade
{
    ILogger<IngredientFacade> localLogger;

    public IngredientFacade(IDbContextFactory<CookBookDbContext> dbContextFactory, IMapper mapper, ILogger<IngredientFacade> logger) : base(dbContextFactory, mapper, logger)
    {
        localLogger = logger;
        localLogger.LogError("asas");
    }

    

}
