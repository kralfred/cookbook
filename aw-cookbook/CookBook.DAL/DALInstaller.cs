using CookBook.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CookBook.DAL;

public static class DALInstaller
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContextFactory<CookBookDbContext, CookBookDbContextFactory>();
        serviceCollection.AddScoped<CookBookDbContext>(sp =>
            sp.GetRequiredService<IDbContextFactory<CookBookDbContext>>().CreateDbContext());

        serviceCollection.AddTransient(typeof(Repository<>));
        serviceCollection.AddTransient<Repository<RecipeEntity>, RecipeRepository>();
        return serviceCollection;
    }
}