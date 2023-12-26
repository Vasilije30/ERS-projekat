using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Odstupanje
    {

        public string Datum { get; set; }
        public string Oblast { get; set; }
        public int Sat { get; set; }
        public int P_potrosnja { get; set; }
        public int O_potrosnja { get; set; }
        public double Odsptup { get; set; }

        public Odstupanje(string Datum, string oblast, int sat, int p_potrosnja, int o_potrosnja, double odsptup)
        {
            this.Datum = Datum;
            Oblast = oblast;
            Sat = sat;
            P_potrosnja = p_potrosnja;
            O_potrosnja = o_potrosnja;
            Odsptup = odsptup;
        }

        public Odstupanje()
        {

        }

        public override string ToString()
        {
            return $"{Datum}, {Oblast}, {Sat}, {P_potrosnja}, {O_potrosnja}, {Odsptup}";
        }
    }
}
