using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms;

namespace Algorithms.Tests
{
    [TestClass]
    public class BechmarkClassTests
    {
        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void PointDistanceClassFloat_inNewClassNull_outExecption()
        {
            //arrange
            //actual 
            BechmarkClass bClass = new BechmarkClass();
            var ss = bClass.PointDistance(new PointClass<float>(), null);
            //assert
        }
        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void PointDistanceClassFloat_inNullNewClass_outExecption()
        {
            //arrange
            //actual 
            BechmarkClass bClass = new BechmarkClass();
            var ss = bClass.PointDistance(null, new PointClass<float>());
            //assert
        }
        [TestMethod]
        public void PointDistanceClassFloat_in2_out2()
        {
            //arrange
            float expected = 2;
            //actual 
            BechmarkClass bClass = new BechmarkClass();
            PointClass<float> p1 = new PointClass<float>() { PointX = 4, PointY = 0 };
            PointClass<float> p2 = new PointClass<float>() { PointX = 2, PointY = 0 };
            
            float actual = bClass.PointDistance(p1, p2);
            //assert
            Assert.AreEqual<float>(expected, actual);
        }
        [TestMethod]
        public void PointDistanceClassFloat_in3_out3()
        {
            //arrange
            float expected = 3;
            //actual 
            BechmarkClass bClass = new BechmarkClass();
            PointClass<float> p1 = new PointClass<float>() { PointX = 6, PointY = 0 };
            PointClass<float> p2 = new PointClass<float>() { PointX = 3, PointY = 0 };

            float actual = bClass.PointDistance(p1, p2);
            //assert
            Assert.AreEqual<float>(expected, actual);
        }
        [TestMethod]
        public void PointDistanceClassFloat_in0_out0()
        {
            //arrange
            float expected = 0;
            //actual 
            BechmarkClass bClass = new BechmarkClass();
            PointClass<float> p1 = new PointClass<float>() { PointX = 0, PointY = 0 };
            PointClass<float> p2 = new PointClass<float>() { PointX = 0, PointY = 0 };

            float actual = bClass.PointDistance(p1, p2);
            //assert
            Assert.AreEqual<float>(expected, actual);
        }


        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void PointDistanceStructDouble_inNewClassNull_outExecption()
        {
            //arrange
            //actual 
            BechmarkClass bClass = new BechmarkClass();
            var ss = bClass.PointDistance(new PointStruct<float>(), null);
            //assert
        }
        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void PointDistanceStructDouble_inNullNewClass_outExecption()
        {
            //arrange
            //actual 
            BechmarkClass bClass = new BechmarkClass();
            var ss = bClass.PointDistance(new PointStruct<float>(), null);
            //assert
        }
        [TestMethod]
        public void PointDistanceStructDouble_in2_out2()
        {
            //arrange
            float expected = 2;
            //actual 
            BechmarkClass bClass = new BechmarkClass();
            PointStruct<float> p1 = new PointStruct<float>() { PointX = 4, PointY = 0 };
            PointStruct<float> p2 = new PointStruct<float>() { PointX = 2, PointY = 0 };

            float actual = (float)bClass.PointDistance(p1, p2);
            //assert
            Assert.AreEqual<float>(expected, actual);
        }
        [TestMethod]
        public void PointDistanceStructDouble_in3_out3()
        {
            //arrange
            float expected = 3;
            //actual 
            BechmarkClass bClass = new BechmarkClass();
            PointStruct<float> p1 = new PointStruct<float>() { PointX = 6, PointY = 0 };
            PointStruct<float> p2 = new PointStruct<float>() { PointX = 3, PointY = 0 };

            float actual = (float)bClass.PointDistance(p1, p2);
            //assert
            Assert.AreEqual<float>(expected, actual);
        }
        [TestMethod]
        public void PointDistanceStructDouble_in0_out0()
        {
            //arrange
            float expected = 0;
            //actual 
            BechmarkClass bClass = new BechmarkClass();
            PointStruct<float> p1 = new PointStruct<float>() { PointX = 0, PointY = 0 };
            PointStruct<float> p2 = new PointStruct<float>() { PointX = 0, PointY = 0 };

            float actual = (float)bClass.PointDistance(p1, p2);
            //assert
            Assert.AreEqual<float>(expected, actual);
        }


        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void PointDistanceStructShortFloat_inNewClassNull_outExecption()
        {
            //arrange
            //actual 
            BechmarkClass bClass = new BechmarkClass();
            var ss = bClass.PointDistanceShort(new PointStruct<float>(), null);
            //assert
        }
        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void PointDistanceStructShortFloat_inNullNewClass_outExecption()
        {
            //arrange
            //actual 
            BechmarkClass bClass = new BechmarkClass();
            var ss = bClass.PointDistanceShort(new PointStruct<float>(), null);
            //assert
        }
        [TestMethod]
        public void PointDistanceStructShortFloat_in2_out2()
        {
            //arrange
            float expected = 2;
            //actual 
            BechmarkClass bClass = new BechmarkClass();
            PointStruct<float> p1 = new PointStruct<float>() { PointX = 4, PointY = 0 };
            PointStruct<float> p2 = new PointStruct<float>() { PointX = 2, PointY = 0 };

            float actual = bClass.PointDistanceShort(p1, p2);
            //assert
            Assert.AreEqual<float>(expected, actual);
        }

        [TestMethod]
        public void PointDistanceStructShortFloat_in3_out3()
        {
            //arrange
            float expected = 3;
            //actual 
            BechmarkClass bClass = new BechmarkClass();
            PointStruct<float> p1 = new PointStruct<float>() { PointX = 6, PointY = 0 };
            PointStruct<float> p2 = new PointStruct<float>() { PointX = 3, PointY = 0 };

            float actual = bClass.PointDistanceShort(p1, p2);
            //assert
            Assert.AreEqual<float>(expected, actual);
        }
        [TestMethod]
        public void PointDistanceStructShortFloat_in0_out0()
        {
            //arrange
            float expected = 0;
            //actual 
            BechmarkClass bClass = new BechmarkClass();
            PointStruct<float> p1 = new PointStruct<float>() { PointX = 0, PointY = 0 };
            PointStruct<float> p2 = new PointStruct<float>() { PointX = 0, PointY = 0 };

            float actual = bClass.PointDistanceShort(p1, p2);
            //assert
            Assert.AreEqual<float>(expected, actual);
        }


        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void PointDistanceStructDoubleDouble_inNewClassNull_outExecption()
        {
            //arrange
            //actual 
            BechmarkClass bClass = new BechmarkClass();
            var ss = bClass.PointDistance(new PointStruct<float>(), null);
            //assert
        }
        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void PointDistanceStructDoubleDouble_inNullNewClass_outExecption()
        {
            //arrange
            //actual 
            BechmarkClass bClass = new BechmarkClass();
            var ss = bClass.PointDistance(new PointStruct<float>(), null);
            //assert
        }
        [TestMethod]
        public void PointDistanceStructDoubleDouble_in2_out2()
        {
            //arrange
            float expected = 2;
            //actual 
            BechmarkClass bClass = new BechmarkClass();
            PointStruct<double> p1 = new PointStruct<double>() { PointX = 4, PointY = 0 };
            PointStruct<double> p2 = new PointStruct<double>() { PointX = 2, PointY = 0 };

            float actual = (float)bClass.PointDistance(p1, p2);
            //assert
            Assert.AreEqual<float>(expected, actual);
        }
        [TestMethod]
        public void PointDistanceStructDoubleDouble_in3_out3()
        {
            //arrange
            float expected = 3;
            //actual 
            BechmarkClass bClass = new BechmarkClass();
            PointStruct<double> p1 = new PointStruct<double>() { PointX = 6, PointY = 0 };
            PointStruct<double> p2 = new PointStruct<double>() { PointX = 3, PointY = 0 };

            float actual = (float)bClass.PointDistance(p1, p2);
            //assert
            Assert.AreEqual<float>(expected, actual);
        }
        [TestMethod]
        public void PointDistanceStructDoubleDouble_in0_out0()
        {
            //arrange
            float expected = 0;
            //actual 
            BechmarkClass bClass = new BechmarkClass();
            PointStruct<double> p1 = new PointStruct<double>() { PointX = 0, PointY = 0 };
            PointStruct<double> p2 = new PointStruct<double>() { PointX = 0, PointY = 0 };

            float actual = (float)bClass.PointDistance(p1, p2);
            //assert
            Assert.AreEqual<float>(expected, actual);
        }
    }
}
//    double PointDistance(PointStruct<double> p1, PointStruct<double> p2)