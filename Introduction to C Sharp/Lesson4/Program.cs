using System;

namespace Lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            GetSampleFullName();
            GetSumm();
            Console.WriteLine(GetSeasonName(GetSeason()));
            Console.WriteLine($"Число Фибоначи: { Fibonacci(GetNumberEntered()) }");
            Console.WriteLine(SplittingSentence("Строка1 Строка2Новая строка 4"));

            Console.ReadKey();
        }

        static void GetSampleFullName()
        {
            Console.WriteLine(GetFullName(firstName: "Василий", lastName: "Соловьев", partronymic: "Иванович"));
            Console.WriteLine(GetFullName(firstName: "Игнат", lastName: "Смирнов", partronymic: "Петрович"));
            Console.WriteLine(GetFullName(firstName: "Дмитрий", lastName: "Бизов", partronymic: "Пахомович"));
            Console.WriteLine(GetFullName(firstName: "Терентий", lastName: "Краков", partronymic: "Алексеевич"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="partronymic">Отчество</param>
        /// <returns></returns>
        static string GetFullName(string firstName, string lastName, string partronymic)
        {
            return $"{lastName} {firstName} {partronymic}";
        }

        static void GetSumm()
        {

            Console.Write("Введите целые числа через пробел и нажмите ENTER\nВветите числа:");
            string stringLine = Console.ReadLine();

            string[] splitStringLine = stringLine.Split(" ");

            int summ = 0;
            int parseNumber = 0;

            for (int i = 0; i < splitStringLine.Length; i++)
            {
                if (int.TryParse(splitStringLine[i], out parseNumber))
                {
                    summ += parseNumber;
                }
                else
                {
                    Console.WriteLine($"Не удалось распознать как число : {splitStringLine[i]}");
                }
            }
            Console.WriteLine($"Сумма чисел: {summ}");
        }

        [Flags]
        enum Seasons
        {
            Winter,
            Spring,
            Summer,
            Autumn
        }
        static Seasons GetSeason()
        {
            bool isTryParse = true;
            int monthNumber = 0;
            Seasons season = Seasons.Winter;

            monthNumber = 0;
            do
            {
                Console.WriteLine("Введите месяц года.");
                monthNumber = GetNumberEntered();

                if (monthNumber < 0 || monthNumber > 13)
                {
                    Console.Write("Не удалось распознать, пожалуйста, введите число в диапазоне от 1 до 12.");
                    isTryParse = false;
                }
                else
                {
                    isTryParse = true;
                }
            } while (!isTryParse);

            switch (monthNumber)
            {
                case 12:
                case 1:
                case 2:
                    season = Seasons.Winter;
                    break;
                case 3:
                case 4:
                case 5:
                    season = Seasons.Spring;
                    break;
                case 6:
                case 7:
                case 8:
                    season = Seasons.Summer;
                    break;
                case 9:
                case 10:
                case 11:
                    season = Seasons.Autumn;
                    break;
            }

            return season;
        }

        static string GetSeasonName(Seasons season)
        {
            string seasonName = "";

            switch (season)
            {
                case Seasons.Winter:
                    seasonName = "Зима";
                    break;
                case Seasons.Spring:
                    seasonName = "Весна";
                    break;
                case Seasons.Summer:
                    seasonName = "Лето";
                    break;
                case Seasons.Autumn:
                    seasonName = "Осень";
                    break;
            }

            return seasonName;
        }

        static int GetNumberEntered()
        {
            int number = 0;
            bool isTryParse = false;
            do
            {
                Console.Write("Введите целое число:");
                string entered = Console.ReadLine();

                isTryParse = int.TryParse(entered, out number);
                if (!isTryParse)
                {
                    Console.WriteLine("Не удалось распознать, пожалуйста, повторите.");
                }
            } while (!isTryParse);

            return number;
        }

        static int Fibonacci(int number)
        {
            if (number == 2 || number == 1)
            {
                return 1;
            }
            if (number == 0)
            {
                return 0;
            }

            return Fibonacci(number - 1) + Fibonacci(number - 2);
        }

        static string SplittingSentence(string sentence)
        {
            string resultString = "";
            string subStr = "";
            int start = 0;

            int n = sentence.Length;
            for (int i = 1; i < sentence.Length; i++)
            {
                char iss = sentence[i];
                if (char.IsUpper(sentence[i]))
                {
                    subStr = sentence.Substring(start, i - start);
                    resultString += subStr.Trim()  + ". ";
                    start = i;
                }
            }

            subStr = sentence.Substring(start, sentence.Length - start);
            resultString += subStr.Trim() + ".";

            return resultString;
        }
    }
}
