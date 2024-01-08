using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class DataBaseImpl:IDataBase
    {
        private static SqlConnection connection;
        private static string connectionString;
        private static DataBaseImpl instance = null;

        public static DataBaseImpl getBase()
        {
            if (instance == null)
            {
                instance = new DataBaseImpl();
            }
            return instance;
        }

        public DataBaseImpl()
        {

            try
            {
                connectionString = "Server=localhost;Database=ProjekatERS;Trusted_Connection=True;";
                connection = new SqlConnection(connectionString);
                connection.Open();

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }


        public void UbaciAudit(Audit audit)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO aud(ImeF, VremeF, Lokacija, Broj) VALUES(@ImeFajla, @Vreme, @Lokacija, @Br_Redova)";

                command.Parameters.AddWithValue("@ImeFajla", audit.Ime);
                command.Parameters.AddWithValue("@Vreme", audit.Vreme);
                command.Parameters.AddWithValue("@Lokacija", audit.Lokacija);
                command.Parameters.AddWithValue("@Br_Redova", audit.Br_Redova);


                int result = command.ExecuteNonQuery();

                if (result != 0)
                {
                    Console.WriteLine("Uspesno ubacen u bazu");
                }
                else
                {
                    Console.WriteLine("Nismo uspeli da upisemo u bazu");
                }
            }
        }


        public void UpdateAudit(Audit audit)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "UPDATE aud SET Ime=@ImeFajla,Vreme=@VremeUcitavanja,Lokacija=@Lokacija,BrojR=@BrojRedova WHERE ImeFajla = @ImeFajla";
                command.Parameters.AddWithValue("@ImeFajla", audit.Ime);
                command.Parameters.AddWithValue("@VremeUcitavanja", audit.Vreme);
                command.Parameters.AddWithValue("@Lokacija", audit.Lokacija);
                command.Parameters.AddWithValue("@BrojRedova", audit.Br_Redova);

                command.ExecuteNonQuery();
            }
        }
        
        public void ObrisiAudit(string ImeFajla)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "DELETE FROM aud WHERE Ime = @ImeFajla";
                command.Parameters.AddWithValue("@ImeFajla", ImeFajla);
                command.ExecuteNonQuery();
            }
        }

        public void ObrisiSveAudit()
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "DELETE FROM aud";
                command.ExecuteNonQuery();
            }
        }
        
        public List<Audit> VratiAudit()
        {

            using (SqlCommand command = new SqlCommand())
            {
                List<Audit> audits = new List<Audit>();
                command.Connection = connection;
                command.CommandText = "SELECT all FROM aud";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Audit audit = new Audit(reader.GetDateTime(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                        audits.Add(audit);
                    }
                    return audits;
                }

            }

        }

        public void UbaciPotrosnju(Potrosnja potrosnja)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO potrosnja(Datum, Sat, load, oblast, ostvIliProg, odstupanje) VALUES(@Datump, @Satp, @loadp,  @Oblastp, @ostvIliProg, @odstupanje)";

                command.Parameters.AddWithValue("@Datump", potrosnja.Datum);
                command.Parameters.AddWithValue("@Satp", potrosnja.Sat);
                command.Parameters.AddWithValue("@Loadp", potrosnja.Load);
                command.Parameters.AddWithValue("@Oblastp", potrosnja.Oblast);
                command.Parameters.AddWithValue("@ostvIliProg", potrosnja.OstvarenaIliPrognozirana);
                command.Parameters.AddWithValue("@odstupanje", potrosnja.Odstupanje);

                int result = command.ExecuteNonQuery();

                if (result != 0)
                {
                    Console.WriteLine("Uspesno ubacen u bazu");
                }
                else
                {
                    Console.WriteLine("Nismo uspeli da upisemo u bazu");
                }
            }

        }

        public void Updatepotrosnja(Potrosnja potrosnja)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "UPDATE potrosnja SET Datum=@Datump,Oblast=@Oblastp,Sat=@Satp, Prog=@Progp, Odstupanje=@Odstupanjep, Load=@Loadp WHERE Ime = @Imep";
                command.Parameters.AddWithValue("@Datump", potrosnja.Datum);
                command.Parameters.AddWithValue("@Oblastp", potrosnja.Oblast);
                command.Parameters.AddWithValue("@Satp", potrosnja.Sat);
                command.Parameters.AddWithValue("@Progp", potrosnja.OstvarenaIliPrognozirana);
                command.Parameters.AddWithValue("@Odstupanjep", potrosnja.Odstupanje);
                command.Parameters.AddWithValue("@Loadp", potrosnja.Load); 

                command.ExecuteNonQuery();

            }
        }

        public void ObrisiPotrosnju(String ime)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "DELETE FROM potrosnja WHERE Ime = @Imep" ;
                command.Parameters.AddWithValue("@Imep", ime);
                command.ExecuteNonQuery();
            }
        }

        public void ObrisiSvePotrosnje()
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "DELETE FROM potrosnja";
                command.ExecuteNonQuery();
            }
        }

        public List<Potrosnja> VratiPotrosnje()
        {

            using (SqlCommand command = new SqlCommand())
            {
                List<Potrosnja> potrosnje = new List<Potrosnja>();
                command.Connection = connection;
                command.CommandText = "SELECT all FROM potrosnja";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Potrosnja potrosnja = new Potrosnja(reader.GetDateTime(0), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4), reader.GetInt32(5), reader.GetFloat(6));
                        potrosnje.Add(potrosnja);
                    }
                    return potrosnje;
                }

            }

        }

        public void UbaciPodrucje(Podrucje podrucje)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "INSERT INTO podrucja(sifra, ime, sirina) VALUES(@Sifra, @Ime, @Sirina)";

                command.Parameters.AddWithValue("@Sifra", podrucje.Sifra);
                command.Parameters.AddWithValue("@Ime", podrucje.Ime);
                command.Parameters.AddWithValue("@Sirina", podrucje.Sirina);

                int result = command.ExecuteNonQuery();

                if (result != 0)
                {
                    Console.WriteLine("Uspesno ubacen u bazu");
                }
                else
                {
                    Console.WriteLine("Nismo uspeli da upisemo u bazu");
                }
            }
        }


        public void UpdatePodrucje(Podrucje podrucje)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "UPDATE podrucja SET sifra=@sifraPodrucja, ime=@imePodrucja,sirina=@sirinaPodrucja, WHERE sifra = @sifra_podrucja";
                command.Parameters.AddWithValue("@sifra", podrucje.Sifra);
                command.Parameters.AddWithValue("@ime", podrucje.Ime);
                command.Parameters.AddWithValue("@sirina", podrucje.Sirina);

                command.ExecuteNonQuery();
            }
        }

        public void ObrisiPodrucje(int sifra)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "DELETE FROM podrucja WHERE sifra = @sifraPodrucja";
                command.Parameters.AddWithValue("@sifraPodrucja", sifra);
                command.ExecuteNonQuery();
            }
        }

        public void ObrisiSvaPodrucja()
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "DELETE FROM podrucja";
                command.ExecuteNonQuery();
            }
        }


        public List<Podrucje> VratiPodrucje()
        {

            using (SqlCommand command = new SqlCommand())
            {
                List<Podrucje> podrucja = new List<Podrucje>();
                command.Connection = connection;
                command.CommandText = "SELECT all FROM podrucja";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Podrucje podrucje = new Podrucje(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                        podrucja.Add(podrucje);
                    }
                    return podrucja;
                }

            }

        }

    }
}

