using NUnit.Framework;
using System;
using ePress;
namespace ePressTests
{
	[TestFixture()]
	public class DzialProgramowyTests
	{
		public Autor autor = new Autor("Jan", "Kowalski","12345678901");
		public DzialProgramowy dprogramowy = new DzialProgramowy();
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
		[Test()]
		public void BrakImienia()
		{
			try
			{
				Autor nieprawidlowyautor1 = new Autor(null, "Kowalski", "12345678901");
				Assert.Fail();
			}
			catch(AutorException)
			{
				Console.WriteLine("Poprawna obsługa błędu");
				Assert.Pass();
			}
		}
		[Test()]
		public void BrakNazwiska()
        {
            try
            {
				Autor nieprawidlowyautor2 = new Autor("Kamil", null, "12345678901");
                Assert.Fail();
            }
            catch (AutorException)
            {
                Console.WriteLine("Poprawna obsługa błędu");
                Assert.Pass();
            }
        }
		[Test()]
        public void ZaKrotkiPesel()
		{
            try
            {
				Autor nieprawidlowyautor3 = new Autor("Jan", "Nowak", "1234567890");
                Assert.Fail();
            }
            catch (AutorException)
            {
                Console.WriteLine("Poprawna obsługa błędu");
                Assert.Pass();
            }
        }
		[Test()]
		public void NieprawidłowyTypDanychImie()
        {
            try
            {
				Autor nieprawidlowyautor5 = new Autor("1", "Kowalski", "12345678901");
                Assert.Fail();
            }
            catch (AutorException)
            {
                Console.WriteLine("Poprawna obsługa błędu");
                Assert.Pass();
            }
        }
		[Test()]
		public void NieprawidłowyTypDanychNazwisko()
        {
            try
            {
				Autor nieprawidlowyautor6 = new Autor("Jan", "1", "12345678901");
                Assert.Fail();
            }
            catch (AutorException)
            {
                Console.WriteLine("Poprawna obsługa błędu");
                Assert.Pass();
            }
        }
		[Test()]
		public void NieprawidłowyTypDanychPesel()
        {
            try
            {
                Autor nieprawidlowyautor7 = new Autor("Jan", "Kowalski", "abcdefghijk");
                Assert.Fail();
            }
            catch (AutorException)
            {
                Console.WriteLine("Poprawna obsługa błędu");
                Assert.Pass();
            }
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
	[TestFixture()]
	public class CzasopismoTests
	{
		[Test()]
        public void CzyKsiazkaToMagazyn()
		{
			Autor autor = new Autor("Pawel", "Bak", "98031111109");
			Ksiazka ksiazka = new KsiazkaSensacyjna(autor, "Nie mam pomyslu", 2012);
			CzasopismoTygodnik tygodnik = new CzasopismoTygodnik("Nie mam pomyslu", 2012);
			Assert.False(tygodnik.Equals(ksiazka));
		}
		[Test()]
        public void CzyTenSamTytulAleInnyRodzaj()
        {
			CzasopismoMiesiecznik miesiecznik = new CzasopismoMiesiecznik("Przeglad sportowy", 4);
            CzasopismoTygodnik tygodnik = new CzasopismoTygodnik("Przeglad sportowy",4);
			Assert.False(tygodnik.Equals(miesiecznik));
        }
		[Test()]
        public void CzyTenSamTytulIRodzajAleInnyNumer()
        {
			CzasopismoTygodnik tygodnik2 = new CzasopismoTygodnik("Science", 3);
            CzasopismoTygodnik tygodnik = new CzasopismoTygodnik("Science", 4);
            Assert.False(tygodnik.Equals(tygodnik2));
        }
		[Test()]
        public void CzyRowneSaRowniejsze()
        {
            CzasopismoTygodnik tygodnik2 = new CzasopismoTygodnik("Budowanie bomb jadrowych dla poczatkujacych", 6);
			CzasopismoTygodnik tygodnik = new CzasopismoTygodnik("Budowanie bomb jadrowych dla poczatkujacych", 6);
            Assert.True(tygodnik.Equals(tygodnik2));
        }
	}
	[TestFixture()]
	public class KsiazkaTests
	{
		[Test()]
        public void CzyKsiazkaToMagazyn()
        {
            Autor autor = new Autor("Pawel", "Bak", "98031111109");
            Ksiazka ksiazka = new KsiazkaSensacyjna(autor, "Nie mam pomyslu", 2012);
            CzasopismoTygodnik tygodnik = new CzasopismoTygodnik("Nie mam pomyslu", 2012);
            Assert.False(ksiazka.Equals(tygodnik));
        }
        [Test()]
        public void CzyTenSamTytulAleInnyRodzaj()
        {
			Autor autor = new Autor("Jakub", "Mroczkowski", "98022334012");
			Ksiazka ksiazka = new KsiazkaAlbum(autor, "Programowanie obrazkowe", 2010);
			Ksiazka ksiazka2 = new KsiazkaSensacyjna(autor, "Programowanie obrazkowe", 2010);
			Assert.False(ksiazka.Equals(ksiazka2));
        }
        [Test()]
        public void CzyTenSamTytulIRodzajAleInnyRokWydania()
        {
			Autor autor = new Autor("Jakub", "Mroczkowski", "98022334012");
			Ksiazka ksiazka = new KsiazkaSensacyjna(autor, "Czemu nic nie dziala i inne porady Visual Studio 2017", 2010);
			Ksiazka ksiazka2 = new KsiazkaSensacyjna(autor, "Czemu nic nie dziala i inne porady Visual Studio 2017", 2017);
			Assert.False(ksiazka.Equals(ksiazka2));
        }
        [Test()]
        public void CzyRowneSaRowniejsze()
        {
			Autor autor = new Autor("Wojciech", "Mojsiejuk", "97013233401");
			Ksiazka ksiazka = new KsiazkaRomans(autor, "Powinienem jednak pisac te testy - TDD dla zoltodziobow", 2017);
			Ksiazka ksiazka2 = new KsiazkaRomans(autor, "Powinienem jednak pisac te testy - TDD dla zoltodziobow", 2017);
			Assert.True(ksiazka.Equals(ksiazka2));
        }
	}
	[TestFixture()]
	public class DzialHandlowyTests
	{
		[Test()]
		public void StworzMinusChleb()
		{
			DzialHandlowy dzialHandlowy = new DzialHandlowy();
			Autor autor = new Autor("Wojciech", "Mojsiejuk", "97013233401");
            Ksiazka ksiazka = new KsiazkaRomans(autor, "Kto wymyslil dodawanie tylu obiektow", 2018);
			try
			{
				dzialHandlowy.Stworz_pozycje(ksiazka, -1);
				Assert.Fail();
			}
			catch (InvalidOperationException) { Assert.Pass(); }
			catch (PozycjaException) { Assert.Pass(); }         
		}
		[Test()]
		public void StworzJuzStworzone()
        {
            DzialHandlowy dzialHandlowy = new DzialHandlowy();
            Autor autor = new Autor("Wojciech", "Mojsiejuk", "97013233401");
            Ksiazka ksiazka = new KsiazkaRomans(autor, "Kto wymyslil dodawanie tylu obiektow2", 2018);
			dzialHandlowy.Stworz_pozycje(ksiazka, 10);
            try
            {
				dzialHandlowy.Stworz_pozycje(ksiazka, 20);
                Assert.Fail();
            }
            catch (InvalidOperationException) { Assert.Pass(); }
            catch (PozycjaException) { Assert.Pass(); }
        }
		[Test()]
        public void ZnajdzNieznajdywalne()
        {
            DzialHandlowy dzialHandlowy = new DzialHandlowy();
            Autor autor = new Autor("Wojciech", "Mojsiejuk", "97013233401");
            Ksiazka ksiazka = new KsiazkaRomans(autor, "Kto wymyslil dodawanie tylu obiektow 3 Kosmici Kontratakuja", 2018);
            dzialHandlowy.Stworz_pozycje(ksiazka, 10);
            try
            {
				dzialHandlowy.ZnajdzPozycje("Kto wymyslil dodawanie tylu obiektow 4 Nowa Nadzieja");
                Assert.Fail();
            }
			catch (BrakPozycjiException){ Assert.Pass(); }
        }
		[Test()]
        public void CaSeSeNsItIvItyAjĆ()
        {
            DzialHandlowy dzialHandlowy = new DzialHandlowy();
            Autor autor = new Autor("Emo", "Martynka", "97323269401");
			Ksiazka ksiazka = new KsiazkaRomans(autor, "ToOmÓóŚ", 2001);
            dzialHandlowy.Stworz_pozycje(ksiazka, 33);
            try
            {
                dzialHandlowy.ZnajdzPozycje("Toomóóś");
                Assert.Pass();
            }
			catch (BrakPozycjiException) { Assert.Fail(); }
        }
		[Test()]
        public void IloscSieZgadza()
        {
            DzialHandlowy dzialHandlowy = new DzialHandlowy();
            Autor autor = new Autor("George", "Martin", "43323269401");
            Ksiazka ksiazka = new KsiazkaSensacyjna(autor, "Wichry Zimy", 2040);
            dzialHandlowy.Stworz_pozycje(ksiazka, 33000);
            try
            {
				dzialHandlowy.Set_pozycja(ksiazka, 200000);
				dzialHandlowy.Get_ilosc(ksiazka).Equals(233000);
            }
            catch (BrakPozycjiException) { Assert.Fail(); }
        }
		[Test()]
        public void NastawWodeNaNiestiniejacaHerbate()
        {
            DzialHandlowy dzialHandlowy = new DzialHandlowy();
            Autor autor = new Autor("George", "Martin", "43323269401");
            Ksiazka ksiazka = new KsiazkaSensacyjna(autor, "Wichry Zimy", 2040);
			Ksiazka ksiazka2 = new KsiazkaSensacyjna(autor, "Final Gry o Tron", 2099);
            dzialHandlowy.Stworz_pozycje(ksiazka, 33000);
            try
            {
                dzialHandlowy.Set_pozycja(ksiazka2, 200000);
				Assert.Fail();
            }
            catch (BrakPozycjiException) { Assert.Pass(); }
        }

	}
}
