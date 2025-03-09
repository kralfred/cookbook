using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.DAL;

namespace CookBook;

public class RecipeEntity : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<IngredientAmount> Amount { get; set; }


    public RecipeEntity()
    {
        this.Id = Guid.NewGuid();
    }

}
