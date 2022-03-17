using Lesson5.Tree;
using NUnit.Framework;
using System;

namespace Lesson5.Tests
{
    [TestFixture]
    public class AddShould
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        [TestCase(11)]
        [TestCase(23)]
        public void In1_out1(int value)
        {
            //arrange
            int expected = value;

            BinaryTree<int> tree = new BinaryTree<int>(BinaryTree<int>.CompareInt);
            tree.Add(value);

            Node<int> node = tree.DFSearching(value);

            //act
            int actual = node.Value;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void In0_outExecption()
        {
            //arrange
            BinaryTree<int> tree = new BinaryTree<int>(BinaryTree<int>.CompareInt);

            //act
            //assert
            Assert.Throws<ArgumentNullException>(() => { Node<int> node = tree.DFSearching(10); });
        }

        [Test]
        public void In3_out1()
        {
            //arrange
            int expected = 23;

            BinaryTree<int> tree = new BinaryTree<int>(BinaryTree<int>.CompareInt);
            tree.Add(20);
            tree.Add(29);
            tree.Add(23);

            Node<int> node = tree.DFSearching(23);

            //act
            int actual = node.Value;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void In3_outNull()
        {
            //arrange
            Node<int> expected = null;

            BinaryTree<int> tree = new BinaryTree<int>(BinaryTree<int>.CompareInt);
            tree.Add(20);
            tree.Add(29);
            tree.Add(23);

            //act
            Node<int> actual = tree.DFSearching(100);

            //assert
            Assert.AreEqual(expected, actual);
        }

    }
}
