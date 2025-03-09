using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Common.Models.Recipe;

public class RecipeListModel : IModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public TimeSpan? Duration { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }

}
