using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.Tree
{
    public class BinaryTree<T> where T : struct
    {
        private Node<T> _root;

        public delegate int CompareFunction(T left, T right);

        CompareFunction _compareFunction;

        public BinaryTree(CompareFunction compareFunction)
        {
            _compareFunction = compareFunction;
        }

        public static int CompareInt(int left, int right)
        {
            return left - right;
        }
        public static int CompareString(string left, string right)
        {
            return left.CompareTo(right);
        }

        public void Add(T value)
        {
            if (_root == null)
            {
                _root = new Node<T>(value);
                return;
            }

            Node<T> currentNode = _root;

            while (true)
            {
                if (currentNode.Value.Equals(value))
                {
                    throw new ArgumentException($"Дерево уже содержит значение {value}");
                }

                int compareValue = _compareFunction(value, currentNode.Value);

                if (compareValue > 0)//Right
                {
                    if (currentNode.RightDescendant != null)
                    {
                        currentNode = currentNode.RightDescendant;
                        continue;
                    }
                    else
                    {
                        currentNode.RightDescendant = new Node<T>(value) { Parent = currentNode };
                        break;
                    }
                }

                if (compareValue <= 0)//Left
                {
                    if (currentNode.LeftDescendant != null)
                    {
                        currentNode = currentNode.LeftDescendant;
                        continue;
                    }
                    else
                    {
                        currentNode.LeftDescendant = new Node<T>(value) { Parent = currentNode };
                        break;
                    }
                }                
            }

        }

        /// <summary>
        /// (breadth-first search) — поиск в ширину
        /// </summary>
        /// <param name="value">Искомое значение</param>
        /// <returns></returns>
        public Node<T> BFSearching(T value)
        {
            if (_root == null)
            {
                throw new ArgumentNullException("Дерево не содержит значений");
            }

            OutToConsole("BFSearching", "1 Положить корень дерева в очередь.");
            Queue<Node<T>> queue = new Queue<Node<T>>();//FIFO
            queue.Enqueue(_root);//Добавление в конец

            OutToConsole("BFSearching", "2 Если очередь пуста, завершить работу алгоритма.");
            while (queue.Count != 0)
            {
                Node<T> current = queue.Dequeue();//Первый
                if (current == null)
                {
                    continue;
                }
                OutToConsole("BFSearching", $"3 Вынуть из очереди элемент. Значение:{current.Value}");

                if (current.Value.Equals(value))
                {
                    OutToConsole("BFSearching", "4 Если элемент искомый, вернуть его и завершить работу алгоритма.");
                    return current;
                }
                OutToConsole("BFSearching", $"5 Положить все дочерние узлы элемента в очередь. R:{current.RightDescendant?.Value} L:{current.LeftDescendant?.Value}");
                //Добавление в конец
                queue.Enqueue(current.RightDescendant);
                queue.Enqueue(current.LeftDescendant);
                OutToConsole("BFSearching", "6 Вернуться к пункту 2.");
                continue;
            }
            OutToConsole("BFSearching", "2 Если очередь пуста, завершить работу алгоритма. Очередь пуста");
            return null;
        }

        /// <summary>
        /// (deep-first search) — поиск в глубину.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Искомое значение</returns>
        public Node<T> DFSearching(T value)
        {
            if (_root == null)
            {
                throw new ArgumentNullException("Дерево не содержит значений");
            }

            OutToConsole("DFSearching", "1 Положить корень дерева в стек.");
            Stack<Node<T>> queue = new Stack<Node<T>>();//LIFO
            queue.Push(_root);//Кладем на верху

            OutToConsole("DFSearching", "2 Если стек пуст, завершить работу алгоритма.");
            while (queue.Count != 0)
            {                
                Node<T> current = queue.Pop();//Берем сверху                

                if (current == null)
                {
                    continue;
                }
                OutToConsole("DFSearching", $"3 Вынуть из стека элемент. Значение:{current.Value}");

                if (current.Value.Equals(value))
                {
                    OutToConsole("DFSearching", "4 Если элемент искомый, вернуть его и завершить работу алгоритма.");
                    return current;
                }
                OutToConsole("DFSearching", $"5 Положить все дочерние узлы элемента в стек. R:{current.RightDescendant?.Value} L:{current.LeftDescendant?.Value}"); 
                queue.Push(current.RightDescendant == null ? null : current.RightDescendant) ;
                queue.Push(current.LeftDescendant == null ? null : current.LeftDescendant);

                OutToConsole("DFSearching", "6 Вернуться к пункту 2."); 
                continue;
            }
            OutToConsole("DFSearching", "2 Если стек пуст, завершить работу алгоритма. Стек пуст");
            return null;
        }

        private void OutToConsole(string method, string step)
        {
            Console.WriteLine($"[{method}]: {step}");
        }


    }
}
