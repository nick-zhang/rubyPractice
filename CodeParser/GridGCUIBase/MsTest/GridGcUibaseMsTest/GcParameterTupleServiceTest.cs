using System.Collections.Generic;
using DSClients;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Slb.Horizon.GCFramework;

namespace GridGcUibaseMsTest
{
    [TestClass]
    public class GcParameterTupleServiceTest
    {
        
        #region Additional test attributes        
        [TestInitialize()]
        public void MyTestInitialize()
        {
            _collMock = new Mock<ISlbDscCollection>();
            _unitServiceMock = new Mock<IGcUnitService>();
            _localizationServiceMock = new Mock<IGcLocalizationService>();
            _localizationServiceMock.Setup(mock => mock.GetString(It.IsAny<string>())).Returns(string.Empty);
            _sut = new GcParameterTupleService(new GcCollectionServiceAttribute(GcCollectionServiceType.ParameterCollectin, _collMock.Object as ISlbDscParameterCollection), _unitServiceMock.Object, _localizationServiceMock.Object);
        }
       
        #endregion

        [TestMethod]
        public void Construct_Parameter_Tuple_Correctly()
        {
            List<GcParameterIdentity> listOfParameters = new List<GcParameterIdentity>() { new GcParameterIdentity() };

            List<GcDataTuple> result = _sut.BuildParameterTuple(listOfParameters);

            Assert.AreEqual(1, result.Count);
        }

        private GcParameterTupleService _sut;
        private Mock<ISlbDscCollection> _collMock;
        private Mock<IGcUnitService> _unitServiceMock;
        private Mock<IGcLocalizationService> _localizationServiceMock;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcParameterTupleServiceTest.cs;3 */
/*       1*[1648975] 26-JUL-2012 02:14:18 (GMT) YLi27 */
/*         "some utility classes to support creating the region definitions easily" */
/*       2*[1657754] 22-AUG-2012 01:31:55 (GMT) XCui4 */
/*         "[P4] Add parameters for logging cable in Depth Summary" */
/*       3*[1675767] 29-SEP-2012 02:25:12 (GMT) SLiu10 */
/*         "[P4] Depth Summary Localization Service: Implement Localization Service on Label Slot" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcParameterTupleServiceTest.cs;3 */
