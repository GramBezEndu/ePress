using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePress
{
    [Serializable]
    public abstract class Pozycja : IInfo, IEquatable<Pozycja>
    {
        protected string _tytul;
        public Pozycja(string tytul)
        {
            this._tytul = tytul;
        }
		public abstract void Informacje();
        public abstract bool Equals(Pozycja pozycja);
        public string Get_tytul()
        {
            return this._tytul;
        }
    }
}
