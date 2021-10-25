using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.LinkedList;

namespace Algorithms.Test
{
    [TestClass]
    public class MyLinkedListTests
    {
        #region AddNode
        [TestMethod]
        public void AddNode_add1Node_outCount1()
        {
            //arrange
            int expected = 1;
            //actual 
            MyLinkedList myList = new MyLinkedList();
            myList.AddNode(1);
            int actual = myList.GetCount();
            //assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void AddNode_add3Node_outCount3()
        {
            //arrange
            int expected = 3;
            //actual 
            MyLinkedList myList = new MyLinkedList();
            myList.AddNode(1);
            myList.AddNode(2);
            myList.AddNode(3);
            int actual = myList.GetCount();
            //assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void AddNode_add2Node_outCount2()
        {
            //arrange
            int expected = 2;
            //actual 
            MyLinkedList myList = new MyLinkedList();
            myList.AddNode(1);
            myList.AddNode(1);
            int actual = myList.GetCount();
            //assert
            Assert.AreEqual<int>(expected, actual);
        }
        [TestMethod]
        public void AddNode_NegativeAdd2Node_outCount0()
        {
            //arrange
            int expected = 0;//Предпологаем что отработает не корректно.
            //actual 
            MyLinkedList myList = new MyLinkedList();
            myList.AddNode(1);
            myList.AddNode(1);
            int actual = myList.GetCount();
            //assert
            Assert.AreEqual<int>(expected, actual);
        }
        #endregion

        #region FindNode
        [TestMethod]
        public void FindNode_FindValue1_outValue1()
        {
            //arrange
            int expected = 1;
            //actual 
            MyLinkedList myList = new MyLinkedList();
            myList.AddNode(1);
            Node fNode = myList.FindNode(1);
            int actual = fNode.Value;
            //assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void FindNode_FindValue2_outValue2()
        {
            //arrange
            int expected = 2;
            //actual 
            MyLinkedList myList = new MyLinkedList();
            myList.AddNode(1);
            myList.AddNode(2);
            Node fNode = myList.FindNode(2);
            int actual = fNode.Value;
            //assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void FindNode_FindValue2_outPrevValue1()
        {
            //arrange
            int expected = 1;
            //actual 
            MyLinkedList myList = new MyLinkedList();
            myList.AddNode(1);
            myList.AddNode(2);
            Node fNode = myList.FindNode(2);
            int actual = fNode.PrevNode.Value;
            //assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void FindNode_FindInEmpryList_outException()
        {
            //arrange
            Node expected = null;
            //actual 
            MyLinkedList myList = new MyLinkedList();
            Node actual = myList.FindNode(1);
            //assert
            Assert.AreEqual<Node>(expected, actual, "Обьект не null");
        }

        [TestMethod]
        public void FindNode_FindValue0_outNull()
        {
            //arrange
            Node expected = null;
            //actual 
            MyLinkedList myList = new MyLinkedList();
            myList.AddNode(1);
            Node actual = myList.FindNode(0);
            //assert
            Assert.AreEqual<Node>(expected, actual, "Обьект не null");
        }
        #endregion

        #region AddNodeAfter
        [TestMethod]
        public void AddNodeAfter_addAfterNode1_outCount2()
        {
            //arrange
            int expected = 2;
            //actual 
            MyLinkedList myList = new MyLinkedList();
            myList.AddNode(1);
            Node fNode = myList.FindNode(1);
            myList.AddNodeAfter(fNode,11);
            int actual = myList.GetCount();
            //assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void AddNodeAfter_addAfterNode1_outCount3()
        {
            //arrange
            int expected = 3;
            //actual 
            MyLinkedList myList = new MyLinkedList();
            myList.AddNode(1);
            myList.AddNode(2);
            Node fNode = myList.FindNode(1);
            myList.AddNodeAfter(fNode, 11);
            int actual = myList.GetCount();
            //assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void AddNodeAfter_addAfterNode1_outNextValue2()
        {
            //arrange
            int expected = 2;
            //actual 
            MyLinkedList myList = new MyLinkedList();
            myList.AddNode(1);
            myList.AddNode(2);
            Node fNode = myList.FindNode(1);
            myList.AddNodeAfter(fNode, 11);
            fNode = myList.FindNode(11);
            int actual = fNode.NextNode.Value;
            //assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void AddNodeAfter_addInEmtyList_outEception()
        {
            //arrange

            //actual 
            MyLinkedList myList = new MyLinkedList();
            Node fNode = null;
            myList.AddNodeAfter(fNode, 11);
            //assert
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void AddNodeAfter_addNullNode_outEception()
        {
            //arrange

            //actual 
            MyLinkedList myList = new MyLinkedList();
            myList.AddNode(1);
            Node fNode = null;
            myList.AddNodeAfter(fNode, 11);
            //assert
        }
        #endregion

        #region RemoveNode(index)
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void RemoveNode_removeOutIndex_outEception()
        {
            //arrange

            //actual 
            MyLinkedList myList = new MyLinkedList();
            myList.AddNode(1);
            myList.RemoveNode(2);
            //assert
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void RemoveNode_removeInEmptyList_outEception()
        {
            //arrange

            //actual 
            MyLinkedList myList = new MyLinkedList();
            myList.RemoveNode(2);
            //assert
        }

        [TestMethod]
        public void RemoveNode_removeHead_outCount1()
        {
            //arrange
            int expected = 1;
            //actual 
            MyLinkedList myList = new MyLinkedList();
            myList.AddNode(1);
            myList.AddNode(2);
            myList.RemoveNode(1);
            int actual = myList.GetCount();
            //assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void RemoveNode_removeMiddleNode_outCount2()
        {
            //arrange
            int expected = 2;
            //actual 
            MyLinkedList myList = new MyLinkedList();
            myList.AddNode(1);
            myList.AddNode(2);
            myList.AddNode(3);
            myList.RemoveNode(2);
            int actual = myList.GetCount();
            //assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void RemoveNode_RemoveTail_outCount2()
        {
            //arrange
            int expected = 2;
            //actual 
            MyLinkedList myList = new MyLinkedList();
            myList.AddNode(1);
            myList.AddNode(2);
            myList.AddNode(3);
            myList.RemoveNode(3);
            int actual = myList.GetCount();
            //assert
            Assert.AreEqual<int>(expected, actual);
        }
        #endregion

        #region RemoveNode(Node)
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void RemoveNodeByNode_notFoundNode_outEception()
        {
            //arrange

            //actual 
            MyLinkedList myList = new MyLinkedList();
            myList.AddNode(1);
            Node fNode = new Node() { Value = 2 };
            myList.RemoveNode(fNode);
            //assert
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void RemoveNodeByNode_removeInEmptyList_outEception()
        {
            //arrange

            //actual 
            MyLinkedList myList = new MyLinkedList();
            Node fNode = new Node() { Value = 1 };
            myList.RemoveNode(fNode);
            //assert
        }

        [TestMethod]
        public void RemoveNodeByNode_removeHead_outCount1()
        {
            //arrange
            int expected = 1;
            //actual 
            MyLinkedList myList = new MyLinkedList();
            myList.AddNode(1);
            myList.AddNode(2);
            Node fNode = myList.FindNode(1);
            myList.RemoveNode(fNode);
            int actual = myList.GetCount();
            //assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void RemoveNodeByNode_removeMiddleNode_outCount2()
        {
            //arrange
            int expected = 2;
            //actual 
            MyLinkedList myList = new MyLinkedList();
            myList.AddNode(1);
            myList.AddNode(2);
            myList.AddNode(3);
            Node fNode = myList.FindNode(2);
            myList.RemoveNode(fNode);
            int actual = myList.GetCount();
            //assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void RemoveNodeByNode_RemoveTail_outCount2()
        {
            //arrange
            int expected = 2;
            //actual 
            MyLinkedList myList = new MyLinkedList();
            myList.AddNode(1);
            myList.AddNode(2);
            myList.AddNode(3);
            Node fNode = myList.FindNode(3);
            myList.RemoveNode(fNode);
            int actual = myList.GetCount();
            //assert
            Assert.AreEqual<int>(expected, actual);
        }
        #endregion

        #region GetCount
        [TestMethod]
        public void GetCount_emptyList_out0()
        {
            //arrange
            int expected = 0;
            //actual 
            MyLinkedList myList = new MyLinkedList();
            int actual = myList.GetCount();
            //assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void GetCount_add3Node_out3()
        {
            //arrange
            int expected = 3;
            //actual 
            MyLinkedList myList = new MyLinkedList();
            myList.AddNode(1);
            myList.AddNode(2);
            myList.AddNode(3);
            int actual = myList.GetCount();
            //assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void GetCount_add3NodeandRemove1_out2()
        {
            //arrange
            int expected = 2;
            //actual 
            MyLinkedList myList = new MyLinkedList();
            myList.AddNode(1);
            myList.AddNode(2);
            myList.AddNode(3);
            Node fNode = myList.FindNode(1);
            myList.RemoveNode(fNode);
            int actual = myList.GetCount();
            //assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void GetCount_add3NodeRemove1NodeAdd2Node_out4()
        {
            //arrange
            int expected = 4;
            //actual 
            MyLinkedList myList = new MyLinkedList();
            myList.AddNode(1);
            myList.AddNode(2);
            myList.AddNode(3);
            Node fNode = myList.FindNode(3);
            myList.RemoveNode(fNode);
            fNode = myList.FindNode(2);
            myList.AddNodeAfter(fNode,21);
            myList.AddNodeAfter(fNode, 22);
            int actual = myList.GetCount();
            //assert
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void GetCount_add3NodeRemove3Node_out0()
        {
            //arrange
            int expected = 0;
            //actual 
            MyLinkedList myList = new MyLinkedList();
            myList.AddNode(1);
            myList.AddNode(2);
            myList.AddNode(3);
            Node fNode = myList.FindNode(3);
            myList.RemoveNode(fNode);
            fNode = myList.FindNode(2);
            myList.RemoveNode(fNode);
            fNode = myList.FindNode(1);
            myList.RemoveNode(fNode);
            int actual = myList.GetCount();
            //assert
            Assert.AreEqual<int>(expected, actual);
        }
        #endregion
    }
}
