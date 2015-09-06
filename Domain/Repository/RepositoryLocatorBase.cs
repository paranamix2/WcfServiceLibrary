using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repository.Interface;

namespace Domain.Repository
{
    public abstract class RepositoryLocatorBase : IRepositoryLocator
    {
        public TEntity Save<TEntity>(TEntity instance)
        {
            return GetRepository<TEntity>().Save(instance);
        }

        public void Update<TEntity>(TEntity instance)
        {
            GetRepository<TEntity>().Update(instance);
        }

        public void Remove<TEntity>(TEntity instance)
        {
            GetRepository<TEntity>().Remove(instance);
        }

        public TEntity GetById<TEntity>(long id)
        {
            return GetRepository<TEntity>().GetById(id);
        }

        public IQueryable<TEntity> FindAll<TEntity>()
        {
            return GetRepository<TEntity>().FindAll();
        }

        public abstract IRepository<T> GetRepository<T>();
    }
}
