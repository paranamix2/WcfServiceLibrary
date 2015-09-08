using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Message
{
    [DataContract]
    public abstract class DtoBase : IDtoResponseEnvelop
    {
        [DataMember]
        private readonly Response _responseInstance = new Response();

        public Response Response
        {
            get { return _responseInstance; }
        }
    }
}
