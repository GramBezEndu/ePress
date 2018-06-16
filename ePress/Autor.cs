using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePress
{
    [Serializable]
    public class Autor : IEquatable<Autor>
    {
        private string _imie;
        private string _nazwisko;
        private string _pesel;
        public Autor(string imie, string nazwisko, string pesel)
        {
            this._imie = imie;
            if(imie == null)
				throw new AutorException("Musisz podać dane!");
            this._nazwisko = nazwisko;
			if (nazwisko == null)
                throw new AutorException("Musisz podać dane!");
			if (pesel.Length != 11)
				throw new AutorException("Nieprawidłowy format peselu dla danych:"+imie+" "+nazwisko+" "+pesel);
            this._pesel = pesel;
        }
        public void Informacje()
        {
            Console.WriteLine("\timie: {0}", this._imie);
            Console.WriteLine("\tnazwisko: {0}", this._nazwisko);
            Console.WriteLine("\tpesel: {0}\n", this._pesel);
        }
		public bool Equals(Autor autor)
		{
			if(this._imie==autor._imie && this._nazwisko==autor._nazwisko && this._pesel==autor._pesel)
				return true;
			return false;
		}
		public string Get_pesel()
		{
			return this._pesel;
		}
    }
}
