using CookBook.BL.Facades;
using CookBook.BL.Facades.Interfaces;
using CookBook.Common.Models.Ingredient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CookBook.MVC.API.Controllers;

[ApiController]
[Route("[controller]")]
public class IngredientsController : ControllerBase
{
    private readonly IIngredientFacade ingredientFacade;

    public IngredientsController(IIngredientFacade ingredientFacade)
    {
        this.ingredientFacade = ingredientFacade;
    }

    [HttpGet]
    [Authorize]
    public IEnumerable<IngredientListModel> GetIngredients()
    {
        return ingredientFacade.Get();
    }

    [HttpGet("{id}")]
    public IngredientDetailModel? GetIngredientById(Guid id)
    {
        return ingredientFacade.Get(id);
    }


    [HttpPost]
    public IngredientDetailModel Insert(IngredientDetailModel ingredient)
    {
        return ingredientFacade.Save(ingredient);
    }

    [HttpPut]
    public IngredientDetailModel Update(IngredientDetailModel ingredient)
    {
        return ingredientFacade.Save(ingredient);
    }

    [HttpDelete]
    [Authorize("recipeadminpolicy")]
    public void Delete(Guid id)
    {
        ingredientFacade.Delete(id);
    }
}

