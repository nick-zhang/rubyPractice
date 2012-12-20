using System;
using DSClients;
using Slb.Horizon.Framework.Dsc;

namespace Slb.Horizon.GCFramework
{
    public class GcRunCollectionService : IGcCollectionService
    {
        public GcRunCollectionService(ISlbDscCollection runColl, int token, string workspaceGuid)
        {
            m_runCollection = runColl;
            m_token = token;
            m_workspaceGuid = workspaceGuid;
        }
        public string GetValue()
        {
            DscQuery query = new DscQueryClass();
            query.PutItem(DataAcquisitionRunTokens.WORKSPACEGUID, -1, DscQueryType_t.DSC_QUERY_EQUALTO, m_workspaceGuid);
            string runGuid = m_runCollection.SearchFirst(query, null) as string;

            int index = m_runCollection.get_Index(runGuid);
            if (index < 0) return String.Empty;

            object tokenValue = m_runCollection.get_ItemByIndex(index, m_token);

            return tokenValue == null ? String.Empty : tokenValue.ToString();
        }

        private ISlbDscCollection m_runCollection;
        private int m_token;
        private string m_workspaceGuid;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcRunCollectionService.cs;3 */
/*       1*[1647956] 24-JUL-2012 01:56:57 (GMT) YLi27 */
/*         "new classes to support new depth summary listing" */
/*       2*[1649339] 26-JUL-2012 06:23:06 (GMT) YLi27 */
/*         "define the first log sequence layout" */
/*       3*[1649463] 27-JUL-2012 03:31:33 (GMT) YLi27 */
/*         "integrate new depth summary listing into exisitng report" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcRunCollectionService.cs;3 */
