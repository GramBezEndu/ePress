using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePress
{
    [Serializable]
    public class DzialProgramowy
    {
        private List<Tuple<Autor, List<Umowa>>> _autorzy;
		public DzialProgramowy()
		{
			this._autorzy = new List<Tuple<Autor, List<Umowa>>>(); //lista autorów wraz ze wszystkimi umowami przypisanymi do konkretnego autora
		}
		/// <summary>
        /// Przeszukuje listę autorów, iterując w krotce sprawdza
		///  czy pesel szukanego autora znajduje się w bazie
        /// </summary>
		public Autor ZnajdzAutora(string pesel)
		{
			foreach(Tuple<Autor, List<Umowa>> tuple in this._autorzy)
			{
				if (tuple.Item1.Get_pesel() == pesel) //konieczność by pesel był unikatowy
					return tuple.Item1;
			}
			throw new AutorException("Nie znaleziono autora");
		}
		/// <summary>
        /// Przeszukuje listę autorów, jeżeli autor znajduje się w liście to dodawana jest dla niego umowa
		/// </summary>
		public void DodajUmowe(Autor autor, Umowa umowa)
		{
			foreach (Tuple<Autor, List<Umowa>> tuple in this._autorzy)
			{
				if (tuple.Item1.Equals(autor))
				{
					tuple.Item2.Add(umowa);
					Console.WriteLine("Pomyslnie dodano umowe");
					Console.WriteLine("\nAby kontunuowac nacisnij dowolny przycisk...");
                    Console.ReadKey();
					return;
				}
    		}
			throw new AutorException("Nie znaleziono autora",autor);
		}
		/// <summary>
        /// Przeszukuje listę autorów, jeżeli autor znajduje się w liście i ma w liście umów podaną umowę to ją usuwa
        /// </summary>
		public void RozwiazUmowe(Umowa umowa)
		{
			foreach (Tuple<Autor, List<Umowa>> tuple in this._autorzy)
            {
				if (tuple.Item2.Contains(umowa))
                {
					if (tuple.Item2.Remove(umowa) == true)
					{
						Console.WriteLine("Pomyslnie usunieto umowe");
						Console.WriteLine("\nAby kontunuowac nacisnij dowolny przycisk...");
						Console.ReadKey();
						return;
					}
					else
					{
						throw new UmowaException("Nie udało się usunąć umowy",tuple.Item1,tuple.Item2);
					}
                }
            }
			throw new UmowaException("Brak umowy w bazie");
		}
		/// <summary>
        /// Przeszukuje listę autorów, jeżeli autor znajduje się w liście to wypisuje wszystkie umowy.
		/// Jeżeli autora nie ma na liście to nie wyrzuca wyjątku, po prostu nic nie wypisze.
		/// Metoda zakłada że autor musi być na liście, by metoda zostala wywołana.
        /// </summary>
		public void PrzegladUmow(Autor autor)
		{
			int i; //numeruje umowy - potrzebne do metody RozwiazUmowe
			i = 1;
			foreach (Tuple<Autor, List<Umowa>> tuple in this._autorzy)
            {
				if (tuple.Item1.Equals(autor))
                {
                    Console.WriteLine("Przeglad umow dla autora:");
                    tuple.Item1.Informacje();
					foreach(Umowa umowa in tuple.Item2)
					{
						Console.WriteLine(i+":");
						umowa.Informacje();
						i++;
					}
                }
            }
		}
		/// <summary>
        /// Dodaje autora do listy autorów. Wszyscy autorzy muszą mieć unikatowy pesel.
        /// </summary>
        public void DodajAutora(Autor autor)
        {
			//metoda nie powinna dodawac juz istniejacego autora, wykorzystanie LINQ
			var posiadaczetegopeselu = from szukaniautorzy in _autorzy where (szukaniautorzy.Item1.Get_pesel()) == autor.Get_pesel() select szukaniautorzy;
			if (posiadaczetegopeselu.Count()==0)
			{
				this._autorzy.Add(new Tuple<Autor, List<Umowa>>(autor, new List<Umowa>()));
				Console.WriteLine("Pomyślnie dodano autora");
				Console.WriteLine("\nAby kontunuowac nacisnij dowolny przycisk...");
                Console.ReadKey();
			}
			else
				throw new AutorException("Autor już istnieje w bazie", posiadaczetegopeselu.ElementAt(0).Item1);
        }
		/// <summary>
        /// Przeszukuje listę autorów i usuwa podanego autora.
		///  RemoveAll zwraca ilośc usuniętych rekordów, jeżeli == 0 to znaczy, że nie ma takiego autora.
        /// </summary>
        public void UsunAutora(Autor autor)
        {
			if (this._autorzy.RemoveAll(i => i.Item1.Equals(autor)) == 0)
				throw new AutorException("Nie znaleziono autora");
        }
		/// <summary>
        /// Wyswietla informacje o każdym z autorów na liście autorów
        /// </summary>
        public void PrzegladAutorow()
        {
            Console.WriteLine("Lista autorow:");
            foreach(Tuple<Autor, List<Umowa>> tuple in _autorzy)
            {
                tuple.Item1.Informacje();
            }
        }
		/// <summary>
        /// Dodatkowa metoda potrzebna przy usuwaniu umów, otrzymuje indeks umowy
		/// dla danego autora i szuka jej w bazie.
        /// </summary>
        public Umowa GetUmowa(Autor autor,int indeks)
		{
			foreach(Tuple<Autor, List<Umowa>> tuple in this._autorzy)
			{
				if(tuple.Item1.Equals(autor))
				{
					Umowa szukanaumowa = tuple.Item2[indeks - 1];
					if(szukanaumowa!=null)
					{
						return szukanaumowa;
					}                        
				}
			}
			throw new UmowaException("Nie ma takiej umowy");
		}
    }
	public class AutorException:Exception
	{
		public Autor autor = null;
		public AutorException(string message):base(message){}
		public AutorException(string message, Autor autor):base(message)
		{
			this.autor = autor;
		}
	}
	public class UmowaException : Exception
    {
		public Autor autorzwiazanyumowa;
		public List<Umowa> lista_umow_autora;
		public UmowaException(string message) : base(message) { }
		public UmowaException(string message, Autor autor,List<Umowa>lista_umow) : base(message)
        {
			autorzwiazanyumowa = autor;
			lista_umow_autora = lista_umow;
        }
    }
}
