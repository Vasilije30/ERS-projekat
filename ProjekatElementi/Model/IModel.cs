using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Model
{
    [ServiceContract]
    public interface IModel
    {
        [OperationContract]
        void poslajiFajl(Potrosnja potrosnja);

        [OperationContract]
        void posaljiAuditFajl(Audit audit);
    }
}
