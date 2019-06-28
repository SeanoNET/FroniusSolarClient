using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FroniusSolarClient.Helpers
{
    internal static class JsonHelper
    {
        internal static T DeSerializeResponse<T>(string content, JsonSerializerSettings settings = null)
        {
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.NullValueHandling = NullValueHandling.Ignore;
            jsonSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            return JsonConvert.DeserializeObject<T>(content, settings: settings ?? jsonSettings);
        }

    }
}
