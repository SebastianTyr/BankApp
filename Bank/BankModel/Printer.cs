using System;
using System.Collections.Generic;
using System.Text;

namespace BankModel
{
    public class Printer : IPrinter
    {
        public void Print(Account account)
        {
            Console.WriteLine($"Dane konta: {account.AccountNumber}");
            Console.WriteLine($"Typ konta: {account.AccountType()}");
            Console.WriteLine($"Saldo konta: {account.GetBalance()}");
            Console.WriteLine($"Imie i nazwisko właściciela: {account.GetFullName()}");
            Console.WriteLine($"PESEL {account.Pesel}");
            Console.WriteLine();
        }
    }
}
