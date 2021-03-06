﻿using System;
using Common.Message;
using Domain.Repository.Interface;

namespace Domain.TransactionManager.Interface
{
    public interface ITransManager : IDisposable
    {
        TResult ExecuteCommand<TResult>(Func<IRepositoryLocator, TResult> command)
            where TResult : class, IDtoResponseEnvelop;

        void BeginTransaction();
        void CommitTransaction();
        void Rollback();
    }
}
