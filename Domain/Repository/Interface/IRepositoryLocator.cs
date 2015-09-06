using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.Interface
{
    public interface IRepositoryLocator
    {
        #region CRUD

        TEntity Save<TEntity>(TEntity instance);
        void Update<TEntity>(TEntity instance);
        void Remove<TEntity>(TEntity instance);

        #endregion

        #region Retrieval

        TEntity GetById<TEntity>(long id);
        IQueryable<TEntity> FindAll<TEntity>();

        #endregion

        IRepository<T> GetRepository<T>();
    }
}
