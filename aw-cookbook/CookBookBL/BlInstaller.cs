using CookBook.BL.Facades.Interfaces;
using CookBook.BL.Facades;
using CookBookBL.Facades.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using CookBookBL.MapperProfiles;



namespace CookBook.BL
{
    public static class BlInstaller
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IIngredientFacade, IngredientFacade>();
            serviceCollection.AddTransient<IRecipeFacade, RecipeFacade>();
            serviceCollection.AddAutoMapper(expression =>
            {
                expression.AddProfile(new IngredientMapperProfile());
                expression.AddProfile(new RecipeMapperProfile());
                expression.AddProfile(new IngredientAmountMapperProfile());
            });
            return serviceCollection;
        }
    }
}
