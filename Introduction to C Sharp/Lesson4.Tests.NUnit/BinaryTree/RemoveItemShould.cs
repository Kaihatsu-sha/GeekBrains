using NUnit.Framework;
using Lesson4.Tree;
using System;

namespace Lesson4.Tests.NUnit.BinaryTree
{
    [TestFixture]
    public class RemoveItemShould
    {
        [Test]
        public void EmpryTree_outException()
        {
            //arrange
            Tree.BinaryTree binaryTree = new Tree.BinaryTree();
            //act
            //assert
            Assert.Throws< ArgumentNullException>(() => binaryTree.RemoveItem(10));
        }

        [Test]
        public void DelRootNode_outException()
        {
            //arrange
            Tree.BinaryTree tree = new Tree.BinaryTree();
            tree.AddItem(3);
            tree.RemoveItem(3);

            //act

            //assert
            Assert.Throws<ArgumentNullException>(() => tree.GetRoot());
        }

        [Test]
        public void DelRightNode_outRootAndLeftNode()
        {
            //arrange
            Tree.BinaryTree tree = new Tree.BinaryTree();
            tree.AddItem(3);
            tree.AddItem(5);
            tree.AddItem(2);
            tree.RemoveItem(5);

            int expectedRoot = 3;
            int expectedLeft = 2;

            //act
            int actualRoot = tree.GetRoot().Value;
            int actualLeft = tree.GetRoot().Left.Value;
            //assert
            Assert.AreEqual(expectedRoot, actualRoot);
            Assert.AreEqual(expectedLeft, actualLeft);
        }

        [Test]
        public void InRootNode_outRootAndLeftNode()
        {
            //arrange
            Tree.BinaryTree tree = new Tree.BinaryTree();
            tree.AddItem(3);
            tree.AddItem(5);
            tree.AddItem(2);
            tree.RemoveItem(3);

            int expectedRoot = 5;
            int expectedLeft = 2;

            //act
            int actualRoot = tree.GetRoot().Value;
            int actualLeft = tree.GetRoot().Left.Value;
            //assert
            Assert.AreEqual(expectedRoot, actualRoot);
            Assert.AreEqual(expectedLeft, actualLeft);
        }

        [Test]
        public void InRootNode_outNewTree()
        {
            //arrange
            Tree.BinaryTree tree = new Tree.BinaryTree();
            tree.AddItem(5);//!
            tree.AddItem(3);//L
            tree.AddItem(7);//R
            tree.AddItem(4);//L-R
            tree.AddItem(2);//L-L
            tree.AddItem(6);//R-L
            tree.AddItem(8);//R-R
            tree.RemoveItem(5);

            int expectedRoot = 6;
            int expectedLeft = 3;
            int expectedRight = 7;

            //act
            int actualRoot = tree.GetRoot().Value;
            int actualLeft = tree.GetRoot().Left.Value;
            int actualRight = tree.GetRoot().Right.Value;
            //assert
            Assert.AreEqual(expectedRoot, actualRoot);
            Assert.AreEqual(expectedLeft, actualLeft);
            Assert.AreEqual(expectedRight, actualRight);
        }

        [Test]
        public void AddingDeleteNode_outNewTree()
        {
            //arrange
            Tree.BinaryTree tree = new Tree.BinaryTree();
            tree.AddItem(5);//!
            tree.AddItem(3);//L
            tree.AddItem(7);//R
            tree.AddItem(4);//L-R
            tree.AddItem(2);//L-L
            tree.AddItem(6);//R-L
            tree.AddItem(8);//R-R
            tree.RemoveItem(5);

            tree.AddItem(5);//L-R-R

            int expectedRoot = 6;
            int expectedLeft = 3;
            int expectedLeftRight = 4;

            //act
            int actualRoot = tree.GetRoot().Value;
            int actualLeft = tree.GetRoot().Left.Value;
            int actualLeftRight = tree.GetRoot().Left.Right.Value;

            //assert
            Assert.AreEqual(expectedRoot, actualRoot);
            Assert.AreEqual(expectedLeft, actualLeft);
            Assert.AreEqual(expectedLeftRight, actualLeftRight);
        }
    }
}
