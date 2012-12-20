using System.Collections.Generic;
using System.Linq;
using GridGCUIBase.GCGridFramework;

namespace Slb.Horizon.GCFramework
{
    public interface IGcBlockBuilder
    {
        GcBlock BuildBlock(List<GcRegionDefinition> listOfRegions);
    }

    public class GcBlockBuilder : IGcBlockBuilder
    {
        public GcBlockBuilder(int blockWidth)
        {
            m_BlockWidth = blockWidth;
        }

        public void Draw(IGcGrid grid, List<GcRegionDefinition> listOfRegions)
        {
            GcBlock block = BuildBlock(listOfRegions);
            int height = block.Size.Height;
            int rowIndex = grid.NewRow(height, 20);
            block.Draw(grid, new GcPosition() { RowIndex = rowIndex, ColumnIndex = 1 }, new GcSize(height + rowIndex - 1, m_BlockWidth), new GcElementAnchor());
        }

        public GcBlock BuildBlock(List<GcRegionDefinition> listOfRegions)
        {
            var maxHeight = listOfRegions.Select(dslRegionDefinition => dslRegionDefinition.Rows.Count).Concat(new[] { 0 }).Max();
            var region = new GcRegionBuilder(maxHeight,
                new GcCellBorderDef(GcBorder.Invisible, GcBorder.Thin, GcBorder.RangeTitle, GcBorder.RangeTitle),
                new GcCellBorderDef(GcBorder.Undefined, GcBorder.Undefined, GcBorder.Undefined, GcBorder.Undefined));
            var block = new GcBlock(m_BlockWidth);
            foreach (var dslRegionDefinition in listOfRegions)
            {
                block.AddElement(region.BuildRegion(dslRegionDefinition));
            }

            return block;
        }

        private readonly int m_BlockWidth;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcBlockBuilder.cs;6 */
/*       1*[1648275] 24-JUL-2012 06:06:01 (GMT) YLi27 */
/*         "new class to define the UI layout for the graphical components" */
/*       2*[1648427] 25-JUL-2012 02:32:30 (GMT) YLi27 */
/*         "Support Customized Cell Style" */
/*       3*[1649463] 27-JUL-2012 03:31:33 (GMT) YLi27 */
/*         "integrate new depth summary listing into exisitng report" */
/*       4*[1657754] 22-AUG-2012 01:31:55 (GMT) XCui4 */
/*         "[P4] Add parameters for logging cable in Depth Summary" */
/*       5*[1665114] 05-SEP-2012 03:45:22 (GMT) XCui4 */
/*         "[P4] Remove Vertical Black Line From Title in Depth Summary" */
/*       6*[1666783] 11-SEP-2012 07:57:13 (GMT) XCui4 */
/*         "[P4] Refactoring after remove vertical black line from title in depth summary" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcBlockBuilder.cs;6 */
