using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Slb.Horizon.GCFramework;

namespace GridGcUibaseMsTest
{    
    [TestClass]
    public class GcRunNoSlotTest
    {
        #region Additional test attributes       
        [TestInitialize()]
        public void MyTestInitialize()
        {
            _runCollMock = new Mock<IGcCollectionService>();
            _parameterMock = new Mock<IGcCollectionService>();
            _localizationServiceMock = new Mock<IGcLocalizationService>();
            _localizationServiceMock.Setup(fw => fw.GetString("Common_Run")).Returns("Run");
            _localizationServiceMock.Setup(fw => fw.GetString("DepthSummary_" + _attribute)).Returns(_attribute);
            _sut = new GcRunNoSlot(_parameterMock.Object, _runCollMock.Object, _localizationServiceMock.Object, _attribute);
        }
        
        #endregion

        [TestMethod]
        public void Return_Customized_Run_Number()
        {
            var customizedRunNumber = ":customized run number";
            _parameterMock.Setup(fw => fw.GetValue()).Returns(customizedRunNumber);

            string result = _sut.GetDataValue().StringValue;
            string expected = customizedRunNumber + _attribute;
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void Return_Run_Number()
        {
            _parameterMock.Setup(fw => fw.GetValue()).Returns(String.Empty);
            _runCollMock.Setup(fw => fw.GetValue()).Returns("1");
            
            string result = _sut.GetDataValue().StringValue;
            string expected = "Run 1" + _attribute;
            Assert.AreEqual(expected, result);

        }

        private Mock<IGcCollectionService> _runCollMock;
        private Mock<IGcCollectionService> _parameterMock;
        private Mock<IGcLocalizationService> _localizationServiceMock;
        private string _attribute = "remarks";
        private GcRunNoSlot _sut;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcRunNoSlotTest.cs;3 */
/*       1*[1647956] 24-JUL-2012 01:56:57 (GMT) YLi27 */
/*         "new classes to support new depth summary listing" */
/*       2*[1657754] 22-AUG-2012 01:31:55 (GMT) XCui4 */
/*         "[P4] Add parameters for logging cable in Depth Summary" */
/*       3*[1677138] 10-OCT-2012 02:27:44 (GMT) SLiu10 */
/*         "[P4] Depth Summary Localization Service: Implement Localization Service on Run Number Slot" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcRunNoSlotTest.cs;3 */
