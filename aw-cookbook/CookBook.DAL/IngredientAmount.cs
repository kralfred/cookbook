using CookBook.DAL;
using Microsoft.Identity.Client;

namespace CookBook;

public class IngredientAmount : IEntity
{ 
    public Guid Id { get; set; }
    public int Amount {  get; set; }
    public RecipeEntity Recipe { get; set; }
    public IngredientEntity Ingredient { get; set; }
    public Guid RecipeId { get; set; }
    public Guid IngredientId { get; set; }

    public IngredientAmount()
    {
        this.Id = Guid.NewGuid();
    }
}


