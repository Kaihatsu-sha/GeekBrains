using System;
using Lesson5.Tree;

namespace Lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>(BinaryTree<int>.CompareInt);
            tree.Add(6);
            tree.Add(1);
            tree.Add(8);
            tree.Add(2);
            tree.Add(3);
            tree.Add(9);
            tree.Add(4);
            tree.Add(10);
            tree.Add(5);            
            tree.Add(7);         

            tree.DFSearching(10);
            tree.BFSearching(5);
            Console.ReadKey();
        }
    }
}
