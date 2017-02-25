using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.WorkinHub.Web.DAL.Repository.Base
{
    interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> Get(Func<TEntity, bool> predicate);

        void SaveAll();

        void Add(TEntity obj);
    }
}