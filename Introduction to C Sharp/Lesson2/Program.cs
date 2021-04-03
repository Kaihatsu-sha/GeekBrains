using System;

namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            GettingAverageDailyTemperature();
            GettingMonthByNumber();
            DeterminingParityOfNumber();
            CheckPrinting();
            Plus();
            PlusPlus();

            Console.ReadKey();
        }

        static float averageTemperature = 0.0f;
        static int monthNumber;
        static void GettingAverageDailyTemperature()
        {
            Console.WriteLine("Вычисление среднесуточной температуры.\nПожалуйста введите минимальную и максимальную температуры за сутки в формате хх,х");

            bool correctInput = false;
            float minTemperature = 0.0f;
            do
            {
                Console.WriteLine("Пожалуйста, введите минимальную температуру:");
                string minTem = Console.ReadLine();
                correctInput = float.TryParse(minTem, out minTemperature);
            } while (!correctInput);

            correctInput = false;
            float maxTemperature = 0.0f;
            do
            {
                Console.WriteLine("Пожалуйста, введите максимальную температуру:");
                string maxTem = Console.ReadLine();
                correctInput = float.TryParse(maxTem, out maxTemperature);
            } while (!correctInput);

            averageTemperature = (minTemperature + maxTemperature) / 2;

            Console.WriteLine($"Среднесуточная температура составила: {averageTemperature.ToString("0.0")}");
        }

        static void GettingMonthByNumber()
        {
            Console.WriteLine("Получение названия месяца по его номеру.");

            bool correctInput = false;

            do
            {
                Console.WriteLine("Пожалуйста, введите номер месяца из диапазона 1-12.");

                string enteredValue = Console.ReadLine();
                correctInput = int.TryParse(enteredValue, out monthNumber);

                if (monthNumber > 12 || monthNumber <= 0)
                {
                    correctInput = false;
                }
            } while (!correctInput);

            DateTime mounth = new DateTime(2000, monthNumber, 1);
            Console.WriteLine($"Выбранный месяц: {mounth.ToString("MMMM")}");
        }

        static void DeterminingParityOfNumber()
        {
            Console.WriteLine("Определение четности введенного числа.");

            float number;
            bool correctInput = false;
            do
            {
                Console.WriteLine("Пожалуйста, введите целое число:");
                string enteredValue = Console.ReadLine();

                correctInput = float.TryParse(enteredValue, out number);
            } while (!correctInput);

            if (number % 2 == 0)
            {
                Console.WriteLine($"Число {number} является четным.");
            }
            else
            {
                Console.WriteLine($"Число {number} не является четным.");
            }
        }

        static void CheckPrinting()
        {

            int regionNumber = 27;
            string region = "Хабаровский кр";
            int index = 123456;
            string city = "Благовещенск";
            string street = "Ленина";
            string house = "11";

            string shopName = "FishkaNet";
            int checkNumber = 1101;
            int smenaNumber = 99;
            string IP = "Пупкин Виталий Акакьевич";
            string cashier = "Котов Алексей";
            double summa = 345.00;

            string nameItem1 = "КотЭ";
            float priceItem1 = 345.80f;
            int countItem1 = 1;


            int lRow = 40;//Ширина строчки

            //Если данные не уомещаются в 1 трочку. Данные по точке
            string rowRegion = $"{index}. {regionNumber}. {region}. г {city}. ул {street}. д {house}";
            if (rowRegion.Length > lRow)
            {
                string result = $"*{rowRegion.Substring(0, lRow)}*";
                rowRegion = result + $"\n*{rowRegion.Substring(rowRegion.Length - lRow, lRow)}{ RowBuilder(lRow, " ", rowRegion.Substring(rowRegion.Length - lRow, lRow))}*";
            }
            else
            {
                rowRegion = $"*{rowRegion}{RowBuilder(lRow, "", rowRegion)}*";
            }

            //Если данные не уомещаются в 1 трочку. Позиции товара.
            float price = priceItem1 * countItem1;
            string rowItem = $"{nameItem1} {countItem1}x{priceItem1}={price.ToString("0.0")}";
            if (rowItem.Length > lRow)
            {
                int deleted = rowItem.Length - lRow;
                rowItem = $"{nameItem1.Substring(0, nameItem1.Length - deleted)} {countItem1}x{priceItem1}={price.ToString("0.0")}";
            }
            else
            {
                rowItem = $"{nameItem1}{RowBuilder(lRow, " ", rowItem)} {countItem1}x{priceItem1}={price.ToString("0.0")}";
            }

            string check =
                $"*{RowBuilder(lRow, "*", "")}*\n" +
                $"*{shopName}{RowBuilder(lRow, " ", $"{shopName}")}*\n" +
                $"*{street} {house}{RowBuilder(lRow, " ", $"{street} {house}")}*\n" +
                $"*{RowBuilder(lRow, " ", "")}*\n" +
                $"*{RowBuilder(lRow / 2, " ", "КАССОВ")}КАССОВЫЙ ЧЕК{RowBuilder(lRow / 2, " ", "ЫЙ ЧЕК")}*\n" +
                $"*{RowBuilder(lRow / 2, " ", $"Продажа №{checkNumber}")}Продажа №{checkNumber} Смена №{smenaNumber}{RowBuilder(lRow / 2, " ", $" Смена №{smenaNumber}")}*\n" +
                $"*{rowItem}*\n" +
                $"*{RowBuilder(lRow, " ", "")}*\n" +
                $"*ИТОГ{RowBuilder(lRow, " ", $"ИТОГ={summa.ToString("0.0")}")}={summa.ToString("0.0")}*\n" +
                $"*Сумма БЕЗ НДС{RowBuilder(lRow, " ", $"Сумма БЕЗ НДС={summa.ToString("0.0")}")}={summa.ToString("0.0")}*\n" +
                $"*{RowBuilder(lRow, "-", "")}*\n" +
                $"*ИП:{RowBuilder(lRow, " ", $"ИП:{IP}")}{IP}*\n" +
                $"{rowRegion}\n" +
                $"*Кассир:{RowBuilder(lRow, " ", $"Кассир:{cashier}")}{cashier}*\n" +
                $"*Место расчетов:{ RowBuilder(lRow, " ", $"Место расчетов:Магазин {shopName}")}Магазин {shopName}*\n" +
                $"*Сайт ФНС:{RowBuilder(lRow, " ", $"Сайт ФНС:www.nalog.ru")}www.nalog.ru*\n" +
                $"*{RowBuilder(lRow, "+", "")}*\n";

            string check2 =
                $"--------------------------------\n" +
                $"{shopName}\n" +
                $"{street} {house}\n" +
                $"\n" +
                $"           КАССОВЫЙ ЧЕК\n" +
                $"    Продажа №{checkNumber}  Смена №{smenaNumber}\n" +
                $"Кот        1.000  х  345.00 =345\n" +
                $"\n" +
                $"ИТОГ                     =345.00\n" +
                $"Сумма БЕЗ НДС            =345.00\n" +
                $"НАЛИЧНЫМИ                =345.00\n" +
                $"--------------------------------\n" +
                $"ИП      {IP}\n" +
                $"Кассир             {cashier}\n" +
                $"Место расчетов Магазин {shopName}\n" +
                $"Сайт ФНС            www.nalog.ru\n" +
                $"--------------------------------\n";


            Console.WriteLine(check);

        }

        static void Plus()
        {
            GettingAverageDailyTemperature();
            GettingMonthByNumber();

            if ((monthNumber == 1 || monthNumber == 2 || monthNumber == 12) && averageTemperature > 0)
            {
                Console.WriteLine("Дождливая зима");
            }
        }

        [Flags]
        enum WorkWeek
        {
            Monday =    0b_0000_0001,
            Tuesday =   0b_0000_0010,
            Wednesday = 0b_0000_0100,
            Thursday =  0b_0000_1000,
            Friday =    0b_0001_0000,
            Saturday =  0b_0010_0000,
            Sunday =    0b_0100_0000
        }

        static void PlusPlus()
        {

            WorkWeek office1 = WorkWeek.Monday | WorkWeek.Tuesday | WorkWeek.Wednesday;
            WorkWeek office2 = WorkWeek.Tuesday | WorkWeek.Friday | WorkWeek.Saturday;

            Console.WriteLine($"График работы офиса 1: {office1}");
            Console.WriteLine($"График работы офиса 2: {office2}");
        }

        static string RowBuilder(int maxLenghtRow, string InsertedValue, string enteredValue)
        {
            string row = "";
            int lenghtValue = enteredValue.Length;
            int spaceCount = maxLenghtRow - lenghtValue;
            for (int i = 0; i < spaceCount; i++)
            {
                row += InsertedValue;
            }

            return row;
        }
    }
}
