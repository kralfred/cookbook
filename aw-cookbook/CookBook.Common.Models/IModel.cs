using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Common.Models
{
    public interface IModel
    {
        public Guid Id { get; set; }
    }
}
