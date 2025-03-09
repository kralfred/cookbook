using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.DAL;
using Microsoft.Extensions.Configuration;

namespace CookBook;

internal class Utility
{
    private readonly CookBookDbContext dbContext;
    public static IConfiguration config = new ConfigurationBuilder().Build();
    public Utility(CookBookDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void ShowAllInformationFromRecipe(string name)
    {

        
        CookBookDbContextFactory factory = new CookBookDbContextFactory();
        using var dbContext = new CookBookDbContextFactory().CreateDbContext([]);
        List<string> names = dbContext.Recipe.Where(n => n.Name.Contains(name)).Select(n => n.Name).ToList();

        List<int> amounts = dbContext.Ingredients.Join(
            dbContext.ingeridentAmounts,
            ingredient => ingredient.Id, amount => amount
            .IngredientId, (ingredient, amount) => new { IngredientName = ingredient.Name, Amount = amount.Amount })
            .Where(result => result.IngredientName.Contains(name))
            .Select(result => result.Amount)
            .ToList();

        foreach (string listName in names)
        {
            Console.WriteLine("Recipe name:  " + listName);
        }
    }

    public List<string> GetListOfIngredientsNames()
    {


        List<string> names = dbContext.Ingredients.Select(n => n.Name).ToList();

        return names;
    }
    public List<IngredientEntity> GetListOfIngredients()
    {
        CookBookDbContextFactory factory = new CookBookDbContextFactory();
        using var dbContext = new CookBookDbContextFactory().CreateDbContext([]);

        return dbContext.Ingredients.ToList(); ;
    }
    public IngredientEntity PromptIngredient()
    {

        IngredientEntity returnValue = new IngredientEntity();

        Console.WriteLine("Ingredient name: ");
        string name = Console.ReadLine();
        returnValue.Name = name;
        Console.WriteLine("Ingredient description: ");
        string description = Console.ReadLine();
        returnValue.Description = description;
        Console.WriteLine("Ingredient img url : ");
        string img = Console.ReadLine();
        returnValue.ImageUrl = img;
        returnValue.Id = Guid.NewGuid();

        return returnValue;
    }

    public int PromptInt()
    {
        Console.WriteLine("write number: ");
        int returnValue;
        string inputValue = Console.ReadLine();

        while (!int.TryParse(inputValue, out returnValue))
        {
            Console.WriteLine("Wrong format, please try again");
            inputValue = Console.ReadLine();
        }
        return returnValue;
    }

    public IngredientAmount PromptAmount(Guid recipeId, Guid ingredientId)
    {
        Console.WriteLine("How many of these do you want to add? ");
        IngredientAmount returnEntity = new IngredientAmount();

        returnEntity.IngredientId = ingredientId;
        returnEntity.RecipeId = recipeId;
        returnEntity.Id = Guid.NewGuid();
        returnEntity.Amount = PromptInt();

        return returnEntity;
    }

    public void PromptRecipe()
    {

        RecipeEntity recipeEntity = new RecipeEntity();

        Console.WriteLine("Enter Name  ");
        string name = Console.ReadLine();
        recipeEntity.Name = name;
        Console.WriteLine("Enter description  ");
        string description = Console.ReadLine();
        recipeEntity.Description = description;
        bool finish = false;
        List<IngredientAmount> amountList = new List<IngredientAmount>();
        List<IngredientEntity> ingredientsList = GetListOfIngredients();
        List<IngredientEntity> ingredientsToAdd = new List<IngredientEntity>();

        while (!finish)
        {
            Console.WriteLine("Which ingredient does this recipe use?");
            int numberOfIngredients = ingredientsList.Count;
            for (int i = 0; i < ingredientsList.Count(); i++)
            {
                Console.WriteLine((i + 1) + " Ingredient " + ingredientsList.ElementAt(i).Name);
            }
            Console.WriteLine((numberOfIngredients + 1) + " add a new ingredient");
            Console.WriteLine((numberOfIngredients + 2) + " finished");

            int option = PromptInt();
            if (option <= numberOfIngredients)
            {

                IngredientAmount amountToAdd = PromptAmount(recipeEntity.Id, ingredientsList.ElementAt(option - 1).Id);
                amountList.Add(amountToAdd);

                Console.WriteLine("Ingredient " + ingredientsList.ElementAt(option - 1) + " added");
            }
            else if (option == numberOfIngredients + 1)
            {
                IngredientEntity ingredientToAdd = PromptIngredient();
                IngredientAmount amountToAdd = PromptAmount(recipeEntity.Id, ingredientToAdd.Id);
                amountList.Add(amountToAdd);
                ingredientsToAdd.Add(ingredientToAdd);

            }
            else if (option == numberOfIngredients + 2)
            {
                finish = true;
            }
        }
        addRecipeWithListOfIngredients(recipeEntity, ingredientsToAdd, amountList);
    }

    public List<IngredientEntity> GetRecipeIngrediens(string name)
    {

        List<RecipeEntity> recipeList = dbContext.Recipe.ToList();
        List<IngredientAmount> ingeridentsAmount = dbContext.ingeridentAmounts.ToList();
        List<IngredientEntity> returnValue = new List<IngredientEntity>();

        foreach (RecipeEntity recipe in recipeList)
        {
            if (recipe.Name.Contains(name))
            {
                foreach (IngredientAmount amount in ingeridentsAmount)
                {
                    if (amount.RecipeId == recipe.Id)
                    {
                        foreach (IngredientEntity ingredientEntity in dbContext.Ingredients.ToList())
                        {
                            if (ingredientEntity.Id == amount.IngredientId)
                            {
                                returnValue.Add(ingredientEntity);
                            }
                        }
                    }
                }
            }
        }
        return returnValue;
    }

    public void ShowRecipeWithEngredients(string name)
    {
        foreach (IngredientEntity output in GetRecipeIngrediens(name))
        {
            Console.WriteLine(name + " has " + output.Name + " in it");
        };
    }

    public static void removeRecipeByName(string name)
    {

        CookBookDbContextFactory factory = new CookBookDbContextFactory();
        using var dbContext = new CookBookDbContextFactory().CreateDbContext([]);

        List<RecipeEntity> recipeList = dbContext.Recipe.ToList();
        List<IngredientAmount> ingeridentsAmount = dbContext.ingeridentAmounts.ToList();

        foreach (RecipeEntity recipe in recipeList)
        {
            if (recipe.Name.Contains(name))
            {
                dbContext.Recipe.Remove(recipe);

                foreach (IngredientAmount ingeridentA in ingeridentsAmount)
                {
                    if (recipe.Id == ingeridentA.RecipeId)
                    {
                        dbContext.ingeridentAmounts.Remove(ingeridentA);
                        Console.WriteLine("Ingredient amount removed");
                    }
                }
                Console.WriteLine(recipe.Name + " Removed");
            }
        }
        dbContext.SaveChanges();
    }

    public void addRecipeWithListOfIngredients(RecipeEntity recipe, List<IngredientEntity> listedIngredients, List<IngredientAmount> listOfAmounts)
    {

        CookBookDbContextFactory factory = new CookBookDbContextFactory();
        using var dbContext = new CookBookDbContextFactory().CreateDbContext([]);
        List<RecipeEntity> recipeList = dbContext.Recipe.ToList();
        List<IngredientEntity> createdIngreadients = dbContext.Ingredients.ToList();

        if (!recipeList.Contains(recipe))
        {

            dbContext.Recipe.Add(recipe);

            foreach (IngredientAmount amount in listOfAmounts)
            {
                dbContext.ingeridentAmounts.Add(amount);
            }


            foreach (IngredientEntity ingredient in listedIngredients)
            {

                if (createdIngreadients.Contains(ingredient))
                {
                    Console.WriteLine("Ingredient exists in database");

                }
                else
                {
                    dbContext.Ingredients.Add(ingredient);
                    Console.WriteLine("Ingredient added to database");
                }

                Console.WriteLine(ingredient.Name + "  added to list of ingredients");


            }
            dbContext.SaveChanges();
            Console.WriteLine(recipe.Name + " added to list of recipes");

        }
        else
        {
            Console.WriteLine("Recipe already exists");
        }
    }
}
