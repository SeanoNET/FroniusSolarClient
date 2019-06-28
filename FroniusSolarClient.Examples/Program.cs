using FroniusSolarClient.Entities.SolarAPI.V1;
using System;

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

            var data = client.GetCommonInverterData(2, Scope.System);

            Console.WriteLine(data.TotalEnergy);

            var data2 = client.GetMinMaxInverterData();

            Console.WriteLine(data2.MaxCurrentDayAcPower);
        }
    }
}
