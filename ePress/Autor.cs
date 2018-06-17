using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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
            if(imie == null)
				throw new AutorException("Musisz podać dane!");
			Regex regex = new Regex("^[A-Za-zĄąĆćĘęŚśÓóŁłŻżŹźŃń]+$");
			Match match = regex.Match(imie);
			if (!match.Success)
				throw new AutorException("Nieprawidlowy format imienia!");
			this._imie = imie;
			if (nazwisko == null)
                throw new AutorException("Musisz podać dane!");
			match = regex.Match(nazwisko);
            if (!match.Success)
                throw new AutorException("Nieprawidlowy format nazwiska!");
			this._nazwisko = nazwisko;
			Regex regexpesel = new Regex("^[0-9]+$");
			Match matchpesel = regexpesel.Match(pesel);
			if (!matchpesel.Success)
			{
				throw new AutorException("Nieprawidlowy format peselu!");
			}
			if (pesel.Length != 11)
				throw new AutorException("Nieprawidłowa dlugosc peselu dla danych:"+imie+" "+nazwisko+" "+pesel);
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
