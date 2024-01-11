using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Model;

[ServiceContract]
public interface IIspis
{

    [OperationContract]

    List<List<Potrosnja>> Izracunaj(DateTime datum, string GeoPodrucje);


}
