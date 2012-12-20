using System.Collections.Generic;

namespace Slb.Horizon.GCFramework
{
    public interface IGcRegionDefinitionBuilder
    {
        GcRegionDefinition Build(IGcDataSlot titleSlot, List<GcDataTuple> parameterList);
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:IGcRegionDefinitionBuilder.cs;1 */
/*       1*[1648975] 26-JUL-2012 02:14:18 (GMT) YLi27 */
/*         "some utility classes to support creating the region definitions easily" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:IGcRegionDefinitionBuilder.cs;1 */
