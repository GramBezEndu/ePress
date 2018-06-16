using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePress
{
	public class UmowaZlecenie : Umowa
	{
		protected Pozycja _pozycja;
		public UmowaZlecenie(Pozycja pozycja)
		{
			this._pozycja = pozycja;
		}
		public override void Informacje()
		{
			Console.WriteLine("Umowa zlecenie:");
			_pozycja.Informacje();
		}
	}
}
