using System;
using MyExternalLibrary;

namespace Lesson8
{
    class Program
    {
        static void Main(string[] args)
        {
            Main main = new Main();
            Console.Write("Введите имя: ");
            string hello = main.SayHello(Console.ReadLine());
            Console.WriteLine(hello);
            main.PrintToConsole();

            Console.ReadKey();
        }
    }
}
