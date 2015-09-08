using System.Collections.Generic;
using System.Linq;
using Common.Dto.Customer;
using Common.ServiceContract;
using Domain.Entities;
using Domain.Repository.Interface;

namespace Domain.Services
{
    public class CustomerService : ServiceBase, ICustomerService
    {
        #region ICustomerService Members

        public CustomerDto CreateNewCustomer(CustomerDto dto)
        {
            return ExecuteCommand(locator => CreateNewCustomerCommand(locator, dto));
        }

        public CustomerDto GetById(long id)
        {
            return ExecuteCommand(locator => GetByIdCommand(locator, id));
        }

        public CustomerDto UpdateCustomer(CustomerDto dto)
        {
            return ExecuteCommand(locator => UpdateCustomerCommand(locator, dto));
        }

        public CustomerDtos FindAll()
        {
            return ExecuteCommand(locator => FindAllCommand(locator));
        }

        #region Commands

        public CustomerDto CreateNewCustomerCommand(IRepositoryLocator locator, CustomerDto dto)
        {
            var customer = Customer.Create(locator, dto);
            return CustomerToDto(customer);
        }

        public CustomerDto GetByIdCommand(IRepositoryLocator locator, long id)
        {
            var customer = locator.GetById<Customer>(id);
            return CustomerToDto(customer);
        }

        public CustomerDto UpdateCustomerCommand(IRepositoryLocator locator, CustomerDto dto)
        {
            var instance = locator.GetById<Customer>(dto.CustomerId);
            instance.Update(locator, dto);
            return CustomerToDto(instance);
        }

        public CustomerDtos FindAllCommand(IRepositoryLocator locator)
        {
            var customers = locator.FindAll<Customer>();
            var result = new CustomerDtos { Customers = new List<CustomerDto>() };
            if (!customers.Any())
                return result;
            customers.ToList().ForEach(c => result.Customers.Add(CustomerToDto(c)));
            return result;
        }

        #endregion

        #endregion

        #region Private Methods

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
        
        #endregion
    }
}
