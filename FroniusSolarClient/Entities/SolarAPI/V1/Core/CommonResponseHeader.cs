using FroniusSolarClient.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FroniusSolarClient.Entities.SolarAPI.V1
{
    /// <summary>
    /// The common response header(CRH) is present in every response. 
    /// It indicates, among other things, whether the request has been successful 
    /// and the body of the response is valid. 
    /// </summary>
    public class CommonResponseHeader
    {
        /// <summary>
        /// Filled with properties named like the given parameters.
        /// </summary>
        [JsonConverter(typeof(RequestArgumentsConverter<Dictionary<string, List<string>>>))]
        public Dictionary<string, List<string>> RequestArguments { get; set; }
     
        /// <summary>
        /// Information about the response. 
        /// </summary>
        public CommonResponseHeaderStatus Status { get; set; }

        /// <summary>
        /// RFC3339 timestamp in localtime of the datalogger
        /// This is the time the request was answered - NOT the time when the data 
        /// was queried from the device. 
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}