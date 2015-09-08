using Domain.TransactionManager.Interface;
using Naive.Repository;

namespace Naive.TransactionManager
{
    public class TransManagerEntityStoreFactory : ITransFactory
    {
        private TransManagerEntityStore TransManager;

        #region ITransFactory Implementation

        public ITransManager CreateManager()
        {
            if (TransManager != null) return TransManager;
            TransManager = new TransManagerEntityStore {Locator = new RepositoryLocatorEntityStore()};
            return TransManager;
        }

        #endregion
    }
}
