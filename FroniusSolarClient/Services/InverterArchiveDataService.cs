using FroniusSolarClient.Entities.SolarAPI.V1;
using FroniusSolarClient.Entities.SolarAPI.V1.ArchiveData;
using System;
using System.Collections.Generic;
using System.Text;

namespace FroniusSolarClient.Services
{
    /// <summary>
    /// Archive requests shall be provided whenever access to historic device-data is possible. The Datalogger web can only provide what is stored in its internal memory and has not been overwritten by newer data yet, it can loose data due to capacity reasons. The number of days stored is dependant on the number of connected units that are logging data.
    /// </summary>
    internal class InverterArchiveDataService : BaseDataService
    {
        private readonly string _cgi = "GetArchiveData.cgi";

        public InverterArchiveDataService(RestClient restClient) 
            : base(restClient)
        {
        }

        /// <summary>
        /// Builds the query string for the request
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        protected string BuildQueryString(int deviceId, Scope scope, SeriesType seriesType, bool humanReadable, DateTime startDate, DateTime endDate, List<Channel> channels, DeviceClass deviceClass)
        {
            if (channels.Count == 0)
                throw new ArgumentNullException(nameof(channels), "You must provide atleast one channel");


            string channelParam = "";

            if (channels.Count > 1)
            {
                foreach (Channel channel in channels)
                {
                    channelParam = $"{channelParam}&Channel={channel.ToString()}";
                }
            }
            else
            {
                channelParam = $"Channel={channels[0].ToString()}";
            }

            // Only need device class if we are scoped to device
            string deviceClassParam = "";
            if (scope == Scope.Device)
                deviceClassParam = $"&DeviceClass={deviceClass.ToString()}";

            return $"?Scope={scope}&StartDate={startDate.ToString("d.M.yyyy")}&EndDate={endDate.ToString("d.M.yyyy")}&HumanReadable={humanReadable.ToString()}&{seriesType.ToString()}{deviceClassParam}" +
                $"&{channelParam}";
        }

        public Response<Dictionary<string, ArchiveData>> GetArchiveData(DateTime startDate, DateTime endDate, List<Channel> channels, int deviceId, Scope scope, SeriesType seriesType, bool humanReadable, DeviceClass deviceClass)
        {
            string baseEndpointURL = _cgi + BuildQueryString(deviceId, scope, seriesType, humanReadable, startDate, endDate, channels, deviceClass);
            return GetDataServiceResponse<Dictionary<string, ArchiveData>>(baseEndpointURL);
        }
    }
}
