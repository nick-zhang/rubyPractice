using System.Collections.Generic;
using System.Linq;

namespace Slb.Horizon.GCFramework
{
    public class GcRow : IGcCompositeElement
    {
       public void Draw(IGcGrid grid, GcPosition position, GcSize size, GcElementAnchor anchor)
        {
            int elementsTotalCount = m_listCells.Count;
            int elementIndex = 0;

            foreach (var cell in m_listCells)
            {
                if (cell.Size.Width + position.ColumnIndex > size.Width + 1)
                    break;

                anchor.Cell = CellAnchorCalcutor.Calculate(elementIndex, elementsTotalCount);
                cell.Draw(grid, position, size, anchor);
                position.ColumnIndex += cell.Size.Width;
                elementIndex++;
            }
        }

        public GcSize Size
        {
            get { return new GcSize(CalcuateHeight(), CalcuateWidth()); }
        }

        private int CalcuateHeight()
        {
            return 1;
        }

        private int CalcuateWidth()
        {
            return m_listCells.Sum(cell => cell.Size.Width);
        }

        public IGcCompositeElement AddElement(IGcElement element)
        {
            m_listCells.Add(element);
            return this;
        }

        private readonly List<IGcElement> m_listCells = new List<IGcElement>();

    }

    internal static class CellAnchorCalcutor
    {
        public static GcElementAnchorType Calculate(int elementIndex, int elementsTotalCount)
        {
            return elementIndex == 0 && elementsTotalCount == 1
                       ? GcElementAnchorType.Full
                       : (elementIndex == 0
                              ? GcElementAnchorType.Left
                              : (elementIndex == elementsTotalCount - 1
                                     ? GcElementAnchorType.Right
                                     : GcElementAnchorType.Middle));
        }
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcRow.cs;2 */
/*       1*[1648275] 24-JUL-2012 06:06:01 (GMT) YLi27 */
/*         "new class to define the UI layout for the graphical components" */
/*       2*[1668705] 12-SEP-2012 07:31:30 (GMT) XCui4 */
/*         "[P4] Depth Summary Code Clean Up, No Logic Change" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcRow.cs;2 */
