using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Task1
    {
        //Напишите на C# функцию согласно блок-схеме
        public bool IsSimpleNumber(int number)
        {
            if (number == 0 || number < 0)
            {
                throw new Exception();
            }

            int d = 0;
            int i = 2;

            while (i < number)
            {
                if (number % i == 0)
                {
                    d++;
                }

                i++;
            }

            if (d == 0)
            {
                Console.WriteLine($"Число {number} простое.");
                return true;
            }
            else 
            {
                Console.WriteLine($"Число {number} не простое.");
                return false;
            }
        }
    }
}
