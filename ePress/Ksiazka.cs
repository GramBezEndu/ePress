using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePress
{
    [Serializable]
    public abstract class Ksiazka : Pozycja
    {
		protected Autor _autor;
		protected int _rokWydania;
        public Ksiazka(Autor autor, string tytul, int rokWydania) : base(tytul)
        {
            this._autor = autor;
            this._rokWydania = rokWydania;
        }
		public override void Informacje()
		{
			Console.WriteLine("tytuł: {0}", this._tytul);
			Console.WriteLine("rodzaj: {0}", this.GetType());
			Console.WriteLine("rok wydania: {0}", this._rokWydania);
			this._autor.Informacje();
		}
        public override bool Equals(Pozycja pozycja)
        {
            if (pozycja.GetType() == this.GetType())
            {
                Ksiazka A = (Ksiazka)pozycja;
                if (this._autor.Equals(A._autor) && this._tytul == A._tytul && this._rokWydania == A._rokWydania)
                    return true;
            }
            return false;
        }
        //public new bool Equals(Ksiazka pozycja)
        //{
        //    Console.WriteLine("Porownanie ksiazek");
        //    Console.WriteLine(pozycja.GetType());
        //    if (pozycja.GetType() == this.GetType() && this._autor.Equals(pozycja._autor) && this._tytul == pozycja._tytul && this._rokWydania == pozycja._rokWydania)
        //        return true;
        //    else
        //        return false;
        //}
    }
}
