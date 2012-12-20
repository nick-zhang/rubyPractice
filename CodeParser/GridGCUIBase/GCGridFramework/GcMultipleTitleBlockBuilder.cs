using System.Collections.Generic;
using System.Linq;
using GridGCUIBase.GCGridFramework;

namespace Slb.Horizon.GCFramework
{
    public class GcMultipleTitleBlockBuilder : IGcBlockBuilder
    {
        public GcMultipleTitleBlockBuilder(int blockWidth)
        {
            m_BlockWidth = blockWidth;
        }

        public GcBlock BuildBlock(List<GcRegionDefinition> listOfRegions)
        {
            var maxHeight = listOfRegions.Select(dslRegionDefinition => dslRegionDefinition.Rows.Count).Concat(new[] { 0 }).Max();
            var region = new GcRegionBuilder(maxHeight, 
                                             new GcCellBorderDef(GcBorder.Invisible, GcBorder.Thin, GcBorder.Undefined, GcBorder.Undefined),
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
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcMultipleTitleBlockBuilder.cs;1 */
/*       1*[1666783] 11-SEP-2012 07:57:13 (GMT) XCui4 */
/*         "[P4] Refactoring after remove vertical black line from title in depth summary" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcMultipleTitleBlockBuilder.cs;1 */
