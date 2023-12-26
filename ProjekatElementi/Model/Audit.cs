using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Audit
    {

        public string Vreme { get; set; }
        public string Ime { get; set; }
        public string Lokacija { get; set; }
        public int Br_Redova { get; set; }

        public Audit(string vreme, string ime, string lokacija, int br_Redova)
        {
            Vreme = vreme;
            Ime = ime;
            Lokacija = lokacija;
            Br_Redova = br_Redova;
        }

        public Audit()
        {

        }

        public override string ToString()
        {
            return $"{Vreme},{Ime},{Lokacija},{Br_Redova}";
        }

    }
}
