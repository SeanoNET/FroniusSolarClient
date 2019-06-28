using FroniusSolarClient.Entities.SolarAPI.V1;

namespace FroniusSolarClient.Services
{
    internal class BaseDataService
    {
        private readonly RestClient _restClient;

        public BaseDataService(RestClient restClient)
        {
            _restClient = restClient;
        }

        protected Response<T> GetDataServiceResponse<T>(string endpointURL)
        {
            return _restClient.GetResponse<T>(endpointURL);
        }
    }
}
