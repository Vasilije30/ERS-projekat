using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Evidencija
{
    class EvidencijaImpl:IEvidencija
    {
        public List<Podrucje> evidencijaGeoPodrucja(string Ime, int Sirina)
        {
            using (SqlCommand command = new SqlCommand())
            {
                List<Podrucje> oblasti = new List<Podrucje>();
                command.Connection = connection;
                command.CommandText = "SELECT all FROM GeografskaPodrucja";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Podrucje GOblast = new Podrucje(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                        oblasti.Add(GOblast);
                    }
                    return oblasti;
                }

            }
        }
    }
}
