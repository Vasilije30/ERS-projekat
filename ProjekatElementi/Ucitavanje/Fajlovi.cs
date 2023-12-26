using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace Ucitavanje
{
    class Fajlovi
    {
        string csvFilePath = "C:/Users/Mateo/Desktop/New folder(2)/New Text Document.txt";
        static string timeStamp = DateTime.Now.ToString("yyyy-MM-dd-hh");
        static string errorMessage = "Greska sa putanjom fajla.";
        string csvRow = $"{timeStamp}, {errorMessage}";
        int greska = -1;
        public string putanja { get; set; }

        public Fajlovi(string putanja)
        {
            this.putanja = putanja;
        }

        public Fajlovi()
        {

        }

        public void ispis(string putanja)
        {

            try
            {
                if (File.Exists(putanja))
                {
                    XDocument dokument = XDocument.Load(putanja);
                    int counter_voj = 0;
                    int counter_bgd = 0;

                    foreach (XElement e in dokument.Descendants("STAVKA"))
                    {
                        if (e.Value == "VOJ")
                        {
                            counter_voj++;
                        }
                        else if (e.Value == "BGD")
                        {
                            counter_bgd++;
                        }
                        else
                        {
                            greska = 1;
                        }

                    }

                    if (greska == 1)
                    {
                        Console.WriteLine("Greska");
                    }

                    Console.WriteLine(counter_voj + " " + counter_bgd);

                    if (counter_voj < 25 && counter_voj > 23 && counter_bgd < 25 && counter_voj > 23)
                    {
                        foreach (XElement element in dokument.Descendants("STAVKA"))
                        {
                            int sat = int.Parse(element.Element("SAT").Value);
                            int load = int.Parse(element.Element("LOAD").Value);
                            string oblast = element.Element("OBLAST").Value;

                            Console.WriteLine("Sat: " + sat + ", Load: " + load + ", oblast: " + oblast);
                        }
                    }
                    else
                    {

                        StreamWriter sw = new StreamWriter(csvFilePath, true);
                        sw.WriteLine(csvRow);
                    }
                }
                else
                {
                    Console.WriteLine("File ne postoji");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Neuspjesno citanje xml file-a");
                Console.WriteLine(e.Message);
            }
        }

        public void upis(string putanja)
        {
            //TO DO .... do sutra bi trebalo zavrsiti
        }
    }
}
