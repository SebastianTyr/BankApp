using System;

namespace BankModel
{
    /// <summary>
    /// Podstawowy model funkcjonalności potrzebny do stworzenia aplikacji bankowej
    /// </summary>
    public abstract class Account
    {
        public int ID { get; }
        public string AccountNumber { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public long Pesel { get; }
        public decimal Balance { get; protected set; }

        public Account(int id, string firstname, string lastname, long pesel)
        {
            ID = id;
            AccountNumber = GenerateAccountNumber(id);
            Balance = 0.0M;
            FirstName = firstname;
            LastName = lastname;
            Pesel = pesel;
        }

        public string GetFullName()
        {
            return string.Format($"{FirstName} {LastName}");
        }

        public string GetBalance()
        {
            return string.Format($"{Balance}zł");
        }

        public abstract string AccountType();

        public string GenerateAccountNumber(int id)
        {
            return string.Format("71{0:D10}", id);
        }

        public void ChangeBalance(decimal value)
        {
            Balance += value;
        }
    }
}
