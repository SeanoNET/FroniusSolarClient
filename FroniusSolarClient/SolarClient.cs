using FroniusSolarClient.Entities.SolarAPI.V1;
using FroniusSolarClient.Entities.SolarAPI.V1.ArchiveData;
using FroniusSolarClient.Entities.SolarAPI.V1.InverterRealtimeData;
using FroniusSolarClient.Services;
using System;
using System.Collections.Generic;

namespace FroniusSolarClient
{
    /// <summary>
    /// Obtain data from various Fronius devices (inverters, SensorCards, StringControls)
    /// </summary>
    public class SolarClient
    {
        private readonly RestClient _restClient;
        private readonly SolarClientConfiguration _configuration;

        // Services
        private InverterRealtimeDataService _inverterRealtimeDataService;
        private InverterArchiveDataService _inverterArchiveDataService;

        public SolarClient(string url, int version, Action<CommonResponseHeader> commonResponseHeader = null)
        {
            _configuration = new SolarClientConfiguration(url, version);
            _restClient = new RestClient(null, _configuration.GetBaseURL(), commonResponseHeader);


            _inverterRealtimeDataService = new InverterRealtimeDataService(_restClient);
            _inverterArchiveDataService = new InverterArchiveDataService(_restClient);
        }

        /// <summary>
        /// Get values which are cumulated to generate a system overview. 
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public CumulationInverterData GetCumulationInverterData(int deviceId = 1, Scope scope = Scope.Device)
        {
            return _inverterRealtimeDataService.GetCumulationInverterData(deviceId, scope);
        }

        /// <summary>
        /// Get values which are provided by all types of Fronius inverters. 
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public CommonInverterData GetCommonInverterData(int deviceId = 1, Scope scope = Scope.Device)
        {
            return _inverterRealtimeDataService.GetCommonInverterData(deviceId, scope);
        }

        /// <summary>
        /// Get values which are provided by 3phase Fronius inverters. 
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public P3InverterData GetP3InverterData(int deviceId = 1, Scope scope = Scope.Device)
        {
            return _inverterRealtimeDataService.GetP3InverterData(deviceId, scope);
        }

        /// <summary>
        /// Get minimum and maximum values of various inverter values.  
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public MinMaxInverterData GetMinMaxInverterData(int deviceId = 1, Scope scope = Scope.Device)
        {
            return _inverterRealtimeDataService.GetMinMaxInverterData(deviceId, scope);
        }

        /// <summary>
        /// Get archived data whenever access to historic device-data is possible. The number of days stored is dependant on the number of connected units that are logging data.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="channels"></param>
        /// <param name="deviceId"></param>
        /// <param name="scope"></param>
        /// <param name="seriesType"></param>
        /// <param name="humanReadable"></param>
        /// <param name="deviceClass"></param>
        /// <returns></returns>
        public Dictionary<string, ArchiveData> GetArchiveData(DateTime startDate, DateTime endDate, List<Channel> channels, int deviceId = 1, Scope scope = Scope.System, SeriesType seriesType = SeriesType.DailySum, bool humanReadable = true, DeviceClass deviceClass = DeviceClass.Inverter)
        {
            return _inverterArchiveDataService.GetArchiveData(startDate, endDate, channels, deviceId, scope, seriesType, humanReadable, deviceClass);
        }

    }
}
