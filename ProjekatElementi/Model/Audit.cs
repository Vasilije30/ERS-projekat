using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class Audit
    {

        [DataMember]
        public DateTime Vreme { get; set; }
        [DataMember]
        public string Ime { get; set; }
        [DataMember]
        public string Lokacija { get; set; }
        [DataMember]
        public int Br_Redova { get; set; }

        public Audit(DateTime vreme, string ime, string lokacija, int br_Redova)
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
