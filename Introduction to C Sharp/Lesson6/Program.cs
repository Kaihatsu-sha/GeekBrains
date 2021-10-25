using System;
using System.Collections.Generic;

namespace Lesson6
{
    class Program
    {
        static void Main(string[] args)
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

            edges = new List<Edge>(){new Edge() { Node = nodeA }};
            nodeC.Edges.AddRange(edges);

            edges = new List<Edge>() { new Edge() { Node = nodeF } };
            nodeH.Edges.AddRange(edges);

            Graph graph= new Graph();
            List<Node> nodes = new List<Node>() { nodeA, nodeB, nodeC, nodeD, nodeE, nodeF, nodeG, nodeH, nodeI };
            graph.Nodes = nodes;

            graph.BFSearching("H");
            graph.DFSearching("H1");

            Console.ReadKey();
        }
    }
}
