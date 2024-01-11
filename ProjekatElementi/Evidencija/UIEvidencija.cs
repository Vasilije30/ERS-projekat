using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidencija
{
    class UIEvidencija
    {
        public IEvidencija Proxy { get; set; }


        public UIEvidencija(IEvidencija proxy)
        {
            Proxy = proxy;
        }



        public void meni()
        {
            while (true)
            {

                Console.WriteLine("Unesite opciju:");
                Console.WriteLine("1.Ispis svih oblasti");
                Console.WriteLine("2.Unos  oblasti");
                Console.WriteLine("3.Izlaz");
                int unos = Int32.Parse(Console.ReadLine());

                switch (unos)
                {
                    case 1:
                        IspisPodrucja();
                        { break; }
                    case 2:
                        {
                            Unops();
                            break;
                        }
                    case 3:
                        { return; }
                    default: { break; }
                }
            }

        }

        //funkcija za ispis
        void IspisPodrucja()
        {
            List<Podrucje> lista = Proxy.evidencijaGeoPodrucja();
            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }
        }
        //funkcija za unos 


        void Unops()
        {
            Podrucje geo = new Podrucje();

            Console.WriteLine("Unesite sifru geo oblasti: ");
            geo.Sifra = Console.ReadLine();

            Console.WriteLine("Unesite oblaime geo sti: ");
            geo.Ime = Console.ReadLine();


            Proxy.upisi(geo);


        }
    }
}
