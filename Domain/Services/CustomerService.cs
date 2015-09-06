using System;
using System.Collections.Generic;
using Common.Dto.Customer;
using Common.ServiceContract;
using Domain.Entities;
using Domain.Repository.Interface;

namespace Domain.Services
{
    public class CustomerService : ICustomerService
    {
        public IRepositoryLocator Repository { get; set; } 

        public CustomerDto CreateNewCustomer(CustomerDto dto)
        {
            var customer = Customer.Create(Repository, dto);
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
            var customer = Repository.GetById<Customer>(id);
            return new CustomerDto
            {
                CustomerId = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Telephone = customer.Telephone
            };
        }

        public CustomerDto UpdateCustomer(CustomerDto dto)
        {
            throw new NotImplementedException();
        }

        public List<CustomerDto> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
