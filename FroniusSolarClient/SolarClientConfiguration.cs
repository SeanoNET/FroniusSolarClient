using System;

namespace FroniusSolarClient
{
    internal class SolarClientConfiguration
    {
        private readonly string _url;
        private readonly string _baseUrl;
        private readonly int _version;

        public string URL => _url;
        public string BaseURL => _baseUrl;
        public int Version => _version;

        public SolarClientConfiguration(string URL, int version)
        {
            if (string.IsNullOrEmpty(URL))
            {
                throw new ArgumentNullException("You must provide the URL of the Fronius datamanger 2.0", nameof(URL));
            }

            _url = URL;
            _version = version == 0 ? 1 : version;
            this._baseUrl = $"/solar_api/v{_version}/";
        }

        /// <summary>
        /// Constructs the base URL
        /// </summary>
        /// <returns></returns>
        public string GetBaseURL()
        {
            return @"http://"+_url+_baseUrl;
        }
    }
}