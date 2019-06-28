using FroniusSolarClient.Entities.SolarAPI.V1;
using Newtonsoft.Json;

namespace FroniusSolarClient.Entities.SolarAPI.V1.InverterRealtimeData
{

    /// <summary>
    /// Values which are provided by all types of Fronius inverters. 
    /// </summary>
    public class CommonInverterData
    {
        /// <summary>
        /// AC power 
        /// </summary>
        [JsonProperty("PAC")]
        public UnitValue<int> AcPower { get; set; }

        /// <summary>
        /// AC current 
        /// </summary>
        [JsonProperty("IAC")]
        public UnitValue<decimal> AcCurrent { get; set; }

        /// <summary>
        /// AC voltage 
        /// </summary>
        [JsonProperty("UAC")]
        public UnitValue<decimal> AcVoltage { get; set; }

        /// <summary>
        /// AC frequency 
        /// </summary>
        [JsonProperty("FAC")]
        public UnitValue<decimal> AcFrequency { get; set; }

        /// <summary>
        /// DC current 
        /// </summary>
        [JsonProperty("IDC")]
        public UnitValue<decimal> DcCurrent { get; set; }

        /// <summary>
        /// DC voltage 
        /// </summary>
        [JsonProperty("UDC")]
        public UnitValue<decimal> DcVoltage { get; set; }

        /// <summary>
        ///  Energy generated on current day 
        /// </summary>
        [JsonProperty("DAY_ENERGY")]
        public UnitValue<decimal> CurrentDayEnergy { get; set; }

        /// <summary>
        ///  Energy generated in current year 
        /// </summary>
        [JsonProperty("YEAR_ENERGY")]
        public UnitValue<decimal> CurrentYearEnergy { get; set; }

        /// <summary>
        ///  Energy generated overall 
        /// </summary>
        [JsonProperty("TOTAL_ENERGY")]
        public UnitValue<decimal> TotalEnergy { get; set; }

        /// <summary>
        /// Status information about inverter
        /// </summary>
        public DeviceStatus DeviceStatus { get; set; }
    }

}