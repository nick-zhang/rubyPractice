namespace Slb.Horizon.GCFramework
{
    internal class GcRangeTitleCellRightBorderCalculator
    {
        public GcRangeTitleCellRightBorderCalculator()
        {
            VerticalBorder = GcBorder.Invisible;
            BlockBorder = GcBorder.ExtraThick;
            RegionBorder = GcBorder.Invisible;
        }

        public GcBorder Calcuate(GcElementAnchor anchor)
        {
            GcBorder border = GcBorder.Invisible;

            if (anchor.Region == GcElementAnchorType.Right || anchor.Region == GcElementAnchorType.Full)
            {
                if (anchor.Cell == GcElementAnchorType.Right || anchor.Cell == GcElementAnchorType.Full)
                    border = BlockBorder;
                else
                {
                    border = VerticalBorder;
                }
            }
            else
            {
                if (anchor.Cell == GcElementAnchorType.Right || anchor.Cell == GcElementAnchorType.Full)
                    border = RegionBorder;
                else
                {
                    border = VerticalBorder;
                }
            }
            return border;
        }

        public GcBorder VerticalBorder { get; set; }
        public GcBorder BlockBorder { get; set; }
        public GcBorder RegionBorder { get; set; }
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcRangeTitleCellRightBorderCalculator.cs;1 */
/*       1*[1665114] 05-SEP-2012 03:45:22 (GMT) XCui4 */
/*         "[P4] Remove Vertical Black Line From Title in Depth Summary" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcRangeTitleCellRightBorderCalculator.cs;1 */
