using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson5
{
    public class ToDoMenu
    {
        readonly EngineToDo _engine;
        List<ToDo> _toDos;
        public ToDoMenu(EngineToDo engine)
        {
            _engine = engine;
            _toDos = _engine.ReadAll();
            _engine = engine;
        }

        public void Start()
        {
            Console.WriteLine("Добро пожаловать в приложение Задачи.");
            bool isWork = true;
            while (isWork)
            {
                ShowMainMenu();
                switch (ReadUserKey())
                {
                    case ConsoleKey.Escape:
                        Save();
                        isWork = false;
                        break;
                    case ConsoleKey.D1:
                        ShowAll();
                        break;
                    case ConsoleKey.D2:
                        ShowAllNotDone();
                        break;
                    case ConsoleKey.D3:
                        IsDone();
                        break;
                    case ConsoleKey.D4:
                        CreateNew();
                        break;
                }
            }
        }

        void ShowMainMenu()
        {
            //Console.Clear();
            Console.WriteLine("\nЭто главное меню, выберите дальнейшее действие:");
            Console.WriteLine("1 - Показать все Задачи\n2 - Показать не выполненые Задачи\n3 - Пометить Задачу как выполненую\n4 - Добавить новую Задачу\nESC - Выйти из приложения\n");
        }

        ConsoleKey ReadUserKey()
        {
            return Console.ReadKey().Key;
        }

        void ShowAll()
        {
            int number = 1;
            foreach (ToDo item in _toDos)
            {
                Console.Write($"\n{number} - {item.Title} {(item.IsDone ? "[x]" : "[]")}");
            }


        }

        void ShowAllNotDone()
        {
            int number = 1;
            foreach (ToDo item in _toDos.Where(p => p.IsDone == false))
            {
                Console.Write($"\n{number} - {item.Title}");
            }
        }

        int ReadUserInput()
        {
            string inputString = Console.ReadLine();
            int number = -1;
            int.TryParse(inputString, out number);

            return number;
        }

        void IsDone()
        {
            Console.Write("\nВведите номер Задачи: ");
            int number = ReadUserInput();

            if (number > 0 && number < _toDos.Count)
            {
                number = number - 1;
                _toDos[number].IsDone = true;
            }
            else
            {
                Console.WriteLine("Введено не корректное значение.");
                Thread.Sleep(300);
            }

        }

        void CreateNew()
        {
            ToDo news = new ToDo();
            Console.Write("\nВведите название Задачи: ");
            news.Title = Console.ReadLine();

            _toDos.Add(news);
        }

        void Save()
        {
            _engine.WriteAll(_toDos);
        }
    }
}
