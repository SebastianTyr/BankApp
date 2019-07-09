using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankModel
{
    public class AccountsManager
    {
        private IList<Account> accounts;

        //Konstruktor klasy
        public AccountsManager()
        {
            accounts = new List<Account>();
        }

        //Generujemy ID konta i zwiększamy o 1
        private int GenerateID()
        {
            int id = 1;

            if (accounts.Any())
                id = accounts.Max(x => x.ID) + 1;
            return id;
        }

        //Metody tworzące konta
        public SavingAccount CreateSavingAccount (string firstname, string lastname, long pesel)
        {
            int id = GenerateID();

            SavingAccount savingAccount = new SavingAccount(id, firstname, lastname, pesel);

            accounts.Add(savingAccount);

            return savingAccount;
        }

        public BillingAccount CreateBillingAccount(string firstname, string lastname, long pesel)
        {
            int id = GenerateID();
            BillingAccount billingAccount = new BillingAccount(id, firstname, lastname, pesel);

            accounts.Add(billingAccount);

            return billingAccount;
        }

        //Wybieramy i zwracamy wszystkie konta z listy
        public IEnumerable<Account> GetAllAccounts()
        {
            return accounts;
        }

        //Wybieramy i zwracamy wszystkie konta należące do dnaego klienta
        public IEnumerable<Account> GetAllAccountsFor(string firstname, string lastname, long pesel)
        {
            return accounts.Where(x => x.FirstName == firstname && x.LastName == lastname && x.Pesel == pesel);
        }

        //Wybieramy i zwracamy konto o podanym numerze
        public Account GetAccount (string accountNo)
        {
            return accounts.Single(x => x.AccountNumber == accountNo);
        }

        //Tworzymy liste klientów
        public IEnumerable<string> ListOfClients()
        {
            return accounts.Select(x => string.Format($"Imie: {x.FirstName} | Nazwisko: {x.LastName} | PESEL: {x.Pesel}"));
        }

        //Zamknięcie miesiąca
        public void CloseMonth()
        {
            foreach (SavingAccount account in accounts.Where(x => x is SavingAccount))
                account.AddInterest(0.04M);
            foreach (BillingAccount account in accounts.Where(x => x is BillingAccount))
                account.TakeCharge(5.0M);
        }

        //Wpłata i wypłata gotówki
        public void AddMoney(string accountNo, decimal value)
        {
            Account account = GetAccount(accountNo);
            account.ChangeBalance(value);
        }

        public void TakeMoney(string accountNo, decimal value)
        {
            Account account = GetAccount(accountNo);
            account.ChangeBalance(-value);
        }
    }
}
