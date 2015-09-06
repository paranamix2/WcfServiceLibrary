using Common.Dto.Customer;
using Domain.Repository.Interface;

namespace Domain.Entities
{
    public class Customer : EntityBase
    {
        protected Customer() { }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Telephone { get; private set; }

        public static Customer Create(IRepositoryLocator locator, CustomerDto operation)
        {
            var instance = new Customer
            {
                FirstName = operation.FirstName,
                LastName = operation.LastName,
                Telephone = operation.Telephone
            };

            locator.Save(instance);
            return instance;
        }

        public void Update(IRepositoryLocator locator, CustomerDto operation)
        {
            FirstName = operation.FirstName;
            LastName = operation.LastName;
            Telephone = operation.Telephone;
            locator.Update(this);
        }

        private void UpdateValidate(IRepositoryLocator locator, CustomerDto operation)
        {
            return;
        }
    }
}
