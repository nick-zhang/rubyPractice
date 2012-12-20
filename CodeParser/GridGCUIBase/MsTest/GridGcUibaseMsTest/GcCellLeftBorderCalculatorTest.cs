using Microsoft.VisualStudio.TestTools.UnitTesting;
using Slb.Horizon.GCFramework;

namespace GridGcUibaseMsTest
{
    [TestClass]
    public class GcCellLeftBorderCalculatorTest
    {
        [TestInitialize()]
        public void MyTestInitialize()
        {
            _anchor = new GcElementAnchor();
        }

        [TestMethod]
        public void Return_Block_Border_When_Region_In_Left_And_Cell_In_Left()
        {
            _anchor.Region = GcElementAnchorType.Left;
            _anchor.Cell = GcElementAnchorType.Left;

            Assert.AreEqual(GcBorder.ExtraThick, _anchor.CalculateLeftBorder());
        }

        [TestMethod]
        public void Return_Block_Border_When_Region_Full_Occupied_And_Cell_In_Left()
        {
            _anchor.Region = GcElementAnchorType.Full;
            _anchor.Cell = GcElementAnchorType.Left;

            Assert.AreEqual(GcBorder.ExtraThick, _anchor.CalculateLeftBorder());
        }

        [TestMethod]
        public void Return_Block_Border_When_Region_In_Left_And_Cell_Full_Occupied()
        {
            _anchor.Region = GcElementAnchorType.Left;
            _anchor.Cell = GcElementAnchorType.Full;

            Assert.AreEqual(GcBorder.ExtraThick, _anchor.CalculateLeftBorder());
        }

        [TestMethod]
        public void Return_Block_Border_When_Region_Full_Occupied_And_Cell_Full_Occupied()
        {
            _anchor.Region = GcElementAnchorType.Full;
            _anchor.Cell = GcElementAnchorType.Full;

            Assert.AreEqual(GcBorder.ExtraThick, _anchor.CalculateLeftBorder());
        }

        [TestMethod]
        public void Return_Region_Border_When_Region_Not_At_Left_And_Cell_In_Left()
        {
            _anchor.Region = GcElementAnchorType.Right;
            _anchor.Cell = GcElementAnchorType.Left;
            Assert.AreEqual(GcBorder.Invisible, _anchor.CalculateLeftBorder());
        }

        [TestMethod]
        public void Return_Vertical_Border_When_Region_At_Left_And_Cell_Not_In_Left()
        {
            _anchor.Region = GcElementAnchorType.Left;
            _anchor.Cell = GcElementAnchorType.Middle;
            Assert.AreEqual(GcBorder.Invisible, _anchor.CalculateLeftBorder());
        }

        [TestMethod]
        public void Return_Vertical_Border_When_Region_Not_At_Left_And_Cell_Not_In_Left()
        {
            _anchor.Region = GcElementAnchorType.Right;
            _anchor.Cell = GcElementAnchorType.Middle;
            Assert.AreEqual(GcBorder.Invisible, _anchor.CalculateLeftBorder());
        }

        private GcElementAnchor _anchor;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcCellLeftBorderCalculatorTest.cs;2 */
/*       1*[1648275] 24-JUL-2012 06:06:01 (GMT) YLi27 */
/*         "new class to define the UI layout for the graphical components" */
/*       2*[1666783] 11-SEP-2012 07:57:13 (GMT) XCui4 */
/*         "[P4] Refactoring after remove vertical black line from title in depth summary" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcCellLeftBorderCalculatorTest.cs;2 */
