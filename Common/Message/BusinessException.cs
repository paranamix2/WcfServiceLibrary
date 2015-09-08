using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Message.Enums;

namespace Common.Message
{
    public class BusinessException : ApplicationException
    {
        public BusinessException(BusinessExceptionEnum type, string message) 
            : base(message)
        {
            ExceptionType = type;
        }

        public BusinessExceptionEnum ExceptionType { get; set; }
    }
}
