using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lesson4
{
    #region BenchmarkDotNet
    //BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.1055 (21H1/May2021Update)
    //Intel Core i5-8265U CPU 1.60GHz(Whiskey Lake), 1 CPU, 8 logical and 4 physical cores
    //.NET SDK= 6.0.100-preview.5.21302.13

    // [Host]     : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT[AttachedDebugger]
    //  DefaultJob : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT


    //|             Method |              Mean |            Error |           StdDev |
    //|------------------- |------------------:|-----------------:|-----------------:|
    //|  SearchingInMassiv | 235,417,502.56 ns | 4,292,805.468 ns | 3,584,686.988 ns |
    //| SearchingInHashSet |          10.05 ns |         0.235 ns |         0.387 ns |
    #endregion

    #region Stopwatch
    //Iteration: 0
    //HashSet 00:00:00.00
    //Massiv 00:00:00.36
    //Iteration: 1
    //HashSet 00:00:00.00
    //Massiv 00:00:00.39
    //Iteration: 2
    //HashSet 00:00:00.00
    //Massiv 00:00:00.32
    //Iteration: 3
    //HashSet 00:00:00.00
    //Massiv 00:00:00.37
    //Iteration: 4
    //HashSet 00:00:00.00
    //Massiv 00:00:00.36
    //Iteration: 5
    //HashSet 00:00:00.00
    //Massiv 00:00:00.33
    //Iteration: 6
    //HashSet 00:00:00.00
    //Massiv 00:00:00.31
    //Iteration: 7
    //HashSet 00:00:00.00
    //Massiv 00:00:00.45
    //Iteration: 8
    //HashSet 00:00:00.00
    //Massiv 00:00:00.43
    //Iteration: 9
    //HashSet 00:00:00.00
    //Massiv 00:00:00.30
    //Среднее значение для массива 36
    //Среднее значение для таблицы 0

    #endregion


    public class BechmarkClass
    {
        string[] _massivString;
        HashSet<String> _hashSet;
        int _numberElements = 10_000_000;

        public BechmarkClass()
        {
            InitStrings();
            //Start();
        }

        void Start()
        {          
            Stopwatch stopWatch = new Stopwatch();
            int massivTime = 0;
            int hashSetTime = 0;

            for (int i = 0; i < 10; i++)
            {
                stopWatch.Reset();
                Console.WriteLine("Iteration: " + i);

                stopWatch.Start();
                SearchingInHashSet("I");
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
                hashSetTime += ts.Milliseconds;
                Console.WriteLine("HashSet " + elapsedTime);

                stopWatch.Reset();

                stopWatch.Start();
                SearchingInMassiv("I");
                stopWatch.Stop();
                ts = stopWatch.Elapsed;
                elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
                massivTime += ts.Milliseconds;
                Console.WriteLine("Massiv " + elapsedTime);
            }

            Console.WriteLine("Среднее значение для массива " + (massivTime / 100));
            Console.WriteLine("Среднее значение для таблицы " + (hashSetTime / 100));
        }

        void InitStrings()
        {
            int i = 0;
            _massivString = new string[_numberElements];
            _hashSet = new HashSet<string>();

            Random random = new Random();

            while (_numberElements > i)
            {
                string element = random.Next(1_000_000_000, 2_147_483_647).ToString() + random.Next(0, 2_147_483_647).ToString();
                _massivString[i] = element;
                _hashSet.Add(element);

                i++;
            }
        }
      
        void SearchingInHashSet(string searchingValue)
        {
            if (_hashSet.Contains(searchingValue))
            {
                Console.WriteLine("true");
                return;
            }
        }
        void SearchingInMassiv(string searchingValue)
        {
            for (int i = 0; i < _numberElements; i++)
            {
                if (_massivString[i].Contains(searchingValue))
                {
                    Console.WriteLine("true");
                    return;
                }
            }
        }

        [Benchmark]
        public void SearchingInMassiv()
        {
            string searchingValue = "I";
            for (int i = 0; i < _numberElements; i++)
            {
                if (_massivString[i].Contains(searchingValue))
                {
                    Console.WriteLine("true");
                    return;
                }
            }
        }
        [Benchmark]
        public void SearchingInHashSet()
        {
            string searchingValue = "I";
            if (_hashSet.Contains(searchingValue))
            {
                Console.WriteLine("true");
                return;
            }
        }

    }

}
