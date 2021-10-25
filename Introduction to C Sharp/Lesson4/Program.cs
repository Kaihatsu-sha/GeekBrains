using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            //BechmarkClass bClass = new BechmarkClass();
            //Console.ReadLine();

            Tree.BinaryTree tree = new Tree.BinaryTree();
            tree.AddItem(10);//R
            tree.AddItem(5);//L
            tree.AddItem(4);//L-L
            tree.AddItem(3);//L-L
            tree.AddItem(2);//L-L
            tree.AddItem(18);//R
            tree.AddItem(8);//L-R
            tree.AddItem(7);//L-P-L
            tree.AddItem(9);//

            tree.PrintTree();
            Console.ReadLine();
        }
    }
}
