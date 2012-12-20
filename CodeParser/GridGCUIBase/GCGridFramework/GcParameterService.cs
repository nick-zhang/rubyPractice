using System;
using DSClients;
using Interface;
using Slb.Horizon.Framework.Dsc;

namespace Slb.Horizon.GCFramework
{
    public class GcParameterService : IGcCollectionService
    {
        public GcParameterService(ISlbDscCollection paraColl, IGcUnitService unitService, GcParameterIdentity parameterId)
        {
            m_ParaColl = paraColl;
            m_UnitService = unitService;
            m_ParameterId = parameterId;
        }

        public string GetValue()
        {
            return GetStringParameterValue();
        }

        private string GetStringParameterValue()
        {
            if (string.IsNullOrEmpty(m_ParameterId.Guid))
                return string.Empty;

            string parameterGuid = m_ParameterId.Guid;
            m_ParameterId.Value = m_ParaColl.get_Item(parameterGuid, ParameterTokens.VALUELIST) as Array;
            m_ParameterId.UnitQuantity = m_ParaColl.get_Item(parameterGuid, ParameterTokens.UNITQUANTITY) as string;
            m_ParameterId.StorageUnit = m_ParaColl.get_Item(parameterGuid, ParameterTokens.STORAGEUNITS) as string;
            m_ParameterId.DataType = (DataType_t)m_ParaColl.get_Item(parameterGuid, ParameterTokens.DATATYPE);

            if (m_ParameterId.Value != null && m_ParameterId.Value.Length > 0)
                return FormatParameterValue(m_ParameterId);

            return string.Empty;
        }

        private string FormatParameterValue(GcParameterIdentity parameterId)
        {
            string parameterValue = m_UnitService.ConvertUnit(parameterId);
            if (String.IsNullOrEmpty(parameterValue)) return String.Empty;

            if (String.IsNullOrEmpty(parameterId.DisplayUnit))
                return parameterValue;
            return parameterValue + " " + parameterId.DisplayUnit;
        }

        private ISlbDscCollection m_ParaColl;
        private IGcUnitService m_UnitService;
        private GcParameterIdentity m_ParameterId;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcParameterService.cs;2 */
/*       1*[1647956] 24-JUL-2012 01:56:57 (GMT) YLi27 */
/*         "new classes to support new depth summary listing" */
/*       2*[1649339] 26-JUL-2012 06:23:06 (GMT) YLi27 */
/*         "define the first log sequence layout" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcParameterService.cs;2 */
