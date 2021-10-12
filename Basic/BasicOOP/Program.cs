using System;

namespace BasicOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account account= new Account(AccountTypeEnum.Credit);

            Console.WriteLine($"Номер счета:{account.GetAccountNumber()}\nТип счета:{account.GetAccountType()}\nБаланс:{account.GetAccountBalance()}");
            Console.ReadKey();

            account = new Account(101);

            Console.WriteLine($"Номер счета:{account.GetAccountNumber()}\nТип счета:{account.GetAccountType()}\nБаланс:{account.GetAccountBalance()}");
            Console.ReadKey();

            account = new Account(99,AccountTypeEnum.Credit);

            Console.WriteLine($"Номер счета:{account.GetAccountNumber()}\nТип счета:{account.GetAccountType()}\nБаланс:{account.GetAccountBalance()}");
            Console.ReadKey();
        }
    }
}
