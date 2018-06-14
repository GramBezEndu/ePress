using NUnit.Framework;
using System;
using ePress;
namespace ePressTests
{
	[TestFixture()]
	public class DzialProgramowyTests
	{
		public Autor autor = new Autor("Jan", "Kowalski", "12345678901");
		public DzialProgramowy dprogramowy = new DzialProgramowy();
		[SetUp]
		public void Init()
		{
			dprogramowy.DodajAutora(autor);
		}
		[Test()]
		public void ZnajdzAutoraPoprawnyPesel()
		{
			dprogramowy.ZnajdzAutora("12345678901");
		}
		[Test()]
		public void ZnajdzAutoraNieprawidlowyPesel()
		{
			try
			{
				dprogramowy.ZnajdzAutora("12345678991");
				Assert.Fail("AutorException should be thrown");
			}
			catch (AutorException)
			{
				Assert.Pass("Poprawna obsługa błędu");
			}
		}
		[Test()]
		public void NieUnikatowyPesel()
		{
			//pesel musi byc unikatowy jezeli jest kluczem
			Autor niepoprawny_autor = new Autor("Mariusz", "Kowalski", "12345678901");
			try
			{
				dprogramowy.DodajAutora(niepoprawny_autor);
				Assert.Fail();          
			}
			catch(AutorException)
			{
				Console.WriteLine("Poprawna obsługa błędu");
                Assert.Pass();
			}
		}
		[Test()]
		public void DodajUmoweNieDodanyAutora()
		{
			Autor niedodany_autor = new Autor("Adrian", "Wolanowski", "98075432111");
			KsiazkaRomans romans = new KsiazkaRomans(niedodany_autor, "Historia bardzo smutnego człowieczka", 2018);
			UmowaZlecenie umowa = new UmowaZlecenie(romans);
			try
			{
				dprogramowy.DodajUmowe(niedodany_autor, umowa);
				Assert.Fail("InvalidOperationException - No matching author should be thrown");
			}
			catch (AutorException)
			{
				Console.WriteLine("Poprawna obsługa błędu");
				Assert.Pass();
			}
		}
		[Test()]
		public void DodajAutoraWielokrotnie()
		{
			try
			{
				Autor autor2 = new Autor("Jan", "Kowalski", "12345678901");
				dprogramowy.DodajAutora(autor2);
				Assert.Fail();
			}
			catch (AutorException)
			{
				Console.WriteLine("Poprawna obsługa błędu");
				Assert.Pass();
			}
		}
		[Test()]
		public void RozwiazUmowe()
		{
			KsiazkaRomans romans = new KsiazkaRomans(autor, "Historia bardzo smutnego człowieczka", 2018);
			KsiazkaAlbum album = new KsiazkaAlbum(autor, "Podlasie i okolice", 2010);
			UmowaZlecenie umowa = new UmowaZlecenie(romans);
			UmowaPraca umowaPraca = new UmowaPraca(DateTime.Today, DateTime.MaxValue);
			UmowaPraca temp = umowaPraca;
			UmowaDzielo dzielo = new UmowaDzielo(DateTime.Today, new DateTime(2018, 2, 16), album);
			dprogramowy.DodajUmowe(autor, umowa);
			dprogramowy.DodajUmowe(autor, umowaPraca);
			dprogramowy.DodajUmowe(autor, dzielo);
			dprogramowy.PrzegladUmow(autor);
			dprogramowy.RozwiazUmowe(umowaPraca);
			dprogramowy.PrzegladUmow(autor);
			temp.Informacje();
		}
	}
	[TestFixture()]
	public class AutorTests
	{
		public Autor autor1 = new Autor("Jan", "Kowalski", "12345678901");
		public Autor autor2 = new Autor("Kamil", "Kowalski", "12345678901");
		public Autor autor3 = new Autor("Jan", "Nowak", "12345678901");
		public Autor autor4 = new Autor("Jan", "Kowalski", "11234567890");
		public Autor autor5 = new Autor("Jan", "Kowalski", "12345678901");
		[Test()]
		public void EqualsDlaRoznychAutorow()
		{
			Assert.AreNotEqual(autor1, autor2);
			Assert.AreNotEqual(autor1, autor3);
			Assert.AreNotEqual(autor1, autor4);
			Assert.AreEqual(autor1, autor5);
		}
	}
	[TestFixture()]
	public class DrukarniaTests
	{
		public Drukarnia drukarnia = new Drukarnia(false);
		public DzialHandlowy dzialHandlowy = new DzialHandlowy();

		[Test()]
		public void PróbaDrukowaniaWZajętejDrukarni()
		{
			try
			{
				drukarnia.Drukuj();
				Assert.Fail();
			}
			catch (ZajetaDrukarniaException)
			{
				Console.WriteLine("Poprawna obsługa błędu");
				Assert.Pass();
			}
		}
	}
}
