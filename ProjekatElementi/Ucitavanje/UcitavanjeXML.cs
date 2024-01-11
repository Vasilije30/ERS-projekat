using DataBase;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ucitavanje
{
    public class UcitavanjeXML : Ucitavanje
    {
        public static SqlConnection connection;
        public UcitavanjeXML(IModel proxy) {
            Proxy = proxy;
        }
        public override void ObradaFajla(string putanja)
        {
            Console.WriteLine($"Obrada XML fajla na putanji: {putanja}");
            string imeFajla = Path.GetFileNameWithoutExtension(putanja);
            string tipFajla;
            DateTime datum;

            if (!ValidirajImeFajla(imeFajla, out tipFajla, out datum))
            {
                return;
            }

            Console.WriteLine($"Tip Fajla: {tipFajla}, Datum: {datum}");
            int brojRedova = 0;


            if (!ValidirajSadrzaj(putanja, out brojRedova))
            {
                Console.WriteLine($"Nevalidan sadržaj XML fajla: {imeFajla}");
                EvidentirajNevalidanFajl(imeFajla, putanja, brojRedova);
                return;
            }

            ObradiValidnePodatke(putanja, tipFajla, datum);
        }

        public override void ObradiValidnePodatke(string putanja, string tipFajla, DateTime datum)
        {
            XDocument xmlDokument = XDocument.Load(putanja);
            var sviRedovi = xmlDokument.Descendants("STAVKA").ToList();

            foreach (var red in sviRedovi)
            {
                int sat = int.Parse(red.Element("SAT").Value);
                double potrosnja = double.Parse(red.Element("LOAD").Value);
                string geografskaOblast = red.Element("OBLAST").Value;
                List<string> lista = Proxy.GeoPodr();
                if (!lista.Contains(geografskaOblast))
                {
                    Podrucje geo = new Podrucje();
                    geo.Sifra = geografskaOblast;
                    geo.Ime = geografskaOblast;
                    Proxy.upisiOblast(geo);
                }
                int OstvarenaIliPrognozirana = 0;
                double Potrosnja = 0;
                Console.WriteLine();
                Console.WriteLine(tipFajla);

                switch (tipFajla.Trim())
                {
                    case "prog": {
                            OstvarenaIliPrognozirana = 0;
                            Potrosnja = potrosnja;
                            break;
                        }
                    case "ostv": {
                            OstvarenaIliPrognozirana = 1;
                            Potrosnja = potrosnja;
                            break;
                        }
                    default:
                        break;
                }

               

                Potrosnja novaPotrosnja = new Potrosnja(datum, sat, Potrosnja, geografskaOblast, OstvarenaIliPrognozirana, 0);
                Console.WriteLine(novaPotrosnja);

                UpisiUBazuPotrosnja(novaPotrosnja);
            }
        }

        

        public override bool ValidirajSadrzaj(string putanja, out int brojRedova)
        {
            XDocument xmlDokument = XDocument.Load(putanja);
            brojRedova = 0;
            bool povratna = true;

            var sveOblasti = xmlDokument.Descendants("OBLAST").Select(o => o.Value).Distinct().ToList();

            foreach (var oblast in sveOblasti)
            {

                var redoviZaOblast = xmlDokument.Descendants("STAVKA").Where(s => s.Element("OBLAST").Value == oblast).ToList();
                brojRedova += redoviZaOblast.Count();
                if (redoviZaOblast.Count != 24 && redoviZaOblast.Count != 23 && redoviZaOblast.Count != 25)
                {
                    povratna = false;
                }
            }
            return povratna;
        }
    }
}
