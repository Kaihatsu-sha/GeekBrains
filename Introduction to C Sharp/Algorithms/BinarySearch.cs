using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class BinarySearch
    {
        //асимптотическая оценка сложности метода N^2(наихудший)
        public BinarySearch(int[] massive, int searchValue, out int indexValue)
        {
            BubbleSort sort = new BubbleSort(ref massive); //асимптотическая оценка сложности сортировки N^2
            indexValue = -1;//NotFound

            int middle = massive.Length / 2;
            int start = 0;
            int end = massive.Length - 1;
            while (start <= end)//асимптотическая оценка сложности поиска Log(N)
            {
                middle = (start + end) / 2;
                if (searchValue == massive[middle])
                {
                    indexValue = middle;
                    break;
                }
                if (searchValue > massive[middle])//Right
                {
                    start = middle + 1;
                }
                else//Left
                {
                    end = middle - 1;
                }
                // 0 1 2 3 4 5 6 7 8 9
                // 9
                // 0 1 2 3 !4! ->- 5 6 7 8 9 
                // 4
            }
        }
    }
}
