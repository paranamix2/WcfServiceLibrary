﻿using System;
using Common.Message;
using Domain.Repository.Interface;
using Domain.TransactionManager.Interface;

namespace Domain.Services
{
    public class ServiceBase
    {
        ITransFactory Factory { get; set; }

        protected TResult ExecuteCommand<TResult>(Func<IRepositoryLocator, TResult> command) 
            where TResult : class, IDtoResponseEnvelop
        {
            using (var manager = Factory.CreateManager())
            {
                return manager.ExecuteCommand(command);
            }
        }
    }
}
