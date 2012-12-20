using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Slb.Horizon.Framework.Dsc;
using Slb.Horizon.GCFramework;
using Moq;
using DSClients;

namespace GridGcUibaseMsTest
{
    /// <summary>
    /// Summary description for GcParameteSimpleServieTest
    /// </summary>
    [TestClass]
    public class GcParameteSimpleServieTest
    {
        public GcParameteSimpleServieTest()
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
            _collMock = new Mock<ISlbDscCollection>();
            _unitServiceMock = new Mock<IGcUnitService>();
            _sut = new GcParameteSimpleServie(_collMock.Object, _unitServiceMock.Object);
        }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Ignore_Parameter_That_Has_No_Value()
        {
            List<GcParameterIdentity> listOfParameters = new List<GcParameterIdentity>(){new GcParameterIdentity()};

            List<GcDataTuple> result = _sut.BuildParameterTuple(listOfParameters);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void Construct_Parameter_Tuple_Correctly()
        {
            string parameterGuid = "parameter guid";
            _collMock.Setup(fw => fw.SearchFirst(It.IsAny<DscQuery>(), It.IsAny<DscSort>())).Returns(parameterGuid);
            _collMock.Setup(fw => fw.get_Item(parameterGuid, ParameterTokens.VALUELIST)).Returns(new double[1] {1.0});
            _collMock.Setup(fw => fw.get_Item(parameterGuid, ParameterTokens.DATATYPE)).Returns(4);
            _unitServiceMock.Setup(fw => fw.ConvertUnit(It.IsAny<GcParameterIdentity>())).Returns("1.0");

            List<GcParameterIdentity> listOfParameters = new List<GcParameterIdentity>() { new GcParameterIdentity() {Guid = parameterGuid}};

            List<GcDataTuple> result = _sut.BuildParameterTuple(listOfParameters);

            Assert.AreEqual(1, result.Count);
        }

        private GcParameteSimpleServie _sut;
        private Mock<ISlbDscCollection> _collMock;
        private Mock<IGcUnitService> _unitServiceMock;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcParameteSimpleServieTest.cs;2 */
/*       1*[1648975] 26-JUL-2012 02:14:18 (GMT) YLi27 */
/*         "some utility classes to support creating the region definitions easily" */
/*       2*[1649339] 26-JUL-2012 06:23:06 (GMT) YLi27 */
/*         "define the first log sequence layout" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcParameteSimpleServieTest.cs;2 */
