using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Message;
using Domain.Repository.Interface;
using Domain.TransactionManager.Interface;

namespace Domain.TransactionManager
{
    public abstract class TransManagerBase : ITransManager
    {
        protected bool _isInTrans;

        public IRepositoryLocator Locator { get; set; }

        #region ItransManager Members

        public TResult ExecuteCommand<TResult>(Func<IRepositoryLocator, TResult> command) 
            where TResult : class, Common.Message.IDtoResponseEnvelop
        {
            try
            {
                BeginTransaction();
                var result = command.Invoke(Locator);
                CommitTransaction();
                CheckForWarnings(result);
                return result;
            }
            catch (BusinessException exception)
            {
                if (_isInTrans) Rollback();
                var type = typeof (TResult);
                var instance = Activator.CreateInstance(type, true) as IDtoResponseEnvelop;
                if (instance != null) instance.Response.AddBusinessException(exception);
                return instance as TResult;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public virtual void BeginTransaction()
        {
            _isInTrans = true;
            return;
        }

        public virtual void CommitTransaction()
        {
            _isInTrans = false;
            return;
        }

        public virtual void Rollback()
        {
            _isInTrans = false;
            return;
        }

        #endregion

        #region IDisposable members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected bool IsDisposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) return;
            if (!IsDisposed && _isInTrans)
            {
                Rollback();
            }
            Locator = null;
            IsDisposed = true;
        }

        #endregion

        #region Private Methods

        private void CheckForWarnings<TResult>(TResult result)
        {
            return;
        }

        #endregion

    }
}
