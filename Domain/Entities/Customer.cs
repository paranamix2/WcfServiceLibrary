using Common.Dto.Customer;
using Domain.Repository.Interface;

namespace Domain.Entities
{
    public class Customer
    {
        protected Customer() { }

        public long Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Telephone { get; private set; }

        public static Customer Create(IRepository<Customer> repository, CustomerDto operation)
        {
            var instance = new Customer
            {
                FirstName = operation.FirstName,
                LastName = operation.LastName,
                Telephone = operation.Telephone
            };

            repository.Save(instance);
            return instance;
        }
    }
}
