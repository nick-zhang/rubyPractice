namespace Slb.Horizon.GCFramework
{
    public class GcCellDefinition
    {
        public GcCellDefinition(IGcDataSlot slot, GcSize size, GcCellStyle cellStyle)
        {
            Slot = slot;
            Size = size;
            CellStyle = cellStyle;
        }

        public IGcDataSlot Slot { get; set; }
        public GcSize Size { get; set; }
        public GcCellStyle CellStyle { get; set; }
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcCellDefinition.cs;3 */
/*       1*[1648275] 24-JUL-2012 06:06:01 (GMT) YLi27 */
/*         "new class to define the UI layout for the graphical components" */
/*       2*[1648427] 25-JUL-2012 02:32:30 (GMT) YLi27 */
/*         "Support Customized Cell Style" */
/*       3*[1668705] 12-SEP-2012 07:31:30 (GMT) XCui4 */
/*         "[P4] Depth Summary Code Clean Up, No Logic Change" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcCellDefinition.cs;3 */
