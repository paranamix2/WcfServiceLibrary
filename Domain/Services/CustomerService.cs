using System.Collections.Generic;
using System.Linq;
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
            return CustomerToDto(customer);
        }
        
        public CustomerDto GetById(long id)
        {
            var customer = Repository.GetById<Customer>(id);
            return CustomerToDto(customer);
        }

        public CustomerDto UpdateCustomer(CustomerDto dto)
        {
            var instance = Repository.GetById<Customer>(dto.CustomerId);
            instance.Update(Repository, dto);
            return CustomerToDto(instance);
        }

        public CustomerDtos FindAll()
        {
            var customers = Repository.FindAll<Customer>();
            var result = new CustomerDtos {Customers = new List<CustomerDto>()};
            if (!customers.Any())
                return result;
            customers.ToList().ForEach(c => result.Customers.Add(CustomerToDto(c)));
            return result;
        }

        private CustomerDto CustomerToDto(Customer customer)
        {
            return new CustomerDto
            {
                CustomerId = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Telephone = customer.Telephone
            };
        }
    }
}
