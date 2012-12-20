using System.Collections.Generic;
using DSClients;

namespace Slb.Horizon.GCFramework
{
    public class GcParameteSimpleServie : IGcParameterTupleService
    {
        public GcParameteSimpleServie(ISlbDscCollection parameterColl, IGcUnitService unitService)
        {
            m_ParameterColl = parameterColl;
            m_UnitService = unitService;
        }

        public List<GcDataTuple> BuildParameterTuple(List<GcParameterIdentity> listOfParameterOsdd)
        {
            var parameterSlots = new List<GcDataTuple>();
            foreach (var gcParameterIdentity in listOfParameterOsdd)
            {
                IGcCollectionService depremSlotService = new GcParameterService(m_ParameterColl, m_UnitService, gcParameterIdentity);

                IGcDataSlot paraValueSlot = new GcParameterSlot(depremSlotService);
                if(string.IsNullOrEmpty(paraValueSlot.GetDataValue().StringValue)) continue;

                parameterSlots.Add(new GcDataTuple(){Data = paraValueSlot});
            }

            return parameterSlots;
        }

        private readonly ISlbDscCollection m_ParameterColl;
        private readonly IGcUnitService m_UnitService;
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcParameteSimpleServie.cs;1 */
/*       1*[1648975] 26-JUL-2012 02:14:18 (GMT) YLi27 */
/*         "some utility classes to support creating the region definitions easily" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcParameteSimpleServie.cs;1 */
