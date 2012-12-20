using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Slb.Horizon.Framework.Dsc;
using Slb.Horizon.GCFramework;
using Moq;
using DSClients;

namespace GridGcUibaseMsTest
{
    [TestClass]
    public class GcEnsembleServiceTest
    {               
        #region Additional test attributes        
        [TestInitialize()]
        public void MyTestInitialize()
        {
            _documentMock = new Mock<ISlbWellLogDocument>();
            _ensembleCollMock = new Mock<ISlbDscCollection>();
            _parameterCollMock = new Mock<ISlbDscCollection>();
        }
        
        #endregion

        [TestMethod]
        public void Get_Related_Parameter_From_Parent_Ensemble()
        {
            _documentMock.Setup(fw => fw.GetCollection(DscDocumentCollectionTokens.DSC_COL_ENSEMBLE, false)).Returns(
                _ensembleCollMock.Object);
            _documentMock.Setup(fw => fw.GetCollection(DscDocumentCollectionTokens.DSC_COL_PARAMETER, false)).Returns(
                _parameterCollMock.Object);

            var ensembleGuid = "ensemble guid";
            _ensembleCollMock.Setup(fw => fw.SearchFirst(It.IsAny<DscQuery>(), It.IsAny<DscSort>())).Returns(
                ensembleGuid);

            var parameterGuid = "parameter guid";
            _parameterCollMock.Setup(fw => fw.SearchFirst(It.IsAny<DscQuery>(), It.IsAny<DscSort>())).Returns(
                parameterGuid);

            var bitSize = "bit size";
            _parameterCollMock.Setup(fw => fw.get_Item(parameterGuid, ParameterTokens.DESC)).Returns(bitSize);

            _sut = new GcEnsembleService(_documentMock.Object, "ensemble prog id", "workspace guid");

            _sut.Configure();

            string parameterOsdd = "BS";
            var result = _sut.GetParameter(parameterOsdd);

            Assert.AreEqual(parameterOsdd, result.Osdd);
            Assert.AreEqual(ensembleGuid, result.Entity);
            Assert.AreEqual(bitSize, result.Description);
            Assert.AreEqual(parameterGuid, result.Guid);
        }

        [TestMethod]
        public void Get_Null_If_No_Parameter_Registered_From_Ensemble()
        {
            _documentMock.Setup(fw => fw.GetCollection(DscDocumentCollectionTokens.DSC_COL_ENSEMBLE, false)).Returns(
                _ensembleCollMock.Object);
            _documentMock.Setup(fw => fw.GetCollection(DscDocumentCollectionTokens.DSC_COL_PARAMETER, false)).Returns(
                _parameterCollMock.Object);

            var ensembleGuid = "ensemble guid";
            _ensembleCollMock.Setup(fw => fw.SearchFirst(It.IsAny<DscQuery>(), It.IsAny<DscSort>())).Returns(
                ensembleGuid);

            var parameterGuid = String.Empty;
            _parameterCollMock.Setup(fw => fw.SearchFirst(It.IsAny<DscQuery>(), It.IsAny<DscSort>())).Returns(
                parameterGuid);

            _sut = new GcEnsembleService(_documentMock.Object, "ensemble prog id", "workspace guid");

            _sut.Configure();

            string parameterOsdd = "BS";
            var result = _sut.GetParameter(parameterOsdd);
            Assert.IsNull(result);
            
        }

        private GcEnsembleService _sut;
        private Mock<ISlbWellLogDocument> _documentMock;
        private Mock<ISlbDscCollection> _ensembleCollMock;
        private Mock<ISlbDscCollection> _parameterCollMock;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcEnsembleServiceTest.cs;2 */
/*       1*[1649463] 27-JUL-2012 03:31:33 (GMT) YLi27 */
/*         "integrate new depth summary listing into exisitng report" */
/*       2*[1675767] 29-SEP-2012 02:25:12 (GMT) SLiu10 */
/*         "[P4] Depth Summary Localization Service: Implement Localization Service on Label Slot" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcEnsembleServiceTest.cs;2 */
