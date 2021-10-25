using System;
using Algorithms.LinkedList;

namespace Algorithms
{
    public class MyLinkedList : ILinkedList
    {
        private int _count;
        private Node _head;

        public MyLinkedList()
        {
            _head = null;
        }

        public void AddNode(int value)
        {
            if (_head == null)
            {
                _head = new Node() { Value = value, NextNode = null, PrevNode = null };
                _count++;
                return;
            }

            Node current = _head;
            while (current.NextNode != null)
            {
                current = current.NextNode;
            }

            _count++;
            current.NextNode = new Node() { Value = value, NextNode = null, PrevNode = current };
        }

        public void AddNodeAfter(Node node, int value)
        {
            if (_head == null)
            {
                throw new Exception("Linked List is empty");
            }

            Node current = _head;
            while (current != null)
            {
                if (current == node)
                {                    
                    Node newNode = new Node() { Value = value, NextNode = current.NextNode, PrevNode = current };
                    Node nextNode = current?.NextNode;
                    if (nextNode != null)
                    {
                        nextNode.PrevNode = newNode;
                    }                    
                    current.NextNode = newNode;
                    
                    _count++;
                    return;
                }
                current = current.NextNode;
            }

            throw new Exception("Node not found");
        }

        public Node FindNode(int searchValue)
        {
            if (_head == null)
            {
                throw new Exception("Linked List is empty");
            }

            Node current = _head;
            while (current != null)
            {
                if (current.Value == searchValue)
                {
                    return current;
                }
                current = current.NextNode;
            }

            return current;
        }

        public int GetCount()
        {
            return _count;
        }

        public void RemoveNode(int index)
        {
            if (_count == 0)
            {
                throw new Exception("Linked List is empty");
            }

            if (index > _count)
            {
                throw new ArgumentOutOfRangeException();
            }

            Node current = _head;
            int i = 0;
            while (current != null && i < _count)
            {
                if (i == index-1)
                {
                    ResetLinks(current);
                    _count--;
                    break;
                }

                current = current.NextNode;
                i++;
            }
        }

        public void RemoveNode(Node node)
        {
            if (_count == 0)
            {
                throw new Exception("Linked List is empty");
            }

            Node current = _head;
            while (current != null)
            {
                if (current == node)
                {
                    ResetLinks(current);
                    _count--;
                    return;
                }
                current = current.NextNode;
            }

            throw new Exception("Node not found");
        }

        private void ResetLinks(Node currentNode)
        {
            if (currentNode?.PrevNode != null)//TAIL
            {
                if (currentNode?.NextNode != null)//MID
                {
                    Node prev = currentNode.PrevNode;
                    Node next = currentNode.NextNode;

                    prev.NextNode = next;
                    next.PrevNode = prev;

                    //current.PrevNode.NextNode = current.NextNode;                            
                }
                else//TAIL
                {
                    Node prev = currentNode.PrevNode;
                    prev.NextNode = null;
                }
            }
            else//HEAD
            {
                if (currentNode?.NextNode != null)//Count>1
                {
                    //Node prev = current.PrevNode;
                    Node next = currentNode.NextNode;

                    //prev.NextNode = next;
                    next.PrevNode = null;

                    currentNode.NextNode.PrevNode = null;
                }
                else//Only HEAD
                {
                    _head = null;
                }
            }
        }
    }
}
