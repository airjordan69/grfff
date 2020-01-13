using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2115_to_jest_gang
{
    class Program
    {
        static void Main(string[] args)
        {
            ZgloszenieUsterki zg1 = new ZgloszenieUsterki("Adam", "odbyt");
            ZgloszenieUsterki zg2 = new ZgloszenieUsterki("Bartek", "kolano");
            ZgloszenieUsterki zg3 = new ZgloszenieUsterki("Mariusz", "ucho");
            //zg3.PrzedluzWaznosc(5);
            //Console.WriteLine(zg3);
            //zg2.SkrocWaznosc(9);
            //Console.WriteLine(zg2);
            ZgloszenieSzybkie zg4 = new ZgloszenieSzybkie("szybka", "jazda");
            zg4.PrzedluzWaznosc(5);
           // Console.WriteLine(zg4);
            TablicaZgloszen tab1 = new TablicaZgloszen("gowno");
            tab1.DodajZgloszenie(zg1);
            tab1.DodajZgloszenie(zg2);
            tab1.DodajZgloszenie(zg3);
            tab1.DodajZgloszenie(zg4);
            tab1.ZnajdzZgloszenie("ucho");
            Console.WriteLine("===========yol");
           // Console.WriteLine(tab1.ToString());

            TablicaZgloszen tab2 = tab1.DeepCopy();
            Console.WriteLine("gownoooooo");
           // Console.WriteLine(tab2.ToString());
            tab1._nazwa = "chuj";
            Console.WriteLine(tab1);
            Console.WriteLine(tab2);
            TablicaZgloszen.SaveXml("zapisuje", tab2);
            Console.ReadKey();


        }
    }
}
