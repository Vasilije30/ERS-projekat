using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PotrosnjaIspis
    {
        public float OstvarenaPotrosnja { get; set; }
        public float PrognoziranaPotrosnja { get; set; }
        public float Odstupanje { get; set; }

        public string GeoObl { get; set; }

        public int Sat { get; set; }

        public DateTime Datum { get; set; }

        public PotrosnjaIspis()
        {

        }


        public override string ToString()
        {
            return $"{GeoObl},{Datum},{Sat},{OstvarenaPotrosnja},{PrognoziranaPotrosnja},{Odstupanje}";
        }

    }
}
