using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Podrucje
    {
        [DataMember]
        public string Sifra { get; set; }
        [DataMember]
        public string Ime { get; set; }
        [DataMember]
        public int Sirina { get; set; }
        public Podrucje() { }
        public Podrucje(string sifra, string ime, int sirina)
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
