using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CookBook.IdentityProvider.DAL;

public class AppIdentityDbContextFactory : IDesignTimeDbContextFactory<AppIdentityDbContext>, IDbContextFactory<AppIdentityDbContext>
{
    public AppIdentityDbContext CreateDbContext(string[] args) => CreateDbContext();
    public AppIdentityDbContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppIdentityDbContext>();
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CookBookIdentity;MultipleActiveResultSets = True;Integrated Security = True")
            .LogTo(Console.WriteLine, LogLevel.Information);
        return new AppIdentityDbContext(optionsBuilder.Options);
    }
}


