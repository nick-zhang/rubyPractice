using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Slb.Horizon.GCFramework;

namespace GridGcUibaseMsTest
{
    /// <summary>
    /// Summary description for GcLabelSlotTest
    /// </summary>
    [TestClass]
    public class GcLabelSlotTest
    {
        public GcLabelSlotTest()
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
            _sut = new GcLabelSlot(_label);
        }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Return_Correct_Label_Value_After_GetDataValue_Is_Called()
        {
            Assert.AreEqual(_label, _sut.GetDataValue().StringValue);
        }

        private GcLabelSlot _sut;
        private string _label = "label";
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcLabelSlotTest.cs;2 */
/*       1*[1647956] 24-JUL-2012 01:56:57 (GMT) YLi27 */
/*         "new classes to support new depth summary listing" */
/*       2*[1649463] 27-JUL-2012 03:31:33 (GMT) YLi27 */
/*         "integrate new depth summary listing into exisitng report" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcLabelSlotTest.cs;2 */
