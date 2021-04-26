using System;

namespace MyExternalLibrary
{
    public class Main
    {
        public string SayHello(string name)
        {
            return $"Hello, {name}! It is External Library";
        }

        public void PrintToConsole()
        {
            Console.WriteLine("Console out");
        }
    }
}
