using System.Collections.Generic;

namespace Slb.Horizon.GCFramework
{
    public class GcRegionDefinition
    {
        public GcRegionDefinition SetTitle(GcRowDefintion title)
        {
            Title = title;
            return this;
        }

        public GcRegionDefinition AddRow(GcRowDefintion row)
        {
            Rows.Add(row);
            return this;
        }


        public GcRegionDefinition()
        {
            Rows = new List<GcRowDefintion>();
        }

        public GcRowDefintion Title { get; set; }
        public List<GcRowDefintion> Rows { get; set; }
        public int Width { get; set; }
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcRegionDefinition.cs;4 */
/*       1*[1648275] 24-JUL-2012 06:06:01 (GMT) YLi27 */
/*         "new class to define the UI layout for the graphical components" */
/*       2*[1648427] 25-JUL-2012 02:32:30 (GMT) YLi27 */
/*         "Support Customized Cell Style" */
/*       3*[1649463] 27-JUL-2012 03:31:33 (GMT) YLi27 */
/*         "integrate new depth summary listing into exisitng report" */
/*       4*[1668705] 12-SEP-2012 07:31:30 (GMT) XCui4 */
/*         "[P4] Depth Summary Code Clean Up, No Logic Change" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcRegionDefinition.cs;4 */
