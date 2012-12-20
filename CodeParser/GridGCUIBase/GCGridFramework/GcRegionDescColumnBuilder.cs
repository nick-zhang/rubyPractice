using System.Collections.Generic;

namespace Slb.Horizon.GCFramework
{
    public class GcRegionDescColumnBuilder : IGcRegionDefinitionBuilder
    {
        public GcRegionDescColumnBuilder(int regionWidth)
        {
            m_RegionWidth = regionWidth;
        }

        public GcRegionDefinition Build(IGcDataSlot titleSlot, List<GcDataTuple> parameterList)
        {
            var paraRegion = new GcRegionDefinition();

            if (titleSlot != null)
                paraRegion.SetTitle(new GcRowDefintion()
                    .AddCell(new GcCellDefinition(titleSlot, new GcSize(1, m_RegionWidth), GcCellStyle.TitleCell)));

            foreach (var gcParameterTuple in parameterList)
            {
                paraRegion.AddRow(new GcRowDefintion()
                    .AddCell(new GcCellDefinition(gcParameterTuple.Desprition, new GcSize(1, m_RegionWidth), GcCellStyle.NormalCell)));
            }
            paraRegion.Width = m_RegionWidth;
            return paraRegion;
        }

        private int m_RegionWidth;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcRegionDescColumnBuilder.cs;1 */
/*       1*[1657754] 22-AUG-2012 01:31:55 (GMT) XCui4 */
/*         "[P4] Add parameters for logging cable in Depth Summary" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcRegionDescColumnBuilder.cs;1 */
