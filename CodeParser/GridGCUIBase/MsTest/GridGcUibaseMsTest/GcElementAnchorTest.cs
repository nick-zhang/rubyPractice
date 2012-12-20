using Microsoft.VisualStudio.TestTools.UnitTesting;
using Slb.Horizon.GCFramework;

namespace GridGcUibaseMsTest
{
    [TestClass]
    public class GcElementAnchorTest
    {
        [TestMethod]
        public void ShouldReturnLeftBorderCorrectly()
        {
            var anchor = new GcElementAnchor();
            anchor.Region = GcElementAnchorType.Left;
            anchor.Row = GcElementAnchorType.Left;
            anchor.Cell = GcElementAnchorType.Left;
            var result = anchor.CalculateLeftBorder();
            Assert.AreEqual(GcBorder.ExtraThick, result);
        }
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcElementAnchorTest.cs;1 */
/*       1*[1683431] 18-OCT-2012 10:03:22 (GMT) XCui4 */
/*         "[2013.1] Add MsTest for GridGcUIBase" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcElementAnchorTest.cs;1 */
