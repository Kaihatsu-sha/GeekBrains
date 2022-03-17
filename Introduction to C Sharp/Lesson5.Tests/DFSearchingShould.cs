using System;
using NUnit.Framework;
using Lesson5.Tree;

namespace Lesson5.Tests
{
    [TestFixture]
    public class DFSearchingShould
    {
        BinaryTree<int> _tree;

        [SetUp]
        public void Setup()
        {
            _tree = new BinaryTree<int>(BinaryTree<int>.CompareInt);
            _tree.Add(21);
            _tree.Add(9);
            _tree.Add(23);
            _tree.Add(20);
            _tree.Add(29);
            _tree.Add(34);
            _tree.Add(2);
            _tree.Add(12);
            _tree.Add(19);
        }

        [Test]
        public void CorrectSearch_value23()
        {
            //arrange
            int expected = 23;
            Node<int> node = _tree.DFSearching(23);

            //act
            int actual = node.Value;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CorrectSearch_value2()
        {
            //arrange
            int expected = 2;
            Node<int> node = _tree.DFSearching(2);

            //act
            int actual = node.Value;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CorrectSearch_value19()
        {
            //arrange
            int expected = 19;
            Node<int> node = _tree.DFSearching(19);

            //act
            int actual = node.Value;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SearchNonExistentValue()
        {
            //arrange
            Node<int> expected = null;
            Node<int> node = _tree.DFSearching(100);

            //act
            Node<int> actual = node;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SearchInNullTree()
        {
            //arrange
            BinaryTree<int> tree = new BinaryTree<int>(BinaryTree<int>.CompareInt);

            //act
            //assert
            Assert.Throws<ArgumentNullException>(() => { Node<int> node = tree.DFSearching(100); });
        }
    }
}
