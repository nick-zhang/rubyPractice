using System.Collections.Generic;
using System.Linq;
namespace Slb.Horizon.GCFramework
{
    public class GcRegion : IGcCompositeElement
    {
        public void Draw(IGcGrid grid, GcPosition rowPosition, GcSize size, GcElementAnchor anchor)
        {
            if (m_listElements.Count == 1)
            {
                anchor.Row = GcElementAnchorType.Full;
                var row = m_listElements[0];
                row.Draw(grid, rowPosition, size, anchor);
                return;
            }

            int elementsTotalCount = m_listElements.Count;
            int elementIndex = 0;
            foreach (var row in m_listElements.TakeWhile(row => rowPosition.RowIndex <= size.Height))
            {
                anchor.Row = RowAnchorCalculator.CalcuateRegionAnchor(elementIndex, elementsTotalCount);
                row.Draw(grid, rowPosition, size, anchor);
                rowPosition.RowIndex++;
                elementIndex++;
            }
        }

        public GcSize Size
        {
            get { return new GcSize(MaximumHeight(), MaximWitdh()); }
        }

        private int MaximWitdh()
        {
            return m_listElements.Select(row => row.Size.Width).Concat(new[] {0}).Max();
        }

        private int MaximumHeight()
        {
            return m_listElements.Sum(row => row.Size.Height);
        }

        public IGcCompositeElement AddElement(IGcElement element)
        {
            m_listElements.Add(element);
            return this;
        }

        private readonly List<IGcElement> m_listElements = new List<IGcElement>();
    }

    internal static class RowAnchorCalculator
    {
        public static GcElementAnchorType CalcuateRegionAnchor(int elementIndex, int elementsTotalCount)
        {
            return elementIndex == 0
                       ? GcElementAnchorType.Top
                       : (elementIndex == elementsTotalCount - 1
                              ? GcElementAnchorType.Bottom
                              : GcElementAnchorType.Middle);
        }
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcRegion.cs;3 */
/*       1*[1648275] 24-JUL-2012 06:06:01 (GMT) YLi27 */
/*         "new class to define the UI layout for the graphical components" */
/*       2*[1665114] 05-SEP-2012 03:45:22 (GMT) XCui4 */
/*         "[P4] Remove Vertical Black Line From Title in Depth Summary" */
/*       3*[1668705] 12-SEP-2012 07:31:30 (GMT) XCui4 */
/*         "[P4] Depth Summary Code Clean Up, No Logic Change" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcRegion.cs;3 */
