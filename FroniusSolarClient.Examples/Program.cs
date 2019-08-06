using FroniusSolarClient.Entities.SolarAPI.V1;
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
        static void OutputResponseHeader(CommonResponseHeader responseHeader)
        {
            Console.WriteLine($"{responseHeader.Status.Code} at {responseHeader.Timestamp}");
        }

        static void Main(string[] args)
        {
            var client = new SolarClient("10.1.1.124", 1, OutputResponseHeader);

            GetArchiveData(client);

            //GetRealTimeData(client);
        }
        static void GetArchiveData(SolarClient client)
        {
            var channels = new List<Channel> { Channel.Voltage_AC_Phase_1, Channel.Voltage_AC_Phase_2, Channel.Voltage_AC_Phase_3 };

            var data = client.GetArchiveData(DateTime.Now.AddDays(-1),DateTime.Now, channels);

            Console.WriteLine(data);
        }
        static void GetRealTimeData(SolarClient client)
        {
            var data = client.GetCommonInverterData(2, Scope.System);

            Console.WriteLine(data.TotalEnergy);

            var data2 = client.GetMinMaxInverterData();

            Console.WriteLine(data2.MaxCurrentDayAcPower);
        }
    }
}
