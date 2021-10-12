using System;

namespace BasicOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account account= new Account();
            account.SetAccountNumber(1);
            account.SetAccountBalance(100);
            account.SetAccountType(AccountTypeEnum.Debit);

            Console.WriteLine($"Номер счета:{account.GetAccountNumber()}\nТип счета:{account.GetAccountType()}\nБаланс:{account.GetAccountBalance()}");
            Console.Read();
        }
    }
}
