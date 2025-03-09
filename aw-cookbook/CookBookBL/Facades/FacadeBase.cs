using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.DAL;
using AutoMapper;
using CookBook.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using CookBook.BL.Facades.Interfaces;
using CookBook.Common.Models;
using Microsoft.Extensions.Logging;


namespace CookBook.BL.Facades
{

    public abstract class FacadeBase<TEntity, TListModel, TDetailModel>(
        IDbContextFactory<CookBookDbContext> dbContextFactory,
        IMapper mapper,
        ILogger logger) : IFacade<TListModel, TDetailModel>
        where TEntity : class, IEntity
        where TListModel : class, IModel
        where TDetailModel : class, IModel

    {
        private readonly IDbContextFactory<CookBookDbContext> dbContextFactory = dbContextFactory;
        private readonly IMapper mapper = mapper;
        
        public void Delete(Guid id)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var repository = new Repository<TEntity>(dbContext);
            repository.Delete(id);
            dbContext.SaveChanges();
        }

        public virtual TDetailModel? Get(Guid id)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var repository = new Repository<TEntity>(dbContext);
            var entity = repository.GetById(id);
            return entity is null ? null : mapper.Map<TDetailModel>(entity);
        }

        public IEnumerable<TListModel> Get()
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var repository = new Repository<TEntity>(dbContext);
            var entities = repository.GetAll();

            logger.Log(LogLevel.Error, "Listed models");
            return mapper.Map<IEnumerable<TListModel>>(entities);
        }
        public TDetailModel Save(TDetailModel model)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var repository = new Repository<TEntity>(dbContext);
            var entity = mapper.Map<TEntity>(model);
            var result = repository.Exist(model.Id) ? repository.Update(entity) : repository.Insert(entity);
            dbContext.SaveChanges();
            return mapper.Map<TDetailModel>(result);
        }

    }

}
