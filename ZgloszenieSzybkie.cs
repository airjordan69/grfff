using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2115_to_jest_gang
{
    class ZgloszenieSzybkie : ZgloszenieUsterki
    {
        DateTime _dataWygasniecia;

        public DateTime dataSzybka
        {
            get { return _dataWygasniecia; }
        }
        public override DateTime DataWygas()
        {
            return DateTime.Now.AddDays(7);
        }
        public ZgloszenieSzybkie() : base() 
        {
            _dataWygasniecia = DataWygas();
        }
        public ZgloszenieSzybkie(string nazwaZgloszeniodawcy, string zgloszonaAwaria) : base(nazwaZgloszeniodawcy, zgloszonaAwaria)
        {
            _dataWygasniecia = DataWygas();
        }
        public override DateTime PrzedluzWaznosc(int dni)
        {
            if (dni > 7)
            {
                throw new KrotkieException("jest to zgloszenie krotkie tzn mniej niz 7");
            }
            else
                return base.PrzedluzWaznosc(dni);
        }
    }
    class KrotkieException : Exception
    {
        public KrotkieException(string msg) : base(msg)
        {

        }
    }
}
