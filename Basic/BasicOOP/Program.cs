using System;

namespace BasicOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account account= new Account(AccountTypeEnum.Credit);

            Console.WriteLine($"Номер счета:{account.Number}\nТип счета:{account.Type}\nБаланс:{account.Balance}");
            Console.ReadKey();
            double amount = 100;
            Console.WriteLine($"Пополение счета на {amount}");
            account.Replenish(amount);
            Console.WriteLine($"Номер счета:{account.Number}\nТип счета:{account.Type}\nБаланс:{account.Balance}");
            Console.ReadKey();

            account = new Account(101);

            Console.WriteLine($"Номер счета:{account.Number}\nТип счета:{account.Type}\nБаланс:{account.Balance}");
            Console.ReadKey();
            amount = 101;
            Console.WriteLine($"Снятие со счета на {amount}");
            account.Withdraw(amount);
            Console.WriteLine($"Номер счета:{account.Number}\nТип счета:{account.Type}\nБаланс:{account.Balance}");
            Console.ReadKey();

            account = new Account(99,AccountTypeEnum.Credit);

            Console.WriteLine($"Номер счета:{account.Number}\nТип счета:{account.Type}\nБаланс:{account.Balance}");
            Console.ReadKey();
            amount = 100;
            Console.WriteLine($"Снятие со счета на {amount}");
            account.Withdraw(amount);
            Console.WriteLine($"Номер счета:{account.Number}\nТип счета:{account.Type}\nБаланс:{account.Balance}");
            Console.ReadKey();
        }
    }
}
