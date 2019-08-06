using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FroniusSolarClient.Extensions
{
    /// <summary>
    /// Converts RequestArguments into string list with either single or multiple item(s)
    /// This is needed due to potentially providing multiple param values in an archive request (Channel), this means that the json will include an array of values
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class RequestArgumentsConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Dictionary<string, List<string>>));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var di = new Dictionary<string, List<string>>();

            JToken token = JToken.Load(reader);

            foreach (JProperty jprop in token.Children<JProperty>())
            {
                if (jprop.First.Type == JTokenType.Array)
                {              
                    di.Add(jprop.Name, ((JArray)jprop.Value).ToObject<List<string>>());
                }
                else
                {
                    di.Add(jprop.Name, new List<string>() { (string)(JValue)jprop.Value });
                }
            }
            return di;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

        }
    }
}
