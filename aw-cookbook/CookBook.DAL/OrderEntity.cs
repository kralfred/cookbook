using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook;

public class OrderEntity
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Complete { get; set; }
    

}
