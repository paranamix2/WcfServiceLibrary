using Common.Message.Enums;

namespace Common.Message
{
    public class BusinessWarning
    {
        protected BusinessWarning() { }

        public BusinessWarning(BusinessWarningEnum type, string message)
        {
            ExceptionType = type;
            Message = message;
        }

        public BusinessWarningEnum ExceptionType { get; set; }
        public string Message { get; set; }
    }
}
