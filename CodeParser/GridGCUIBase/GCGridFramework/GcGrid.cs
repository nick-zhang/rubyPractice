using Slb.Horizon.Products.GenericComponents;
using Syncfusion.Windows.Forms.Grid;

namespace Slb.Horizon.GCFramework
{
    public class GcGrid : IGcGrid
    {
        public GcGrid(SlbGridControl2 gridControl)
        {
            m_gridControlMain = gridControl;
        }

        public int NewRow(int rowHeight)
        {
            return NewRow(1, rowHeight);
        }

        public int NewRow(int rowCount, int rowHeight)
        {
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                m_gridControlMain.RowCount += 1;
                m_gridControlMain.RowHeights[m_gridControlMain.RowCount] = rowHeight;
            }

            return m_gridControlMain.RowCount - rowCount + 1;
        }

        public void SetText(string text, GcCellBorderDef cellBorderDef, GcPosition position, GcSize size, GcCellStyle cellStyle)
        {
            m_gridControlMain.CoveredRanges.Add(GridRangeInfo.Cells(position.RowIndex, position.ColumnIndex, position.RowIndex + size.Height - 1, position.ColumnIndex + size.Width - 1));

            GridStyleInfo gridCellStyle = GcGridStyleRoutine.GetGridStyleInfo(cellBorderDef, cellStyle);
            gridCellStyle.CellValue = text;

            m_gridControlMain.SetCellInfo(position.RowIndex, position.ColumnIndex, gridCellStyle, Syncfusion.Styles.StyleModifyType.Changes, true, false);

            m_gridControlMain.Model.RowHeights.ResizeToFit(GridRangeInfo.Cells(position.RowIndex, position.ColumnIndex,
                position.RowIndex + size.Height - 1, position.ColumnIndex + size.Width - 1), GridResizeToFitOptions.NoShrinkSize);
        }

        protected SlbGridControl2 m_gridControlMain;

    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcGrid.cs;1 */
/*       1*[1648275] 24-JUL-2012 06:06:01 (GMT) YLi27 */
/*         "new class to define the UI layout for the graphical components" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcGrid.cs;1 */
