using DSClients;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Slb.Horizon.GCFramework;

namespace GridGcUibaseMsTest
{
    [TestClass]
    public class GcRunCollectionServiceTest
    {
        private int m_token = 0;
        private string m_workspaceGuid = "workspaceGuid";
        private string m_runGuid = "runGuid";

        [TestMethod]
        public void return_empty_string_when_can_not_find_run_guid()
        {            
            int index = -1;
            object tokenValue = "tokenValue";

            ISlbDscCollection mockRunCollection = prepareMockRunCollection(index, tokenValue);

            GcRunCollectionService sut = new GcRunCollectionService(mockRunCollection, m_token, m_workspaceGuid);

            string result = sut.GetValue();
            Assert.AreEqual(string.Empty,result);
        }

        [TestMethod]
        public void return_token_value_typical()
        {
            int index = 1;
            object tokenValue = "tokenValue";

            ISlbDscCollection mockRunCollection = prepareMockRunCollection(index, tokenValue);

            GcRunCollectionService sut = new GcRunCollectionService(mockRunCollection, m_token, m_workspaceGuid);

            string result = sut.GetValue();
            Assert.AreEqual(tokenValue.ToString(), result);
        }

        [TestMethod]
        public void return_empty_string_when_token_value_is_null()
        {
            int index = 1;
            object tokenValue = null;            

            ISlbDscCollection mockRunCollection = prepareMockRunCollection(index, tokenValue);

            GcRunCollectionService sut = new GcRunCollectionService(mockRunCollection, m_token, m_workspaceGuid);

            string result = sut.GetValue();

            Assert.AreEqual(string.Empty, result);
        }

        private ISlbDscCollection prepareMockRunCollection(int index, object tokenValue)
        {
            Mock<ISlbDscCollection> mockRunCollection = new Mock<ISlbDscCollection>();

            mockRunCollection.Setup(mock => mock.SearchFirst(It.IsAny<DscQuery>(), null)).Returns(m_runGuid);
            mockRunCollection.Setup(mock => mock.get_Index(m_runGuid)).Returns(index);
            mockRunCollection.Setup(mock => mock.get_ItemByIndex(index, m_token)).Returns(tokenValue);

            return mockRunCollection.Object;
        }
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcRunCollectionServiceTest.cs;1 */
/*       1*[1661100] 23-AUG-2012 01:51:11 (GMT) SLiu10 */
/*         "[P4] Add unit test for Depth Summary : GcRunCollectionService" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcRunCollectionServiceTest.cs;1 */
