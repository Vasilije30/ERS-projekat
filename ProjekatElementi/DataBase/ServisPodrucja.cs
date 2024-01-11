using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    class ServisPodrucja : IEvidencija
    {
        DataBaseImpl baza = DataBaseImpl.getBase();
        public List<Podrucje> evidencijaGeoPodrucja()
        {
            return baza.evidencijaGeoPodrucja();
        }

        public void upisi(Podrucje p)
        {
            baza.UbaciPodrucje(p);
        }

        
    }
}
