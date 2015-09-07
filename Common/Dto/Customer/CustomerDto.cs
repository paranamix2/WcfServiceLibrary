using Common.Message;

namespace Common.Dto.Customer
{
    public class CustomerDto : DtoBase
    {
        public long CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        
    }
}
