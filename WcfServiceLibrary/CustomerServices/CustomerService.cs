using System;
using System.Collections.Generic;
using Common.Dto.Customer;
using Domain.Entities;
using Domain.Repository.Interface;
using WcfServiceLibrary.CustomerServices.Interface;

namespace WcfServiceLibrary.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        public IRepositoryLocator Locator { get; set; } 

        public CustomerDto CreateNewCustomer(CustomerDto dto)
        {
            var customer = Customer.Create(Locator, dto);
            return new CustomerDto
            {
                CustomerId = customer.Id,
                FirstName = customer.FirstName,
                LastName =  customer.LastName,
                Telephone = customer.Telephone
            };
        }
        
        public CustomerDto GetById(long id)
        {
            throw new NotImplementedException();
        }

        public CustomerDto UpdateCustomer(CustomerDto customer)
        {
            throw new NotImplementedException();
        }

        public List<CustomerDto> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
