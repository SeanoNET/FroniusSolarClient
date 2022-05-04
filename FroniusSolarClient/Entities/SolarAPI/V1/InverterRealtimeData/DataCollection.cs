using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FroniusSolarClient.Entities.SolarAPI.V1.InverterRealtimeData
{
   public enum DataCollection
    {
        CumulationInverterData,
        CommonInverterData,
        MinMaxInverterData,
        /// <summary>
        /// 3PInverterData, but Enum cannot start with number.
        /// </summary>
        [Description("3PInverterData")]
        P3InverterData
    }
}
