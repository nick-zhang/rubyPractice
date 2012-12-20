using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Slb.Horizon.GCFramework;
using Syncfusion.Windows.Forms.Grid;

namespace GridGcUibaseMsTest
{
    
    [TestClass]
    public class GcGridStyleRoutineTest
    {
        
        [TestMethod]
        public void return_title_font_when_font_type_is_title_text()
        {
            GridFontInfo expectedTitleFont = new GridFontInfo();
            expectedTitleFont.Facename = "Microsoft Sans Serif";
            Font titleFont = new Font(expectedTitleFont.Facename, (float) 8);
            expectedTitleFont.Size = GridFontInfo.SizeInWorldUnit(titleFont);
            expectedTitleFont.Bold = true;

            GcFontType font = GcFontType.TitleText;
            GcCellHorizontalAlignment horizontalAlignment = GcCellHorizontalAlignment.Left;

            GcCellBorderDef boarderDef = new GcCellBorderDef();
            GcCellStyle cellStyle = new GcCellStyle(font,horizontalAlignment);

            GridStyleInfo styleInfo = GcGridStyleRoutine.GetGridStyleInfo(boarderDef.Calculate(new GcElementAnchor()), cellStyle);
                        
            Assert.AreEqual(expectedTitleFont.Facename, styleInfo.Font.Facename);
            Assert.AreEqual(expectedTitleFont.Size, styleInfo.Font.Size);
            Assert.AreEqual(expectedTitleFont.Bold,styleInfo.Font.Bold);
        }

        [TestMethod]
        public void return_normal_font_when_font_type_is_normal_text()
        {
            GridFontInfo expectedTitleFont = new GridFontInfo();
            expectedTitleFont.Facename = "Microsoft Sans Serif";
            Font titleFont = new Font(expectedTitleFont.Facename, (float)6);
            expectedTitleFont.Size = GridFontInfo.SizeInWorldUnit(titleFont);
            expectedTitleFont.Bold = false;

            GcFontType font = GcFontType.NormalText;
            GcCellHorizontalAlignment horizontalAlignment = GcCellHorizontalAlignment.Left;

            GcCellBorderDef boarderDef = new GcCellBorderDef();
            GcCellStyle cellStyle = new GcCellStyle(font, horizontalAlignment);

            GridStyleInfo styleInfo = GcGridStyleRoutine.GetGridStyleInfo(boarderDef.Calculate(new GcElementAnchor()), cellStyle);

            Assert.AreEqual(expectedTitleFont.Facename, styleInfo.Font.Facename);
            Assert.AreEqual(expectedTitleFont.Size, styleInfo.Font.Size);
            Assert.AreEqual(expectedTitleFont.Bold, styleInfo.Font.Bold);
        }

        [TestMethod]
        public void return_left_alignment_when_input_left_alignment()
        {
            GcFontType font = GcFontType.TitleText;
            GcCellHorizontalAlignment horizontalAlignment = GcCellHorizontalAlignment.Left;

            GcCellBorderDef boarderDef = new GcCellBorderDef();
            GcCellStyle cellStyle = new GcCellStyle(font, horizontalAlignment);

            GridStyleInfo styleInfo = GcGridStyleRoutine.GetGridStyleInfo(boarderDef.Calculate(new GcElementAnchor()), cellStyle);

            Assert.AreEqual(GridHorizontalAlignment.Left, styleInfo.HorizontalAlignment);
        }

        [TestMethod]
        public void return_center_alignment_when_input_center_alignment()
        {
            GcFontType font = GcFontType.TitleText;
            GcCellHorizontalAlignment horizontalAlignment = GcCellHorizontalAlignment.Center;

            GcCellBorderDef boarderDef = new GcCellBorderDef();
            GcCellStyle cellStyle = new GcCellStyle(font, horizontalAlignment);

            GridStyleInfo styleInfo = GcGridStyleRoutine.GetGridStyleInfo(boarderDef.Calculate(new GcElementAnchor()), cellStyle);

            Assert.AreEqual(GridHorizontalAlignment.Center, styleInfo.HorizontalAlignment);
        }

        [TestMethod]
        public void return_right_alignment_when_input_right_alignment()
        {
            GcFontType font = GcFontType.TitleText;
            GcCellHorizontalAlignment horizontalAlignment = GcCellHorizontalAlignment.Right;

            GcCellBorderDef boarderDef = new GcCellBorderDef();
            GcCellStyle cellStyle = new GcCellStyle(font, horizontalAlignment);

            GridStyleInfo styleInfo = GcGridStyleRoutine.GetGridStyleInfo(boarderDef.Calculate(new GcElementAnchor()), cellStyle);

            Assert.AreEqual(GridHorizontalAlignment.Right, styleInfo.HorizontalAlignment);
        }
        
        [TestMethod]
        public void return_boarder_by_boarderdef()
        {
            GcFontType font = GcFontType.TitleText;
            GcCellHorizontalAlignment horizontalAlignment = GcCellHorizontalAlignment.Left;

            var boarderDef = new GcCellBorderDef
                                 {
                                     Top = GcBorder.ExtraThick,
                                     Bottom = GcBorder.Thick,
                                     Left = GcBorder.Thin,
                                     Right = GcBorder.Invisible
                                 };

            var cellStyle = new GcCellStyle(font, horizontalAlignment);

            var styleInfo = GcGridStyleRoutine.GetGridStyleInfo(boarderDef, cellStyle);

            var expectedTopBorder = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.ExtraThick);
            var expectedBottomBorder = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thick);
            var expectedLeftBorder = new GridBorder(GridBorderStyle.Solid, Color.Black, GridBorderWeight.Thin);
            var expectedRightBorder = new GridBorder(GridBorderStyle.None, Color.Black, GridBorderWeight.Thin);

            Assert.AreEqual(expectedTopBorder, styleInfo.Borders.Top);
            Assert.AreEqual(expectedBottomBorder, styleInfo.Borders.Bottom);
            Assert.AreEqual(expectedLeftBorder, styleInfo.Borders.Left);
            Assert.AreEqual(expectedRightBorder, styleInfo.Borders.Right);
        }
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcGridStyleRoutineTest.cs;2 */
/*       1*[1661568] 24-AUG-2012 05:40:45 (GMT) SLiu10 */
/*         "[P4] Depth Summary unit test for GcGrid and GcGridStyleRoutine" */
/*       2*[1666783] 11-SEP-2012 07:57:13 (GMT) XCui4 */
/*         "[P4] Refactoring after remove vertical black line from title in depth summary" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcGridStyleRoutineTest.cs;2 */
