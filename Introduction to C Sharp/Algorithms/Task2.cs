using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Task2
    {
        //Вычислите асимптотическую сложность функции

        //O(6 + N^3) Правило 2 => O(N^3) Правило 3
        //Асимптотическая сложность функции O(N^3) - N в кубе. Правило 4
        //Значения констант можно пренебречь.
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0;//O(1)
            for (int i = 0; i < inputArray.Length; i++)//O(N)
            {
                for (int j = 0; j < inputArray.Length; j++)//O(N) * O(N) Правило 4
                {
                    for (int k = 0; k < inputArray.Length; k++)//O(N) * O(N) * O(N) Правило 4
                    {
                        int y = 0;//O(1)

                        if (j != 0)//O(1)
                        {
                            y = k / j;//O(1)
                        }

                        sum += inputArray[i] + i + k + j + y;//O(1)
                    }
                }
            }

            return sum;//O(1)
        }
    }
}
