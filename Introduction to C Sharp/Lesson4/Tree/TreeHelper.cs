using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4.Tree
{
    public static class TreeHelper
    {
        public static NodeInfo[] GetTreeInLine(ITree tree)
        {
            Queue<NodeInfo> buffer = new Queue<NodeInfo>();//FIFO
            List<NodeInfo> returnArray = new List<NodeInfo>();

            if (tree.GetRoot() == null)
            {
                throw new ArgumentNullException();
            }

            NodeInfo root = new NodeInfo() { Node = tree.GetRoot() };

            buffer.Enqueue(root);//Положили голову

            while (buffer.Count != 0)
            {
                NodeInfo element = buffer.Dequeue();//Берем элемент, удаляем из очереди и возвращаем
                returnArray.Add(element);

                int depth = element.Depth + 1;//1: 0 + 1

                if (element.Node.Left != null)
                {
                    NodeInfo left = new NodeInfo()
                    {
                        Node = element.Node.Left,
                        Depth = depth
                    };

                    buffer.Enqueue(left);
                }
                if (element.Node.Right != null)
                {
                    NodeInfo right = new NodeInfo()
                    {
                        Node = element.Node.Right,
                        Depth = depth
                    };

                    buffer.Enqueue(right);
                }
            }

            return returnArray.ToArray();
        }
    }
}
