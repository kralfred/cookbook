using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Repositories;

public class Repository<T>(
    CookBookDbContext dbContext
    )
    where T : class, IEntity
{

    public virtual IEnumerable<T> GetAll()
    { 
        return dbContext.Set<T>().ToList();
    }
    public virtual T? GetById(Guid Id)
    { 
        return dbContext.Set<T>().SingleOrDefault( x => x.Id == Id);
    }
    public IEnumerable<T> GetByName(string searchString)
    {
        if (string.IsNullOrEmpty(searchString))
        {
            throw new ArgumentException("Search string cannot be null or empty.", nameof(searchString));
        }

        return dbContext.Set<T>()
            .Where(entity => EF.Property<string>(entity, "Name").Contains(searchString))
            .ToList();
    }

    public T Insert(T item) { 
     var entry = dbContext.Set<T>().Add(item);
     dbContext.SaveChanges();
        return item;
    }

    public void Delete(Guid id) {

        var item = dbContext.Set<T>().SingleOrDefault(x => x.Id == id);

        if (item is not null) {
            dbContext.Set<T>().Remove(item);
            dbContext.SaveChanges();
        }
        else {
            throw new ArithmeticException("item does not exist");
        }
    }
    public void Save() { 
    
    }
    public virtual T Update(T item)
    {
        var entry = dbContext.Set<T>().Update(item);
        dbContext.SaveChanges();

        return entry.Entity;
    }
    public bool Exist(Guid id)
    {
        return dbContext.Set<T>().Any(ingredientEntity => ingredientEntity.Id == id);
    }

}
