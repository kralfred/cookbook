using CookBook.Common.Models.Ingredient;
using CookBook.Web.Api;
using Microsoft.AspNetCore.Components;


namespace CookBook.Web.Components.Pages.Ingredient;

public partial class IngredientEditForm
{
    [Inject]
    public ILogger<IngredientEditForm> Logger { get; set; }

    [Inject]
    public IIngredientsClient Client { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        
    }
    private ICollection<IngredientListModel> ingredients = new List<IngredientListModel>();


    [Parameter]
    public Guid? Id { get; set; }

    private IngredientDetailModel ingredient = new IngredientDetailModel
    {
        Id = Guid.NewGuid(),
        Name = "asdasd",
        Description = string.Empty,
        ImageUrl = string.Empty
    };

    private async Task HandleSubmit()
    {
        if (Id == null)
        {
            var newIngredientModel = new IngredientDetailModel
            {
                Id = Guid.NewGuid(),
                Name = ingredient.Name,
                Description = ingredient.Description,
                ImageUrl = ingredient.ImageUrl
            };

            Console.WriteLine($"New ingredint with id:{ingredient.Id} added");

          await Client.IngredientsPOSTAsync(newIngredientModel);
        }
        else
        {
            var newIngredientModel = new IngredientDetailModel
            {
                Id = (Guid)Id,
                Name = ingredient.Name,
                Description = ingredient.Description,
                ImageUrl = ingredient.ImageUrl
            };
            await Client.IngredientsPUTAsync(newIngredientModel);
            Console.WriteLine($"Ingredient with id {ingredient.ImageUrl} updated");
        }
        Logger.LogError("Submited");
    }
}

