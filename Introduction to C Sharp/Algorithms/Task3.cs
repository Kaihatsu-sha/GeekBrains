using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Task3
    {
        public int FibonacciRecursion(int number)
        {
            if (number < 0)
            {
                throw new Exception();
            }

            if (number == 0)
            {
                return 0;
            }

            if (number == 1 || number == 2)
            {
                return 1;
            }

            return (FibonacciRecursion(number - 2) + FibonacciRecursion(number - 1));
        }

        public int Fibonacci(int number)
        {
            if (number < 0)
            {
                throw new Exception();
            }

            if (number == 0)
            {
                return 0;
            }

            if (number == 1 || number == 2)
            {
                return 1;
            }

            int fibonacciNumber = 0;
            Stack<int> stack = new Stack<int>();
            stack.Push(number);

            do
            {
                int currentNumber = stack.Pop();

                if (currentNumber == 1 || currentNumber == 2)
                {
                    fibonacciNumber++;
                }
                else
                {
                    stack.Push(currentNumber - 1);
                    stack.Push(currentNumber - 2);
                }

            } while (stack.Count > 0);

            return fibonacciNumber;
        }
    }
}
