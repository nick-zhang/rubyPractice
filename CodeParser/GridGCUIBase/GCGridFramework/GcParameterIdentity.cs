using System;
using Interface;

namespace Slb.Horizon.GCFramework
{
    public class GcParameterIdentity
    {
        public string Guid { get; set; }
        public string Osdd { get; set; }
        public string UnitQuantity { get; set; }
        public string StorageUnit { get; set; }
        public string DisplayUnit { get; set; }
        public Array Value { get; set; }
        public string Entity { get; set; }
        public string Description { get; set; }
        public DataType_t DataType { get; set; }
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcParameterIdentity.cs;2 */
/*       1*[1647855] 23-JUL-2012 07:32:38 (GMT) YLi27 */
/*         "Some basic definition for graphical components" */
/*       2*[1649339] 26-JUL-2012 06:23:06 (GMT) YLi27 */
/*         "define the first log sequence layout" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcParameterIdentity.cs;2 */
