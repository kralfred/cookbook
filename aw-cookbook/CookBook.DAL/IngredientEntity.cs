using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.DAL;

namespace CookBook;

public class IngredientEntity : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public List<IngredientAmount> ingeridentAmounts { get; set; }

   
}
