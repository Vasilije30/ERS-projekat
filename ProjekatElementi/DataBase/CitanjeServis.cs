using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    class CitanjeServis : IModel
    {
        DataBaseImpl baza = DataBaseImpl.getBase();

        
        public void posaljiAuditFajl(Audit audit)
        {
            baza.UbaciAudit(audit);
        }

        public void poslajiFajl(Potrosnja potrosnja)
        {
            baza.UbaciPotrosnju(potrosnja);
        }

        public List<string> GeoPodr()
        {
            List<Podrucje> podrucja = baza.evidencijaGeoPodrucja();
            List<string> rez = new List<string>();

            foreach (var p in podrucja)
            {
                if (!rez.Contains(p.Sifra))
                {
                    rez.Add(p.Sifra);
                }
            }

            return rez;
        }

        public void upisiOblast(Podrucje geo)
        {
            baza.UbaciPodrucje(geo);
        }
    }
}
