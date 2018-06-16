using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePress
{
    [Serializable]
    public class KsiazkaSensacyjna : Ksiazka
    {
        public KsiazkaSensacyjna(Autor autor, string tytul, int rokWydania) : base(autor, tytul, rokWydania) { }
    }
}
