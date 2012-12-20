namespace Slb.Horizon.GCFramework
{
    public class GcLabelSlot : IGcDataSlot
    {
        public GcLabelSlot(string label)
        {
            m_Label = label;
        }
        

        public GcDataSlotValue GetDataValue()
        {
            return new GcDataSlotValue(){StringValue =  m_Label};
        }

        private readonly string m_Label;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcLabelSlot.cs;1 */
/*       1*[1647956] 24-JUL-2012 01:56:57 (GMT) YLi27 */
/*         "new classes to support new depth summary listing" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcLabelSlot.cs;1 */
