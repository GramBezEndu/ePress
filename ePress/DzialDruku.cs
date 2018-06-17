using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePress
{
    [Serializable]
    public class DzialDruku
    {
        private List<Drukarnia> _drukarnie;
        //Stworzenie i dodanie drukarni
        public DzialDruku()
        {
            this._drukarnie = new List<Drukarnia>();
            this._drukarnie.Add(new Drukarnia());
            this._drukarnie.Add(new Drukarnia());
            this._drukarnie.Add(new DrukarniaAlbumowa());
        }
        public void ZlecenieDruku(DzialHandlowy dzialHandlowy, Pozycja pozycja, int ilosc)
        {
            if (pozycja is KsiazkaAlbum)
            {
                foreach(Drukarnia temp in _drukarnie)
                {
                    if(temp is DrukarniaAlbumowa)
                    {
                        temp.ZlecenieDruku(dzialHandlowy, pozycja, ilosc);
                        break;
                    }
                }
            }
            else
            {
                Drukarnia temp = _drukarnie.First();
                temp.ZlecenieDruku(dzialHandlowy, pozycja, ilosc);
            }
        }
        //public void ZapiszDruku()
        //{
        //    FileStream plik = new FileStream("Druku.dat", FileMode.Create);
        //    BinaryFormatter nowy = new BinaryFormatter();
        //    nowy.Serialize(plik, _drukarnie);
        //    plik.Close();
        //}
        //public void WczytajDruku()
        //{
        //    FileStream plik;
        //    plik = new FileStream("Druku.dat", FileMode.Open);
        //    BinaryFormatter nowy = new BinaryFormatter();
        //    _drukarnie = (List<Drukarnia>)nowy.Deserialize(plik);
        //    plik.Close();
        //}
    }
}
