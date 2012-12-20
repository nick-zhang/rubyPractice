namespace Slb.Horizon.GCFramework
{
    public class GcParameterSlot : IGcDataSlot
    {
        public GcParameterSlot(IGcCollectionService collectionService)
        {
            m_paraService = collectionService;
        }


        public GcDataSlotValue GetDataValue()
        {
            return new GcDataSlotValue(){StringValue =  m_paraService.GetValue()};

        }


        private IGcCollectionService m_paraService;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcParameterSlot.cs;1 */
/*       1*[1647956] 24-JUL-2012 01:56:57 (GMT) YLi27 */
/*         "new classes to support new depth summary listing" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcParameterSlot.cs;1 */
