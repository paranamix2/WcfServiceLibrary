using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.TransactionManager.Interface
{
    public interface ITransFactory
    {
        ITransManager CreateManager();
    }
}
