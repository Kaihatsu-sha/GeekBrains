using NUnit.Framework;
using Lesson4.Tree;
using System;

namespace Lesson4.Tests.NUnit.BinaryTree
{
    [TestFixture]
    public class GetNodeByValueShould
    {
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void AssertTreeNodeValue_Root(int value)
        {
            //arrange
            int expected = value;

            Tree.BinaryTree tree = new Lesson4.Tree.BinaryTree();
            tree.AddItem(value);
            TreeNode node = tree.GetNodeByValue(value);

            //act
            int actual = node.Value;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void In2Items_outValue4()
        {
            //arrange
            int expected = 4;

            Tree.BinaryTree tree = new Tree.BinaryTree();
            tree.AddItem(2);
            tree.AddItem(4);

            TreeNode node = tree.GetNodeByValue(4);
            
            //act
            int actual = node.Value;

            //assert
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void In4Items_outValue3()
        {
            //arrange
            int expected = 3;

            Tree.BinaryTree tree = new Tree.BinaryTree();
            tree.AddItem(2);
            tree.AddItem(1);
            tree.AddItem(8);
            tree.AddItem(3);

            TreeNode node = tree.GetNodeByValue(3);

            //act
            int actual = node.Value;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void In3Items_outException()
        {
            //arrange
            Tree.BinaryTree tree = new Tree.BinaryTree();
            tree.AddItem(2);
            tree.AddItem(8);
            tree.AddItem(3);

            //assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { TreeNode node = tree.GetNodeByValue(4); });
        }

    }
}
