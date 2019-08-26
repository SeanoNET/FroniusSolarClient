using FroniusSolarClient.Entities.SolarAPI.V1;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace FroniusSolarClient.Examples
{
    class Program
    {

        /// <summary>
        /// Prints out the status of the last response header
        /// </summary>
        /// <param name="responseHeader"></param>
        static void OutputResponseHeader(CommonResponseHeader responseHeader, ILogger logger)
        {
            logger.LogInformation($"Response Header Status - {responseHeader.Status.Code} at {responseHeader.Timestamp}");
        }

        static void Main(string[] args)
        {
            // Configure logger
            var serviceProvider = new ServiceCollection()
                .AddLogging(build => build.AddConsole())
                .Configure<LoggerFilterOptions>(opt => opt.MinLevel = LogLevel.Debug)
                .BuildServiceProvider();
           
            var client = new SolarClient("10.1.1.124", 1, serviceProvider.GetService<ILogger<SolarClient>>(), OutputResponseHeader);

            //GetArchiveDataOverPast24Hours(client);
            GetRealTimeData(client);
        }
       
        #region RealtimeData
        static void GetRealTimeData(SolarClient client)
        {
            var data = client.GetMinMaxInverterData();

            Console.WriteLine(data.MaxCurrentDayAcPower);
        }
        #endregion

        #region ArchiveData
        static void GetArchiveDataBetweenDates(SolarClient client)
        {
            var channels = new List<Channel> { Channel.Voltage_AC_Phase_1, Channel.Voltage_AC_Phase_2, Channel.Voltage_AC_Phase_3 };

            var dateFrom = DateTime.Parse("01/08/2019");
            var dateTo = DateTime.Parse("05/08/2019");

            var data = client.GetArchiveData(dateFrom, dateTo, channels);

            Console.WriteLine(data);
        }
        static void GetArchiveDataOverPast24Hours(SolarClient client)
        {
            var channels = new List<Channel> { Channel.Voltage_AC_Phase_1, Channel.Voltage_AC_Phase_2, Channel.Voltage_AC_Phase_3 };

            var data = client.GetArchiveData(DateTime.Now.AddDays(-1), DateTime.Now, channels);

            Console.WriteLine(data);
        }
        #endregion
    }
}
