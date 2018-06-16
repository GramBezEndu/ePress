using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePress
{
    public class DzialHandlowy
    {
        private List<Tuple<Pozycja, int>> _pozycje;
        public DzialHandlowy()
        {
            _pozycje = new List<Tuple<Pozycja, int>>();   //lista pozycji wraz z ich dostępną liczbą
        }
        public void Sprzedaj(Pozycja pozycja, int ilosc)
        {
            if (ilosc <= 0)
				throw new NieprawidlowaIloscException();
                //dopisać wyjątki, gdy brak pozycji lub błędna liczba
            foreach (Tuple<Pozycja, int> p in this._pozycje)
            {
                if (p.Item1.Equals(pozycja))
                {
                    if (p.Item2 >= ilosc)
                    {
                        //Zmiana ilosci ksiazek na stanie
                        Tuple<Pozycja, int> temp = new Tuple<Pozycja, int>(pozycja, p.Item2 - ilosc);
                        this._pozycje.Remove(p);
                        this._pozycje.Add(temp);
                        Console.WriteLine("Kupiono książkę");
                    }
                    //Za mala ilosc w magazynie
                    else
                    {
						throw new NieprawidlowaIloscException(p.Item1,ilosc,p.Item2);
                    }
                }
            }
            //Brak pozycji
			throw new BrakPozycjiException(pozycja);
        }
        public void WyswietlPozycje()
        {
            foreach(Tuple<Pozycja, int> p in this._pozycje)
            {
				Console.WriteLine(p.Item1+" Ilość sztuk: "+p.Item2); //tutaj jest założenie, że na liście są tylko dostępne pozycje (wg mnie inaczej)
                //Pozycje mozna przegladac wszystkie, to czy sa na stanie aktualnie w dziale programowym to inna sprawa #Kuba
            }
        }
        public void ZlecenieDruku(DzialDruku dzialDruku, Pozycja p, int ilosc)
        {
            dzialDruku.ZlecenieDruku(this, p, ilosc);
        }
        /// <summary>
        /// Dodaje jedna nowa pozycje (usuwajac parametry starej pozycji, jesli istnieje juz na liscie)
        /// </summary>
        public void Set_pozycja(Pozycja pozycja, int ilosc)
        {
            foreach(Tuple<Pozycja, int> temp in _pozycje)
            {
                if(pozycja.Equals(temp.Item1))
                {
                    Tuple<Pozycja, int> temp2 = new Tuple<Pozycja, int>(pozycja, ilosc);
                    this._pozycje.Remove(temp);
                    this._pozycje.Add(temp2);
                    break;
                }
            }
            //Nie znaleziono podanej pozycji na liscie
			throw new BrakPozycjiException(pozycja);

        }
        public void Stworz_pozycje(Pozycja pozycja, int ilosc)
        {
            foreach(Tuple<Pozycja, int> temp in _pozycje)
            {
                if(pozycja.Equals(temp.Item1))
                {
                    throw new InvalidOperationException("Podana pozycja jest juz na liscie");
                }
            }
            this._pozycje.Add(new Tuple<Pozycja,int>(pozycja, ilosc));
        }
        public int Get_ilosc(Pozycja pozycja)
        {
            foreach (Tuple<Pozycja, int> temp in _pozycje)
            {
                if (pozycja.Equals(temp.Item1))
                {
                    return temp.Item2;
                }
            }
            //Nie znaleziono podanej pozycji
			throw new BrakPozycjiException(pozycja);
        }
        public Pozycja ZnajdzPozycje(string nazwa)
        {
            foreach (Tuple<Pozycja, int> temp in _pozycje)
            {
                if (temp.Item1.Get_tytul()==nazwa)
                {
                    return temp.Item1;
                }
            }
            throw new BrakPozycjiException(nazwa);
        }
    }
	public class PozycjaException:Exception
	{
		
		public PozycjaException(string message):base(message)
		{
			
		}
	}
	public class BrakPozycjiException:PozycjaException
	{
		public Pozycja szukanapozycja=null;
		public BrakPozycjiException(string nazwapozycji): base("Nie ma takiej pozycji: "+nazwapozycji+", spróbuj ponownie")
		{
			
		}
		public BrakPozycjiException(Pozycja pozycja):base("Nie ma takiej pozycji")
		{
			szukanapozycja = pozycja;
		}
	}
	public class NieprawidlowaIloscException:PozycjaException
	{
		public Pozycja pozycja=null;
		public int ilechcekupic;
		public int ilejestdostepnych;
		public NieprawidlowaIloscException():base("Podana została nieodpowiednia ilość, spróbuj ponownie")
		{
			
		}
		public NieprawidlowaIloscException(Pozycja szukanapozycja, int ilekupic, int iledostepnych):base("Nie ma takiej ilosci szukanej pozycji w bazie")
        {
			pozycja = szukanapozycja;
			ilechcekupic = ilekupic;
			ilejestdostepnych = iledostepnych;
        }
	}
}