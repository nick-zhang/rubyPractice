namespace Slb.Horizon.GCFramework
{
    public enum GcBorder
    {
        Undefined,
        ExtraThick,
        Thick,
        Thin,
        Invisible,
        RangeTitle
    }

    public class GcCellBorderDef
    {
        public GcCellBorderDef()
        {
            Left = GcBorder.Undefined;
            Right = GcBorder.Undefined;
            Top = GcBorder.Undefined;
            Bottom = GcBorder.Undefined;
        }

        public GcCellBorderDef(GcBorder top, GcBorder bottom, GcBorder left, GcBorder right)
        {
            Left = left;
            Right = right;
            Top = top;
            Bottom = bottom;
        }

        public virtual GcCellBorderDef Calculate(GcElementAnchor anchor)
        {
            return new GcCellBorderDef(
                GetTopStyleBorder(anchor), 
                GetBottomStyleBorder(anchor), 
                GetLeftStyleBorder(anchor), 
                GetRightStyleBorder(anchor));
        }

        private GcBorder GetTopStyleBorder(GcElementAnchor anchor)
        {
            return Top != GcBorder.Undefined
                       ? Top
                       : anchor.CalculateTopBorder();
        }

        private GcBorder GetBottomStyleBorder(GcElementAnchor anchor)
        {
            return Bottom != GcBorder.Undefined
                       ? Bottom
                       : anchor.CalculateBottomBorder();
        }

        private GcBorder GetLeftStyleBorder(GcElementAnchor anchor)
        {
            var retVal = Left;

            if (Left == GcBorder.Undefined)
                retVal = anchor.CalculateLeftBorder();
            else if (Left == GcBorder.RangeTitle)
                retVal = anchor.CalculateRangeTitleLeftBorder();

            return retVal;
        }

        private GcBorder GetRightStyleBorder(GcElementAnchor anchor)
        {
            var retVal = Right;

            if (Right == GcBorder.Undefined)
                retVal = anchor.CalculateRightBorder();
            else if (Right == GcBorder.RangeTitle)
                retVal = anchor.CalculateRangeTitleRightBorder();

            return retVal;
        }

        public GcBorder Left { get; set; }
        public GcBorder Right { get; set; }
        public GcBorder Top { get; set; }
        public GcBorder Bottom { get; set; }
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcCellBorderDef.cs;4 */
/*       1*[1647855] 23-JUL-2012 07:32:38 (GMT) YLi27 */
/*         "Some basic definition for graphical components" */
/*       2*[1648427] 25-JUL-2012 02:32:30 (GMT) YLi27 */
/*         "Support Customized Cell Style" */
/*       3*[1665114] 05-SEP-2012 03:45:22 (GMT) XCui4 */
/*         "[P4] Remove Vertical Black Line From Title in Depth Summary" */
/*       4*[1666783] 11-SEP-2012 07:57:13 (GMT) XCui4 */
/*         "[P4] Refactoring after remove vertical black line from title in depth summary" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcCellBorderDef.cs;4 */
