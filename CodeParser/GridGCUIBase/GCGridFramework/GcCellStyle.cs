namespace Slb.Horizon.GCFramework
{
    public enum GcCellHorizontalAlignment
    {
        Left,
        Center,
        Right
    }

    public enum GcFontType
    {
        TitleText,
        NormalText
    }

    public class GcCellStyle
    {
        public GcCellStyle(GcFontType font, GcCellHorizontalAlignment alignment)
        {
            Font = font;
            HorizontalAlignment = alignment;
        }

        public GcCellHorizontalAlignment HorizontalAlignment { get; set; }

        public GcFontType Font { get; set; }

        public static GcCellStyle TitleCell = new GcCellStyle(GcFontType.TitleText, GcCellHorizontalAlignment.Left);
        public static GcCellStyle NormalCell = new GcCellStyle(GcFontType.NormalText, GcCellHorizontalAlignment.Left);
    }

}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcCellStyle.cs;3 */
/*       1*[1647855] 23-JUL-2012 07:32:38 (GMT) YLi27 */
/*         "Some basic definition for graphical components" */
/*       2*[1657754] 22-AUG-2012 01:31:55 (GMT) XCui4 */
/*         "[P4] Add parameters for logging cable in Depth Summary" */
/*       3*[1665114] 05-SEP-2012 03:45:22 (GMT) XCui4 */
/*         "[P4] Remove Vertical Black Line From Title in Depth Summary" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcCellStyle.cs;3 */
