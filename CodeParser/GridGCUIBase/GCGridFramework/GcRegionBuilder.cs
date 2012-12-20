using Slb.Horizon.GCFramework;

namespace GridGCUIBase.GCGridFramework
{
    internal interface IGcRegionBuilder
    {
        GcRegion BuildRegion(GcRegionDefinition gcRegionDefinition);
    }

    class GcRegionBuilder : IGcRegionBuilder
    {

        public GcRegionBuilder(int height, GcCellBorderDef titleCellBorderDef, GcCellBorderDef paramCellBorderDef)
        {
            m_GcTitleCellBorderDef = titleCellBorderDef;
            m_GcParamCellBorderDef = paramCellBorderDef;
            m_Height = height;
        }

        public GcRegion BuildRegion(GcRegionDefinition gcRegionDefinition)
        {
            var region = new GcRegion();
            ConstructRegionTitle(gcRegionDefinition, region);
            ConstructRegionParam(gcRegionDefinition, region);

            return region;
        }

        private void ConstructRegionTitle(GcRegionDefinition gcRegionDefinition, GcRegion region)
        {
            var titleRow = new GcRow();

            titleRow.AddElement(new GcTextCell(gcRegionDefinition.Title.Cells[0].Slot,
                                               gcRegionDefinition.Title.Cells[0].Size,
                                               gcRegionDefinition.Title.Cells[0].CellStyle, m_GcTitleCellBorderDef));
            region.AddElement(titleRow);
        }

        private void ConstructRegionParam(GcRegionDefinition gcRegionDefinition, GcRegion region)
        {
            foreach (var dslRowDefinition in gcRegionDefinition.Rows)
            {
                var row = new GcRow();
                foreach (var dslCellDefinition in dslRowDefinition.Cells)
                {
                    row.AddElement(new GcTextCell(dslCellDefinition.Slot, dslCellDefinition.Size, dslCellDefinition.CellStyle, m_GcParamCellBorderDef));
                }

                region.AddElement(row);
            }

            for (int restRows = 0; restRows < m_Height - gcRegionDefinition.Rows.Count; restRows++)
            {
                region.AddElement(
                    new GcRow().AddElement(new GcEmptyCell(new GcSize(1, gcRegionDefinition.Width), GcCellStyle.NormalCell)));
            }
        }

        private readonly GcCellBorderDef m_GcTitleCellBorderDef;
        private readonly GcCellBorderDef m_GcParamCellBorderDef;
        private readonly int m_Height;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcRegionBuilder.cs;2 */
/*       1*[1665114] 05-SEP-2012 03:45:22 (GMT) XCui4 */
/*         "[P4] Remove Vertical Black Line From Title in Depth Summary" */
/*       2*[1666783] 11-SEP-2012 07:57:13 (GMT) XCui4 */
/*         "[P4] Refactoring after remove vertical black line from title in depth summary" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcRegionBuilder.cs;2 */
