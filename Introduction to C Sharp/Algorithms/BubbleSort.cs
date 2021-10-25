using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class BubbleSort
    {
        public BubbleSort(ref int[] massiv)
        {
            int length = massiv.Length;
            
            if (length == 0)
            {
                throw new Exception("Empty massiv");
            }

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length - 1; j++)
                {
                    if (massiv[j] > massiv[j + 1])
                    {
                        int temp = massiv[j + 1];
                        massiv[j + 1] = massiv[j];
                        massiv[j] = temp;
                    }
                }
            }
        }
    }
}
