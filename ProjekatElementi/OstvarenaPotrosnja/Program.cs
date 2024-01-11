using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace OstvarenaPotrosnja
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IDrugaTacka> channel = new ChannelFactory<IDrugaTacka>("Serv");

            IDrugaTacka proxy = channel.CreateChannel();

            List<List<Potrosnja>> lista = proxy.Izracunaj(new DateTime(2020, 5, 7, 0, 0, 0), "BGD");

            List<PotrosnjaIspis> izracunato = new List<PotrosnjaIspis>();

            for (int i = 0; i < lista[0].Count; i++)
            {
                PotrosnjaIspis p = new PotrosnjaIspis();

                float odstupanje = ((float)Math.Abs((lista[0][i].Load - lista[1][i].Load) / lista[0][i].Load) * 100.0f);

                p.PrognoziranaPotrosnja = (float)lista[1][i].Load;
                p.OstvarenaPotrosnja = (float)lista[0][i].Load;
                p.Odstupanje = odstupanje;
                p.GeoObl = lista[1][i].Oblast;
                p.Sat = lista[1][i].Sat;
                p.Datum = lista[0][i].Datum;
                izracunato.Add(p);

            }

            foreach (var item in izracunato)
            {
                Console.WriteLine(item);
            }

            Console.Read();
        }
    }
}
