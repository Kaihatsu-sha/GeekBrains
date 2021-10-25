using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {

            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

            Console.ReadKey();
        }
    }

    public class BechmarkClass
    {
        PointClass<float>[] _massivFC1;
        PointClass<float>[] _massivFC2;

        PointStruct<float>[] _massivFS1;
        PointStruct<float>[] _massivFS2;

        PointStruct<double>[] _massivDS1;
        PointStruct<double>[] _massivDS2;


        int _count = 10_000;

        public BechmarkClass()
        {
            _massivFC1 = MockData.GetFloatClass(_count);
            _massivFC2 = MockData.GetFloatClass(_count);

            _massivFS1 = MockData.GetFloatStruct(_count);
            _massivFS2 = MockData.GetFloatStruct(_count);

            _massivDS1 = MockData.GetDoubleStruct(_count);
            _massivDS2 = MockData.GetDoubleStruct(_count);
        }

        [Benchmark]
        public void ExecFloatClass()
        {
            for (int i = 0; i < _count; i++)
            {
                PointDistance(_massivFC1[i], _massivFC2[i]);
            }            
        }

        [Benchmark]
        public void ExecFloatStruct()
        {
            for (int i = 0; i < _count; i++)
            {
                PointDistance(_massivFS1[i], _massivFS2[i]);
            }
        }

        [Benchmark]
        public void ExecFloatStructShort()
        {
            for (int i = 0; i < _count; i++)
            {
                PointDistanceShort(_massivFS1[i], _massivFS2[i]);
            }
        }

        [Benchmark]
        public void ExecDoubleStruct()
        {
            for (int i = 0; i < _count; i++)
            {
                PointDistance(_massivDS1[i], _massivDS2[i]);
            }
        }

        public float PointDistance(PointClass<float> p1, PointClass<float> p2)
        {
            float x = p1.PointX - p2.PointX;
            float y = p1.PointY - p2.PointY;

            return MathF.Sqrt((x * x) + (y * y));
        }

        public double PointDistance(PointStruct<float> p1, PointStruct<float> p2)
        {
            float x = p1.PointX - p2.PointX;
            float y = p1.PointY - p2.PointY;

            return MathF.Sqrt((x * x) + (y * y));
        }

        public double PointDistance(PointStruct<double> p1, PointStruct<double> p2)
        {
            double x = p1.PointX - p2.PointX;
            double y = p1.PointY - p2.PointY;

            return MathF.Sqrt((float)((x * x) + (y * y)));
        }

        public float PointDistanceShort(PointStruct<float> p1, PointStruct<float> p2)
        {
            float x = p1.PointX - p2.PointX;
            float y = p1.PointY - p2.PointY;

            return MathF.Sqrt((x * x) + (y * y));
        }
    }
}
/*
BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.1052 (21H1/May2021Update)
Intel Core i5-8265U CPU 1.60GHz (Whiskey Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=5.0.300
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
 */
#region 1
/*
|               Method |     Mean |    Error |   StdDev |
|--------------------- |---------:|---------:|---------:|
|       ExecFloatClass | 14.14 us | 0.259 us | 0.243 us |
|      ExecFloatStruct | 27.71 us | 0.427 us | 0.378 us |
| ExecFloatStructShort | 14.58 us | 0.287 us | 0.268 us |
|     ExecDoubleStruct | 31.18 us | 0.617 us | 1.316 us |
 */
#endregion
#region 2
/*
|               Method |     Mean |    Error |   StdDev |
|--------------------- |---------:|---------:|---------:|
|       ExecFloatClass | 14.05 us | 0.266 us | 0.248 us |
|      ExecFloatStruct | 27.19 us | 0.246 us | 0.230 us |
| ExecFloatStructShort | 14.41 us | 0.286 us | 0.391 us |
|     ExecDoubleStruct | 31.62 us | 0.631 us | 1.185 us |
 */
#endregion
#region 3
/*
|               Method |     Mean |    Error |   StdDev |
|--------------------- |---------:|---------:|---------:|
|       ExecFloatClass | 14.55 us | 0.279 us | 0.310 us |
|      ExecFloatStruct | 27.82 us | 0.456 us | 0.427 us |
| ExecFloatStructShort | 14.50 us | 0.281 us | 0.289 us |
|     ExecDoubleStruct | 30.22 us | 0.452 us | 0.401 us |
 */
#endregion
#region 4
/*
|               Method |     Mean |    Error |   StdDev |
|--------------------- |---------:|---------:|---------:|
|       ExecFloatClass | 14.22 us | 0.265 us | 0.248 us |
|      ExecFloatStruct | 27.11 us | 0.262 us | 0.245 us |
| ExecFloatStructShort | 14.49 us | 0.286 us | 0.267 us |
|     ExecDoubleStruct | 30.38 us | 0.219 us | 0.194 us |
 */
#endregion
#region 5
/*
|               Method |     Mean |    Error |   StdDev |
|--------------------- |---------:|---------:|---------:|
|       ExecFloatClass | 14.76 us | 0.294 us | 0.508 us |
|      ExecFloatStruct | 27.56 us | 0.439 us | 0.411 us |
| ExecFloatStructShort | 14.47 us | 0.116 us | 0.091 us |
|     ExecDoubleStruct | 30.72 us | 0.587 us | 0.603 us |
 */
#endregion
