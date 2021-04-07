using System;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintDiagonalArrayElements();
            CreatingTelephoneDirectory();
            InvertingLine();
            PrintSeaBattlefield();
            OffsetArrayElements();


            Console.ReadKey();
        }

        static void PrintDiagonalArrayElements()
        {

            char[,] massiv = new char[4, 6];
            massiv[0, 0] = 'q';
            massiv[0, 1] = 'q';
            massiv[0, 2] = 'q';
            massiv[0, 3] = 'q';
            massiv[0, 4] = 'q';
            massiv[0, 5] = 'q';

            massiv[1, 0] = 's';
            massiv[1, 1] = 's';
            massiv[1, 2] = 's';
            massiv[1, 3] = 's';
            massiv[1, 4] = 's';
            massiv[1, 5] = 's';

            massiv[2, 0] = 'p';
            massiv[2, 1] = 'p';
            massiv[2, 2] = 'p';
            massiv[2, 3] = 'p';
            massiv[2, 4] = 'p';
            massiv[2, 5] = 'p';

            for (int i = 0; i < massiv.GetLength(0); i++)
            {
                for (int j = 0; j < massiv.GetLength(1); j++)
                {
                    Console.Write(i == j ? massiv[i, j] : ' ');
                }
                Console.WriteLine();
            }
        }

        static void CreatingTelephoneDirectory()
        {
            string[,] phoneDirectory = new string[5, 2];
            phoneDirectory[0, 0] = "Василий А.";
            phoneDirectory[0, 1] = "8 999 000 11 22";

            phoneDirectory[1, 0] = "Анна В.";
            phoneDirectory[1, 1] = "AnnyKat@mail.ru";

            phoneDirectory[2, 0] = "Иван С.";
            phoneDirectory[2, 1] = "strongMan@gmail.com";

            phoneDirectory[3, 0] = "Инна Р.";
            phoneDirectory[3, 1] = "8 999 0000 22 33";

            phoneDirectory[4, 0] = "Инна В.";
            phoneDirectory[4, 1] = "AnnyKat@mail.ru";

            Console.WriteLine("Добро пожаловать в приложение Телефонный справочник!\nВведите интересующее Вас имя и программа отобразит контактные данные");
            do
            {
                Console.Write("Введите имя: ");
                string searchName = Console.ReadLine();

                for (int i = 0; i < phoneDirectory.GetLength(0); i++)
                {
                    string name = phoneDirectory[i, 0];
                    //int j = 0;
                    for (int j = 0; j < name.Length; j++)//Выход за переделы массива
                    {
                        if (j < searchName.Length)
                        {
                            if (searchName[j] != name[j])
                            {
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Мы нашли: {phoneDirectory[i, 0]} {phoneDirectory[i, 1]} ");
                            break;
                        }
                    }

                }

            } while (true);
        }

        static void InvertingLine()
        {
            Console.Write("Введите строку и нажмите ENTER : ");
            string line = Console.ReadLine();

            for (int i = line.Length - 1; i >= 0; i--)
            {
                Console.Write(line[i]);
            }
        }

        static void PrintSeaBattlefield()
        {
            char[,] battlefield = new char[10, 10]
                {    {'O', 'X', 'X', 'O', 'X', 'X', 'O', 'X', 'O', 'X' },
                     {'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'X' },
                     {'O', 'X', 'O', 'X', 'O', 'X', 'O', 'X', 'O', 'O' },
                     {'O', 'X', 'O', 'O', 'O', 'X', 'O', 'X', 'O', 'X' },
                     {'O', 'X', 'O', 'X', 'O', 'O', 'O', 'X', 'O', 'O' },
                     {'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'X' },
                     {'X', 'O', 'O', 'O', 'X', 'X', 'X', 'X', 'O', 'X' },
                     {'X', 'O', 'X', 'O', 'O', 'O', 'O', 'O', 'O', 'X' },
                     {'X', 'O', 'X', 'O', 'X', 'O', 'X', 'O', 'O', 'X' },
                     {'X', 'O', 'X', 'O', 'X', 'O', 'O', 'O', 'O', 'X' }
                };

            for (int i = 0; i < battlefield.GetLength(0); i++)
            {
                for (int j = 0; j < battlefield.GetLength(1); j++)
                {
                    Console.Write(battlefield[i, j]);
                }
                Console.Write(Environment.NewLine);
            }
        }

        static void OffsetArrayElements()
        {
            int[] massive = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Console.WriteLine("Сдвиг элементов массива на указанное значение.\n Число со знаком '-' сдвигает элементы влево.");

            bool isCorrect = false;
            int offset = 0;

            do
            {
                Console.Write("Пожалуйста введите число: ");
                string inputLine = Console.ReadLine();
                isCorrect = int.TryParse(inputLine, out offset);

            } while (!isCorrect);

            Console.Write("   Массив до: ");
            for (int i = 0; i < massive.Length; i++)
            {
                Console.Write($"{massive[i]} ");
            }
            Console.Write("\nМассив после: ");

            int tempCurrent = 0;//Сохраняем текущий элемент
            int tempNext = -1;//Сохраняем следующий элемент
            int j = massive.Length;//Количество итераций
            int currentIndex = 0;//Индекс элемента для вставки          
            int nextIndex = 0;//Индекс следующего элемента

            if (offset < 0)
            {
                offset = massive.Length + offset;
            }

            while (massive.Length < offset)//Исключаем "полные" сдвиги
            {
                offset = offset - massive.Length;
            }

            if (massive.Length != offset)
            {
                do
                {
                    if (currentIndex >= massive.Length)
                    {
                        currentIndex = currentIndex - massive.Length;//Начали сначала
                        if (massive.Length % offset == 0)
                        {
                            currentIndex = 1;
                            tempNext = massive[currentIndex];
                        }
                    }

                    nextIndex = currentIndex + offset;
                    if (nextIndex >= massive.Length)
                    {
                        nextIndex = nextIndex - massive.Length;//Начали сначала                   
                    }

                    tempCurrent = tempNext;
                    tempNext = massive[nextIndex];//Сохранили следующий элемент


                    if (tempCurrent == -1)
                        tempCurrent = massive[currentIndex];//Сохранили текущий для 1-й итерации

                    massive[nextIndex] = tempCurrent;//На место сдвига поставили элемент с предыдущего места
                    currentIndex = currentIndex + offset;               

                    j--;
                } while (j != 0);
            }

            for (int i = 0; i < massive.Length; i++)
            {
                Console.Write($"{massive[i]} ");
            }

        }
    }
}
