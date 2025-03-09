using Microsoft.AspNetCore.Components;
using static Azure.Core.HttpHeader;
using CookBook.Web.Components;


namespace CookBook.Web.Components.Pages.Ingredient;

public partial class IngredientEditPage
{
    

    [Parameter]
    public Guid? Id { get; set; }



}
