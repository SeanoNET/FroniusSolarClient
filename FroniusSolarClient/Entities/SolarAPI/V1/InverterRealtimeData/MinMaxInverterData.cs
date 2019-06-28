using FroniusSolarClient.Entities.SolarAPI.V1;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FroniusSolarClient.Entities.SolarAPI.V1.InverterRealtimeData
{
    /// <summary>
    /// Minimum- and Maximum-values of various inverter values. 
    /// </summary>
    public class MinMaxInverterData
    {
        /// <summary>
        /// Maximum AC power of current day
        /// </summary>
        [JsonProperty("DAY_PMAX")]
        public UnitValue<int> MaxCurrentDayAcPower { get; set; }

        /// <summary>
        /// Maximum AC voltage of current day 
        /// </summary>
        [JsonProperty("DAY_UACMAX")]
        public UnitValue<decimal> MaxCurrentDayAcVoltage { get; set; }

        /// <summary>
        /// Minimum AC voltage of current day 
        /// </summary>
        [JsonProperty("DAY_UACMIN")]
        public UnitValue<decimal> MinCurrentDayAcVoltage { get; set; }

        /// <summary>
        /// Maximum DC voltage of current day 
        /// </summary>
        [JsonProperty("DAY_UDCMAX")]
        public UnitValue<decimal> MaxCurrentDayDcVoltage { get; set; }

        /// <summary>
        /// Maximum AC power of current year 
        /// </summary>
        [JsonProperty("YEAR_PMAX")]
        public UnitValue<int> MaxCurrentYearAcPower { get; set; }

        /// <summary>
        /// Maximum AC voltage of current year 
        /// </summary>
        [JsonProperty("YEAR_UACMAX")]
        public UnitValue<decimal> MaxCurrentYearAcVoltage { get; set; }

        /// <summary>
        /// Minimum AC voltage of current year 
        /// </summary>
        [JsonProperty("YEAR_UACMIN")]
        public UnitValue<decimal> MinCurrentYearAcVoltage { get; set; }

        /// <summary>
        /// Maximum DC voltage of current year 
        /// </summary>
        [JsonProperty("YEAR_UDCMAX")]
        public UnitValue<decimal> MaxCurrentYearDcVoltage { get; set; }

        /// <summary>
        /// Maximum AC power of current year 
        /// </summary>
        [JsonProperty("TOTAL_PMAX")]
        public UnitValue<int> MaxTotalAcPower { get; set; }

        /// <summary>
        /// Maximum AC voltage overall 
        /// </summary>
        [JsonProperty("TOTAL_UACMAX")]
        public UnitValue<decimal> MaxTotalAcVoltage { get; set; }

        /// <summary>
        /// Minimum AC voltage overall 
        /// </summary>
        [JsonProperty("TOTAL_UACMIN")]
        public UnitValue<decimal> MinTotalAcVoltage { get; set; }

        /// <summary>
        /// Maximum DC voltage overall
        /// </summary>
        [JsonProperty("TOTAL_UDCMAX")]
        public UnitValue<decimal> MaxTotalDcVoltage { get; set; }
    }
}
