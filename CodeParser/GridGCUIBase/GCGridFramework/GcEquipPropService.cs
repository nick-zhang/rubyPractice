using System;
using DSClients;
using Interface;
using Slb.Horizon.Framework.Dsc;

namespace Slb.Horizon.GCFramework
{
    public class GcEquipPropService : IGcCollectionService
    {
        public GcEquipPropService(ISlbDscCollection equipPropColl, IGcUnitService unitService, GcParameterIdentity gcParameterId)
        {
            m_EquipPropColl = equipPropColl;
            m_UnitService = unitService;
            m_GcParameterId = gcParameterId;
        }

        public string GetValue()
        {
            return GetStringParameterValue();
        }

        private string GetStringParameterValue()
        {
            if (string.IsNullOrEmpty(m_GcParameterId.Guid))
                return string.Empty;

            m_GcParameterId.Value = new Object[] { m_EquipPropColl.get_Item(m_GcParameterId.Guid, EquipPropertyTokens.VALUE) };
            m_GcParameterId.UnitQuantity = m_EquipPropColl.get_Item(m_GcParameterId.Guid, EquipPropertyTokens.UNITQUANTITY) as string;
            m_GcParameterId.StorageUnit = m_EquipPropColl.get_Item(m_GcParameterId.Guid, EquipPropertyTokens.STORAGEUNITS) as string;
            m_GcParameterId.DataType = (DataType_t)m_EquipPropColl.get_Item(m_GcParameterId.Guid, EquipPropertyTokens.DATATYPE);

            if (m_GcParameterId.Value != null && m_GcParameterId.Value.Length > 0)
                return FormatParameterValue(m_GcParameterId);

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

        private readonly ISlbDscCollection m_EquipPropColl;
        private readonly IGcUnitService m_UnitService;
        private readonly GcParameterIdentity m_GcParameterId;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcEquipPropService.cs;2 */
/*       1*[1657754] 22-AUG-2012 01:31:55 (GMT) XCui4 */
/*         "[P4] Add parameters for logging cable in Depth Summary" */
/*       2*[1680440] 15-OCT-2012 01:31:50 (GMT) XCui4 */
/*         "[2013.1] Depth Summary - Implement Tension Device Display Rules" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcEquipPropService.cs;2 */
