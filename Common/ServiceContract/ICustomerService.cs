using System.Collections.Generic;
using System.ServiceModel;
using Common.Dto.Customer;

namespace Common.ServiceContract
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        CustomerDto CreateNewCustomer (CustomerDto customer);

        [OperationContract]
        CustomerDto GetById(long id);

        [OperationContract]
        CustomerDto UpdateCustomer(CustomerDto customer);

        [OperationContract]
        CustomerDtos FindAll();
    }
}
