using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataBase
{
    class ServiceIspis : IDrugaTacka
    {
        DataBaseImpl baza = DataBaseImpl.getBase();
        public List<List<Potrosnja>> Izracunaj(DateTime datum, string GeoPodrucje)
        {
            List<Potrosnja> ostvarene = baza.OstvGeoPodrucje(datum, GeoPodrucje);
            List<Potrosnja> prognozirne = baza.ProgGeoPodrucje(datum, GeoPodrucje);

            List<List<Potrosnja>> povratna = new List<List<Potrosnja>>();
            povratna.Add(ostvarene);
            povratna.Add(prognozirne);


            return povratna;
        }
    }
}
