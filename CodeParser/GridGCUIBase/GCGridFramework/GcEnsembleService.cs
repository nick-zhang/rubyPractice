using DSClients;
using Slb.Horizon.Framework.Dsc;
using System;

namespace Slb.Horizon.GCFramework
{
    public interface IGcEnsembleService
    {
        GcParameterIdentity GetParameter(string parameterOsdd);
        GcParameterIdentity GetEquipProp(string equipmentParameterOsdd);
        GcParameterIdentity GetWellEnsemble(string equipmentParameterOsdd);
    }

    public class GcEnsembleService : IGcEnsembleService
    {
        public GcEnsembleService(ISlbWellLogDocument wellLogDocument, string ensembleProgId, string workspaceGuid)
        {
            m_EnsembleCollection = wellLogDocument.GetCollection(DscDocumentCollectionTokens.DSC_COL_ENSEMBLE, false);
            m_ParameterCollection = wellLogDocument.GetCollection(DscDocumentCollectionTokens.DSC_COL_PARAMETER, false);
            m_EquipPropCollection = wellLogDocument.GetCollection(DscDocumentCollectionTokens.DSC_COL_EQUIP_PROPERTY, false);
            m_EnsembleProgID = ensembleProgId;
            m_WorkSpaceGuid = workspaceGuid;
        }

        public void Configure()
        {
            DscQuery query = new DscQueryClass();
            query.PutItem(EnsembleTokens.ENSEMBLEPROGID, -1, DscQueryType_t.DSC_QUERY_EQUALTO, m_EnsembleProgID);
            query.PutItem(EnsembleTokens.WORKSPACEGUID, -1, DscQueryType_t.DSC_QUERY_EQUALTO, m_WorkSpaceGuid);

            m_EnsembleGuid = m_EnsembleCollection.SearchFirst(query, null);
        }

        public GcParameterIdentity GetParameter(string parameterOsdd)
        {
            DscQuery query = new DscQueryClass();
            query.PutItem(ParameterTokens.OSDDCODE, -1, DscQueryType_t.DSC_QUERY_EQUALTO, parameterOsdd);
            query.PutItem(ParameterTokens.ENTITYGUID, -1, DscQueryType_t.DSC_QUERY_EQUALTO, m_EnsembleGuid);
            string parameterGuid = m_ParameterCollection.SearchFirst(query, null);

            if(String.IsNullOrEmpty(parameterGuid)) return null;

            var parameterId = new GcParameterIdentity();
            parameterId.Osdd = parameterOsdd;
            parameterId.Entity = m_EnsembleGuid;
            parameterId.Guid = parameterGuid;
            parameterId.Description = m_ParameterCollection.get_Item(parameterId.Guid, ParameterTokens.DESC) as string;
            parameterId.Value = m_ParameterCollection.get_Item(parameterId.Guid, ParameterTokens.VALUELIST) as Array;

            return parameterId;
        }

        public GcParameterIdentity GetEquipProp(string equipmentParameterOsdd)
        {
            DscQuery query = new DscQueryClass();
            query.PutItem(EquipPropertyTokens.OSDDCODE, -1, DscQueryType_t.DSC_QUERY_EQUALTO, equipmentParameterOsdd);
            query.PutItem(EquipPropertyTokens.ENTITYGUID, -1, DscQueryType_t.DSC_QUERY_EQUALTO, m_EnsembleGuid);
            string parameterGuid = m_EquipPropCollection.SearchFirst(query, null);

            if (String.IsNullOrEmpty(parameterGuid)) return null;

            var parameterId = new GcParameterIdentity();
            parameterId.Osdd = equipmentParameterOsdd;
            parameterId.Entity = m_EnsembleGuid;
            parameterId.Guid = parameterGuid;
            parameterId.Description = m_EquipPropCollection.get_Item(parameterId.Guid, EquipPropertyTokens.DESC) as string;
            parameterId.Value = new Object[] { m_EquipPropCollection.get_Item(parameterId.Guid, EquipPropertyTokens.VALUE)};
            return parameterId;
        }

        public GcParameterIdentity GetWellEnsemble(string equipmentParameterOsdd)
        {
            DscQuery query = new DscQueryClass();
            query.PutItem(ParameterTokens.OSDDCODE, -1, DscQueryType_t.DSC_QUERY_EQUALTO, equipmentParameterOsdd);
            string parameterGuid = m_ParameterCollection.SearchFirst(query, null);

            if (String.IsNullOrEmpty(parameterGuid)) return null;

            var parameterId = new GcParameterIdentity();
            parameterId.Osdd = equipmentParameterOsdd;
            parameterId.Entity = m_EnsembleGuid;
            parameterId.Guid = parameterGuid;
            parameterId.Description = m_ParameterCollection.get_Item(parameterId.Guid, ParameterTokens.DESC) as string;
            return parameterId;
        }

        private ISlbDscCollection m_EnsembleCollection;
        private ISlbDscCollection m_ParameterCollection;
        private ISlbDscCollection m_EquipPropCollection;
        private string m_EnsembleProgID;
        private string m_WorkSpaceGuid;
        private string m_EnsembleGuid;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcEnsembleService.cs;6 */
/*       1*[1649339] 26-JUL-2012 06:23:06 (GMT) YLi27 */
/*         "define the first log sequence layout" */
/*       2*[1649463] 27-JUL-2012 03:31:33 (GMT) YLi27 */
/*         "integrate new depth summary listing into exisitng report" */
/*       3*[1657754] 22-AUG-2012 01:31:55 (GMT) XCui4 */
/*         "[P4] Add parameters for logging cable in Depth Summary" */
/*       4*[1674597] 26-SEP-2012 05:54:50 (GMT) YLi27 */
/*         "Support depth parameter summary free layout" */
/*       5*[1680440] 15-OCT-2012 01:31:50 (GMT) XCui4 */
/*         "[2013.1] Depth Summary - Implement Tension Device Display Rules" */
/*       6*[1682873] 17-OCT-2012 08:55:25 (GMT) YLi27 */
/*         "[2013.1] Add DslTensionDeviceParameterPackage class to support different cali points" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcEnsembleService.cs;6 */
