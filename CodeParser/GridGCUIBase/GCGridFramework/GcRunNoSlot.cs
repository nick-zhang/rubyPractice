namespace Slb.Horizon.GCFramework
{
    public class GcRunNoSlot : IGcDataSlot
    {
        public GcRunNoSlot(IGcCollectionService runParameterService, IGcCollectionService collectionService, IGcLocalizationService localizationService, string attribute)
        {
            m_RunParameterParaService = runParameterService;
            m_runCollService = collectionService;
            m_attribute = attribute;
            m_LocalizationService = localizationService;
        }

        public GcDataSlotValue GetDataValue()
        {
            string customizedRunNo = m_RunParameterParaService.GetValue();
            string runNo = string.IsNullOrEmpty(customizedRunNo)
                               ? m_LocalizationService.GetString("Common_Run") + " " + m_runCollService.GetValue()
                               : customizedRunNo;            
            return new GcDataSlotValue() { StringValue = runNo + m_attribute };
        }

        private readonly IGcCollectionService m_RunParameterParaService;
        private readonly IGcCollectionService m_runCollService;
        private readonly string m_attribute;
        private IGcLocalizationService m_LocalizationService;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcRunNoSlot.cs;3 */
/*       1*[1647956] 24-JUL-2012 01:56:57 (GMT) YLi27 */
/*         "new classes to support new depth summary listing" */
/*       2*[1657754] 22-AUG-2012 01:31:55 (GMT) XCui4 */
/*         "[P4] Add parameters for logging cable in Depth Summary" */
/*       3*[1677138] 10-OCT-2012 02:27:44 (GMT) SLiu10 */
/*         "[P4] Depth Summary Localization Service: Implement Localization Service on Run Number Slot" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcRunNoSlot.cs;3 */
