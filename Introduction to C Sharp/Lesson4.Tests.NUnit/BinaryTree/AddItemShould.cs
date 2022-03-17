using NUnit.Framework;
using Lesson4.Tree;
using System;

namespace Lesson4.Tests.NUnit.BinaryTree
{
    [TestFixture]
    public class AddItemShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void Add_in1_out0(int value)
        {
            //arrange
            int expected = 0;

            Tree.BinaryTree tree = new Lesson4.Tree.BinaryTree();
            tree.AddItem(value);
            NodeInfo[] info = TreeHelper.GetTreeInLine(tree);

            //act
            int actual = info[0].Depth;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_in0_outExecption()
        {
            //arrange
            Tree.BinaryTree tree = new Lesson4.Tree.BinaryTree();

            //act

            //assert
            Assert.Throws<ArgumentNullException>(() => { NodeInfo[] info = TreeHelper.GetTreeInLine(tree); });
        }

        [Test]
        public void Add_in3_out1()
        {
            //arrange
            int expected = 1;

            Tree.BinaryTree tree = new Lesson4.Tree.BinaryTree();
            tree.AddItem(3);
            tree.AddItem(2);
            tree.AddItem(4);
            NodeInfo[] info = TreeHelper.GetTreeInLine(tree);

            //act
            int actual = info[1].Depth;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_in3_outException()
        {
            //arrange
            Tree.BinaryTree tree = new Lesson4.Tree.BinaryTree();
            tree.AddItem(3);
            tree.AddItem(2);

            //act
            //assert
            Assert.Throws<ArgumentException>(() => { tree.AddItem(3); });
        }

        [Test]
        public void In3Node_outRoot3()
        {
            //arrange
            int expected = 3;

            Tree.BinaryTree tree = new Tree.BinaryTree();
            tree.AddItem(3);
            tree.AddItem(2);
            tree.AddItem(4);

            //act
            int actualRight = tree.GetRoot().Right.Parent.Value;
            int actualLeft = tree.GetRoot().Left.Parent.Value;

            //assert
            Assert.AreEqual(expected, actualRight);
            Assert.AreEqual(expected, actualLeft);
        }

        [Test]
        public void In6Node_outRootLeft3()
        {
            //arrange
            int expected = 3;

            Tree.BinaryTree tree = new Tree.BinaryTree();
            tree.AddItem(5);
            tree.AddItem(3);//L
            tree.AddItem(4);
            tree.AddItem(2);
            tree.AddItem(8);//R
            tree.AddItem(6);
            tree.AddItem(7);

            TreeNode leftNode = tree.GetRoot().Left;
            //act
            int actualRight = leftNode.Right.Parent.Value;
            int actualLeft = leftNode.Left.Parent.Value;

            //assert
            Assert.AreEqual(expected, actualRight);
            Assert.AreEqual(expected, actualLeft);
        }
    }
}
