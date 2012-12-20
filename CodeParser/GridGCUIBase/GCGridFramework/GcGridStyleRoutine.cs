using System;
using System.Drawing;
using Syncfusion.Windows.Forms.Grid;

namespace Slb.Horizon.GCFramework
{
    public static class GcGridStyleRoutine
    {
        static GcGridStyleRoutine()
        {
            m_NormalFont.Facename = "Microsoft Sans Serif";
            Font rowDataFont = new Font(m_NormalFont.Facename, (float) 6);
            m_NormalFont.Size = GridFontInfo.SizeInWorldUnit(rowDataFont);
            m_NormalFont.Bold = false;

            m_TitleFont.Facename = "Microsoft Sans Serif";
            Font titleFont = new Font(m_TitleFont.Facename, (float) 8);
            m_TitleFont.Size = GridFontInfo.SizeInWorldUnit(titleFont);
            m_TitleFont.Bold = true;
        }

        public static GridStyleInfo GetGridStyleInfo(GcCellBorderDef borderDef, GcCellStyle cellStyle)
        {
            var gridStyleInfo = new GridStyleInfo();
            gridStyleInfo.Borders.Top = GetGridBorder(borderDef.Top);
            gridStyleInfo.Borders.Bottom = GetGridBorder(borderDef.Bottom);
            gridStyleInfo.Borders.Left = GetGridBorder(borderDef.Left);
            gridStyleInfo.Borders.Right = GetGridBorder(borderDef.Right);

            gridStyleInfo.HorizontalAlignment = GetGridHorizontalAlignmentInfo(cellStyle.HorizontalAlignment);
            gridStyleInfo.Font = GetGridFontInfo(cellStyle.Font);

            return gridStyleInfo;
        }

        private static GridFontInfo GetGridFontInfo(GcFontType dslFontType)
        {
            if (dslFontType == GcFontType.NormalText)
            {
                return m_NormalFont;
            }
            return m_TitleFont;
        }

        private static GridHorizontalAlignment GetGridHorizontalAlignmentInfo(
            GcCellHorizontalAlignment horizontalAlignment)
        {
            switch (horizontalAlignment)
            {
                case GcCellHorizontalAlignment.Center:
                    return GridHorizontalAlignment.Center;
                case GcCellHorizontalAlignment.Right:
                    return GridHorizontalAlignment.Right;
            }
            return GridHorizontalAlignment.Left;
        }

        private static GridBorder GetGridBorder(GcBorder border)
        {
            GridBorder gridBorder = null;
            switch (border)
            {
                case GcBorder.ExtraThick:
                    gridBorder = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.ExtraThick);
                    break;
                case GcBorder.Thick:
                    gridBorder = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thick);
                    break;
                case GcBorder.Thin:
                    gridBorder = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thin);
                    break;
                case GcBorder.Invisible:
                    gridBorder = new GridBorder(GridBorderStyle.None, Color.Black, GridBorderWeight.Thin);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("border");
            }

            return gridBorder;
        }

        private static GridFontInfo m_NormalFont = new GridFontInfo();
        private static GridFontInfo m_TitleFont = new GridFontInfo();
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcGridStyleRoutine.cs;2 */
/*       1*[1648275] 24-JUL-2012 06:06:01 (GMT) YLi27 */
/*         "new class to define the UI layout for the graphical components" */
/*       2*[1661568] 24-AUG-2012 05:40:45 (GMT) SLiu10 */
/*         "[P4] Depth Summary unit test for GcGrid and GcGridStyleRoutine" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcGridStyleRoutine.cs;2 */
