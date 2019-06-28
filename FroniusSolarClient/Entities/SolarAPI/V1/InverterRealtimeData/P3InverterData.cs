using FroniusSolarClient.Entities.SolarAPI.V1;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FroniusSolarClient.Entities.SolarAPI.V1.InverterRealtimeData
{
    /// <summary>
    /// 3PInverterData - Values which are provided by 3phase Fronius inverters. 
    /// </summary>
    public class P3InverterData
    {
        /// <summary>
        /// AC current Phase 1 
        /// </summary>
        [JsonProperty("IAC_L1")]
        public UnitValue<decimal> L1AcCurrent { get; set; }

        /// <summary>
        /// AC current Phase 2 
        /// </summary>
        [JsonProperty("IAC_L2")]
        public UnitValue<decimal> L2AcCurrent { get; set; }

        /// <summary>
        /// AC current Phase 3 
        /// </summary>
        [JsonProperty("IAC_L3")]
        public UnitValue<decimal> L3AcCurrent { get; set; }

        /// <summary>
        /// AC voltage Phase 1 
        /// </summary>
        [JsonProperty("UAC_L1")]
        public UnitValue<decimal> L1AcVoltage { get; set; }

        /// <summary>
        /// AC voltage Phase 2 
        /// </summary>
        [JsonProperty("UAC_L2")]
        public UnitValue<decimal> L2AcVoltage { get; set; }

        /// <summary>
        /// AC voltage Phase 3 
        /// </summary>
        [JsonProperty("UAC_L3")]
        public UnitValue<decimal> L3AcVoltage { get; set; }

        /// <summary>
        /// Ambient temperature 
        /// </summary>
        [JsonProperty("T_AMBIENT")]
        public UnitValue<int> AmbientTemperature { get; set; }

        /// <summary>
        /// Rotation speed of front left fan 
        /// </summary>
        [JsonProperty("ROTATION_SPEED_FAN_FL")]
        public UnitValue<decimal> FanFrontLeftSpeed { get; set; }

        /// <summary>
        /// Rotation speed of front right fan 
        /// </summary>
        [JsonProperty("ROTATION_SPEED_FAN_FR")]
        public UnitValue<decimal> FanFrontRightSpeed { get; set; }

        /// <summary>
        /// Rotation speed of back left fan 
        /// </summary>
        [JsonProperty("ROTATION_SPEED_FAN_BL")]
        public UnitValue<decimal> FanBackLeftSpeed { get; set; }

        /// <summary>
        /// Rotation speed of back right fan
        /// </summary>
        [JsonProperty("ROTATION_SPEED_FAN_BR")]
        public UnitValue<decimal> FanBackRightSpeed { get; set; }
    }
}
