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
    /// Summary description for GcParameterTupleProxyServiceTest
    /// </summary>
    [TestClass]
    public class GcParameterTupleProxyServiceTest
    {
        public GcParameterTupleProxyServiceTest()
        {
           
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

        [TestMethod]
        public void Get_Default_Value_When_Pass_Empty_Parameter_Identity()
        {
            string defaultValue = "default value";
            var sut = new GcParameterTupleProxyService(null, defaultValue);

            var listOfParameters = new List<GcParameterIdentity>() { new GcParameterIdentity() { Osdd = String.Empty } };

            var result = sut.BuildParameterTuple(listOfParameters);

            Assert.AreEqual(defaultValue, result[0].Data.GetDataValue().StringValue);
        }

        [TestMethod]
        public void Get_Data_Slot_From_Concreat_Service_When_Pass_Valid_Parameter_Identity()
        {
            var listOfParameters = new List<GcParameterIdentity>() { new GcParameterIdentity() { Osdd = "GR" } };

            var concreateService = new Mock<IGcParameterTupleService>();

            var dataTuple = new GcDataTuple();
            concreateService.Setup(fw => fw.BuildParameterTuple(listOfParameters)).Returns(new List<GcDataTuple>() { dataTuple});

            var sut = new GcParameterTupleProxyService(concreateService.Object, "default value");

            var result = sut.BuildParameterTuple(listOfParameters);

            Assert.AreEqual(dataTuple, result[0]);
        }
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcParameterTupleProxyServiceTest.cs;1 */
/*       1*[1682805] 17-OCT-2012 03:36:50 (GMT) YLi27 */
/*         "[P4] Add New Class to handle the NA cell" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcParameterTupleProxyServiceTest.cs;1 */
