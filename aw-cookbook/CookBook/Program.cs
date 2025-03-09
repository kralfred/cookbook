

using System.Reflection;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using CookBook.DAL;
using Microsoft.Extensions.DependencyInjection;


namespace CookBook;

public class Program
{
     static void Main(string[] args)
    {

        ServiceCollection services = new ServiceCollection();
        services.AddDbContextFactory<CookBookDbContext, CookBookDbContextFactory>();
        services.AddScoped<CookBookDbContext>(options =>
        options.GetRequiredService<IDbContextFactory<CookBookDbContext>>().CreateDbContext());


        services.AddTransient<Utility>();
        var provider = services.BuildServiceProvider();
        Utility utility = provider.GetRequiredService<Utility>();
     

        utility.PromptRecipe();

        utility.ShowAllInformationFromRecipe("Pizza");

    
    }
}
