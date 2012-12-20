using Microsoft.VisualStudio.TestTools.UnitTesting;
using Slb.Horizon.GCFramework;

namespace GridGcUibaseMsTest
{
    [TestClass]
    public class GcCellBottomBorderCalculatorTest
    {
        [TestInitialize()]
        public void MyTestInitialize()
        {
            _anchor = new GcElementAnchor();
        }

        [TestMethod]
        public void Return_Block_Border_If_Row_Full_Occupied_The_Region()
        {
            _anchor.Row = GcElementAnchorType.Full;
            Assert.AreEqual(GcBorder.Thin, _anchor.CalculateBottomBorder());
        }

        [TestMethod]
        public void Return_Block_Border_If_Row_Is_At_Bottom()
        {
            _anchor.Row = GcElementAnchorType.Bottom;
            Assert.AreEqual(GcBorder.Thin, _anchor.CalculateBottomBorder());
        }

        [TestMethod]
        public void Return_Horizontal_Border_If_Row_Is_Not_At_Bottom()
        {
            _anchor.Row = GcElementAnchorType.Middle;
            Assert.AreEqual(GcBorder.Invisible, _anchor.CalculateBottomBorder());
        }

        private GcElementAnchor _anchor;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcCellBottomBorderCalculatorTest.cs;2 */
/*       1*[1648275] 24-JUL-2012 06:06:01 (GMT) YLi27 */
/*         "new class to define the UI layout for the graphical components" */
/*       2*[1666783] 11-SEP-2012 07:57:13 (GMT) XCui4 */
/*         "[P4] Refactoring after remove vertical black line from title in depth summary" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcCellBottomBorderCalculatorTest.cs;2 */
