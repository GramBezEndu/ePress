using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePress
{
    [Serializable]
    public class UmowaDzielo : UmowaZlecenie
    {
		private DateTime _dataZawarcia;
		private DateTime _dataKonca;
        public UmowaDzielo(DateTime dataZawarcia, DateTime dataKonca, Pozycja pozycja) : base(pozycja)
        {
			if (dataZawarcia.CompareTo(dataKonca) > 0)
            {
                throw new UmowaException("Data rozpoczecia musi byc wczesniej niz data zakonczenia");
            }
            this._dataZawarcia = dataZawarcia;
            this._dataKonca = dataKonca;
            this._pozycja = pozycja;
        }
		public override void Informacje()
        {
            Console.WriteLine("Umowa o dzielo:");
            Console.WriteLine("\tdata zawarcia: {0}", this._dataZawarcia);
            Console.WriteLine("\tdata konca: {0}", this._dataKonca);
            Console.WriteLine("\tdzieło:");
            this._pozycja.Informacje();
        }
    }
}
