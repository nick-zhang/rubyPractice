using System.Collections.Generic;

namespace Slb.Horizon.GCFramework
{
    public class GcRegionTwoColumnBuilder : IGcRegionDefinitionBuilder
    {
        public GcRegionTwoColumnBuilder(int regionWidth)
        {
            m_RegionWidth = regionWidth;
        }
        public GcRegionDefinition Build(IGcDataSlot titleSlot, List<GcDataTuple> parameterList)
        {
            var paraRegion = new GcRegionDefinition();
            var gcTitleSlot = titleSlot ?? new GcLabelSlot(string.Empty);

            paraRegion
                .SetTitle(new GcRowDefintion()
                              .AddCell(new GcCellDefinition(gcTitleSlot, new GcSize(1, m_RegionWidth), GcCellStyle.TitleCell)));

            var cellWidth = m_RegionWidth/2;
            foreach (var gcParameterTuple in parameterList)
            {
                paraRegion.AddRow(new GcRowDefintion()
                                      .AddCell(new GcCellDefinition(gcParameterTuple.Desprition, new GcSize(1, cellWidth),
                                                                    GcCellStyle.NormalCell))
                                      .AddCell(new GcCellDefinition(gcParameterTuple.Data, new GcSize(1, cellWidth),
                                                                    GcCellStyle.NormalCell)));

            }
            paraRegion.Width = m_RegionWidth;
            return paraRegion;
        }

        private readonly int m_RegionWidth ;

    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcRegionTwoColumnBuilder.cs;4 */
/*       1*[1648975] 26-JUL-2012 02:14:18 (GMT) YLi27 */
/*         "some utility classes to support creating the region definitions easily" */
/*       2*[1649463] 27-JUL-2012 03:31:33 (GMT) YLi27 */
/*         "integrate new depth summary listing into exisitng report" */
/*       3*[1665114] 05-SEP-2012 03:45:22 (GMT) XCui4 */
/*         "[P4] Remove Vertical Black Line From Title in Depth Summary" */
/*       4*[1668705] 12-SEP-2012 07:31:30 (GMT) XCui4 */
/*         "[P4] Depth Summary Code Clean Up, No Logic Change" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcRegionTwoColumnBuilder.cs;4 */
