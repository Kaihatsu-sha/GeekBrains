using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    public class BubbleSort
    {
        public void Sort(int[] massiv)
        {
            if (massiv == null)
            {
                throw new ArgumentNullException();
            }
            if (massiv.Length == 0)
            {
                throw new ArgumentException();
            }

            for (int i = 1; i < massiv.Length; i++)
            {
                for (int j = 0; j < massiv.Length - i; j++)
                {
                    if (massiv[j] > massiv[j+1])
                    {
                        Swap(ref massiv[j], ref massiv[j+1]);
                    }
                }
            }
        }

        private void Swap(ref int elementA, ref int elementB)
        {
            int temp = elementA;
            elementA = elementB;
            elementB = temp;
        }
    }
}
