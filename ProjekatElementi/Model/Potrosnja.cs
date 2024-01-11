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
   public class Potrosnja
    {
        [DataMember]
        public DateTime Datum { get; set; }
        [DataMember]
        public int Sat { get; set; }
        [DataMember]
        public double Load { get; set; }
        [DataMember]
        public String Oblast { get; set; }
        [DataMember]
        public int OstvarenaIliPrognozirana { get; set; }
        //1 ostvarena, 0 prognozirana
        [DataMember]
        public float Odstupanje { get; set; }

        public Potrosnja()
        {

        }
        public Potrosnja(DateTime datum, int sat, double load, string oblast, int ostvarenaIliPrognozirana, float odstupanje)
        {
            Datum = datum;
            Sat = sat;
            Load = load;
            Oblast = oblast;
            OstvarenaIliPrognozirana = ostvarenaIliPrognozirana;
            Odstupanje = odstupanje;
        }



        public override string ToString()
        {
            string pomoc = "";
            if(OstvarenaIliPrognozirana== 1)
            {
                pomoc = "Ostvarena";
            }
            else
            {
                pomoc = "Prognozirana";
            }
            return $"{Datum},{Sat},{Load},{Oblast},{Odstupanje},{pomoc}";
        }

    }
}
