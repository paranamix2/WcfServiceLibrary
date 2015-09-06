using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Common.Message
{
    [DataContract]
    public class Response
    {
        #region Constructors

        public Response() : this(0) {}

        public Response(long entityId)
        {
            _entityIdInstance = entityId;
        }

        #endregion

        #region Private Members

        [DataMember]
        private BusinessExceptionDto _businessExceptionInstance;

        [DataMember]
        private readonly IList<BusinessWarning> _businesswarningList = new List<BusinessWarning>();
            
        [DataMember]
        private readonly long _entityIdInstance;

        #endregion

        #region Public Methods

        public void AddBusinessException(BusinessExceptionDto exception)
        {
            _businessExceptionInstance = new BusinessExceptionDto(exception.ExceptionType, exception.Message, exception.StackTrace);
        }

        public void AddBusinessWarnings(IEnumerable<BusinessWarning> warnings)
        {
            warnings.ToList().ForEach(w => _businesswarningList.Add(w));
        }

        #endregion

        #region Public Getters

        public bool HasWarning
        {
            get { return _businesswarningList.Count > 0; }
        }

        public IEnumerable<BusinessWarning> BusinessWarnings
        {
            get { return new ReadOnlyCollection<BusinessWarning>(_businesswarningList);}
        }

        public long EntityId
        {
            get { return _entityIdInstance; }
        }

        public bool HasException
        {
            get { return _businessExceptionInstance != null; }
        }

        public BusinessExceptionDto BusinessException
        {
            get { return _businessExceptionInstance; }
        }

        #endregion
    }
}
