using System;
using System.Collections.Generic;
using System.Text;

namespace BankModel
{
    public class SavingAccount : Account
    {
        public SavingAccount(int id, string firstname, string lastname, long pesel)
            : base(id, firstname, lastname, pesel)
        {
        }

        public void AddInterest(decimal interest)
        {
            Balance += Balance * interest;
        }

        public override string AccountType()
        {
            return "Oszczędnościowe";
        }
    }
}
