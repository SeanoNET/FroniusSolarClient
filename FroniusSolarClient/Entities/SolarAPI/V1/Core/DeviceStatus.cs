using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FroniusSolarClient.Entities.SolarAPI.V1
{
    public class DeviceStatus
    {
        [JsonProperty("StatusCode")]
        public int StatusCode { get; set; }
        [JsonProperty("MgmtTimerRemainingTime")]
        public int MgmtTimerRemainingTime { get; set; }
        [JsonProperty("ErrorCode")]
        public int ErrorCode { get; set; }
        [JsonProperty("LEDColor")]
        public int LedColor { get; set; }
        [JsonProperty("LEDState")]
        public int LedState { get; set; }
        [JsonProperty("StateToReset")]
        public bool StateToReset { get; set; }
    }

}