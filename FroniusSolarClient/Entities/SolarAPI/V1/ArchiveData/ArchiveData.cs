using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FroniusSolarClient.Entities.SolarAPI.V1.ArchiveData
{
    /// <summary>
    /// Archive data response channel data
    /// </summary>
    public class ArchiveData
    {
        [JsonProperty(PropertyName = "Data")]
        Dictionary<string, ChannelValues> ChannelData;
    }

    /// <summary>
    /// Channel data values
    /// </summary>
    public class ChannelValues
    {
        [JsonProperty(PropertyName = "Unit")]
        string Unit;

        [JsonProperty(PropertyName = "Values")]
        Dictionary<string, string> Values;
    }
}
