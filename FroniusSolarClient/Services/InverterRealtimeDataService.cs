using FroniusSolarClient.Entities.SolarAPI.V1;
using FroniusSolarClient.Entities.SolarAPI.V1.InverterRealtimeData;
using FroniusSolarClient.Extensions;
using System;

namespace FroniusSolarClient.Services
{
    /// <summary>
    /// These requests will be provided where direct access to the realtime data of the devices is possible. This is currently the case for the Fronius Datalogger Web and the Fronius Datamanager.
    /// </summary>
    internal class InverterRealtimeDataService : BaseDataService
    {
        private readonly string _cgi = "GetInverterRealtimeData.cgi";

        public InverterRealtimeDataService(RestClient restClient)
            : base(restClient)
        {
        }

        /// <summary>
        /// Builds the query string for the request
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        protected string BuildQueryString(int deviceId, Scope scope, DataCollection dataCollection)
        {
            //TODO: Support list of string dictionary to build HTTP query string
            return $"?Scope={scope}&DeviceId={deviceId}&DataCollection={dataCollection.GetDescription()}";
        }

        public Response<CumulationInverterData> GetCumulationInverterData(int deviceId = 1, Scope scope = Scope.Device)
        {
            string baseEndpointURL = _cgi + BuildQueryString(deviceId, scope, DataCollection.CumulationInverterData);
            return GetDataServiceResponse<CumulationInverterData>(baseEndpointURL);
        }

        public Response<CommonInverterData> GetCommonInverterData(int deviceId = 1, Scope scope = Scope.Device)
        {
            string baseEndpointURL = _cgi + BuildQueryString(deviceId, scope, DataCollection.CommonInverterData);
            return GetDataServiceResponse<CommonInverterData>(baseEndpointURL);
        }

        public Response<P3InverterData> Get3PInverterData(int deviceId = 1, Scope scope = Scope.Device)
        {
            string baseEndpointURL = _cgi + BuildQueryString(deviceId, scope, DataCollection.P3InverterData);
            return GetDataServiceResponse<P3InverterData>(baseEndpointURL);
        }

        [Obsolete("use Get3PInverterData")]
        public Response<P3InverterData> GetP3InverterData(int deviceId = 1, Scope scope = Scope.Device) => Get3PInverterData(deviceId, scope);

        public Response<MinMaxInverterData> GetMinMaxInverterData(int deviceId = 1, Scope scope = Scope.Device)
        {
            string baseEndpointURL = _cgi + BuildQueryString(deviceId, scope, DataCollection.MinMaxInverterData);
            return GetDataServiceResponse<MinMaxInverterData>(baseEndpointURL);
        }
    }
}
