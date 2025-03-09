using CookBook.BL.Validations;
using CookBook.Common.Models.Ingredient;
using CookBook.Common.Models.Recipe;


namespace CookBook.xUnitTests;

public class UnitTest1
{
    private IngredientDetailModelValidator ingredientValidator = new();
    private RecipeDetailModelValidator recipeValidater = new();

    [Fact]
    public void IngredientNameNull_Throws()
    {
        // Arrange
        var ingredient = new IngredientDetailModel
        {
            Id = default,
            Name = null,
            Description = null,
        };

        // Act
        var result = ingredientValidator.Validate(ingredient);

        // Assert
        Assert.False(result.IsValid);
    }

    [Fact]
    public void Automatic_Id_Creation_Test()
    {
        // Arrange
        var RecipeTest = new RecipeDetailModel();

        // Act
        var result = recipeValidater.Validate(RecipeTest);

        // Assert
        Assert.True(result.IsValid);
    }
    

}
