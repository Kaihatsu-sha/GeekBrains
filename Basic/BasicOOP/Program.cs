using System;

namespace BasicOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account account= new Account();
            account.SetAccountNumber();
            account.SetAccountBalance(100);
            account.SetAccountType(AccountTypeEnum.Debit);

            Console.WriteLine($"Номер счета:{account.GetAccountNumber()}\nТип счета:{account.GetAccountType()}\nБаланс:{account.GetAccountBalance()}");
            Console.Read();

            account = new Account();
            account.SetAccountNumber();
            account.SetAccountBalance(99);
            account.SetAccountType(AccountTypeEnum.Credit);

            Console.WriteLine($"Номер счета:{account.GetAccountNumber()}\nТип счета:{account.GetAccountType()}\nБаланс:{account.GetAccountBalance()}");
            Console.Read();
        }
    }
}
