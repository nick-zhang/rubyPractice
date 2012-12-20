namespace Slb.Horizon.GCFramework
{
    public interface IGcGrid
    {
        int NewRow(int rowHeight);
        int NewRow(int rowCount, int rowHeight);
        void SetText(string text, GcCellBorderDef cellBorderDef, GcPosition position, GcSize size, GcCellStyle cellStyle);
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:IGcGrid.cs;1 */
/*       1*[1647855] 23-JUL-2012 07:32:38 (GMT) YLi27 */
/*         "Some basic definition for graphical components" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:IGcGrid.cs;1 */
