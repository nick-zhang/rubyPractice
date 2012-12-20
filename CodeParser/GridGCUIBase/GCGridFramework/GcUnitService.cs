using System;
using Interface;

namespace Slb.Horizon.GCFramework
{
    public interface IGcUnitService
    {
        string ConvertUnit(GcParameterIdentity parameterId);
    }

    public class GcUnitService : IGcUnitService
    {
        public GcUnitService(string componentUnitSystem, Interface.ISlbUnits unitServer)
        {
            m_componentUnitSystem = componentUnitSystem;
            m_unitServer = unitServer;
            m_unitConvertor = m_unitServer as ISlbConvertUnits;
        }

        public string ConvertUnit(GcParameterIdentity parameterId)
        {
            if (parameterId.Value == null || parameterId.Value.Length <= 0) 
                return String.Empty;

            object oNewValue = parameterId.Value.GetValue(0);

            if (oNewValue == null) 
                return string.Empty;

            if(String.IsNullOrEmpty(parameterId.StorageUnit) || 
                string.IsNullOrEmpty(parameterId.UnitQuantity) || 
                parameterId.UnitQuantity == m_Unitless)
                return oNewValue.ToString();
            

            return ConvertParameterValue(parameterId, oNewValue);
        }

        private string ConvertParameterValue(GcParameterIdentity parameterId, object oNewValue)
        {
            parameterId.DisplayUnit = m_unitServer.UnitForSystem(parameterId.UnitQuantity, m_componentUnitSystem);
            int iPrecission = ((ISlbUnits2) m_unitServer).PrecisionForSystem(parameterId.UnitQuantity, m_componentUnitSystem);

            string stringParameterValue = string.Empty;
            if (!String.IsNullOrEmpty(parameterId.DisplayUnit))
            {
                double gain;
                double offset = m_unitConvertor.ConversionFactorScalar(parameterId.StorageUnit, parameterId.DisplayUnit,
                                                                       out gain);

                oNewValue = m_unitConvertor.ConvertVariant(oNewValue, gain, offset);

                switch (parameterId.DataType)
                {
                    case DataType_t.DATA_TYPE_INT8: // DataType.INT8 :
                    case DataType_t.DATA_TYPE_UINT8: //DataType.UINT8 :
                    case DataType_t.DATA_TYPE_IEEE64: //DataType.DOUBLE :                     
                    case DataType_t.DATA_TYPE_IEEE32: //DataType.SINGLE : 
                    case DataType_t.DATA_TYPE_INT32: //DataType.INT32 :                       
                    case DataType_t.DATA_TYPE_INT16: //DataType.INT16 :                       
                    case DataType_t.DATA_TYPE_UINT16: //DataType.UINT16 :                     
                    case DataType_t.DATA_TYPE_UINT32: //DataType.UINT32 :
                        {
                            double doubleNumberValue;

                            if (Double.TryParse(oNewValue.ToString(), out doubleNumberValue) && !double.IsNaN(doubleNumberValue))
                            {
                                double roundedDoubleValue = Math.Round(doubleNumberValue, iPrecission);
                                string sFormat = string.Format("F{0}", iPrecission);
                                stringParameterValue = roundedDoubleValue.ToString(sFormat);
                            }
                        }
                        break;
                }
            }

            return stringParameterValue;
        }

        private string m_componentUnitSystem;
        private ISlbUnits m_unitServer;
        private ISlbConvertUnits m_unitConvertor;
        private string m_Unitless  = "Unitless";
    }
}
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcUnitService.cs;3 */
/*       1*[1647956] 24-JUL-2012 01:56:57 (GMT) YLi27 */
/*         "new classes to support new depth summary listing" */
/*       2*[1648427] 25-JUL-2012 02:32:30 (GMT) YLi27 */
/*         "Support Customized Cell Style" */
/*       3*[1657754] 22-AUG-2012 01:31:55 (GMT) XCui4 */
/*         "[P4] Add parameters for logging cable in Depth Summary" */
/*+- OmniWorks Replacement History - hzproductsapi`GCFramework`GridGCUIBase`GCGridFramework:GcUnitService.cs;3 */
