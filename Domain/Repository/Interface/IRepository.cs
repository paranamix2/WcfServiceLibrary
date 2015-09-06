using System.Linq;

namespace Domain.Repository.Interface
{
    public interface IRepository<TEntity>
    {
        #region CRUD operations

        TEntity Save(TEntity instance);
        void Update(TEntity instance);
        void Delete(TEntity instance);

        #endregion

        #region Retrieval operation

        TEntity GetById(long id);
        IQueryable<TEntity> FindAll();

        #endregion

    }
}
