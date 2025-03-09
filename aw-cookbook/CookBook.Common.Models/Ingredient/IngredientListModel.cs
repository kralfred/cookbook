

namespace CookBook.Common.Models.Ingredient;

public class IngredientListModel : IModel
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public string? ImageUrl { get; set; }
}