using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CookBook.IdentityProvider.DAL;

public static class IdentityProviderDALInstaller
{
    public static IServiceCollection AddIdentityProviderDataLayer(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IDbContextFactory<AppIdentityDbContext>, AppIdentityDbContextFactory>();
        serviceCollection.AddTransient(serviceProvider =>
        {
            var dbContextFactory = serviceProvider.GetRequiredService<IDbContextFactory<AppIdentityDbContext>>();
            return dbContextFactory.CreateDbContext();
        });
        serviceCollection.AddScoped<IUserStore<IdentityUser>, UserStore<IdentityUser, IdentityRole, AppIdentityDbContext>>();
        serviceCollection.AddScoped<IRoleStore<IdentityRole>, RoleStore<IdentityRole, AppIdentityDbContext>>();
        return serviceCollection;
    }
}
