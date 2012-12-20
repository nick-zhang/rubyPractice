using System;
using System.Collections.Generic;
using Slb.Horizon.GCFramework;

namespace Slb.Horizon.GCFramework
{
    public class GcParameterTupleProxyService : IGcParameterTupleService
    {
        public GcParameterTupleProxyService(IGcParameterTupleService service, string defaultValue)
        {
            m_TupleService = service;
            m_DefaultValue = defaultValue;
        }

        #region IGcParameterTupleService Members

        public List<GcDataTuple> BuildParameterTuple(List<GcParameterIdentity> listOfParameterOsdd)
        {
            var dataTupleList = new List<GcDataTuple>();
            foreach (var gcParameterIdentity in listOfParameterOsdd)
            {
                if (String.IsNullOrEmpty(gcParameterIdentity.Osdd))
                {
                    dataTupleList.Add(new GcDataTuple() {Data = new GcLabelSlot(m_DefaultValue)});
                    continue;
                }

                dataTupleList.Add(m_TupleService.BuildParameterTuple(new List<GcParameterIdentity>() { gcParameterIdentity})[0]);
            }

            return dataTupleList;
        }

        #endregion

        private readonly IGcParameterTupleService m_TupleService;
        private readonly string m_DefaultValue;

    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcParameterTupleProxyService.cs;1 */
/*       1*[1682805] 17-OCT-2012 03:36:50 (GMT) YLi27 */
/*         "[P4] Add New Class to handle the NA cell" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcParameterTupleProxyService.cs;1 */
