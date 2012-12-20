using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Slb.Horizon.GCFramework;
using Moq;

namespace GridGcUibaseMsTest
{
    /// <summary>
    /// Summary description for GcRegionTwoColumnBuilderTest
    /// </summary>
    [TestClass]
    public class GcRegionTwoColumnBuilderTest
    {
        public GcRegionTwoColumnBuilderTest()
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
            _sut = new GcRegionTwoColumnBuilder(4);
        }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            Mock<IGcDataSlot> titleSlotMock = new Mock<IGcDataSlot>();
            GcDataTuple oneData = new GcDataTuple();
            List<GcDataTuple> listOfDatas = new List<GcDataTuple>();
            listOfDatas.Add(oneData);

            GcRegionDefinition result = _sut.Build(titleSlotMock.Object, listOfDatas);

            Assert.AreEqual(1, result.Title.Cells.Count);
            Assert.AreEqual(4, result.Title.Cells[0].Size.Width);
            Assert.AreEqual(1, result.Rows.Count);
            Assert.AreEqual(2, result.Rows[0].Cells.Count);
            Assert.AreEqual(2, result.Rows[0].Cells[0].Size.Width);
            Assert.AreEqual(2, result.Rows[0].Cells[1].Size.Width);
        }

        private GcRegionTwoColumnBuilder _sut;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcRegionTwoColumnBuilderTest.cs;1 */
/*       1*[1648975] 26-JUL-2012 02:14:18 (GMT) YLi27 */
/*         "some utility classes to support creating the region definitions easily" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcRegionTwoColumnBuilderTest.cs;1 */
