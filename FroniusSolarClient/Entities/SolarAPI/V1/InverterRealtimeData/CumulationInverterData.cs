using FroniusSolarClient.Entities.SolarAPI.V1;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FroniusSolarClient.Entities.SolarAPI.V1.InverterRealtimeData
{
    /// <summary>
    /// Values which are cumulated to generate a system overview. 
    /// </summary>
    public class CumulationInverterData
    {
        /// <summary>
        /// AC power 
        /// </summary>
        [JsonProperty("PAC")]
        public UnitValue<decimal> AcPower { get; set; }

        /// <summary>
        ///  Energy generated on current day 
        /// </summary>
        [JsonProperty("DAY_ENERGY")]
        public UnitValue<decimal> CurentDayEnergy { get; set; }

        /// <summary>
        /// Energy generated in current year 
        /// </summary>
        [JsonProperty("YEAR_ENERGY")]
        public UnitValue<decimal> CurrentYearEnergy { get; set; }

        /// <summary>
        /// Energy generated overall
        /// </summary>
        [JsonProperty("TOTAL_ENERGY")]
        public UnitValue<decimal> TotalEnergy { get; set; }

        /// <summary>
        /// Status information about inverter
        /// </summary>
        public DeviceStatus DeviceStatus { get; set; }
    }
}
