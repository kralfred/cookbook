using System.ComponentModel.DataAnnotations;

namespace CookBook.Common.Models.Ingredient;

public class IngredientDetailModel : IModel
{
    public required Guid Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [MinLength(2,ErrorMessage = "Name has to be at least 2 characters long")]
    public required string Name { get; set; }

    public required string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public IngredientDetailModel()
    {
        this.Id = new Guid();
    }

}
