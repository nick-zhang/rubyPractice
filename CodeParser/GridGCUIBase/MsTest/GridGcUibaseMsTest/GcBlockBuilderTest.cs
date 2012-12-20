using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Slb.Horizon.GCFramework;
using Moq;

namespace GridGcUibaseMsTest
{
    [TestClass]
    public class GcBlockBuilderTest
    {
        [TestInitialize]
        public void MyTestInitialize()
        {
            _sut = new GcBlockBuilder(BlockWidth);
            _emptySlot = new Mock<IGcDataSlot>();
            _gridMock = new Mock<IGcGrid>();
            m_Region = new GcRegionDefinition();
        }

        [TestMethod]
        public void ShouldDrawBlockWithOneTitleAndTwoCellsAtCorrectPosition()
        {
            m_Region.Title = new GcRowDefintion().AddCell(new GcCellDefinition(_emptySlot.Object, new GcSize(1, 4), GcCellStyle.TitleCell));
            m_Region.AddRow(new GcRowDefintion()
                .AddCell(new GcCellDefinition(_emptySlot.Object, new GcSize(1, 2), GcCellStyle.NormalCell))
                .AddCell(new GcCellDefinition(_emptySlot.Object, new GcSize(1, 2), GcCellStyle.NormalCell)));

            _emptySlot.Setup(fw => fw.GetDataValue()).Returns(new GcDataSlotValue { StringValue = CellTextValue });
            _gridMock.Setup(fw => fw.NewRow(2, 20)).Returns(0);

            _sut.Draw(_gridMock.Object, new List<GcRegionDefinition> { m_Region });

            _gridMock.Verify(fw => fw.SetText(CellTextValue, It.IsAny<GcCellBorderDef>(), It.Is<GcPosition>(position => position.RowIndex == 0 && position.ColumnIndex == 1), new GcSize(1, 4), GcCellStyle.TitleCell));
            _gridMock.Verify(fw => fw.SetText(CellTextValue, It.IsAny<GcCellBorderDef>(), It.Is<GcPosition>(position => position.RowIndex == 1 && position.ColumnIndex == 1), new GcSize(1, 2), GcCellStyle.NormalCell));
            _gridMock.Verify(fw => fw.SetText(CellTextValue, It.IsAny<GcCellBorderDef>(), It.Is<GcPosition>(position => position.RowIndex == 1 && position.ColumnIndex == 3), new GcSize(1, 2), GcCellStyle.NormalCell));
        }

        private GcBlockBuilder _sut;
        private const int BlockWidth = 4;
        private Mock<IGcDataSlot> _emptySlot;
        private Mock<IGcGrid> _gridMock;
        private const String CellTextValue = "text";
        private GcRegionDefinition m_Region;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcBlockBuilderTest.cs;4 */
/*       1*[1649463] 27-JUL-2012 03:31:33 (GMT) YLi27 */
/*         "integrate new depth summary listing into exisitng report" */
/*       2*[1666783] 11-SEP-2012 07:57:13 (GMT) XCui4 */
/*         "[P4] Refactoring after remove vertical black line from title in depth summary" */
/*       3*[1668705] 12-SEP-2012 07:31:30 (GMT) XCui4 */
/*         "[P4] Depth Summary Code Clean Up, No Logic Change" */
/*       4*[1683431] 18-OCT-2012 10:03:22 (GMT) XCui4 */
/*         "[2013.1] Add MsTest for GridGcUIBase" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`MsTest`GridGcUibaseMsTest:GcBlockBuilderTest.cs;4 */
