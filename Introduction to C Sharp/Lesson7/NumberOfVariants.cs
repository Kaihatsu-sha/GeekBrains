using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    public class NumberOfVariants
    {
        private Dictionary<int, int> _hash;
        private int _recursionCount = 0;
        private int _hashCount = 0;

        public NumberOfVariants()
        {
            _hash = new Dictionary<int, int>();
            //int number1= CountingOfVariants(16);
            //int number2 = RecursiveCountingOfVariants(16);

            //Console.WriteLine($"Рекурсия: {_recursionCount}{Environment.NewLine}Хэш: {_hashCount}");
        }

        public int CountingOfVariants(int number)
        {
            if (number == 0)
            {
                throw new ArgumentException();
            }

            _hashCount++;
            if (number == 1)
            {
                return 1;
            }
            if (number % 2 == 0)
            {
                return CheckHash(number - 1) + CheckHash(number / 2);
            }
            else
            {
                return CheckHash(number - 1);
            }
        }

        public int RecursiveCountingOfVariants(int number)
        {
            _recursionCount++;
            if (number == 1)
            {
                return 1;
            }
            if (number % 2 == 0)
            {
                return RecursiveCountingOfVariants(number - 1) + RecursiveCountingOfVariants(number / 2);
            }
            else
            {
                return RecursiveCountingOfVariants(number - 1);
            }
        }

        private int CheckHash(int value)
        {
            if (!_hash.ContainsKey(value))
            {
                _hash.Add(value, CountingOfVariants(value));
            }
            
            return _hash[value];
        }
    }
}
