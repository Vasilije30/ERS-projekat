using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using Model;

namespace DataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(CitanjeServis));

            host.AddServiceEndpoint(typeof(IModel), new NetTcpBinding(), new Uri("net.tcp://localhost:4000/IModel"));
            host.Open();
            Console.WriteLine("Servis1 je uspesno pokrenut");


            ServiceHost host1 = new ServiceHost(typeof(ServiceIspis));

            host1.AddServiceEndpoint(typeof(IDrugaTacka),
    
                     new NetTcpBinding(),
                   new Uri("net.tcp://localhost:4001/IDrugaTacka"));

            host1.Open();
            Console.WriteLine("Servis2 je uspesno pokrenut");



            ServiceHost host2 = new ServiceHost(typeof(ServisPodrucja));

            host2.AddServiceEndpoint(typeof(IEvidencija),

                     new NetTcpBinding(),
                   new Uri("net.tcp://localhost:4002/IEvidencija"));

            host2.Open();
            Console.WriteLine("Servis2 je uspesno pokrenut");

            Console.ReadKey();
        }
    }
}
