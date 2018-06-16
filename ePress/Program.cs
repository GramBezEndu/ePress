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
        static private Pozycja DodajNowaPozycje(Wydawnictwo wydawnictwo)
        {
            string input;
            int wybor3;
            Console.WriteLine("Wybierz typ pozycji:");
            Console.WriteLine("0. Powrot");
            Console.WriteLine("1. Ksiazka");
            Console.WriteLine("2. Czasopismo");
            input = Console.ReadLine();
            if (!Int32.TryParse(input, out wybor3))
            {
                Console.WriteLine("Nieprawidlowy wybor");
                Console.ReadKey();
                return null;
            }
            switch (wybor3)
            {
                case 0:
                    return null;
                case 1:
                    Autor autor_do_dodania = ZnajdzAutora(wydawnictwo);
                    if (autor_do_dodania == null)
                    {
                        Console.WriteLine("Nieodpowiedni autor");
                        Console.ReadKey();
                        return null;
                    }
                    string tytul_do_dodania, czytaj;
                    int rok_do_dodania;
                    Console.WriteLine("Podaj tytul:");
                    tytul_do_dodania = Console.ReadLine();
                    Console.WriteLine("Podaj rok wydania:");
                    czytaj = Console.ReadLine();
                    if (!Int32.TryParse(czytaj, out rok_do_dodania))
                    {
                        Console.WriteLine("Nieprawidlowy rok");
                        Console.ReadKey();
                        return null;
                    }
                    int ilosc;
                    Console.WriteLine("Podaj ilosc");
                    czytaj = Console.ReadLine();
                    if(!Int32.TryParse(input, out ilosc))
                    {
                        Console.WriteLine("Nieprawidlowa ilosc");
                        Console.ReadKey();
                        return null;
                    }
                    int wybor4;
                    Console.WriteLine("Wybierz typ ksiazki:");
                    Console.WriteLine("0. Anuluj dodawanie ksiazki");
                    Console.WriteLine("1. Ksiazka album");
                    Console.WriteLine("2. Ksiazka romans");
                    Console.WriteLine("3. Ksiazka sensacyjna");
                    input = Console.ReadLine();
                    if(!Int32.TryParse(input, out wybor4))
                    {
                        Console.WriteLine("Nieprawidlowa ilosc");
                        Console.ReadKey();
                        return null;
                    }
                    Pozycja nowa = null;
                    switch (wybor4)
                    {
                        case 0:
                            break;
                        case 1:
                            nowa = new KsiazkaAlbum(autor_do_dodania, tytul_do_dodania, rok_do_dodania);
                            wydawnictwo.Get_dzialHandlowy().ZlecenieDruku(wydawnictwo.Get_dzialDruku(), nowa, ilosc);
                            break;
                        case 2:
                            nowa = new KsiazkaRomans(autor_do_dodania, tytul_do_dodania, rok_do_dodania);
                            wydawnictwo.Get_dzialHandlowy().ZlecenieDruku(wydawnictwo.Get_dzialDruku(), nowa, ilosc);
                            break;
                        case 3:
                            nowa = new KsiazkaSensacyjna(autor_do_dodania, tytul_do_dodania, rok_do_dodania);
                            wydawnictwo.Get_dzialHandlowy().ZlecenieDruku(wydawnictwo.Get_dzialDruku(), nowa, ilosc);
                            break;
                        default:
                            Console.WriteLine("Niepoprawny wybor");
                            Console.ReadKey();
                            return null;
                    }
                    return nowa;
                case 2:
                    string tytul_do_dodania2, czytaj2;
                    int numer_czasopisma2, wybor5;
                    Console.WriteLine("Podaj tytul");
                    tytul_do_dodania2 = Console.ReadLine();
                    Console.WriteLine("Podaj numer czasopisma");
                    czytaj2 = Console.ReadLine();
                    if (!Int32.TryParse(czytaj2, out numer_czasopisma2))
                    {
                        Console.WriteLine("Nieprawidlowy numer czasopisma");
                        Console.ReadKey();
                        return null;
                    }
                    int ilosc2;
                    Console.WriteLine("Podaj ilosc");
                    czytaj2 = Console.ReadLine();
                    if (!Int32.TryParse(czytaj2, out ilosc2))
                    {
                        Console.WriteLine("Niepoprawna ilosc");
                        Console.ReadKey();
                        return null;
                    }
                    Console.WriteLine("Wybierz typ czasopisma:");
                    Console.WriteLine("0. Anuluj dodawanie czasopisma");
                    Console.WriteLine("1. Czasopismo tygodnik");
                    Console.WriteLine("2. Czasopismo miesiecznik");
                    input = Console.ReadLine();
                    if (!Int32.TryParse(input, out wybor5))
                    {
                        Console.WriteLine("Nieprawidlowy wybor");
                        Console.ReadKey();
                        return null;
                    }
                    Pozycja nowa2 = null;
                    switch (wybor5)
                    {
                        case 0:
                            break;
                        case 1:
                            nowa2 = new CzasopismoTygodnik(tytul_do_dodania2, numer_czasopisma2);
                            wydawnictwo.Get_dzialHandlowy().ZlecenieDruku(wydawnictwo.Get_dzialDruku(), nowa2, ilosc2);
                            break;
                        case 2:
                            nowa2 = new CzasopismoMiesiecznik(tytul_do_dodania2, numer_czasopisma2);
                            wydawnictwo.Get_dzialHandlowy().ZlecenieDruku(wydawnictwo.Get_dzialDruku(), nowa2, ilosc2);
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
        static private Pozycja ZnajdzPozycje(Wydawnictwo wydawnictwo, string komunikat = "Podaj nazwe czasopisma/ksiazki")
        {
            //int wybor;
            string input;
            Pozycja temp = null;
            //"Podaj nazwe ksiazki/czasopisma"
            Console.WriteLine(komunikat);
            input = Console.ReadLine();
            temp = wydawnictwo.Get_dzialHandlowy().ZnajdzPozycje(input);
            return temp;
        }
        static private void SprzedajPozycje(Wydawnictwo wydawnictwo, Pozycja pozycja, string komunikat = "Pomyslnie dokonano zakupu")
        {
            string input;
            int ilosc;
            Console.WriteLine("Podaj ilosc");
            input = Console.ReadLine();
            if (!Int32.TryParse(input, out ilosc))
            {
                Console.WriteLine("Nieprawidlowa ilosc");
                Console.ReadKey();
                return;
            }
            wydawnictwo.Get_dzialHandlowy().Sprzedaj(pozycja, ilosc);
            //Pomyslnie zakupiono pozycje!
            Console.WriteLine(komunikat);
        }
        static private void HandlowySprzedajPozycje(Wydawnictwo wydawnictwo)
        {
            try
            {
                Pozycja temp = ZnajdzPozycje(wydawnictwo, "Podaj nazwe ksiazki/czasopisma");
                SprzedajPozycje(wydawnictwo, temp, "Zakup pomyslny");
                Console.ReadKey();
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
                if (nie.pozycja != null)
                {
                    nie.pozycja.Informacje();
                    Console.WriteLine("W bazie znajduje się: " + nie.ilejestdostepnych);
                    Console.WriteLine("Ilość w twoim zleceniu: " + nie.ilechcekupic);
                    if (nie.ilejestdostepnych == 0)
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
        }
        /// <summary>
        /// Zwraca null jesli nie znaleziono autora
        /// </summary>
        /// <param name="wydawnictwo"></param>
        /// <returns></returns>
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
            catch (Exception)
            {
                Console.WriteLine("Wystąpił błąd: Nie znaleziono autora");
                Console.ReadKey();
                //temp = ZnajdzAutora(wydawnictwo);
            }
            return temp;
        }
        public static void MainMenu(Wydawnictwo wydawnictwo)
        {
            int wybor;
            string input;
            Console.Clear();
            Console.WriteLine("Wybierz opcje\n");
            Console.WriteLine("0. Wyjscie z programu");
            Console.WriteLine("1. Dzial programowy");
            Console.WriteLine("2. Dzial handlowy");
            input = Console.ReadLine();
            if(Int32.TryParse(input, out wybor))
            {
                switch (wybor)
                {
                    case 0:
                        break;
                    case 1:
                        ProgramowyMenu(wydawnictwo, null);
                        break;
                    case 2:
                        HandlowyMenu(wydawnictwo);
                        break;
                    default:
                        Console.WriteLine("Nieodpowiedni wybor");
                        Console.ReadKey();
                        MainMenu(wydawnictwo);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Nieodpowiedni wybor");
                Console.ReadKey();
                MainMenu(wydawnictwo);
            }
        }
        public static void HandlowyMenu(Wydawnictwo wydawnictwo)
        {
            int wybor;
            string input;
            Console.Clear();
            Console.WriteLine("0. Powrot do menu glownego");
            Console.WriteLine("1. Sprzedaj/kup pozycje");
            Console.WriteLine("2. Wyswietl pozycje");
            Console.WriteLine("3. Zlecenie druku");
            input = Console.ReadLine();
            if (!Int32.TryParse(input, out wybor))
            {
                Console.WriteLine("Nieprawidlowy wybor");
                Console.ReadKey();
                MainMenu(wydawnictwo);
                return;
            }
            switch(wybor)
            {
                case 0:
                    MainMenu(wydawnictwo);
                    return;
                case 1:
                    {
                        HandlowySprzedajPozycje(wydawnictwo);
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
                        if (!Int32.TryParse(input, out wybor2))
                        {
                            Console.WriteLine("Nieprawidlowy wybor");
                            Console.ReadKey();
                            MainMenu(wydawnictwo);
                            return;
                        }
                        switch (wybor2)
                        {
                            case 0:
                                HandlowyMenu(wydawnictwo);
                                return;
                            case 1:
                                try
                                {
                                    Pozycja temp = ZnajdzPozycje(wydawnictwo, "Podaj nazwe ksiazki/czasopisma");
                                    Console.WriteLine("Podaj ilosc");
                                    string czytaj = Console.ReadLine();
                                    int ilosc;
                                    if (!Int32.TryParse(czytaj, out ilosc))
                                    {
                                        Console.WriteLine("Niepoprawna ilosc");
                                        MainMenu(wydawnictwo);
                                        return;
                                    }
                                    wydawnictwo.Get_dzialHandlowy().ZlecenieDruku(wydawnictwo.Get_dzialDruku(), temp, ilosc);
                                }
                                catch(Exception)
                                {
                                    Console.WriteLine("Nie znaleziono ksiazki/czasopisma");
                                    Console.ReadKey();
                                }
                                HandlowyMenu(wydawnictwo);
                                return;
                            case 2:
                                DodajNowaPozycje(wydawnictwo);
                                HandlowyMenu(wydawnictwo);
                                return;
                            default:
                                Console.WriteLine("Nieprawidlowy wybor");
                                Console.ReadKey();
                                HandlowyMenu(wydawnictwo);
                                return;
                        }
                        break;
                    }
                default:
                    Console.WriteLine("Nieodpowiedni wybor");
                    Console.ReadKey();
                    break;
            }
        }
        static void ProgramowyMenu(Wydawnictwo wydawnictwo, Autor wybranyautor)
        {
            int wybor;
            string input;
            Autor autor = wybranyautor;
            Console.Clear();
            Console.WriteLine("0. Powrot do menu glownego");
            Console.WriteLine("1. Dodaj autora");
            Console.WriteLine("2. Usun autora");
            Console.WriteLine("3. Znajdz autora");
            Console.WriteLine("4. Przeglad wszystkich autorow");
            Console.WriteLine("5. Dodaj umowe");
            Console.WriteLine("6. Rozwiaz umowe");
            Console.WriteLine("7. Przeglad umow dla autora\n");
            Console.WriteLine("Obecnie wybrany autor:");
            if (autor == null)
            {
                Console.WriteLine("Nie wybrano autora\n");
            }
            else
                autor.Informacje();
            Console.WriteLine("Wybierz opcje:");
            input = Console.ReadLine();
            Int32.TryParse(input, out wybor);
            string imie = null;
            string nazwisko = null;
            string pesel = null;
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
                    catch (AutorException ae)
                    {
                        Console.WriteLine(ae.Message);
                        if (ae.autor != null)
                        {
                            ae.autor.Informacje();
                        }
                        Console.WriteLine("\nAby kontunuowac nacisnij dowolny przycisk...");
                        Console.ReadKey();
                    }
                    finally
                    {
                        ProgramowyMenu(wydawnictwo, autor);
                    }
                    break;
                case 2:
                    if (autor == null)
                    {
                        Console.WriteLine("Nie wybrano żadnego autora");
						Console.WriteLine("\nAby kontunuowac nacisnij dowolny przycisk...");
                        Console.ReadKey();
                        ProgramowyMenu(wydawnictwo, autor);
                    }
                    try
                    {
                        wydawnictwo.Get_dzialProgramowy().UsunAutora(autor);
                    }
                    catch (AutorException ae)
                    {
                        Console.WriteLine(ae.Message);
                        Console.WriteLine("\nAby kontunuowac nacisnij dowolny przycisk...");
                        Console.ReadKey();
                    }
                    finally
                    {
						//nie ma autora, wiec ponownie trzeba wybrac autora
                        ProgramowyMenu(wydawnictwo, null);
                    }
                    break;
                case 3:
                    try
                    {
                        autor = ZnajdzAutora(wydawnictwo);
                    }
                    catch (AutorException ae)
                    {
                        Console.WriteLine(ae.Message);
                        Console.WriteLine("\nAby kontunuowac nacisnij dowolny przycisk...");
                        Console.ReadKey();
                    }
                    finally
                    {
                        ProgramowyMenu(wydawnictwo, autor);
                    }
                    break;
                case 4:
                    wydawnictwo.Get_dzialProgramowy().PrzegladAutorow();
                    Console.WriteLine("\nAby kontunuowac nacisnij dowolny przycisk...");
                    Console.ReadKey();
                    ProgramowyMenu(wydawnictwo, autor);
                    break;
                case 5:
					if (autor == null)
                    {
                        Console.WriteLine("Nie wybrano żadnego autora");
						Console.WriteLine("\nAby kontunuowac nacisnij dowolny przycisk...");
                        Console.ReadKey();
                        ProgramowyMenu(wydawnictwo, autor);
                    }
					string rodzajumowy;
                    int wyborumowy;
					DateTime datarozpoczecia=new DateTime();
					DateTime datazakonczenia=new DateTime();
					string data;

                    Console.WriteLine("Wybierz typ umowy:");
                    Console.WriteLine("0. Powrot");
                    Console.WriteLine("1. Umowa o prace");
                    Console.WriteLine("2. Umowa o dzielo");
					Console.WriteLine("3. Umowa zlecenie");
                    rodzajumowy = Console.ReadLine();
                    Int32.TryParse(rodzajumowy, out wyborumowy);
					switch (wyborumowy){
						case 0:
							ProgramowyMenu(wydawnictwo, autor);
							break;
						case 1:
							try
							{
								Console.WriteLine("Podaj date rozpoczecia: yyyy-mm-dd");
								data = Console.ReadLine();
								datarozpoczecia = DateTime.Parse(data);
								Console.WriteLine("Podaj date zakonczenia: yyyy-mm-dd");
                                data = Console.ReadLine();
								datazakonczenia = DateTime.Parse(data);
								UmowaPraca umowaPraca = new UmowaPraca(datarozpoczecia, datazakonczenia);
								wydawnictwo.Get_dzialProgramowy().DodajUmowe(autor, umowaPraca);
							}
                            catch(FormatException)
                            {
								Console.WriteLine("Nie udalo sie przekonwertowac dat.");
								Console.WriteLine("\nAby kontunuowac nacisnij dowolny przycisk...");
								Console.ReadKey();
                            }
							catch(AutorException ae)
							{
								Console.WriteLine(ae.Message);
                                if (ae.autor != null)
                                {
                                    ae.autor.Informacje();
                                }
                                Console.WriteLine("\nAby kontunuowac nacisnij dowolny przycisk...");
                                Console.ReadKey();
							}
							finally
							{
								ProgramowyMenu(wydawnictwo, autor);
							}
							break;
						case 2://dodajpozycje wszystkie wyjatki
							try
                            {
                                Console.WriteLine("Podaj date rozpoczecia: yyyy-mm-dd");
                                data = Console.ReadLine();
                                datarozpoczecia = DateTime.Parse(data);
                                Console.WriteLine("Podaj date zakonczenia: yyyy-mm-dd");
                                data = Console.ReadLine();
                                datazakonczenia = DateTime.Parse(data);
								Console.WriteLine("Musisz dodac pozycje");
								//Pozycja pozycja = DodajPozycje(wydawnictwo);
								//UmowaDzielo umowaDzielo = new UmowaDzielo(datarozpoczecia, datazakonczenia,pozycja);
                                //wydawnictwo.Get_dzialProgramowy().DodajUmowe(autor, umowaDzielo);
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Nie udalo sie przekonwertowac dat.");
                                Console.WriteLine("\nAby kontunuowac nacisnij dowolny przycisk...");
                                Console.ReadKey();
                            }
                            catch (AutorException ae)
                            {
                                Console.WriteLine(ae.Message);
                                if (ae.autor != null)
                                {
                                    ae.autor.Informacje();
                                }
                                Console.WriteLine("\nAby kontunuowac nacisnij dowolny przycisk...");
                                Console.ReadKey();
                            }
                            finally
                            {
                                ProgramowyMenu(wydawnictwo, autor);
                            }
							break;
						case 3: //problematyczne
							try
                            {
                               
                                Console.WriteLine("Musisz dodac pozycje");
                               /* Pozycja pozycja = DodajPozycje(wydawnictwo);
                                UmowaDzielo umowaDzielo = new UmowaDzielo(datarozpoczecia, datazakonczenia, pozycja);
                                wydawnictwo.Get_dzialProgramowy().DodajUmowe(autor, umowaDzielo);*/
                            }
                            catch (AutorException ae)
                            {
                                Console.WriteLine(ae.Message);
                                if (ae.autor != null)
                                {
                                    ae.autor.Informacje();
                                }
                                Console.WriteLine("\nAby kontunuowac nacisnij dowolny przycisk...");
                                Console.ReadKey();
                            }
                            finally
                            {
                                ProgramowyMenu(wydawnictwo, autor);
                            }
							break;
					}
                    break;
                case 6:
					if (autor == null)
                    {
                        Console.WriteLine("Nie wybrano żadnego autora");
                        ProgramowyMenu(wydawnictwo, autor);
                    }
					wydawnictwo.Get_dzialProgramowy().PrzegladUmow(autor);
					Console.WriteLine("Podaj nr umowy do usuniecia");
					int nrumowy;
					string umowa;
					Umowa umowadousuniecia;
                    umowa = Console.ReadLine();
					if(Int32.TryParse(umowa, out nrumowy))
					{
						try
						{
							umowadousuniecia = wydawnictwo.Get_dzialProgramowy().GetUmowa(autor, nrumowy);
                            wydawnictwo.Get_dzialProgramowy().RozwiazUmowe(umowadousuniecia);
						}
						catch(UmowaException ue)
						{
							Console.WriteLine(ue.Message);
							if(ue.autorzwiazanyumowa!=null)
							{
								ue.autorzwiazanyumowa.Informacje();
								foreach (Umowa umowyautora in ue.lista_umow_autora)
                                    umowyautora.Informacje();
							}

						}
						finally
						{
							ProgramowyMenu(wydawnictwo, autor);
						}

					}

                    break;
                case 7:
                    if (autor == null)
                    {
                        Console.WriteLine("Nie wybrano żadnego autora");
                        ProgramowyMenu(wydawnictwo, autor);
                    }
                    wydawnictwo.Get_dzialProgramowy().PrzegladUmow(autor);
                    Console.ReadKey();
                    ProgramowyMenu(wydawnictwo, autor);
                    break;
                default:
                    Console.WriteLine("Nieodpowiedni wybor");
                    Console.ReadKey();
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