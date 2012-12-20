using Microsoft.VisualStudio.TestTools.UnitTesting;
using Slb.Horizon.GCFramework;
using Slb.Horizon.Products.GenericComponents;

namespace GridGcUibaseMsTest
{    
    [TestClass]
    public class GcGridTest
    {    
        private const int ROW_HEIGHT = 5;
        [TestMethod]
        public void row_count_plus_one_after_add_new_row()
        {
            SlbGridControl2 gridControlMain = new SlbGridControl2();
            int initialGridRowCount = gridControlMain.RowCount;
            GcGrid sut = new GcGrid(gridControlMain);

            int rowCount = sut.NewRow(ROW_HEIGHT);

            Assert.AreEqual(initialGridRowCount+1, rowCount);
        }        
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcGridTest.cs;1 */
/*       1*[1661568] 24-AUG-2012 05:40:45 (GMT) SLiu10 */
/*         "[P4] Depth Summary unit test for GcGrid and GcGridStyleRoutine" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcGridTest.cs;1 */
