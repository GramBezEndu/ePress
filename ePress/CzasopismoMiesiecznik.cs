using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePress
{
    [Serializable]
    public class CzasopismoMiesiecznik : Czasopismo
    {
        public CzasopismoMiesiecznik(string tytul, int numer) : base(tytul, numer) { }
    }
}
