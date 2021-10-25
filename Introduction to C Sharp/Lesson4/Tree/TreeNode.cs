using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4.Tree
{
    public class TreeNode: IDisposable
    {
        public int Value { get; set; }
        public TreeNode Parent { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public void Dispose()
        {
            if (Parent != null)
            {
                if (Parent.Left != null && Parent.Left.Equals(this))
                {
                    Parent.Left = null;
                }
                if (Parent.Right != null && Parent.Right.Equals(this))
                {
                    Parent.Right = null;
                }
            }

            Parent = null;
            Left = null;
            Right = null;
        }

        public override bool Equals(object obj)
        {
            TreeNode node = obj as TreeNode;
            if (node == null)
            {
                return false;
            }

            return node.Value == Value;
        }
    }
}
