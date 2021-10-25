using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class MockData
    {
        public static PointClass<float>[] GetFloatClass(int count)
        {
            if (count <= 0)
            {
                throw new Exception("Count <= 0");
            }

            Random random = new Random();
            PointClass<float>[] massiv = new PointClass<float>[count];
            for (int i = 0; i < count; i++)
            {
                massiv[i] = new PointClass<float>() { PointX = (float)(random.NextDouble() * random.Next(10, 10000)), PointY = (float)(random.NextDouble() * random.Next(10, 10000)) };
            }

            return massiv;
        }

        public static PointStruct<float>[] GetFloatStruct(int count)
        {
            if (count <= 0)
            {
                throw new Exception("Count <= 0");
            }

            Random random = new Random();
            PointStruct<float>[] massiv = new PointStruct<float>[count];
            for (int i = 0; i < count; i++)
            {
                massiv[i] = new PointStruct<float>() { PointX = (float)(random.NextDouble() * random.Next(10, 10000)), PointY = (float)(random.NextDouble() * random.Next(10, 10000)) };
            }

            return massiv;
        }

        public static PointStruct<double>[] GetDoubleStruct(int count)
        {
            if (count <= 0)
            {
                throw new Exception("Count <= 0");
            }

            Random random = new Random();
            PointStruct<double>[] massiv = new PointStruct<double>[count];
            for (int i = 0; i < count; i++)
            {
                massiv[i] = new PointStruct<double>() { PointX = (random.NextDouble() * random.Next(10, 10000)), PointY = (random.NextDouble() * random.Next(10, 10000)) };
            }

            return massiv;
        }
    }
}
