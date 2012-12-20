using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Slb.Horizon.GCFramework;

namespace GridGcUibaseMsTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class GcUnitServiceTest
    {
        public GcUnitServiceTest()
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
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext){}
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            _unitMock = new Mock<ISlbUnits>();
            _unit2Mock = _unitMock.As<ISlbUnits2>();
            _unitConverter = _unitMock.As<ISlbConvertUnits>();
            _sut = new GcUnitService(m_UnitSystem, _unitMock.Object);
        }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ConvertUnit_Return_EmptyString_When_Null_Value_Passed_In()
        {
            GcParameterIdentity parmeterId = new GcParameterIdentity();
            parmeterId.Value = null;

            Assert.IsTrue(String.IsNullOrEmpty(_sut.ConvertUnit(parmeterId)));


        }

        [TestMethod]
        public void ConvertUnit_Return_EmptyString_When_Zero_Value_Passed_In()
        {
            GcParameterIdentity parmeterId = new GcParameterIdentity();
            parmeterId.Value = new double[0];

            Assert.IsTrue(String.IsNullOrEmpty(_sut.ConvertUnit(parmeterId)));
        }

        [TestMethod]
        public void ConvertUnit_Return_Original_Value_When_No_Need_Unit_Conversion()
        {
            GcParameterIdentity parmeterId = new GcParameterIdentity();
            parmeterId.Value = new double[1];
            parmeterId.Value.SetValue( 2.5, 0);

            string result = _sut.ConvertUnit(parmeterId);
            Assert.AreEqual("2.5", result);
        }

        [TestMethod]
        public void ConvertUnit_Return_Correct_Value_Of_The_Right_Unit()
        {
            _unitMock.Setup(fw => fw.UnitForSystem(m_UnitQuantity, m_UnitSystem)).Returns("ft");

            _unit2Mock.Setup(fw => fw.PrecisionForSystem(m_UnitQuantity, m_UnitSystem)).Returns(2);

            _unitConverter.Setup(fw => fw.ConvertVariant(It.IsAny<object>(), It.IsAny<double>(), It.IsAny<double>())).
                Returns(4.5);

            GcParameterIdentity parmeterId = new GcParameterIdentity();
            parmeterId.Value = new double[1];
            parmeterId.Value.SetValue(2.5, 0);
            parmeterId.StorageUnit = "m";
            parmeterId.UnitQuantity = m_UnitQuantity;
            parmeterId.DataType = DataType_t.DATA_TYPE_IEEE64;

            string result = _sut.ConvertUnit(parmeterId);
            Assert.AreEqual("4.50", result);
            Assert.AreEqual<string>("ft", parmeterId.DisplayUnit);
        }

        private GcUnitService _sut;
        private Moq.Mock<ISlbUnits> _unitMock;
        private Mock<ISlbUnits2> _unit2Mock;
        private Mock<ISlbConvertUnits> _unitConverter;
        private String m_UnitSystem = "unit system";
        private String m_UnitQuantity = "length";
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcUnitServiceTest.cs;1 */
/*       1*[1647956] 24-JUL-2012 01:56:57 (GMT) YLi27 */
/*         "new classes to support new depth summary listing" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcUnitServiceTest.cs;1 */
