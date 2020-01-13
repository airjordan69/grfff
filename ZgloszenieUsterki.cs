using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2115_to_jest_gang
{
    public class ZgloszenieUsterki
    {
        string _nazwaZgloszeniodawcy;
        string _zgloszonaAwaria;
        DateTime _dataWygasniecia;
        string _numerZgloszenia;

        static int _biezacyNumerZgloszenia;

        public string nazwaZgloszeniodawcy
        {
            get { return _nazwaZgloszeniodawcy; } 

        }
        public string zgloszonaAwaria
        {
            get { return _zgloszonaAwaria; }
        }
        public DateTime dataWygasniecia
        {
            get { return _dataWygasniecia; }
        }
        public virtual DateTime DataWygas()
        {
            return (DateTime.Now.AddMonths(1));
        }
        static ZgloszenieUsterki()
        {
            _biezacyNumerZgloszenia = 0;
            DateTime _dataWygasniecia = DateTime.Now.AddMonths(1);
        }
        public ZgloszenieUsterki()
        {
            _nazwaZgloszeniodawcy = null;
            _zgloszonaAwaria = null;
            _dataWygasniecia = DataWygas();
            _numerZgloszenia = $"{_nazwaZgloszeniodawcy}/{++_biezacyNumerZgloszenia}";
            Console.WriteLine($"=== Utworzono nowe zgłoszenie: ===\n{ToString()}");

        }
        public ZgloszenieUsterki(string nazwaZgloszeniodawcy, string zgloszonaAwaria)
        {
            if (nazwaZgloszeniodawcy.Length > 3)
            {
                _nazwaZgloszeniodawcy = nazwaZgloszeniodawcy;
            }
            else
            {
                throw new Exception("za krotka nazwa");
            }
            _zgloszonaAwaria = zgloszonaAwaria;
            _dataWygasniecia = DataWygas();
            _numerZgloszenia = $"{_nazwaZgloszeniodawcy}/{++_biezacyNumerZgloszenia}";
            Console.WriteLine($"=== Utworzono nowe zgłoszenie: ===\n{ToString()}");

        }
        public virtual DateTime PrzedluzWaznosc(int dni)
        {
            return (_dataWygasniecia = _dataWygasniecia.AddDays(dni));
        }
        public virtual DateTime SkrocWaznosc(int dni)
        {
            
            DateTime odjete = _dataWygasniecia = _dataWygasniecia.AddDays(-dni);
            if (odjete > DateTime.Now.AddDays(1))
            {
                return odjete;
            }
            else throw new Exception();
        }
        //public ZgloszenieUsterki(string nazwaZgloszeniodawcy, string zgloszonaAwaria, DateTime dataWygasniecia)
        //{
        //    _nazwaZgloszeniodawcy = nazwaZgloszeniodawcy;
        //    _zgloszonaAwaria = zgloszonaAwaria;
        //    _dataWygasniecia = dataWygasniecia;
        //    _numerZgloszenia = $"{_nazwaZgloszeniodawcy}/{++_biezacyNumerZgloszenia}";
        //    Console.WriteLine($"=== Utworzono nowe zgłoszenie: ===\n{ToString()}");

        //}
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Zgloszeniodawca: {nazwaZgloszeniodawcy}");
            sb.AppendLine($"Zgloszona awaria: {zgloszonaAwaria}");
            sb.AppendLine($"Data wygasniecia: {dataWygasniecia:yyyy-MM-dd}");
            sb.AppendLine($"Numer zgloszenia: {this._numerZgloszenia}");

            return sb.ToString();
        }
    }
}
