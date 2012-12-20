using System.Collections.Generic;
using DSClients;

namespace Slb.Horizon.GCFramework
{
    public class GcParameterTupleService : IGcParameterTupleService
    {
        public GcParameterTupleService(GcCollectionServiceAttribute gcCollectionServiceAttribute, IGcUnitService unitService, IGcLocalizationService localizationService)
        {
            m_DscCollection = gcCollectionServiceAttribute.DscCollection;
            m_UnitService = unitService;
            m_LocalizationService = localizationService;
            m_CollectionServiceType = gcCollectionServiceAttribute.CollectionServiceType;
        }

        public List<GcDataTuple> BuildParameterTuple(List<GcParameterIdentity> listOfParameterOsdd)
        {
            var listOfParas = new List<GcDataTuple>();
            foreach (var gcParameterIdentity in listOfParameterOsdd)
            {
                var paraTuple = new GcDataTuple();
                paraTuple.Desprition = new GcLocalizationSlot(new GcLabelSlot(gcParameterIdentity.Description), m_LocalizationService);

                IGcCollectionService parameterCollService =
                    GcCollectionServiceFactory.CreateCollectionService(m_CollectionServiceType, m_DscCollection,
                                                                       m_UnitService, gcParameterIdentity);
                paraTuple.Data = new GcParameterSlot(parameterCollService);

                listOfParas.Add(paraTuple);
            }

            return listOfParas;
        }

        private readonly ISlbDscCollection m_DscCollection;
        private readonly IGcUnitService m_UnitService;
        private readonly IGcLocalizationService m_LocalizationService;
        private readonly GcCollectionServiceType m_CollectionServiceType;
        
    }

    public class GcCollectionServiceAttribute
    {
        public GcCollectionServiceAttribute(GcCollectionServiceType collectionServiceType, ISlbDscCollection dscCollection)
        {
            m_CollectionServiceType = collectionServiceType;
            m_DscCollection = dscCollection;
        }

        public GcCollectionServiceType CollectionServiceType
        {
            get { return m_CollectionServiceType; }
        }

        public ISlbDscCollection DscCollection
        {
            get { return m_DscCollection; }
        }
        
        private readonly GcCollectionServiceType m_CollectionServiceType;
        private readonly ISlbDscCollection m_DscCollection;

    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcParameterTupleService.cs;4 */
/*       1*[1648975] 26-JUL-2012 02:14:18 (GMT) YLi27 */
/*         "some utility classes to support creating the region definitions easily" */
/*       2*[1657754] 22-AUG-2012 01:31:55 (GMT) XCui4 */
/*         "[P4] Add parameters for logging cable in Depth Summary" */
/*       3*[1675767] 29-SEP-2012 02:25:12 (GMT) SLiu10 */
/*         "[P4] Depth Summary Localization Service: Implement Localization Service on Label Slot" */
/*       4*[1680440] 15-OCT-2012 01:31:50 (GMT) XCui4 */
/*         "[2013.1] Depth Summary - Implement Tension Device Display Rules" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcParameterTupleService.cs;4 */
