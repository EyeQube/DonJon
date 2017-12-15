using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Tests
{
    [TestClass]
    public class LimitedListTests
    {
        [TestMethod]
        public void Add_IfNotFull()
        {

            //Arrange
            var list = new LimitedList<int>(3);


            //Act
            var added = list.Add(1);


            //Assert
            Assert.IsTrue(added);
        }


        [TestMethod]
        public void Add_OnlyIfFull()
        {

            //Arrange
            var list = new LimitedList<int>(2);
            list.Add(1);


            //Act
            var added = list.Add(2);
            var failed = list.Add(3);


            //Assert
            Assert.IsTrue(added);
            Assert.IsFalse(failed);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_NegativeCapacity_Throws()
        {
            var list = new LimitedList<int>(-1);

        }

        [TestMethod()]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_NegativeCapacity_ThrowsAndCatch()
        {
            try
            {
                var list = new LimitedList<int>(-1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.AreEqual("capacity", e.ParamName);
                return;
            }

            //Assert.Fail();

        }

        [TestMethod()]
        public void Indexer_ReturnsContents()
        {
            var list = new LimitedList<int>(2);
            list.Add(1);
            list.Add(2);


            var first = list[0];
            var second = list[1];

            //Act
            Assert.AreEqual(1, first);
            Assert.AreEqual(2, second);
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexer_OutOfRange_Throws()
        {
            var list = new LimitedList<int>(2);
            list.Add(1);

            var second = list[1];

        }


    }
}