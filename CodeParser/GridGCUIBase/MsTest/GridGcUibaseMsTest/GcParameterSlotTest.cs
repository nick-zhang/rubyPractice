using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Slb.Horizon.GCFramework;

namespace GridGcUibaseMsTest
{
    /// <summary>
    /// Summary description for GcParameterSlotTest
    /// </summary>
    [TestClass]
    public class GcParameterSlotTest
    {
        public GcParameterSlotTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            _collectionServiceMock = new Mock<IGcCollectionService>();
            _sut = new GcParameterSlot(_collectionServiceMock.Object);
        }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetDataValue_Return_Correct_Parameter_Value()
        {
            var parameterValue = "parameter value";
            _collectionServiceMock.Setup(fw => fw.GetValue()).Returns(parameterValue);
            string result = _sut.GetDataValue().StringValue;

            Assert.AreEqual(parameterValue, result);
        }

        private GcParameterSlot _sut;
        private Mock<IGcCollectionService> _collectionServiceMock;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcParameterSlotTest.cs;1 */
/*       1*[1647956] 24-JUL-2012 01:56:57 (GMT) YLi27 */
/*         "new classes to support new depth summary listing" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcParameterSlotTest.cs;1 */
