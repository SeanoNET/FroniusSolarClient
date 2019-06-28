using FroniusSolarClient.Entities.SolarAPI.V1;
using FroniusSolarClient.Helpers;
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

        /// <summary>
        /// This action delegate provides access to the response headers
        /// </summary>
        private Action<CommonResponseHeader> _commonResponseHeader;

        public RestClient(HttpClient httpClient, string url, Action<CommonResponseHeader> commonResponseHeader)
        {
            if (String.IsNullOrEmpty(url))
                throw new ArgumentException("URL not specified");

            this._httpClient = httpClient ?? new HttpClient();
            this._url = url;

            _commonResponseHeader = commonResponseHeader;
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
                var response = JsonHelper.DeSerializeResponse<Response<T>>(content);

                if (_commonResponseHeader != null)
                    _commonResponseHeader.Invoke(response.Head);

                return response;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
                return null;
            }
        }
     

    }
}
