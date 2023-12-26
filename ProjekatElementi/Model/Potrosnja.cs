using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Potrosnja
    {
       

        public String Ime { get; set; }
        public int Sat { get; set; }
        public int Load { get; set; }

        public String Oblast { get; set; }
        //1 ostvarena, 0 prognozirana
        public int OstvarenaIliPrognozirana { get; set; }

        public Potrosnja()
        {

        }
        public Potrosnja(string ime, int sat, int load, string oblast, int ostvarenaIliPrognozirana)
        {
            Ime = ime;
            Sat = sat;
            Load = load;
            Oblast = oblast;
            OstvarenaIliPrognozirana = ostvarenaIliPrognozirana;
        }



        public override string ToString()
        {
            string pomoc = "";
            if(OstvarenaIliPrognozirana==1)
            {
                pomoc = "Ostvarena";
            }
            else
            {
                pomoc = "Prognozirana";
            }
            return $"{Ime},{Sat},{Load},{Oblast},{pomoc}";
        }

    }
}
