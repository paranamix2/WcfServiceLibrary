using Domain.TransactionManager;

namespace Naive.TransactionManager
{
    public class TransManagerEntityStore : TransManagerBase
    {
        protected override void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (!IsDisposed && _isInTrans)
            {
                Rollback();
            }
            IsDisposed = true;
        }
    }
}
