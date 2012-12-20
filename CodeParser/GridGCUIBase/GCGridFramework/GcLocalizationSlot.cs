namespace Slb.Horizon.GCFramework
{
    public class GcLocalizationSlot : IGcDataSlot
    {
        private IGcDataSlot m_Slot;
        private IGcLocalizationService m_LocalService;

        public GcLocalizationSlot(IGcDataSlot slot, IGcLocalizationService service)
        {
            m_Slot = slot;
            m_LocalService = service;
        }

        public GcDataSlotValue GetDataValue()
        {
            GcDataSlotValue gcDataSlotValue = new GcDataSlotValue();

            if (string.IsNullOrEmpty(m_Slot.GetDataValue().StringValue))
                gcDataSlotValue.StringValue = string.Empty;
            else
                gcDataSlotValue.StringValue = m_LocalService.GetString("DepthSummary_" + m_Slot.GetDataValue().StringValue);

            return gcDataSlotValue;
        }
    }    
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcLocalizationSlot.cs;2 */
/*       1*[1675220] 27-SEP-2012 09:26:51 (GMT) SLiu10 */
/*         "[P4] Depth Summary Localization Service: Add LocalizationSlot" */
/*       2*[1675767] 29-SEP-2012 02:25:12 (GMT) SLiu10 */
/*         "[P4] Depth Summary Localization Service: Implement Localization Service on Label Slot" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcLocalizationSlot.cs;2 */
