
using CookBook.BL.Validations;
using CookBook.Common.Models.Recipe;

namespace CookBook.xUnitTests;



public class RecipeTesting
{

    private RecipeDetailModelValidator recipeValidater = new();


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
    [Fact]
    public void Name_Validation()
    {
        // Arrange
        var RecipeTest = new RecipeDetailModel();

        // Act
        var result = recipeValidater.Validate(RecipeTest);

        // Assert
        Assert.True(result.IsValid);
    }


}
