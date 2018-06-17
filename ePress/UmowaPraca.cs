using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePress
{
    [Serializable]
	public class UmowaPraca : Umowa
	{
		protected DateTime _dataZawarcia;
		protected DateTime _dataKonca;
		public UmowaPraca(DateTime dataZawarcia, DateTime dataKonca)
		{
            //DateTime dateTime = DateTime.Today;
            //this._dataZawarcia = dateTime.ToString();
            //this._dataKonca = "nieokreślony";
            this._dataZawarcia = dataZawarcia;
            this._dataKonca = dataKonca;
		}
		public override void Informacje()
		{
			Console.WriteLine("Umowa o prace:");
            Console.WriteLine("\tdata zawarcia: {0}", this._dataZawarcia);
            Console.WriteLine("\tdata konca: {0}", this._dataKonca);
		}
	}
}
