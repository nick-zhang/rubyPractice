namespace Slb.Horizon.GCFramework
{
    public enum GcElementAnchorType
    {
        Left,
        Middle,
        Right,
        Top,
        Bottom,
        Full
    }

    public struct GcElementAnchor
    {
        public GcElementAnchorType Region { get; set; }
        public GcElementAnchorType Row { get; set; }
        public GcElementAnchorType Cell { get; set; }

        public GcBorder CalculateTopBorder()
        {
            var cellBorder = GcBorder.Invisible;
            var blockBorder = GcBorder.Thin;

            return Row == GcElementAnchorType.Top || Row == GcElementAnchorType.Full
                         ? blockBorder
                         : cellBorder;
        }

        public GcBorder CalculateBottomBorder()
        {
            var cellBorder = GcBorder.Invisible;
            var blockBorder = GcBorder.Thin;

            return Row == GcElementAnchorType.Bottom || Row == GcElementAnchorType.Full
                         ? blockBorder
                         : cellBorder;
        }

        public GcBorder CalculateLeftBorder()
        {

            var cellBorder = GcBorder.Invisible;
            var blockBorder = GcBorder.ExtraThick;
            var regionBorder = GcBorder.Invisible;

            return Region == GcElementAnchorType.Left || Region == GcElementAnchorType.Full

                         ? (Cell == GcElementAnchorType.Left || Cell == GcElementAnchorType.Full
                                ? blockBorder
                                : cellBorder)
                         : (Cell == GcElementAnchorType.Left || Cell == GcElementAnchorType.Full
                                ? regionBorder
                                : cellBorder);
        }

        public GcBorder CalculateRightBorder()
        {
            var cellBorder = GcBorder.Invisible;
            var blockBorder = GcBorder.ExtraThick;
            var regionBorder = GcBorder.Thin;

            return Region == GcElementAnchorType.Right || Region == GcElementAnchorType.Full

                         ? (Cell == GcElementAnchorType.Right || Cell == GcElementAnchorType.Full
                                ? blockBorder
                                : cellBorder)
                         : (Cell == GcElementAnchorType.Right || Cell == GcElementAnchorType.Full
                                ? regionBorder
                                : cellBorder);
        }

        public GcBorder CalculateRangeTitleLeftBorder()
        {
            var cellBorder = GcBorder.Invisible;
            var blockBorder = GcBorder.ExtraThick;
            var regionBorder = GcBorder.Invisible;

            return Region == GcElementAnchorType.Left || Region == GcElementAnchorType.Full
                         ? (Cell == GcElementAnchorType.Left || Cell == GcElementAnchorType.Full
                                ? blockBorder
                                : cellBorder)
                         : (Cell == GcElementAnchorType.Left || Cell == GcElementAnchorType.Full
                                ? regionBorder
                                : cellBorder);
        }

        public GcBorder CalculateRangeTitleRightBorder()
        {
            var cellBorder = GcBorder.Invisible;
            var blockBorder = GcBorder.ExtraThick;
            var regionBorder = GcBorder.Invisible;

            return Region == GcElementAnchorType.Right || Region == GcElementAnchorType.Full
                         ? (Cell == GcElementAnchorType.Right || Cell == GcElementAnchorType.Full
                                ? blockBorder
                                : cellBorder)
                         : (Cell == GcElementAnchorType.Right || Cell == GcElementAnchorType.Full
                                ? regionBorder
                                : cellBorder);
        }
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcElementAnchor.cs;2 */
/*       1*[1647855] 23-JUL-2012 07:32:38 (GMT) YLi27 */
/*         "Some basic definition for graphical components" */
/*       2*[1666783] 11-SEP-2012 07:57:13 (GMT) XCui4 */
/*         "[P4] Refactoring after remove vertical black line from title in depth summary" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcElementAnchor.cs;2 */
