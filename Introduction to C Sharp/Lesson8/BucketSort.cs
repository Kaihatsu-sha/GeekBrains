using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    public class BucketSort
    {
        int _numberBuckets;
        public BucketSort(int numberBuckets = 2)
        {
            if (numberBuckets == 0)
            {
                throw new ArgumentException();
            }
            _numberBuckets = numberBuckets;
        }

        public void Sort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            if (array.Length == 0)
            { 
                throw new ArgumentException();
            }

            List<int>[] buckets = new List<int>[_numberBuckets];
            (int minValue, int maxValue) = GetMinimumAndMaximumValues(array);

            for (int i = 0; i < _numberBuckets; i++)
            {
                buckets[i] = new List<int>();
                int endRage = GetRangeValues(minValue, maxValue, _numberBuckets - i);
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j] >= minValue && array[j] < endRage)
                    {
                        buckets[i].Add(array[j]);
                    }
                }
                minValue = endRage;
            }

            InsertingAndSorting(array, buckets);
        }

        private void InsertingAndSorting(int[] array, List<int>[] buckets)
        {
            BubbleSort bubbleSort = new BubbleSort();
            int index = 0;
            for (int i = 0; i < _numberBuckets; i++)
            {
                int[] tempArray = new int[buckets[i].Count];
                tempArray = buckets[i].ToArray();
                bubbleSort.Sort(tempArray);

                for (int j = 0; j < tempArray.Length; j++)
                {
                    array[index] = tempArray[j];
                    index++;
                }
            }
        }

        private (int minValue, int maxValue) GetMinimumAndMaximumValues(int[] massiv)
        {
            int minValue = massiv[0];
            int maxValue = massiv[0];

            for (int i = 1; i < massiv.Length; i++)
            {
                if (massiv[i] > maxValue)
                {
                    maxValue = massiv[i];
                    continue;
                }
                if (massiv[i] < minValue)
                {
                    minValue = massiv[i];
                }
            }

            return (minValue, maxValue);
        }

        private int GetRangeValues(int start, int end, int count)
        {
            if (count == 1)
            {
                return end + 1;
            }

            if (count == 0)
            {
                throw new ArgumentException();
            }

            int answer = (end - start) / count;
            return start + answer;
        }
    }
}
