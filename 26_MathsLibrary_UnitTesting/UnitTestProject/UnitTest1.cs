using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMyAddMethod()
        {
            //Arrange
            MathsLibrary_UnitTesting.MyMaths mathObj = new MathsLibrary_UnitTesting.MyMaths();
            
            //Act
            int result = mathObj.Add(5, 6);

            //Assert
            Assert.AreEqual<int>(11, result);
          
        }
    }
}
