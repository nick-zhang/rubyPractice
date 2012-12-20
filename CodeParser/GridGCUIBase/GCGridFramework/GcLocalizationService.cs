using LocalizationLib;

namespace Slb.Horizon.GCFramework
{
    public interface IGcLocalizationService
    {
        string GetString(string key);
    }

    public class GcLocalizationService : IGcLocalizationService
    {
        private readonly string m_cultureCode;

        public GcLocalizationService(string cultureCode)
        {
            m_cultureCode = cultureCode;
        }
                
        public string GetString(string key)
        {            
            return LocalizationHelper.GetString(key, m_cultureCode);
        }
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcLocalizationService.cs;1 */
/*       1*[1674956] 26-SEP-2012 01:48:53 (GMT) SLiu10 */
/*         "[P4] Depth Summary Localization support" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcLocalizationService.cs;1 */
