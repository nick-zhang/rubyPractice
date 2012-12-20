namespace Slb.Horizon.GCFramework
{
    public class GcEmptyCell : IGcElement
    {
        public GcEmptyCell(GcSize size)
        {
            m_Size = size;
        }

        public GcEmptyCell(GcSize size, GcCellStyle cellStyle)
        {
            m_Size = size;
            m_CellStyle = cellStyle;
        }

        public void Draw(IGcGrid grid, GcPosition position, GcSize size, GcElementAnchor anchor)
        {
            grid.SetText(string.Empty, new GcCellBorderDef().Calculate(anchor), position, m_Size, m_CellStyle);
        }

        public GcSize Size
        {
            get { return new GcSize(1, m_Size.Width);}
        }

        private GcSize m_Size;
        private GcCellStyle m_CellStyle;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcEmptyCell.cs;3 */
/*       1*[1648275] 24-JUL-2012 06:06:01 (GMT) YLi27 */
/*         "new class to define the UI layout for the graphical components" */
/*       2*[1648427] 25-JUL-2012 02:32:30 (GMT) YLi27 */
/*         "Support Customized Cell Style" */
/*       3*[1666783] 11-SEP-2012 07:57:13 (GMT) XCui4 */
/*         "[P4] Refactoring after remove vertical black line from title in depth summary" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcEmptyCell.cs;3 */
