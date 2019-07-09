using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankModel;

namespace ConsoleAppBankModelTest
{
    class BankManager
    {
        private AccountsManager _accountsManager;
        private IPrinter _printer;

        //Tworzymy zmienne managera kont i drukarki i generujemy ich obiekty w konstruktorze
        public BankManager()
        {
            _accountsManager = new AccountsManager();
            _printer = new Printer();
        }

        //Dodajemy drukowanie menu
        private void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Wybierz akcję:");
            Console.WriteLine("1 - Lista kont klienta");
            Console.WriteLine("2 - Dodaj konto rozliczeniowe");
            Console.WriteLine("3 - Dodaj konto oszczędnościowe");
            Console.WriteLine("4 - Wpłać pieniądze na konto");
            Console.WriteLine("5 - Wypłać pieniądze z konta");
            Console.WriteLine("6 - Lista klientów");
            Console.WriteLine("7 - Wszystkie konta");
            Console.WriteLine("8 - Zamknij miesiąc");
            Console.WriteLine("0 - Zakończ");
        }

        //Metoda 'Run' uruchamia bank
        public void Run()
        {
            int action;

            do
            {
                PrintMainMenu();
                action = SelectedAction();

                switch (action)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("Wybrano wszystkie konta klienta");
                            Console.ReadKey();
                            ListOfAccounts();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("Wybrano otwarcie konta rozliczeniowego");
                            Console.ReadKey();
                            AddBillingAccount();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("Wybrano otwarcie konta oszczędnościowego");
                            Console.ReadKey();
                            AddSavingAccount();
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("Wybrano wpłatę gotówki na konto");
                            Console.ReadKey();
                            AddMoney();
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            Console.WriteLine("Wybrano wypłatę gotówki z konta");
                            Console.ReadKey();
                            TakeMoney();
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            Console.WriteLine("Wybrano listę klientow");
                            Console.ReadKey();
                            AllClients();
                            break;
                        }
                    case 7:
                        {
                            Console.Clear();
                            Console.WriteLine("Wybrano wszystkie konta");
                            Console.ReadKey();
                            AllAccounts();
                            break;
                        }
                    case 8:
                        {
                            Console.Clear();
                            Console.WriteLine("Wybrano zamknięcie miesiąca");
                            Console.ReadKey();
                            CloseMonth();
                            break;
                        }
                    case 0:
                        {
                            Console.Clear();
                            Console.WriteLine("Koniec");
                            break;
                        }
                    default:
                        break;
                }
            } while (action != 0);
        }

        //Odczytujemy wybór użytkownika
        private int SelectedAction()
        {
            Console.Write("Akcja: ");
            string action = Console.ReadLine();

            if (string.IsNullOrEmpty(action))
            {
                return -1;
            }
            try
            {
                return int.Parse(action);
            }
            catch (FormatException)
            {
                return -1;
            }
            catch (OverflowException)
            {
                return -1;
            }
        }

        // Odczytanie danych podanych przez klienta
        private CustomerData ReadCustomerData()
        {
            string firstName;
            string lastName;
            string pesel;
            Console.WriteLine("Podaj dane klienta");
            Console.Write("Imie: ");
            firstName = Console.ReadLine();
            Console.Write("Nazwisko: ");
            lastName = Console.ReadLine();
            Console.Write("PESEL: ");
            pesel = Console.ReadLine();
            Console.WriteLine();

            return new CustomerData(firstName, lastName, pesel);
        }

        // ---- AKCJE ----
        // 1.Lista kont klienta
        private void ListOfAccounts()
        {
            Console.Clear();
            CustomerData data = ReadCustomerData();
            Console.WriteLine();
            Console.WriteLine("Konta klienta: {0} {1} {2}", data.FirstName, data.LastName, data.Pesel);

            foreach (Account account in _accountsManager.GetAllAccountsFor(data.FirstName, data.LastName, data.Pesel))
            {
                _printer.Print(account);
            }
            Console.ReadKey();
        }

        // 2.Nowe konto rozliczeniowe
        private void AddBillingAccount()
        {
            Console.Clear();
            CustomerData data = ReadCustomerData();
            Account billingaccount = _accountsManager.CreateBillingAccount(data.FirstName, data.LastName, data.Pesel);

            Console.WriteLine("Utworzono konto rozliczeniowe:");
            Console.WriteLine();
            _printer.Print(billingaccount);

            Console.ReadKey();
        }

        // 3.Nowe konto oszczędnościowe
        private void AddSavingAccount()
        {
            Console.Clear();
            CustomerData data = ReadCustomerData();
            Account savingaccount = _accountsManager.CreateSavingAccount(data.FirstName, data.LastName, data.Pesel);

            Console.WriteLine("Utworzono konto oszczednosciowe:");
            Console.WriteLine();
            _printer.Print(savingaccount);

            Console.ReadKey();
        }

        // 4.Wpłata gotówki na konto
        private void AddMoney()
        {
            string accountNo;
            decimal value;

            Console.Clear();
            Console.WriteLine("Wpłata pieniędzy");
            Console.WriteLine();
            Console.Write("Podaj numer konta: ");
            accountNo = Console.ReadLine();
            Console.Write("Podaj kwote wpłaty: ");
            value = decimal.Parse(Console.ReadLine());
            Console.WriteLine();

            _accountsManager.AddMoney(accountNo, value);
            Account account = _accountsManager.GetAccount(accountNo);
            _printer.Print(account);

            Console.ReadKey();
        }

        // 5.Wypłata gotówki z konta
        private void TakeMoney()
        {
            string accountNo;
            decimal value;

            Console.Clear();
            Console.WriteLine("Wypłata pieniędzy");
            Console.WriteLine();
            Console.Write("Podaj numer konta: ");
            accountNo = Console.ReadLine();
            Console.Write("Podaj kwote wypłaty: ");
            value = decimal.Parse(Console.ReadLine());
            Console.WriteLine();

            _accountsManager.TakeMoney(accountNo, value);
            Account account = _accountsManager.GetAccount(accountNo);
            _printer.Print(account);

            Console.ReadKey();
        }

        // 6.Lista klientów
        private void AllClients()
        {
            Console.Clear();
            Console.WriteLine("Lista klientów");
            Console.WriteLine();

            foreach (string customers in _accountsManager.ListOfClients())
            {
                Console.WriteLine(customers);
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        // 7.Wszystkie konta
        private void AllAccounts()
        {
            Console.Clear();
            Console.WriteLine("Wszystkie konta");
            Console.WriteLine();

            foreach (Account accounts in _accountsManager.GetAllAccounts())
            {
                _printer.Print(accounts);
            }

            Console.ReadKey();
        }

        // 8.Zamkniecie miesiaca
        private void CloseMonth()
        {
            Console.Clear();
            _accountsManager.CloseMonth();
            Console.WriteLine("Miesiąc zamknięty");
            Console.ReadKey();
        }
    }

    class CustomerData
    {
        public string FirstName { get; }
        public string LastName { get; }
        public long Pesel { get; }

        public CustomerData(string firstName, string lastName, string pesel)
        {
            FirstName = firstName;
            LastName = lastName;
            Pesel = long.Parse(pesel);
        }
    }

}