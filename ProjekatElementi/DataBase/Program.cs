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
            /*
            using (ServiceHost host = new ServiceHost(typeof(Server)))
            {
                host.Open();
                Console.WriteLine("Servis je uspjesno pokrenut");
                Console.ReadKey();
            }
            */

            DataBaseImpl baza = DataBaseImpl.getBase();
            Audit audit = new Audit(new DateTime(2019,10,10), "nesto", "nekalok", 32);
            baza.UbaciAudit(audit);
            Console.ReadLine();
        }
    }
}
