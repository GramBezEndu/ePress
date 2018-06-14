using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePress
{
	public class Wydawnictwo
	{
		private DzialDruku _dzialDruku;
		private DzialHandlowy _dzialHandlowy;
		private DzialProgramowy _dzialProgramowy;
		private string _nazwa;
		public Wydawnictwo(DzialDruku dzialDruku, DzialHandlowy dzialHandlowy, DzialProgramowy dzialProgramowy)
		{
			this._dzialDruku = dzialDruku;
			this._dzialHandlowy = dzialHandlowy;
			this._dzialProgramowy = dzialProgramowy;
		}
		public DzialDruku Get_dzialDruku()
		{
			return this._dzialDruku;
		}
		public DzialHandlowy Get_dzialHandlowy()
		{
			return this._dzialHandlowy;
		}
		public DzialProgramowy Get_dzialProgramowy()
		{
			return this._dzialProgramowy;
		}
	}
}
