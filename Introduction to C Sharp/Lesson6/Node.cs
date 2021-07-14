using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    public class Node
    {
        public string Value { get; set; }
        public List<Edge> Edges { get; set; }

        public Node(string value)
        {
            Value = value;
            Edges = new List<Edge>();
        }
    }
}
