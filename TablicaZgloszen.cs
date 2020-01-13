using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _2115_to_jest_gang
{
    [Serializable]

    public class TablicaZgloszen : ICloneable
    {
        public string _nazwa;
        private int _liczbaZgloszen;
        Queue<ZgloszenieUsterki> _tablicaZgloszen;

        public string Nazwa
        {
            get { return _nazwa; }
        }
        public int LiczbaZgloszen
        {
            get { return _liczbaZgloszen; }
        }
        public TablicaZgloszen()
        {
            _nazwa = null;
            _tablicaZgloszen = new Queue<ZgloszenieUsterki>();
        }
        public TablicaZgloszen(string nazwa)
        {
            _nazwa = nazwa;
            _tablicaZgloszen = new Queue<ZgloszenieUsterki>();
        }
        public void DodajZgloszenie(ZgloszenieUsterki zg)
        {
            _tablicaZgloszen.Enqueue(zg);
            _liczbaZgloszen = _tablicaZgloszen.Count;
        }
        public void UsunZgloszenie() //tutaj trzeba bylo od nrZgloszenia
                     //ale to duzo zabawy z tym, nie ma czasu na kolosie
        {
            _tablicaZgloszen.Dequeue();
            _liczbaZgloszen = _tablicaZgloszen.Count;
        }
        public void ZnajdzZgloszenie(string slowo)
        {
            foreach (ZgloszenieUsterki zgloszenie in _tablicaZgloszen)
            {
                if (zgloszenie.nazwaZgloszeniodawcy.Contains(slowo))
                {
                    Console.WriteLine(zgloszenie);
                }
                else if (zgloszenie.zgloszonaAwaria.Contains(slowo))
                {
                    Console.WriteLine(zgloszenie);
                }
                else { };
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"nazwa kolejki: {Nazwa}");
            sb.AppendLine($"ilosc zgloszen: {LiczbaZgloszen}");
            sb.AppendLine("obecne zgloszenia:");
            int idx = 0;
            foreach (ZgloszenieUsterki z in _tablicaZgloszen)
            {
                sb.AppendLine($"==={++idx}===");
                sb.AppendLine(z.ToString());

            }
            return sb.ToString();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public TablicaZgloszen DeepClone<TablicaZgloszen>()
        {
            using (var memoryStream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();

                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                return (TablicaZgloszen)formatter.Deserialize(memoryStream);
            }
        }
        public TablicaZgloszen DeepCopy()
        {
            // TablicaZgloszen kopia = (TablicaZgloszen)this.MemberwiseClone();
            TablicaZgloszen kopia = new TablicaZgloszen();
            kopia._nazwa = this._nazwa;
            kopia._liczbaZgloszen = this._liczbaZgloszen;
            foreach (ZgloszenieUsterki zgl in this._tablicaZgloszen){
                kopia._tablicaZgloszen.Enqueue(zgl);
            }
            return kopia;

        }
        public static void SaveXml(string fileName, TablicaZgloszen tablica)
        {
            
            XmlSerializer serializer = new XmlSerializer(typeof(TablicaZgloszen));
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, tablica);
            }

        }

    }
}
