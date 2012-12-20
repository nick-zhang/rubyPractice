using System.Collections.Generic;
using System.Linq;

namespace Slb.Horizon.GCFramework
{
    public class GcBlock : IGcCompositeElement
    {
        public GcBlock(int width)
        {
            m_Width = width;
        }

        public void Draw(IGcGrid grid, GcPosition regionPosition, GcSize size, GcElementAnchor anchor)
        {
            if(m_ListElements.Count == 1)
            {
                anchor.Region = GcElementAnchorType.Full;
                var region = m_ListElements[0];
                region.Draw(grid, regionPosition, size, anchor);
                return;
            }
 
            int elementsTotalCount = m_ListElements.Count;
            int elementIndex = 0;
            foreach (var region in m_ListElements.TakeWhile(region => region.Size.Width + regionPosition.ColumnIndex <= size.Width + 1))
            {
                anchor.Region = RegionAnchorCalculator.CalcuateRegionAnchor(elementIndex, elementsTotalCount);
                region.Draw(grid, regionPosition, size, anchor);
                regionPosition.ColumnIndex += region.Size.Width;
                elementIndex++;
            }
        }

        public GcSize Size
        {
            get { return new GcSize(MaximumHeight(), m_Width); }
        }

        public IGcCompositeElement AddElement(IGcElement element)
        {
            m_ListElements.Add(element);
            return this;
        }

        private int MaximumHeight()
        {
            return m_ListElements.Select(row => row.Size.Height).Concat(new[] {0}).Max();
        }


        private readonly List<IGcElement> m_ListElements = new List<IGcElement>();
        private readonly int m_Width;
    }

    internal static class RegionAnchorCalculator
    {
        public static GcElementAnchorType CalcuateRegionAnchor(int elementIndex, int elementsTotalCount)
        {
            return elementIndex == 0
                       ? GcElementAnchorType.Left
                       : (elementIndex == elementsTotalCount - 1
                              ? GcElementAnchorType.Right
                              : GcElementAnchorType.Middle);
        }
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcBlock.cs;3 */
/*       1*[1648275] 24-JUL-2012 06:06:01 (GMT) YLi27 */
/*         "new class to define the UI layout for the graphical components" */
/*       2*[1665114] 05-SEP-2012 03:45:22 (GMT) XCui4 */
/*         "[P4] Remove Vertical Black Line From Title in Depth Summary" */
/*       3*[1668705] 12-SEP-2012 07:31:30 (GMT) XCui4 */
/*         "[P4] Depth Summary Code Clean Up, No Logic Change" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcBlock.cs;3 */
