using Microsoft.VisualStudio.TestTools.UnitTesting;
using Slb.Horizon.GCFramework;

namespace GridGcUibaseMsTest
{
    [TestClass]
    public class GcCellTopBorderCalculatorTest
    {
        [TestMethod]
        public void Return_Block_Border_If_Row_Full_Occupied_The_Region()
        {
            _anchor.Row = GcElementAnchorType.Full;
            Assert.AreEqual(GcBorder.Thin, _anchor.CalculateTopBorder());
        }

        [TestMethod]
        public void Return_Block_Border_If_Row_Is_In_Top()
        {
            _anchor.Row = GcElementAnchorType.Top;
            Assert.AreEqual(GcBorder.Thin, _anchor.CalculateTopBorder());
        }

        [TestMethod]
        public void Return_Horizontal_Border_If_Row_Is_Not_In_Top()
        {
            _anchor.Row = GcElementAnchorType.Middle;
            Assert.AreEqual(GcBorder.Invisible, _anchor.CalculateTopBorder());
        }

        private GcElementAnchor _anchor;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcCellTopBorderCalculatorTest.cs;2 */
/*       1*[1648275] 24-JUL-2012 06:06:01 (GMT) YLi27 */
/*         "new class to define the UI layout for the graphical components" */
/*       2*[1666783] 11-SEP-2012 07:57:13 (GMT) XCui4 */
/*         "[P4] Refactoring after remove vertical black line from title in depth summary" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcCellTopBorderCalculatorTest.cs;2 */
