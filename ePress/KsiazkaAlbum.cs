using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePress
{
    public class KsiazkaAlbum : Ksiazka
    {
        public KsiazkaAlbum(Autor autor, string tytul, int rokWydania) : base(autor, tytul, rokWydania) { }
    }
}
