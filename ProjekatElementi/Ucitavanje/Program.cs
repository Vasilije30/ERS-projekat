using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ucitavanje
{
    class Program
    {
        static void Main(string[] args)
        {
            bool zavrsi = false;
            int opcija = -1;

            do
            {
                Console.WriteLine("Odaberite opciju: ");// while petlja da vrti meni, klasa za putanju 
                Console.WriteLine("0. Izlaz");
                Console.WriteLine("1. Citanje file-ova");

                try
                {
                    opcija = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Nepostojeca opcija");
                }

                if (opcija == 0)
                {
                    opcija = 0;
                    Console.WriteLine("Program zavrsen");
                    zavrsi = true;

                }
                else if (opcija == 1)
                {
                    Fajlovi put = new Fajlovi();
                    Console.WriteLine("Upisite putanju file-a");
                    string path = Console.ReadLine();

                    put.putanja = path;

                    put.ispis(put.putanja);
                    opcija = -1;
                }
                else if (opcija == 2)
                {
                    Console.WriteLine("Proslijedite u koji zelite pisati");

                }
            } while (zavrsi != true);

            Console.ReadLine();
        }// C:\Users\Mateo\Downloads\prog_2020_05_07.xml
        //Fajlovi.otvori()
    }
}

