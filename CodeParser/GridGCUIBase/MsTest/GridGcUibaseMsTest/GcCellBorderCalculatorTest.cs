using Microsoft.VisualStudio.TestTools.UnitTesting;
using Slb.Horizon.GCFramework;

namespace GridGcUibaseMsTest
{
    [TestClass]
    public class GcCellBorderCalculatorTest
    {
        [TestMethod]
        public void Return_Predefined_Border_Def_If_All_Cell_Borders_Are_Defined()
        {
            _sut = new GcCellBorderDef(GcBorder.Thin, GcBorder.Thin, GcBorder.Thin, GcBorder.Thin);
            var result = _sut.Calculate(new GcElementAnchor());

            AssertBordefDefintion(result, _sut);
        }

        [TestMethod]
        public void Return_Calculated_Border_Def_If_All_Cell_Borders_Are_Not_Defined()
        {
            _sut = new GcCellBorderDef(GcBorder.Undefined, GcBorder.Undefined, GcBorder.Undefined, GcBorder.Undefined);
            var predefinedBorder = _sut.Calculate(new GcElementAnchor() { Region = GcElementAnchorType.Left, Row = GcElementAnchorType.Top, Cell = GcElementAnchorType.Left });
            var result = new GcCellBorderDef(GcBorder.Thin, GcBorder.Invisible, GcBorder.ExtraThick, GcBorder.Invisible);
            
            AssertBordefDefintion(result, predefinedBorder);
        }

        private static void AssertBordefDefintion(GcCellBorderDef result, GcCellBorderDef predefinedBorder)
        {
            Assert.AreEqual(predefinedBorder.Top, result.Top);
            Assert.AreEqual(predefinedBorder.Bottom, result.Bottom);
            Assert.AreEqual(predefinedBorder.Left, result.Left);
            Assert.AreEqual(predefinedBorder.Right, result.Right);
        }

        private GcCellBorderDef _sut;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcCellBorderCalculatorTest.cs;3 */
/*       1*[1649463] 27-JUL-2012 03:31:33 (GMT) YLi27 */
/*         "integrate new depth summary listing into exisitng report" */
/*       2*[1657754] 22-AUG-2012 01:31:55 (GMT) XCui4 */
/*         "[P4] Add parameters for logging cable in Depth Summary" */
/*       3*[1666783] 11-SEP-2012 07:57:13 (GMT) XCui4 */
/*         "[P4] Refactoring after remove vertical black line from title in depth summary" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcCellBorderCalculatorTest.cs;3 */
