namespace Slb.Horizon.GCFramework
{
    public interface IGcElement
    {
        void Draw(IGcGrid grid, GcPosition position, GcSize size, GcElementAnchor anchor);
        GcSize Size { get; }
    }

    public interface IGcCompositeElement : IGcElement
    {
        IGcCompositeElement AddElement(IGcElement element);
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:IGcElement.cs;1 */
/*       1*[1647855] 23-JUL-2012 07:32:38 (GMT) YLi27 */
/*         "Some basic definition for graphical components" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:IGcElement.cs;1 */
