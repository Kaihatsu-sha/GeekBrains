using System;
using System.IO;

namespace BasicOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //AccountTest();
            //StringTest();
            BuildingTest();
        }

        static void AccountTest()
        {
            Account account = new Account(AccountTypeEnum.Credit);

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

            account = new Account(99, AccountTypeEnum.Credit);

            Console.WriteLine($"Номер счета:{account.Number}\nТип счета:{account.Type}\nБаланс:{account.Balance}");
            Console.ReadKey();
            amount = 10;
            Console.WriteLine($"Снятие со счета на {amount}");
            account.Withdraw(amount);
            Console.WriteLine($"Номер счета:{account.Number}\nТип счета:{account.Type}\nБаланс:{account.Balance}");
            Console.ReadKey();

            Account account2 = new Account(100, AccountTypeEnum.Credit);
            Console.WriteLine($"Номер счета:{account2.Number}\nТип счета:{account2.Type}\nБаланс:{account2.Balance}");
            Console.ReadKey();
            Console.WriteLine($"Номер счета:{account.Number}\nТип счета:{account.Type}\nБаланс:{account.Balance}");
            Console.WriteLine($"Перевод на счет {account.Number} сумма {amount}");
            account.TransferFromAccount(account2, amount);
            Console.WriteLine($"Номер счета:{account.Number}\nТип счета:{account.Type}\nБаланс:{account.Balance}");
            Console.WriteLine($"Номер счета:{account2.Number}\nТип счета:{account2.Type}\nБаланс:{account2.Balance}");
            Console.ReadKey();
        }

        static void StringTest()
        {
            string example = "";
            //example = "examPle";
            //example = StringUtils.RevertString(example);
            //Console.WriteLine(example);

            example = StringUtils.SearchMailsFromFile(@"C:\Users\User\Desktop\note.txt", '&');
            StringUtils.WriteMailsToFile(@"C:\Users\User\Desktop\notes.txt", example);
            Console.WriteLine(example);


            Console.ReadKey();
        }

        static void BuildingTest()
        {
            Building buildingA = new Building("Парковка");
            Console.WriteLine(buildingA);

            Building buildingB = new Building("Башня Старка", 99, 14, 4, 3.0);
            Console.WriteLine(buildingB);

            Building buildingC = Creator.CreateBuild();
            Console.WriteLine(buildingC);
            Creator.DestroyBuilding(buildingC.BuildingNumber);

            Building buildingD = Creator.CreateBuild("Simple building");
            Console.WriteLine(buildingC);
            //
        }

    }
}
