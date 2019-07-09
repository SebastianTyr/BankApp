using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankModel;

namespace ConsoleAppBankModelTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BankManager bankManager = new BankManager();
            bankManager.Run();
        }
    }
}
