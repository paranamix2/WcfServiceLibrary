using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities.Interface;
using Domain.Repository.Interface;

namespace Domain.Repository
{
    public class RepositoryEntityStore<TEntity> : IRepository<TEntity>
    {
        protected readonly IDictionary<long, TEntity> RepositoryMap = new Dictionary<long, TEntity>();

        #region iRepository members

        public TEntity Save(TEntity instance)
        {
            var entityInstance = GetEntityInstance(instance);
            if (entityInstance.Id != 0)
                throw  new ApplicationException("Current entity instance cannot be saved " + "the id property is not zero");

            GetNewId(entityInstance);
            RepositoryMap.Add(entityInstance.Id, instance);
            return instance;
        }

        public void Update(TEntity instance)
        {
            
        }

        public void Remove(TEntity instance)
        {
            var entityInstance = GetEntityInstance(instance);
            RepositoryMap.Remove(entityInstance.Id);
        }

        public TEntity GetById(long id)
        {
            return RepositoryMap[id];
        }

        public IQueryable<TEntity> FindAll()
        {
            return RepositoryMap.Values.AsQueryable();
        }

        #endregion

        #region Helper methods

        private void GetNewId(IEntity instance)
        {
            instance.Id = 1;
        }

        private IEntity GetEntityInstance(TEntity instance)
        {
            var entityInstance = instance as IEntity;
            if (entityInstance == null)
                throw new ArgumentException("Current instance is not IEntity");

            return entityInstance;
        }

        #endregion
    }
}
