using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePress
{
    [Serializable]
    public class KsiazkaRomans : Ksiazka
    {
        public KsiazkaRomans(Autor autor, string tytul, int rokWydania) : base(autor, tytul, rokWydania) { }
    }
}
