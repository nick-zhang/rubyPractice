using DSClients;

namespace Slb.Horizon.GCFramework
{
    public class GcCollectionServiceFactory
    {
        public static IGcCollectionService CreateCollectionService(GcCollectionServiceType collectionServiceType, 
                                                                   ISlbDscCollection collection, 
                                                                   IGcUnitService unitService, 
                                                                   GcParameterIdentity gcParameterId)
        {
            switch (collectionServiceType)
            {
                case GcCollectionServiceType.ParameterCollectin:
                    return new GcParameterService(collection, unitService, gcParameterId);
                case GcCollectionServiceType.EquipmentPropertyCollection:
                    return new GcEquipPropService(collection, unitService, gcParameterId);
                default:
                    return null;
            }
        }
    }

    public enum GcCollectionServiceType
    {
        ParameterCollectin,
        EquipmentPropertyCollection
    }

}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcCollectionServiceFactory.cs;1 */
/*       1*[1657754] 22-AUG-2012 01:31:55 (GMT) XCui4 */
/*         "[P4] Add parameters for logging cable in Depth Summary" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcCollectionServiceFactory.cs;1 */
