using FroniusSolarClient.Entities.SolarAPI.V1;
using FroniusSolarClient.Helpers;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;

namespace FroniusSolarClient
{
    /// <summary>
    /// Handles HTTP request/response to the Fronius Solar API
    /// </summary>
    internal class RestClient
    {

        private readonly HttpClient _httpClient;
        private readonly string _url;
        private readonly ILogger _logger;
        /// <summary>
        /// This action delegate provides access to the response headers
        /// </summary>
        private Action<CommonResponseHeader, ILogger> _commonResponseHeader;

        public RestClient(HttpClient httpClient, string url, Action<CommonResponseHeader, ILogger> commonResponseHeader, ILogger logger)
        {
            if (String.IsNullOrEmpty(url))
                throw new ArgumentException("URL not specified");

            this._httpClient = httpClient ?? new HttpClient();
            this._url = url;

            _commonResponseHeader = commonResponseHeader;
            _logger = logger;
        }

        /// <summary>
        /// Prepares the HTTP request
        /// </summary>
        /// <returns></returns>
        public HttpRequestMessage PrepareHTTPMessage(string cgi)
        {
            var requestMessage = new HttpRequestMessage();
            requestMessage.RequestUri = new Uri($"{_url}{cgi}");
            requestMessage.Method = HttpMethod.Get;
            _logger.LogInformation($"RequestUri: {requestMessage.RequestUri}");
            return requestMessage;
        }

        public HttpResponseMessage ExecuteRequest(HttpRequestMessage requestMessage)
        {
            return _httpClient.SendAsync(requestMessage).Result;
        }

 
        public  Response<T> GetResponse<T>(string endpoint)
        {
            try
            {

                var httpRequest = PrepareHTTPMessage(endpoint);

                var httpResponse = ExecuteRequest(httpRequest);

                httpResponse.EnsureSuccessStatusCode();

                var content = httpResponse.Content.ReadAsStringAsync().Result;
                _logger.LogInformation($"Response Code: {httpResponse.StatusCode.ToString()}");
                _logger.LogDebug($"Content: {content}");

                var response = JsonHelper.DeSerializeResponse<Response<T>>(content);

                if (_commonResponseHeader != null)
                    _commonResponseHeader.Invoke(response.Head, _logger);

                return response;
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"An error occured: {ex.Message}");
                return null;
            }
        }
     

    }
}
