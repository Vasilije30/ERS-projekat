using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Podrucje
    {

        public int Sifra { get; set; }
        public string Ime { get; set; }
        public int Sirina { get; set; }

        public Podrucje(int sifra, string ime, int sirina)
        {
            Sifra = sifra;
            Ime = ime;
            Sirina = sirina;
        }

        public override string ToString()
        {
            return $"{Sifra}, {Ime}, {Sirina}";
        }
    }
}
