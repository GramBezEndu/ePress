using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePress
{
    public class Program
    {
        /// <summary>
        /// Dodaje pozycje do listy w dziale handlowym
        /// zwraca dodaną pozycje, jezeli nie dodano - zwraca null
        /// </summary>
        static private Pozycja DodajPozycje(Wydawnictwo wydawnictwo)
        {
            string input;
            int wybor3;
            Console.WriteLine("Wybierz typ pozycji:");
            Console.WriteLine("0. Powrot");
            Console.WriteLine("1. Ksiazka");
            Console.WriteLine("2. Czasopismo");
            input = Console.ReadLine();
            Int32.TryParse(input, out wybor3);
            switch (wybor3)
            {
                case 0:
                    return null;
                case 1:
                    Autor autor_do_dodania = ZnajdzAutora(wydawnictwo);
                    string tytul_do_dodania, czytaj;
                    int rok_do_dodania;
                    Console.WriteLine("Podaj tytul:");
                    tytul_do_dodania = Console.ReadLine();
                    Console.WriteLine("Podaj rok wydania:");
                    czytaj = Console.ReadLine();
                    Int32.TryParse(czytaj, out rok_do_dodania);
                    int ilosc;
                    Console.WriteLine("Podaj ilosc");
                    czytaj = Console.ReadLine();
                    Int32.TryParse(input, out ilosc);
                    int wybor4;
                    Console.WriteLine("Wybierz typ ksiazki:");
                    Console.WriteLine("0. Powrot");
                    Console.WriteLine("1. Ksiazka album");
                    Console.WriteLine("2. Ksiazka romans");
                    Console.WriteLine("3. Ksiazka sensacyjna");
                    input = Console.ReadLine();
                    Int32.TryParse(input, out wybor4);
                    Pozycja nowa = null;
                    switch (wybor4)
                    {
                        case 0:
                            break;
                        case 1:
                            nowa = new KsiazkaAlbum(autor_do_dodania, tytul_do_dodania, rok_do_dodania);
                            wydawnictwo.Get_dzialHandlowy().Stworz_pozycje(nowa, ilosc);
                            break;
                        case 2:
                            nowa = new KsiazkaRomans(autor_do_dodania, tytul_do_dodania, rok_do_dodania);
                            wydawnictwo.Get_dzialHandlowy().Stworz_pozycje(nowa, ilosc);
                            break;
                        case 3:
                            nowa = new KsiazkaSensacyjna(autor_do_dodania, tytul_do_dodania, rok_do_dodania);
                            wydawnictwo.Get_dzialHandlowy().Stworz_pozycje(nowa, ilosc);
                            break;
                        default:
                            break;
                    }
                    return nowa;
                case 2:
                    string tytul_do_dodania2, czytaj2;
                    int numer_czasopisma2, wybor5;
                    Console.WriteLine("Podaj tytul");
                    tytul_do_dodania2 = Console.ReadLine();
                    Console.WriteLine("Podaj numer czasopisma");
                    czytaj2 = Console.ReadLine();
                    Int32.TryParse(czytaj2, out numer_czasopisma2);
                    int ilosc2;
                    Console.WriteLine("Podaj ilosc");
                    czytaj2 = Console.ReadLine();
                    Int32.TryParse(czytaj2, out ilosc2);
                    Console.WriteLine("Wybierz typ czasopisma:");
                    Console.WriteLine("0. Powrot");
                    Console.WriteLine("1. Czasopismo tygodnik");
                    Console.WriteLine("2. Czasopismo miesiecznik");
                    input = Console.ReadLine();
                    Int32.TryParse(input, out wybor5);
                    Pozycja nowa2 = null;
                    switch (wybor5)
                    {
                        case 0:
                            break;
                        case 1:
                            nowa2 = new CzasopismoTygodnik(tytul_do_dodania2, numer_czasopisma2);
                            wydawnictwo.Get_dzialHandlowy().Stworz_pozycje(nowa2, ilosc2);
                            break;
                        case 2:
                            nowa2 = new CzasopismoMiesiecznik(tytul_do_dodania2, numer_czasopisma2);
                            wydawnictwo.Get_dzialHandlowy().Stworz_pozycje(nowa2, ilosc2);
                            break;
                        default:
                            break;
                    }
                    return nowa2;
                default:
                    //przy podaniu nieprawidlowych danych
                    return null;
            }
        }
        static private Pozycja ZnajdzPozycje(Wydawnictwo wydawnictwo, string komunikat="Podaj nazwe czasopisma/ksiazki")
        {
            //int wybor;
            string input;
            Pozycja temp = null;
            //"Podaj nazwe ksiazki/czasopisma, ktore chcesz kupic"
            Console.WriteLine(komunikat);
            input = Console.ReadLine();
            temp = wydawnictwo.Get_dzialHandlowy().ZnajdzPozycje(input);
            return temp;
        }
        static private void SprzedajPozycje(Wydawnictwo wydawnictwo, Pozycja pozycja, string komunikat="Pomyslnie dokonano zakupu")
        {
            string input;
            int ilosc;
            Console.WriteLine("Podaj ilosc");
            input = Console.ReadLine();
            Int32.TryParse(input, out ilosc);
			wydawnictwo.Get_dzialHandlowy().Sprzedaj(pozycja, ilosc);
            //Pomyslnie zakupiono pozycje!
            Console.WriteLine(komunikat);
        }
        static private Autor ZnajdzAutora(Wydawnictwo wydawnictwo)
        {
            Autor temp = null;
            string input;
            Console.WriteLine("Podaj pesel autora");
            input = Console.ReadLine();
            try
            {
                temp = wydawnictwo.Get_dzialProgramowy().ZnajdzAutora(input);
            }
            catch (Exception e)
            {
                Console.WriteLine("Wystąpił błąd: '{0}'", e);
                temp = ZnajdzAutora(wydawnictwo);
            }
            return temp;
        }
        public static  void MainMenu(Wydawnictwo wydawnictwo)
        {
            int wybor;
            string input;
            Console.Clear();
            Console.WriteLine("Wybierz opcje\n");
            Console.WriteLine("0. Wyjscie z programu");
            Console.WriteLine("1. Dzial programowy");
            Console.WriteLine("2. Dzial handlowy");
            Console.WriteLine("3. Dzial druku");
            input = Console.ReadLine();
            Int32.TryParse(input, out wybor);
            switch (wybor)
            {
                case 0:
                    break;
                case 1:
                    ProgramowyMenu(wydawnictwo);
                    break;
                case 2:
                    HandlowyMenu(wydawnictwo);
                    break;
                case 3:
                    DrukuMenu(wydawnictwo);
                    break;
                default:
                    Console.WriteLine("Nieodpowiedni wybor");
                    break;
            }
        }
        public static void HandlowyMenu(Wydawnictwo wydawnictwo)
        {
            int wybor;
            string input;
            Console.Clear();
            Console.WriteLine("0. Powrot do menu glownego");
            Console.WriteLine("1. Sprzedaj pozycje"); //nie powinno być kup pozycje?
            Console.WriteLine("2. Wyswietl pozycje");
            Console.WriteLine("3. Zlecenie druku");
            input = Console.ReadLine();
            Int32.TryParse(input, out wybor);
            switch (wybor)
            {
                case 0:
                    MainMenu(wydawnictwo);
                    break;
                case 1:
                    {
						try
						{
							Pozycja temp = ZnajdzPozycje(wydawnictwo, "Podaj nazwe ksiazki/czasopisma");
							SprzedajPozycje(wydawnictwo, temp, "Zakup pomyslny");
						}
						catch (BrakPozycjiException bpe)
						{
							Console.WriteLine(bpe.Message);
							Console.WriteLine("\nAby kontunuowac nacisnij dowolny przycisk...");
                            Console.ReadKey();
						}
						catch (NieprawidlowaIloscException nie)
						{
							Console.WriteLine(nie.Message);
							if (nie.pozycja!=null)
							{
								nie.pozycja.Informacje();
								Console.WriteLine("W bazie znajduje się: "+nie.ilejestdostepnych);
								Console.WriteLine("Ilość w twoim zleceniu: " + nie.ilechcekupic);
								if(nie.ilejestdostepnych==0)
									Console.WriteLine("Pozycja obecnie nie jest dostępna w magazynie");
								else
									Console.WriteLine("Spróbuj ponownie podając ilość nie przekraczającą dostępność w magazynie");
								Console.WriteLine("\nAby kontunuowac nacisnij dowolny przycisk...");
                                Console.ReadKey();
							}
						}
						finally
						{
							HandlowyMenu(wydawnictwo);
						}
                        break;
                    }
                case 2:
                    {
                        wydawnictwo.Get_dzialHandlowy().WyswietlPozycje();
                        Console.WriteLine("\nAby kontunuowac nacisnij dowolny przycisk...");
                        Console.ReadKey();
                        HandlowyMenu(wydawnictwo);
                        break;
                    }
                case 3:
                    {
                        int wybor2;
                        Console.WriteLine("Drukuj:");
                        Console.WriteLine("0. Powrot");
                        Console.WriteLine("1. Znajdz czasopismo/ksiazke w bazie");
                        Console.WriteLine("2. Dodaj nowe czasopismo/ksiazke do bazy");
                        input = Console.ReadLine();
                        Int32.TryParse(input, out wybor2);
                        switch (wybor2)
                        {
                            case 0:
                                break;
                            case 1:
                                ZnajdzPozycje(wydawnictwo, "Podaj nazwe ksiazki/czasopisma");
                                break;
                            case 2:
                                DodajPozycje(wydawnictwo);
                                break;
                            default:
                                break;
                        }
                        break;
                    }
                default:
                    Console.WriteLine("Nieodpowiedni wybor");
                    break;
            }
        }
        static void ProgramowyMenu(Wydawnictwo wydawnictwo)
        {
            int wybor;
            string input;
            Console.Clear();
            Console.WriteLine("0. Powrot do menu glownego");
            Console.WriteLine("1. Dodaj autora");
            Console.WriteLine("2. Usun autora");
            Console.WriteLine("3. Znajdz autora");
            Console.WriteLine("4. Przeglad wszystkich autorow");
            Console.WriteLine("5. Dodaj umowe");
            Console.WriteLine("6. Rozwiaz umowe");
            Console.WriteLine("7. Przeglad umow dla autora\n");
            input = Console.ReadLine();
            Int32.TryParse(input, out wybor);
			string imie=null;
            string nazwisko=null;
            string pesel=null;
            switch (wybor)
            {
                case 0:
                    MainMenu(wydawnictwo);
                    break;
                case 1:
					
                    Console.WriteLine("Podaj imie: ");
                    imie = Console.ReadLine();
                    Console.WriteLine("Podaj nazwisko: ");
                    nazwisko = Console.ReadLine();
                    Console.WriteLine("Podaj pesel: ");
                    pesel = Console.ReadLine();
					try
					{
						Autor nowyautor = new Autor(imie, nazwisko, pesel);
						wydawnictwo.Get_dzialProgramowy().DodajAutora(nowyautor);
					}
					catch(AutorException ae)
					{
						Console.WriteLine(ae.Message);
						if(ae.autor!=null)
						{
							ae.autor.Informacje();
						}
						Console.WriteLine("\nAby kontunuowac nacisnij dowolny przycisk...");
						Console.ReadKey();
					}
					finally
					{
						ProgramowyMenu(wydawnictwo);
					}
					break;
				case 2:
                    Console.WriteLine("Podaj pesel autora którego chcesz usunąć: ");
                    pesel = Console.ReadLine();
					wydawnictwo.Get_dzialProgramowy().ZnajdzAutora(pesel);
                    break;
                case 3:
                    
                    break;
                case 4:
					wydawnictwo.Get_dzialProgramowy().PrzegladAutorow();
                    break;
                case 5:
                    throw new NotImplementedException();
                    break;
                case 6:
                    throw new NotImplementedException();
                    break;
                case 7:
                    throw new NotImplementedException();
                    break;
                default:
                    Console.WriteLine("Nieodpowiedni wybor");
                    break;
            }
        }
        static void DrukuMenu(Wydawnictwo wydawnictwo)
        {
            int wybor;
            string input;
            Console.Clear();
            Console.WriteLine("0. Powrot do menu glownego");
            Console.WriteLine("1. Zlecenie druku");
            input = Console.ReadLine();
            Int32.TryParse(input, out wybor);
            switch (wybor)
            {
                case 0:
                    MainMenu(wydawnictwo);
                    break;
                case 1:
                    throw new NotImplementedException();
                    break;
                default:
                    Console.WriteLine("Nieodpowiedni wybor");
                    break;
            }
        }
        static void Main(string[] args)
        {
            //Stworzenie wydawnictwa
            Wydawnictwo ePress = new Wydawnictwo(new DzialDruku(), new DzialHandlowy(), new DzialProgramowy());
            //Pozycja ksiazka1 = new CzasopismoTygodnik("Mleko", 1);
            //ePress.Get_dzialHandlowy().Set_pozycja(ksiazka1, 10);

            //Wczytaj dane

            //Zarzadzanie wydawnictwem
            MainMenu(ePress);

            //Zapisz dane

			/////Stworzenie autorow
			//DzialProgramowy programowy = ePress.Get_dzialProgramowy();
			//programowy.DodajAutora(new Autor("Jan", "Nowak", "87122113892"));
			//programowy.DodajAutora(new Autor("Anna", "Byk", "96112808085"));
			//programowy.DodajAutora(new Autor("Wojciech", "Krawczyk", "82062407876"));

			////Znalezienie autora po peselu
			//Autor mojUlubieny = programowy.ZnajdzAutora("87122113892");
			//Autor mojUlubieny2 = programowy.ZnajdzAutora("96112808085");
			//Autor mojUlubieny3 = programowy.ZnajdzAutora("82062407876");

   //         //Dodanie umow poprawnych/niepoprawnych
   //         Umowa jakas = new UmowaZlecenie(new CzasopismoMiesiecznik("Miesiecznik Mietka", 1));
			//programowy.DodajUmowe(mojUlubieny, new UmowaPraca(new DateTime(2018,6,1), new DateTime(2020,6,1)));
			//programowy.DodajUmowe(mojUlubieny, new UmowaZlecenie(new KsiazkaAlbum(mojUlubieny, "Ogniem i mieczem", 2018)));
   //         programowy.DodajUmowe(mojUlubieny, jakas);
			//programowy.DodajUmowe(mojUlubieny2, new UmowaDzielo(new DateTime(2018,6,01), new DateTime(2018, 5, 25), new KsiazkaRomans(mojUlubieny2, "Tytul 1", 2018)));
			//programowy.DodajUmowe(mojUlubieny3, new UmowaZlecenie(new KsiazkaAlbum(mojUlubieny3, "Album A", 2018)));

			////Przeglad wszystkich autorow
			//programowy.PrzegladAutorow();

			////Przeglad umow dla jednego autora
			//programowy.PrzegladUmow(mojUlubieny);

			////Rozwiazanie umowy istniejacej/nieistniejacej
			//programowy.RozwiazUmowe(jakas);

			////Usuniecie autora z listy
			//programowy.UsunAutora(mojUlubieny);

			////Usuniecie autora niebedacego na liscie/wywolanie null
			//Autor random = new Autor("J", "X", "111");
			////programowy.UsunAutora(random);
			////programowy.UsunAutora(null);

			////Autor a1 = new Autor("Jan", "Nowak", "111111111111");
			////Pozycja p1 = new Ksiazka(a1, "album", "Krzyzacy");
			/////Zatrudnienie a1
			////Umowa u1 = new Umowa("01.01.2016", "01.01.2022");
			////a1.DodajUmowe(u1);
			/////Zlecenie na konkretna pozycje dla a1
			////Pozycja p2 = new Ksiazka(a1, "romans", "Romeo");
			////Umowa u2 = new UmowaDzielo("01.05.2018", "14.05.2018", p1);
			////a1.DodajUmowe(u2);
			/////Wyswietlenie wszystkich umow dla autora a1
			////a1.PrzegladUmow();
			/////Stworzenie dzialu programowego
			/////Dodanie autora do dzialu
			////glowny.DodajAutora(a1);
			//Console.ReadKey();
        }
    }
}