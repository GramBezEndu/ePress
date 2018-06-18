using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ePress
{
    public class ZapisSystemu
    {
        public ZapisSystemu()
        {
        }
        public void Zapisz(Wydawnictwo wydawnictwo)
        {
            FileStream plik = new FileStream("Dane.dat", FileMode.Create);
            if (plik == null)
            {
                throw new SaveException("Blad zapisu!");
            }
            BinaryFormatter nowy = new BinaryFormatter();
            nowy.Serialize(plik, wydawnictwo);
            plik.Close();
        }
        public Wydawnictwo Wczytaj()
        {
            FileStream plik;
            plik = new FileStream("Dane.dat", FileMode.Open);
            BinaryFormatter nowy = new BinaryFormatter();
            Wydawnictwo nowe = (Wydawnictwo)nowy.Deserialize(plik);
            plik.Close();
            return nowe;
        }
    }
}
public class SaveException : Exception
{
    public SaveException(string message) : base(message)
    {

    }
}
public class LoadException : Exception
{
    public LoadException(string message) : base(message)
    {

    }
}