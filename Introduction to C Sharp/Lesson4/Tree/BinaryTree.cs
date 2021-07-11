using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4.Tree
{
    public class BinaryTree : ITree
    {
        private TreeNode _root;

        public void AddItem(int value)
        {
            if (_root == null)
            {
                _root = new TreeNode() { Value = value };
                return;
            }

            TreeNode currentNode = _root;
            TreeNode parent = _root;
            while (true)
            {
                if (currentNode.Value == value)
                {
                    throw new ArgumentException("Дерево уже содержит данное значение");
                }

                if (currentNode.Value < value)//Right 
                {
                    if (currentNode.Right != null)
                    {
                        currentNode = currentNode.Right;
                        parent = currentNode;
                        continue;
                    }
                    else
                    {
                        currentNode.Right = new TreeNode() { Value = value, Parent = parent };
                        break;
                    }
                }

                if (value < currentNode.Value)//Left
                {
                    if (currentNode.Left != null)
                    {
                        currentNode = currentNode.Left;
                        parent = currentNode;
                        continue;
                    }
                    else
                    {
                        currentNode.Left = new TreeNode() { Value = value, Parent = parent };
                        break;
                    }
                }
            }

        }

        public TreeNode GetNodeByValue(int value)
        {
            GetRoot();

            TreeNode currentNode = _root;

            while (true)
            {
                if (currentNode.Value == value)
                {
                    return currentNode;
                }

                if (currentNode.Value < value)//Right
                {
                    if (currentNode.Right != null)
                    {
                        currentNode = currentNode.Right;
                        continue;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }

                if (currentNode.Value > value)//Left
                {
                    if (currentNode.Left != null)
                    {
                        currentNode = currentNode.Left;
                        continue;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

        public TreeNode GetRoot()
        {
            if (_root == null)
            {
                throw new ArgumentNullException("Пустое дерево");
            }

            return _root;
        }

        public void PrintTree()
        {
            GetRoot();//Проверка на null
            (int maxLengthWord, int heightTree) = GettingParams();

            int SPACE = 1;
            int maxWidth = (int)Math.Pow(2, heightTree - 1) * // кол-во слов
                           (maxLengthWord + SPACE * 2); // умножить на их длину и пробелы срава и слева

            PrintRow(new List<TreeNode>() { GetRoot() }, maxLengthWord, heightTree, maxWidth);
        }

        void PrintRow(List<TreeNode> currenLst, int maxLengthWord, int heightTree, int maxWidth)
        {
            // Отступ слева и справа между словами в текущей строке / высоте
            int space = (maxWidth - currenLst.Count * maxLengthWord) / (currenLst.Count * 2);
            Console.CursorLeft = 1;

            // Прорисовка узлов
            for (int i = 0; i < currenLst.Count; i++)
            {
                Console.CursorLeft += space;
                // Если данного узла нет, сдвигаем позицию
                if (currenLst[i] == null)
                {
                    Console.CursorLeft += maxLengthWord + space;
                    continue;
                }

                string value = currenLst[i].Value.ToString();

                // Если слово в левой половине - смещается левее, если в правой - правее
                // Приведение к double - только для первой строки / высоты / корня
                int half = i < (double)currenLst.Count / 2 ? 0 : 1;
                // Позиция слова слева
                int positionLeftValue = Console.CursorLeft + ((maxLengthWord - value.Length + half) / 2);

                for (int j = 0, k = 0; j < maxLengthWord; j++)
                {
                    if (Console.CursorLeft >= positionLeftValue && k < value.Length)
                        Console.Write(value[k++]);
                    else
                        Console.Write(' ');
                }
                Console.CursorLeft += space;
            }
            Console.WriteLine();
            // Если все дерево прорисовано - выходим из рекурсии
            if (Math.Pow(2, heightTree - 1) == currenLst.Count)
                return;

            // Прорисовка 'веток', то есть знаков  /  и  \
            // Теперь space отвечает за отступы между данными символами (ветками)
            space = maxWidth / (currenLst.Count * 8);
            // Выбор слеша (ветки)
            // true /
            // false \
            bool slashLeft = true;
            for (int i = space * 3, j = -1; i < maxWidth - space * 3 + 1; i += space * (slashLeft ? 6 : 2))
            {
                if (slashLeft)
                    j++;
                Console.CursorLeft = i + (slashLeft ? 1 : 0);

                if (currenLst[j] != null)
                {
                    if (slashLeft && currenLst[j].Left != null)
                        Console.Write('/');
                    else if (!slashLeft && currenLst[j].Right != null)
                        Console.Write('\\');
                }
                slashLeft = !slashLeft;
            }
            Console.WriteLine();

            // Создание списка с узлами, которые идут ниже
            // Задаем Capacity в 2 раза больше, чем у текущего списка
            List<TreeNode> newLst = new List<TreeNode>(currenLst.Count * 2);
            foreach (var node in currenLst)
            {
                newLst.Add(node == null ? null : (node.Left ?? null));
                newLst.Add(node == null ? null : (node.Right ?? null));
            }
            PrintRow(newLst, maxLengthWord, heightTree, maxWidth);
        }

        private (int maxLengthWord, int heightTree) GettingParams()
        {
            int heightTree = 1;
            int maxLengthWord = 1;

            Foo(GetRoot(), 1);

            void Foo(TreeNode node, int height)
            {
                if (height > heightTree)
                {
                    heightTree = height;
                }
                if (node.Value.ToString().Length > maxLengthWord)
                {
                    maxLengthWord = node.Value.ToString().Length;
                }
                if (node.Left != null)
                {
                    Foo(node.Left, height + 1);
                }
                if (node.Right != null)
                {
                    Foo(node.Right, height + 1);
                }
            }

            return (maxLengthWord, heightTree);
        }

        public void RemoveItem(int value)
        {
            GetRoot();

            TreeNode currentNode = _root;

            while (true)
            {
                if (currentNode.Value == value)
                {
                    if (currentNode.Left == null && currentNode.Right == null)//Leaf
                    {
                        if (currentNode == _root)
                        {
                            _root = null;
                            return;
                        }

                        TreeNode parent = currentNode.Parent;
                        if (parent.Right.Equals(currentNode))
                        {
                            parent.Right = null;
                        }
                        else
                        {
                            parent.Left = null;
                        }
                        currentNode.Dispose();
                        return;
                    }

                    if (currentNode.Left == null || currentNode.Right == null)//One Descendant
                    {
                        if (currentNode == _root)
                        {
                            if (currentNode.Right != null)
                            {
                                _root = currentNode.Right;
                                currentNode.Right.Parent = null;
                            }
                            else
                            {
                                _root = currentNode.Left;
                                currentNode.Left.Parent = null;
                            }
                        }

                        TreeNode parent = currentNode.Parent;
                        if (currentNode.Right != null)
                        {
                            parent.Right = currentNode.Right;
                            currentNode.Right.Parent = parent;
                        }
                        else
                        {
                            parent.Left = currentNode.Right;
                            currentNode.Left.Parent = parent;
                        }
                        return;
                    }
                    else//Two Descendants
                    {
                        TreeNode rightNodes = currentNode.Right;
                        TreeNode nodeMinValue = rightNodes;
                        while (rightNodes.Left != null)
                        {
                            nodeMinValue = rightNodes.Left;
                            rightNodes = rightNodes.Left;
                        }

                        currentNode.Value = nodeMinValue.Value;
                        nodeMinValue.Dispose();
                    }
                    return;
                }

                if (currentNode.Value < value)//Right
                {
                    if (currentNode.Right != null)
                    {
                        currentNode = currentNode.Right;
                        continue;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                if (currentNode.Value > value)//Left
                {
                    if (currentNode.Left != null)
                    {
                        currentNode = currentNode.Left;
                        continue;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

    }
}
