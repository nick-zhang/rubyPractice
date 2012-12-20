using System.Collections.Generic;

namespace Slb.Horizon.GCFramework
{
    public class GcRegionEmptyColumnBuilder : IGcRegionDefinitionBuilder
    {
        public GcRegionEmptyColumnBuilder(int regionWidth, int rowCount)
        {
            m_RegionWidth = regionWidth;
            m_RowCount = rowCount;
        }

        public GcRegionDefinition Build(IGcDataSlot titleSlot, List<GcDataTuple> parameterList)
        {
            int emptyRowCount = m_RowCount;
            var paraRegion = new GcRegionDefinition();

            paraRegion.SetTitle(new GcRowDefintion()
                    .AddCell(new GcCellDefinition(new GcLabelSlot(string.Empty), new GcSize(1, m_RegionWidth), GcCellStyle.TitleCell)));

            for (int i = 0; i < emptyRowCount; i++)
            {
                paraRegion.AddRow(new GcRowDefintion()
                    .AddCell(new GcCellDefinition(new GcLabelSlot(string.Empty), new GcSize(1, m_RegionWidth), GcCellStyle.NormalCell)));
            }

            paraRegion.Width = m_RegionWidth;
            return paraRegion;
        }

        private int m_RegionWidth;
        private int m_RowCount;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcRegionEmptyColumnBuilder.cs;1 */
/*       1*[1657754] 22-AUG-2012 01:31:55 (GMT) XCui4 */
/*         "[P4] Add parameters for logging cable in Depth Summary" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcRegionEmptyColumnBuilder.cs;1 */
