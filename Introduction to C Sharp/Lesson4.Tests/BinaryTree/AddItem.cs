using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lesson4.Tree;

namespace Lesson4.Tests.BinaryTree
{
    [TestClass]
    public class AddItem
    {
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void Add1_out1()
        {
            //arrange
            int expected = 1;
            //actual
            Lesson4.Tree.BinaryTree tree = new BinaryTree()
            int actual = massiv.Length;
            //assert
            Assert.AreEqual<int>(expected, actual);
        }

        ////arrange
        //int expected = 3;
        ////actual 
        //PointStruct<float>[] massiv = MockData.GetFloatStruct(3);
        //int actual = massiv.Length;
        ////assert
        //Assert.AreEqual<int>(expected, actual);
    }
}
