using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Slb.Horizon.Framework.Dsc;
using Slb.Horizon.GCFramework;
using DSClients;

namespace GridGcUibaseMsTest
{
    /// <summary>
    /// Summary description for GcParameterServiceTest
    /// </summary>
    [TestClass]
    public class GcParameterServiceTest
    {
        public GcParameterServiceTest()
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
            _collectionMock = new Mock<ISlbDscCollection>();
            _unitServiceMock = new Mock<IGcUnitService>();
            _parameterId = new GcParameterIdentity();
            _sut = new GcParameterService(_collectionMock.Object, _unitServiceMock.Object, _parameterId);
        }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetValue_Return_Empty_String_If_Parameter_Object_Does_Not_Exist()
        {
            _collectionMock.Setup(fw => fw.SearchFirst(It.IsAny<DscQuery>(), null)).Returns(String.Empty);

            string result = _sut.GetValue();

            Assert.IsTrue(String.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void GetValue_Return_Empty_String_If_Parameter_Value_Is_Null()
        {
            _collectionMock.Setup(fw => fw.SearchFirst(It.IsAny<DscQuery>(), null)).Returns(_parameterGuid);
            _collectionMock.Setup(fw => fw.get_Item(_parameterGuid, ParameterTokens.VALUELIST)).Returns(null);
            _collectionMock.Setup(fw => fw.get_Item(_parameterGuid, ParameterTokens.DATATYPE)).Returns(2);

            string result = _sut.GetValue();

            Assert.IsTrue(String.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void GetValue_Return_Empty_String_If_Zero_Parameter_Value()
        {
            _collectionMock.Setup(fw => fw.SearchFirst(It.IsAny<DscQuery>(), null)).Returns(_parameterGuid);
            _collectionMock.Setup(fw => fw.get_Item(_parameterGuid, ParameterTokens.VALUELIST)).Returns(new double[0]);
            _collectionMock.Setup(fw => fw.get_Item(_parameterGuid, ParameterTokens.DATATYPE)).Returns(2);

            string result = _sut.GetValue();

            Assert.IsTrue(String.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void GetValue_Return_Empty_Value_When_UnitConversionService_Return_Empty_String()
        {
            _collectionMock.Setup(fw => fw.SearchFirst(It.IsAny<DscQuery>(), null)).Returns(_parameterGuid);
            double[] parameterValue = new double[1];
            parameterValue[0] = 4.5;
            _collectionMock.Setup(fw => fw.get_Item(_parameterGuid, ParameterTokens.VALUELIST)).Returns(parameterValue);
            _collectionMock.Setup(fw => fw.get_Item(_parameterGuid, ParameterTokens.DATATYPE)).Returns(2);

            _unitServiceMock.Setup(fw => fw.ConvertUnit(It.IsAny<GcParameterIdentity>())).Returns(String.Empty);
            _parameterId.DisplayUnit = "ft";
            string result = _sut.GetValue();

            Assert.IsTrue(String.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void GetValue_Return_Correct_Parameter_Value_Without_Unit()
        {
            _parameterId.Guid = _parameterGuid;
            double[] parameterValue = new double[1];
            parameterValue[0] = 4.5;
            _collectionMock.Setup(fw => fw.get_Item(_parameterGuid, ParameterTokens.VALUELIST)).Returns(parameterValue);
            _collectionMock.Setup(fw => fw.get_Item(_parameterGuid, ParameterTokens.DATATYPE)).Returns(2);

            _unitServiceMock.Setup(fw => fw.ConvertUnit(It.IsAny<GcParameterIdentity>())).Returns("4.5");
            string result = _sut.GetValue();

            Assert.AreEqual("4.5", result);
        }

        [TestMethod]
        public void GetValue_Return_Correct_Parameter_Value_With_Correct_Display_Unit()
        {
            _parameterId.Guid = _parameterGuid;
            double[] parameterValue = new double[1];
            parameterValue[0] = 4.5;
            _collectionMock.Setup(fw => fw.get_Item(_parameterGuid, ParameterTokens.VALUELIST)).Returns(parameterValue);
            _collectionMock.Setup(fw => fw.get_Item(_parameterGuid, ParameterTokens.DATATYPE)).Returns(2);

            _unitServiceMock.Setup(fw => fw.ConvertUnit(It.IsAny<GcParameterIdentity>())).Returns("4.5");
            _parameterId.DisplayUnit = "ft";
            string result = _sut.GetValue();

            Assert.AreEqual("4.5 ft", result);
        }

        private GcParameterService _sut;
        private Mock<ISlbDscCollection> _collectionMock;
        private Mock<IGcUnitService> _unitServiceMock;
        private GcParameterIdentity _parameterId;
        private String _parameterGuid = "parameter guid";
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcParameterServiceTest.cs;3 */
/*       1*[1647956] 24-JUL-2012 01:56:57 (GMT) YLi27 */
/*         "new classes to support new depth summary listing" */
/*       2*[1649339] 26-JUL-2012 06:23:06 (GMT) YLi27 */
/*         "define the first log sequence layout" */
/*       3*[1668705] 12-SEP-2012 07:31:30 (GMT) XCui4 */
/*         "[P4] Depth Summary Code Clean Up, No Logic Change" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcParameterServiceTest.cs;3 */
