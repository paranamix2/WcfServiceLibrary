using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Message
{
    public class BusinessExceptionDto
    {
        protected BusinessExceptionDto() { }

        public BusinessExceptionDto(BusinessExceptionEnum type, string message, string stackTrace)
        {
            ExceptionType = type;
            Message = message;
            StackTrace = stackTrace;
        }

        public BusinessExceptionEnum ExceptionType { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}
