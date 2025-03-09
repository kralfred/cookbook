using CookBook.Common.Models.Ingredient;
using CookBook.Web.Api;
using Microsoft.AspNetCore.Components;

namespace CookBook.Web.Components.Pages.Ingredient;

public partial class IngredientListPage
{
    [Inject]
    public IIngredientsClient Client { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        ingredients = await Client.IngredientsAllAsync();
    }

    private ICollection<IngredientListModel> ingredients = new List<IngredientListModel>();
}
