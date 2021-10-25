using NUnit.Framework;
using Lesson6;
using System.Collections.Generic;
using System;

namespace Lesson6.Tests
{
    public class BFSearchingShould
    {
        private Graph _graph;
        private Node _nodeA;
        private Node _nodeI;

        [SetUp]
        public void Setup()
        {
            /*    C D-E 
             *  /   | |
             * A- B-G |
             *  \ |  \|
            *     I   F-H
            */
            Node nodeA = new Node("A");
            Node nodeB = new Node("B");
            Node nodeC = new Node("C");
            Node nodeD = new Node("D");
            Node nodeE = new Node("E");
            Node nodeF = new Node("F");
            Node nodeG = new Node("G");
            Node nodeH = new Node("H");
            Node nodeI = new Node("I");

            List<Edge> edges = new List<Edge>(){
                new Edge() { Node = nodeB },
                new Edge() { Node = nodeC },
                new Edge() { Node = nodeI }};
            nodeA.Edges.AddRange(edges);

            edges = new List<Edge>(){
                new Edge() { Node = nodeA },
                new Edge() { Node = nodeG },
                new Edge() { Node = nodeI }};
            nodeB.Edges.AddRange(edges);

            edges = new List<Edge>(){
                new Edge() { Node = nodeB },
                new Edge() { Node = nodeD },
                new Edge() { Node = nodeF }};
            nodeG.Edges.AddRange(edges);

            edges = new List<Edge>(){
                new Edge() { Node = nodeE },
                new Edge() { Node = nodeG }};
            nodeD.Edges.AddRange(edges);

            edges = new List<Edge>(){
                new Edge() { Node = nodeD },
                new Edge() { Node = nodeF }};
            nodeE.Edges.AddRange(edges);

            edges = new List<Edge>(){
                new Edge() { Node = nodeA },
                new Edge() { Node = nodeB }};
            nodeI.Edges.AddRange(edges);

            edges = new List<Edge>(){
                new Edge() { Node = nodeH },
                new Edge() { Node = nodeE }};
            nodeF.Edges.AddRange(edges);

            edges = new List<Edge>() { new Edge() { Node = nodeA } };
            nodeC.Edges.AddRange(edges);

            edges = new List<Edge>() { new Edge() { Node = nodeF } };
            nodeH.Edges.AddRange(edges);

            _graph = new Graph();
            List<Node> nodes = new List<Node>() { nodeA, nodeB, nodeC, nodeD, nodeE, nodeF, nodeG, nodeH, nodeI };
            _graph.Nodes = nodes;

            _nodeA = nodeA;
            _nodeI = nodeI;
        }

        [Test]
        public void ShowException_emptyGraph()
        {
            //arrange
            Graph graph = new Graph();
            //act
            //assert
            Assert.Throws<ArgumentNullException>( () => {graph.BFSearching("A"); });
        }

        [Test]
        public void ReturnedNotNullNode()
        {//Негативный сценарий. Ожидается, что найдет объект которой не включен в граф.

            // Arrange
            Node expected = new Node("Q");

            // Act
            var actual = _graph.BFSearching("Q");

            // Assert
            Assert.AreNotEqual(expected, actual);
        }

        [Test]
        public void ReturnedNullNode()
        {
            // Arrange
            Node expected = null;

            // Act
            var actual = _graph.BFSearching("Q");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnedNodeI()
        {
            // Arrange
            Node expected = _nodeI;

            // Act
            var actual = _graph.BFSearching("I");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnedNodeA()
        {
            // Arrange
            Node expected = _nodeA;

            // Act
            var actual = _graph.BFSearching("A");

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
