using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace Model
{
    [ServiceContract]
    public interface IDrugaTacka
    {
        [OperationContract]
        List<List<Potrosnja>> Izracunaj(DateTime datum, string GeoPodrucje);
    }
}
