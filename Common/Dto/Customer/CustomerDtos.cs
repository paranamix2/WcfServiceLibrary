using System.Collections.Generic;
using Common.Message;

namespace Common.Dto.Customer
{
    public class CustomerDtos : DtoBase
    {
        public IList<CustomerDto> Customers { get; set; } 
    }
}
