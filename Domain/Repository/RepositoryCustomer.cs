using System;
using Domain.Entities;

namespace Domain.Repository
{
    public class RepositoryCustomer<TEntity> : RepositoryEntityStore<TEntity>
    {
        #region RepositoryEntityStore members

        public override TEntity Save(TEntity instance)
        {
            throw new NotImplementedException();
        }

        public override void Update(TEntity instance)
        {
            throw new NotImplementedException();
        }

        public override void Delete(TEntity instance)
        {
            throw new NotImplementedException();
        }

        #endregion

        private void GetNewId(Customer instanse)
        {
            
        }
    }
}
