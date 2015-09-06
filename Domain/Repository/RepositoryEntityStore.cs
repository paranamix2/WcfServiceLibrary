using System.Collections.Generic;
using System.Linq;
using Domain.Repository.Interface;

namespace Domain.Repository
{
    public abstract class RepositoryEntityStore<TEntity> : IRepository<TEntity>
    {
        protected readonly IDictionary<long, TEntity> RepositoryMap = new Dictionary<long, TEntity>();

        #region iRepository members

        public abstract TEntity Save(TEntity instance);

        public abstract void Update(TEntity instance);

        public abstract void Delete(TEntity instance);

        public TEntity GetById(long id)
        {
            return RepositoryMap[id];
        }

        public IQueryable<TEntity> FindAll()
        {
            return RepositoryMap.Values.AsQueryable();
        }

        #endregion
    }
}
