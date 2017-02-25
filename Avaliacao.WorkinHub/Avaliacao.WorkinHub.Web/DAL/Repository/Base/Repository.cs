using Avaliacao.WorkinHub.Web.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Avaliacao.WorkinHub.Web.DAL.Repository.Base
{
    public abstract class Repository<TEntity> : IDisposable,
      IRepository<TEntity> where TEntity : class
    {

        WorkinHubContext ctx = new WorkinHubContext();

        public void Add(TEntity obj)
        {
            ctx.Set<TEntity>().Add(obj);
        }

        public void Dispose()
        {
            if (ctx != null)
                ctx.Dispose();

        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }

        public IQueryable<TEntity> GetAll()
        {
            return ctx.Set<TEntity>();
        }

        public void SaveAll()
        {
            ctx.SaveChanges();
        }
    }
}