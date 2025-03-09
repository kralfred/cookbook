using CookBook.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CookBook;

public class CookBookDbContextFactory : IDesignTimeDbContextFactory<CookBookDbContext>, IDbContextFactory<CookBookDbContext>
{
    public CookBookDbContext CreateDbContext()
    {
       return CreateDbContext([]);
    }

    public CookBookDbContext CreateDbContext(string[] args)
    {       
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<CookBookDbContext>()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<CookBookDbContext>();
                   optionsBuilder.UseSqlServer(configuration.GetConnectionString("CookBook"))
            .LogTo(Console.WriteLine, LogLevel.Information);
        CookBookDbContext cookBookDbContext = new CookBookDbContext(optionsBuilder.Options);
        return cookBookDbContext;
    }


}
