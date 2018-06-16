using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePress
{
	public class Drukarnia
	{
		protected List<Tuple<DzialHandlowy, Pozycja, int>> _zlecenia;
		protected bool _dostepna;
		public Drukarnia(bool dostepna = true)
		{
			this._zlecenia = new List<Tuple<DzialHandlowy, Pozycja, int>>();
			this._dostepna = dostepna;
		}
		/// <summary>
		/// Dodaje konkretne zlecenie na liste
		/// </summary>
		/// <param name="handlowy"></param>
		/// <param name="pozycja"></param>
		/// <param name="ilosc"></param>
		public void ZlecenieDruku(DzialHandlowy handlowy, Pozycja pozycja, int ilosc)
		{
			this._zlecenia.Add(new Tuple<DzialHandlowy, Pozycja, int>(handlowy, pozycja, ilosc));
            //powinno być unikatowe, ale w sumie jezeli nie bedzie to nic zlego sie nie stanie
            this.Drukuj();
		}
		/// <summary>
		/// Drukuje wszystkie zlecenia, jesli drukarnia jest dostepna
		/// </summary>
		public void Drukuj()
		{
			if (this._dostepna == true)
			{
				foreach (Tuple<DzialHandlowy, Pozycja, int> tuple in _zlecenia)
				{
					try
                    {
                        //Dzial_handlowy.Set_pozycja(Pozycja, ilosc + Pozycja.Get_ilosc()); 
                        tuple.Item1.Set_pozycja(tuple.Item2, tuple.Item3 + tuple.Item1.Get_ilosc(tuple.Item2));
                        //Console.WriteLine("Ile: {0}", tuple.Item3 + tuple.Item1.Get_ilosc(tuple.Item2));
                        //Console.ReadKey();
                    }
					catch(BrakPozycjiException brakpozycji)
					{
						Console.WriteLine("Pozycja nie znajduje się jeszcze w ofercie, zostanie utworzona");
						brakpozycji.szukanapozycja.Informacje();
						tuple.Item1.Stworz_pozycje(tuple.Item2, tuple.Item3); //trzeba sprawdzic czy ma to rece i nogi
                        Console.ReadKey();
					}
                }
                this._zlecenia.Clear();
			}
			else
			{
				throw new ZajetaDrukarniaException();
			}
		}
		public List<Tuple<DzialHandlowy, Pozycja, int>> Get_zlecenia()
		{
			return this._zlecenia;
		}
		public bool Get_dostepna()
		{
			return this._dostepna;
		}
	}
	public class DrukarniaException : Exception
	{
		public DrukarniaException(string message) : base(message)
		{

		}
	}
	public class ZajetaDrukarniaException:DrukarniaException
	{
		public ZajetaDrukarniaException():base("Drukarnia jest obecnie zajeta")
		{
			
		}
	}
}