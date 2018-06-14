using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePress
{
    public abstract class Czasopismo : Pozycja
    {
		protected int _numer;
        public Czasopismo(string tytul, int numer) : base(tytul)
        {
            this._numer = numer;
        }
		public override void Informacje()
		{
			Console.WriteLine("tytuł: {0}", this._tytul);
			Console.WriteLine("rodzaj: {0}", this.GetType());
			Console.WriteLine("numer: {0}", this._numer);
		}
        public override bool Equals(Pozycja pozycja)
        {
            if (this.GetType() == pozycja.GetType())
            {
                Czasopismo A = (Czasopismo)pozycja;
                if (this._tytul == A._tytul && this._numer == A._numer)
                    return true;
            }
            return false;
        }
        //public new bool Equals(Czasopismo pozycja)
        //{
        //    if (this.GetType() == pozycja.GetType()  && this._tytul == pozycja._tytul && this._numer == pozycja._numer)
        //        return true;
        //    else
        //        return false;
        //}
    }
}
