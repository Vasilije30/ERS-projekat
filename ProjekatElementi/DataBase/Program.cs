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
            ServiceHost host = new ServiceHost(typeof(DataBaseImpl));

            host.AddServiceEndpoint(typeof(IModel), new NetTcpBinding(), new Uri("net.tcp://localhost:4000/IEvidencija"));
            host.Open();
            Console.WriteLine("Servis1 je uspesno pokrenut");


            ServiceHost host1 = new ServiceHost(typeof(ServiceIspis));

            host1.AddServiceEndpoint(typeof(IIspis)
    
                     new NetTcpBinding(),
                   new Uri("net.tcp://localhost:4001/IIspis"));

            host1.Open();
            Console.WriteLine("Servis2 je uspesno pokrenut");
            Console.ReadKey();
        }
    }
}
