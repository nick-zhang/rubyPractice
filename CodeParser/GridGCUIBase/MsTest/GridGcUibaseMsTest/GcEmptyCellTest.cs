using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Slb.Horizon.GCFramework;

namespace GridGcUibaseMsTest
{    
    [TestClass]
    public class GcEmptyCellTest
    {        
        private const int CELL_WIDTH = 5;
        private const int CELL_HEIGHT = 5;
        private const int EMPTY_CELL_HEIGHT = 1;

        [TestMethod]
        public void empty_cell_size_when_height_is_one()
        {
            GcSize size = new GcSize(CELL_HEIGHT, CELL_WIDTH);

            GcEmptyCell sut = new GcEmptyCell(size);

            GcSize emptyCellSize = sut.Size;

            Assert.AreEqual(EMPTY_CELL_HEIGHT, emptyCellSize.Height);
            Assert.AreEqual(CELL_WIDTH, emptyCellSize.Width);
        }

        [TestMethod]
        public void empty_cell_draw_shoule_set_empty_string()
        {
            GcSize size = new GcSize();
            GcEmptyCell sut = new GcEmptyCell(size);

            Mock<IGcGrid> mockGrid = new Mock<IGcGrid>();
            GcPosition gcPosition = new GcPosition();
            GcSize gcSize = new GcSize();
            GcElementAnchor elementAnchor = new GcElementAnchor();


            mockGrid.Setup(
                mock =>
                mock.SetText(It.IsAny<string>(), It.IsAny<GcCellBorderDef>(), It.IsAny<GcPosition>(), 
                             It.IsAny<GcSize>(), It.IsAny<GcCellStyle>()));

            sut.Draw(mockGrid.Object, gcPosition, gcSize, elementAnchor);

            mockGrid.Verify(
                mock =>
                mock.SetText(string.Empty, It.IsAny<GcCellBorderDef>(), It.IsAny<GcPosition>(), 
                             It.IsAny<GcSize>(), It.IsAny<GcCellStyle>()), Times.Once());
        }
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcEmptyCellTest.cs;1 */
/*       1*[1660835] 22-AUG-2012 10:01:07 (GMT) SLiu10 */
/*         "[P4] Add unit test for Depth Summary part 1" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcEmptyCellTest.cs;1 */
