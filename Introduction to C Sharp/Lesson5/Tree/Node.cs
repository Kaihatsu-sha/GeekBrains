using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.Tree
{
    public class Node <T> where T : struct
    {
        public Node<T> Parent { get; set; }
        public Node<T> LeftDescendant { get; set; }
        public Node<T> RightDescendant { get; set; }
        public T Value { get; set; }

        public Node(T value)
        {
            Value = value;
            //Ссылочные типо по умолчанию null
        }
    }
}
