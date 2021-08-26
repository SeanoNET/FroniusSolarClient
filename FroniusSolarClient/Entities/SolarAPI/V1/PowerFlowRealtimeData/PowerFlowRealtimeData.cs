using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FroniusSolarClient.Entities.SolarAPI.V1.PowerFlowRealtimeData
{
    public class PowerFlowRealtimeData
    {
        public Dictionary<string, Inverters> Inverters { get; set; }
        public Site Site { get; set; }

        /// <summary>
        /// Describes the available fields for this request (PowerFlowVersion)
        /// </summary>
        public string Version { get; set; }
    }

    public class Inverters
    {
        /// <summary>
        /// Device type of inverter 
        /// </summary>
        [JsonProperty("DT")]
        public int DT { get; set; }

        /// <summary>
        /// Energy [Wh] this day, null if no inverter is connected 
        /// </summary>
        [JsonProperty("E_Day")]
        public decimal EDay { get; set; }

        /// <summary>
        /// Energy [Wh] ever since, null if no inverter is connected 
        /// </summary>
        [JsonProperty("E_Total")]
        public decimal ETotal { get; set; }

        /// <summary>
        /// Energy [Wh] this year, null if no inverter is connected 
        /// </summary>
        [JsonProperty("E_Year")]
        public decimal EYear { get; set; }

        /// <summary>
        /// Current state of charge in % ( 0 - 100% ) 
        /// </summary>
        [JsonProperty("SOC")]
        public decimal SOC { get; set; }

        /// <summary>
        /// Current power in Watt, null if not running 
        /// </summary>
        [JsonProperty("P")]
        public int P { get; set; }

        /// <summary>
        /// "disabled", "normal", "service", "charge boost",
        /// "nearly depleted", "suspended", "calibrate",
        /// "grid support", "deplete recovery", "non operable (voltage)",
        /// "non operable (temperature)", "preheating" or "startup"
        /// </summary>
        [JsonProperty("Battery_Mode")]
        public string BatteryMode { get; set; }
    }
    public class Site
    {
        /// <summary>
        /// Energy [Wh] this day, null if no inverter is connected
        /// </summary>
        [JsonProperty("E_Day")]
        public decimal EDay { get; set; }

        /// <summary>
        /// Energy [Wh] ever since, null if no inverter is connected 
        /// </summary>
        [JsonProperty("E_Total")]
        public decimal ETotal { get; set; }

        /// <summary>
        /// Energy [Wh] this year, null if no inverter is connected 
        /// </summary>
        [JsonProperty("E_Year")]
        public decimal EYear { get; set; }

        /// <summary>
        /// "load", "grid" or "unknown" (during backup power) 
        /// </summary>
        [JsonProperty("Meter_Location")]
        public string MeterLocation { get; set; }

        /// <summary>
        /// "produce-only", "meter", "vague-meter", "bidirectional" or "ac-coupled" 
        /// </summary>
        public string Mode { get; set; }

        /// <summary>
        /// This value is null if no battery is active ( + charge, - discharge ) 
        /// </summary>
        [JsonProperty("P_Akku")]
        public int PAkku { get; set; }

        /// <summary>
        /// This value is null if no meter is enabled ( + from grid, - to grid ) 
        /// </summary>
        [JsonProperty("P_Grid")]
        public decimal PGrid { get; set; }

        /// <summary>
        /// This value is null if no meter is enabled ( + generator, - consumer ) 
        /// </summary>
        [JsonProperty("P_Load")]
        public decimal PLoad { get; set; }

        /// <summary>
        /// This value is null if inverter is not running ( + production ( default ) ) 
        /// </summary>
        [JsonProperty("P_PV")]
        public int PPV { get; set; }

        /// <summary>
        /// Current relative autonomy in %, null if no smart meter is connected     
        /// </summary>
        [JsonProperty("rel_Autonomy")]
        public decimal? RelAutonomy { get; set; }

        /// <summary>
        /// Current relative self consumption in %, null if no smart meter is connected 
        /// </summary>
        [JsonProperty("rel_SelfConsumption")]
        public decimal? RelSelfConsumption { get; set; }

        /// <summary>
        /// Field is available if configured (false) or active (true)
        /// If not available, mandatory config is not set 
        /// </summary>
        [JsonProperty("BackupMode")]
        public int BackupMode { get; set; }

        /// <summary>
        /// True when battery is in standby 
        /// </summary>
        [JsonProperty("BatteryStandby")]
        public int BatteryStandby { get; set; }
    }
}
