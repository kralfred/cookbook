using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CookBook.DAL;

public class CookBookDbContext : DbContext
{

    DbContextOptions options;

    public CookBookDbContext(DbContextOptions options) : base(options)
    {
        this.options = options;
    }

    public DbSet<OrderEntity> Order { get; set; }
    public DbSet<IngredientEntity> Ingredients { get; set; }
    public DbSet<IngredientAmount> ingeridentAmounts { get; set; }
    public DbSet<RecipeEntity> Recipe {  get; set; }



    public RecipeEntity? GetRecipe(Guid id) {

        RecipeEntity recipeRet = null;
        foreach (RecipeEntity recipe in Recipe) {
            if (recipe.Id == id) {
                recipeRet = recipe;
            }
        }
        return recipeRet;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IngredientEntity>();

        modelBuilder.Entity<RecipeEntity>();

        modelBuilder.Entity<IngredientAmount>();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(result => System.Diagnostics.Trace.WriteLine(result), Microsoft.Extensions.Logging.LogLevel.Information);
        optionsBuilder.EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
        
        optionsBuilder.UseSeeding((context, _) =>
        {
            var ingredientEgg = context.Set<IngredientEntity>().FirstOrDefault(ingredient => ingredient.Name == "Vejce");
            if (ingredientEgg is null)
            {
                context.Set<IngredientEntity>().Add(new IngredientEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Vejce",
                    Description = "Popis vejce",
                    ImageUrl = "https://i.ibb.co/d7mZWGN/image.jpg"
                });
                context.SaveChanges();
            }


            var ingredientMilk = context.Set<IngredientEntity>().FirstOrDefault(ingredient => ingredient.Name == "Vejce");
            if (ingredientMilk is null)
            {
                context.Set<IngredientEntity>().Add(new IngredientEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Mleko",
                    Description = "Dobre do caje",
                    ImageUrl = "https://i.ibb.co/d7mZWGN/image.jpg"
                });
                context.SaveChanges();
            }

           

            var recipeScrabledEggs = context.Set<RecipeEntity>().FirstOrDefault(Recipe => Recipe.Name == "Michana vejce");
            if (recipeScrabledEggs is null)
            {
                context.Set<RecipeEntity>().Add(new RecipeEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Michana vejce",
                    Description = "Dobre k snidani",
                });
                context.SaveChanges();
            }
            var scrambledEggsAmount = context.Set<RecipeEntity>().FirstOrDefault(
                
                );
              if (ingredientEgg is not null && recipeScrabledEggs is not null) {
                context.Set<IngredientAmount>().Add(new IngredientAmount
                {
                    Id = Guid.NewGuid(),
                    Amount = 5,
                    Ingredient = ingredientEgg,
                    Recipe = recipeScrabledEggs,
                    RecipeId = recipeScrabledEggs.Id,
                    IngredientId = ingredientEgg.Id,
                });
                context.SaveChanges();
            }
        });
    }
}


