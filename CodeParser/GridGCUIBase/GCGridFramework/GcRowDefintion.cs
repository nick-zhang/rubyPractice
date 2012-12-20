using System.Collections.Generic;

namespace Slb.Horizon.GCFramework
{
    public class GcRowDefintion
    {
        public GcRowDefintion()
        {
            Cells = new List<GcCellDefinition>();
        }

        public GcRowDefintion AddCell(GcCellDefinition cell)
        {
            Cells.Add(cell);
            
            return this;
        }

        public List<GcCellDefinition> Cells { get; set; }
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcRowDefintion.cs;3 */
/*       1*[1648275] 24-JUL-2012 06:06:01 (GMT) YLi27 */
/*         "new class to define the UI layout for the graphical components" */
/*       2*[1648427] 25-JUL-2012 02:32:30 (GMT) YLi27 */
/*         "Support Customized Cell Style" */
/*       3*[1668705] 12-SEP-2012 07:31:30 (GMT) XCui4 */
/*         "[P4] Depth Summary Code Clean Up, No Logic Change" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcRowDefintion.cs;3 */
