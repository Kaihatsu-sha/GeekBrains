using Lesson5.Interfaces;
using System;
using System.Collections.Generic;

namespace Lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            //SampleWriteTextFromConsole();
            //SampleStartupWrite();
            SampleBinaryWriter();
            //SampleEmployees();
            //SampleToDos();


            Console.ReadKey();
        }

        static void SampleWriteTextFromConsole()
        {
            Console.WriteLine("Введите набор данных через пробел и нажмите Enter: ");
            string data = Console.ReadLine();

            IWriter writer = new StringWriter("textFromConsole.txt");
            writer.Write(data);
        }

        static void SampleStartupWrite()
        {
            IWriter writer = new StartupWriter("startup.txt");
        }

        static void SampleBinaryWriter()
        {
            string data = "";
            do
            {
                Console.WriteLine("Введите набор цифр от 0 до 255 и нажмите Enter: ");
                data = Console.ReadLine();
            } while (!CkeckNumber(data));

            IWriter writer = new BinaryWriter("binary.bin");
            writer.Write(data);
        }


        private static bool CkeckNumber(string data)
        {
            string[] splitData = data.Split();
            int number = 0;
            foreach (string item in splitData)
            {
                if (!int.TryParse(item, out number))
                {
                    return false;
                }
                else
                {
                    if (number < 0 || number > 255)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static void SampleEmployees()
        {
            List<IEmployee> employees = new List<IEmployee>
            {
                new Employee("Иван","Сидоров","Андреевич", 41, "внутренний 2341", "sidorov_ia@company.ru","доставщик корреспонденции", 39840),
                new Employee("Андрей","Покров","Алексеевич", 24, "8(9999)-536-897", "pokrov_aa@company.ru","специалист поддержки клиентов", 50890),
                new Employee("Дмитрий","Соколов","Александрович", 46, "8(9999)-536-878", "sokolov_da@company.ru","Руководитель отдела продаж", 92000),
                new Employee("Ирина","Петрова","Ивановна", 42, "внутренний 2246", "petrova_ii@company.ru","младший специалист отдела маркетинга", 65800),
                new Employee("Роза","Сидорова","Петровна", 45, "внутренний 2001", "sidorova_rp@company.ru","бухгалтер заработной платы", 68800),
                new Employee("Екатерина","Ситцева","Ивановна", 40, "8(9999)-536-821", "sidorov_ia@company.ru","специалист службы кадров", 55080)
            };

            Predicate<IEmployee> ageFilter = delegate (IEmployee employee) { return employee.Person.Age > 40; };

            foreach (IEmployee employee in employees.FindAll(ageFilter))
            {
                employee.OutputToConsole();
            }
        }

        static void SampleToDos()
        {
            EngineToDo engine = new EngineToDo("todo.txt");
            ToDoMenu menu = new ToDoMenu(engine);
            menu.Start();
        }
    }
}
