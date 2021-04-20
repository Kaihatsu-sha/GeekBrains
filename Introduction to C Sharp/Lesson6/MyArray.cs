using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    class MyArray
    {
        readonly int _maxSize;

        public MyArray(int maxSize = 4)
        {
            _maxSize = maxSize;   
        }

        public int ArraySumm(string[,] array)
        {
            int sum = 0;

            if (array.GetLength(0) != _maxSize || array.GetLength(1) != _maxSize)
                throw new MyArraySizeException();


            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    int number;

                    if (!int.TryParse(array[i, j], out number))
                    {
                        throw new MyArrayDataException($"Ошибка данных в [{i},{j}] = {array[i,j]}");
                    }

                    sum += number;
                }
            }

            return sum;
        }
    }
}
