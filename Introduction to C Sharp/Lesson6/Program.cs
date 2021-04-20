using System;

namespace Lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleMyArray();
            SampleTaskManager();
        }

        #region SampleException
        static void SampleMyArray()
        {
            try
            {
                MyArray myArray = new MyArray();
                int summ = myArray.ArraySumm(MyArrayDataException());
                //int summ = myArray.ArraySumm(MyArraySizeException());
                //int summ = myArray.ArraySumm(MyArraySumm());

                Console.WriteLine($"Сумма : {summ} ") ;
            }
            catch (MyArrayDataException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (MyArraySizeException ex)
            {
                Console.WriteLine("Ошибка ограничений размера");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Прочая ошибка: {ex.Message}");
            }
        }

        static string[,] MyArraySizeException()
        {
            return new string[4, 3]
            {
                {"1","2","3" },
                {"3","2","1" },
                {"7","6","5" },
                {"5","6","7" }
            };
        }
        static string[,] MyArrayDataException()
        {
            return new string[4, 4]
            {
                {"1","2","3","3" },
                {"3","f","1","3" },
                {"7","6","A","3" },
                {"5","6","7","3" }
            };
        }
        static string[,] MyArraySumm()
        {
            // 4*4 + 1 = 17
            return new string[4, 4]
            {
                {"2","1","1","1" },
                {"1","1","1","1" },
                {"1","1","1","1" },
                {"1","1","1","1" }
            };
        }
        #endregion

        static void SampleTaskManager()
        {
            TaskManager tManager = new TaskManager();


            while (true)
            {
                Console.WriteLine("Возможные операции:\n[1] Вывод всех процессов\n[2] Завершение процесса по имени\n[3] Завершение процесса по [номеру]\n[0] Для выхода");
                Console.Write("Введите номер действия: ");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        tManager.PrintAllProcesses();
                        break;
                    case ConsoleKey.D2:
                        KillByName(tManager);
                        break;
                    case ConsoleKey.D3:
                        KillById(tManager);
                        break;
                    case ConsoleKey.D0:
                        return;
                }
            }  
        }

        static void KillByName(TaskManager manager)
        {
            Console.Write("\nЗавершение процесса по Имени\n");
            Console.WriteLine("Введите имя процесса");
            string name = Console.ReadLine();

            manager.KillProcessByName(name);
        }
        static void KillById(TaskManager manager)
        {
            Console.Write("\nЗавершение процесса по [номеру]");
            string sId;
            int id;

            do
            {
                Console.WriteLine();
                Console.Write("Введите [номер] процесса: ");
                sId = Console.ReadLine();
            }
            while(!int.TryParse(sId, out id));

            manager.KillProcessesById(id);
        }

        static void Menu()
        {
            
        }
    }
}
