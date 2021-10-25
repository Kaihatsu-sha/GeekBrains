using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    public class Graph
    {
        private List<Node> _nodes;
        public List<Node> Nodes { get { return _nodes; } set { _nodes = value; } }

        public Graph()
        {
            _nodes = new List<Node>();
        }

        public Node BFSearching(string serchValue)//Обход в ширину
        {
            if (_nodes.Count == 0)
            {
                throw new ArgumentNullException("Граф пуст");
            }

            Queue<Node> wavefront = new Queue<Node>();//Вершины в которые волна пришла
            List<Node> waveGone = new List<Node>();//Вершины из которых волна ушла.

            wavefront.Enqueue(_nodes[0]);//1. Положить корень дерева в очередь
            OutToConsole("BFSearching", "Кладем в очередь значение: " + _nodes[0].Value);
            while (wavefront.Count > 0)//2. Если очередь пуста, завершить работу алгоритма.
            {
                Node current = wavefront.Dequeue();//Извлекаем сначала очереди //3. Вынуть из очереди элемент.

                OutToConsole("BFSearching", "Извлеченное значение: " + current.Value);

                if (current.Value == serchValue)
                {
                    OutToConsole("BFSearching", "Найдено, искоемое значение: " + current.Value);
                    return current;//4. Если элемент искомый, вернуть его и завершить работу алгоритма.
                }

                waveGone.Add(current);
                foreach (Edge edge in current.Edges)
                {
                    if (!waveGone.Contains(edge.Node) && !wavefront.Contains(edge.Node))//Добавляем вершины в которые волна еще не попала. && Добавляем единожды
                    {
                        OutToConsole("BFSearching", "Добавление значения: " + edge.Node.Value);
                        wavefront.Enqueue(edge.Node);//5. Положить все дочерние узлы элемента в очередь.
                    }
                }
                //6. Вернуться к пункту 2.
            }
            OutToConsole("BFSearching", "Значение не найдено.");
            return null;
        }

        public Node DFSearching(string serchValue)//Обход в глубину
        {
            if (_nodes.Count == 0)
            {
                throw new ArgumentNullException("Граф пуст");
            }

            Stack<Node> nodesPath = new Stack<Node>();//Вершины пути
            List<Node> nodesGone = new List<Node>();//Пройденные вершины

            nodesPath.Push(_nodes[0]);//1. Положить вершину в стек
            OutToConsole("DFSearching", "Кладем в стек значение: " + _nodes[0].Value);
            string path = "";
            Node newPath = null;
            Node lastNode = null;
            while (nodesPath.Count > 0)//2. Если стек пуст, завершить работу алгоритма.
            {
                Node current = nodesPath.Pop();//Извлекаем с вершины стека
                if (nodesGone.Contains(current))//Если вершину прошли, сохраняем
                {
                    newPath = current;
                    continue;
                }
                nodesGone.Add(current);
                if (newPath != null && newPath != lastNode)//Если возвращались к пройденным вершинам
                {
                    path += $"/{newPath.Value}->" + current.Value;//Новый пусть 
                }
                else
                {
                    newPath = null;
                    path += "->" + current.Value;
                }
                lastNode = current;//Сохранение последней вершины
                OutToConsole("DFSearching", "Извлеченное значение: " + current.Value);

                if (current.Value == serchValue)
                {
                    OutToConsole("DFSearching", "Найдено, искоемое значение: " + current.Value);
                    return current;//4. Если элемент искомый, вернуть его и завершить работу алгоритма.
                }

                foreach (Edge edge in current.Edges)
                {
                    nodesPath.Push(current);//Добавляем текущие вершины для возврата и просмотра не пройденных путей

                    if (!nodesGone.Contains(edge.Node))//Добавляем не пройденные вершины
                    {
                        OutToConsole("DFSearching", "Добавление значения: " + edge.Node.Value);
                        nodesPath.Push(edge.Node);//5. Положить все дочерние узлы элемента в очередь. //Добавляем вершину
                    }
                }
                //6. Вернуться к пункту 2.
            }
            OutToConsole("DFSearching", "Значение не найдено.");

            Console.WriteLine(path);//Вывод пути обхода
            return null;
        }

        public void OutToConsole(string step, string text)
        {
            Console.WriteLine($"[{step}] : {text}");
        }
    }
}