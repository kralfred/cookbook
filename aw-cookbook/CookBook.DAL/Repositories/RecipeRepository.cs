using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Repositories
{
    public class RecipeRepository : Repository<RecipeEntity>
    {
        public RecipeRepository(CookBookDbContext cookBookDbContext) : base(cookBookDbContext)
        {
        }

       
    }
}
