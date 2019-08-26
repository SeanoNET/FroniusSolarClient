# FroniusSolarClient [![Build Status](https://travis-ci.org/SeanoNET/FroniusSolarClient.svg?branch=master)](https://travis-ci.org/SeanoNET/FroniusSolarClient)
A .NET Client wrapper for the [Fronius Solar API](https://www.fronius.com/en/photovoltaics/products/all-products/system-monitoring/open-interfaces/fronius-solar-api-json-) to obtain data from various Fronius devices (inverters, SensorCards, StringControls) in a defined format through a central facility which acts as a proxy(e.g. FroniusDatalogger Web or Fronius Solar web).

## Getting Started

Install the [NuGet package](https://www.nuget.org/packages/FroniusSolarClient.Core/)

 `Install-Package FroniusSolarClient.Core`

```csharp
using FroniusSolarClient.Entities.SolarAPI.V1;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


static void OutputResponseHeader(CommonResponseHeader responseHeader, ILogger logger)
{
    logger.LogInformation($"Response Header Status - {responseHeader.Status.Code} at {responseHeader.Timestamp}");
}

// Configure logger
var serviceProvider = new ServiceCollection()
    .AddLogging(build => build.AddConsole())
    .Configure<LoggerFilterOptions>(opt => opt.MinLevel = LogLevel.Debug)
    .BuildServiceProvider();

var client = new SolarClient("IP_ADDRESS", 1, serviceProvider.GetService<ILogger<SolarClient>>(), OutputResponseHeader);
```

see [examples](#examples)

## Logging

Internal logging has been implemented so you can parse in your own logger implementation see [Microsoft.Extensions.Logging](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger?view=aspnetcore-2.2)


## Implementation

[Realtime Requests](#realtime-requests)

- [GetInverterRealtimeData](#GetInverterRealtimeData)

[Archive Data Requests](#Archive-Data-Requests)

- [Channels](#Channels)



### Realtime Requests
These requests will be provided where direct access to the realtime data of the devices is possible. This is currently the case for the Fronius Datalogger Web and the Fronius Datamanager.

#### GetInverterRealtimeData
This request does not care about the configured visibility of single inverters. All inverters are reported.

- CumulationInverterData - Values which are cumulated to generate a system overview. 
- CommonInverterData - Values which are provided by all types of Fronius inverters. 
- P3InverterData (3PInverterData) - Values which are provided by 3phase Fronius inverters. 
- MinMaxInverterData - Minimum and Maximum values of various inverter values. 

### Archive Data Requests
Archive requests are provided whenever access to historic device-data is possible. The Datalogger web can only provide what is stored in its internal memory and has not been overwritten by newer data yet, it can loose data due to capacity reasons. The number of days stored is dependant on the number of connected units that are logging data.

#### Channels
Each channel is handled and requested by name. Most of the channels are recorded in constant cyclic intervals which can be set between 5 and 30 minutes. Only `Digital_PowerManagementRelay_Out_1`, `InverterErrors`, `InverterEvents` and `Hybrid_Operating_State` are event triggered and may occur every time.

|Name|Unit|
|---|---|
|TimeSpanInSec |sec|
|Digital_PowerManagementRelay_Out_1|1|
|EnergyReal_WAC_Sum_Produced|Wh|
|InverterEvents | struct|
|InverterErrors |  struct|
|Current_DC_String_1 |1A |
|Current_DC_String_2 |1A |
|Voltage_DC_String_1 |1V |
|Voltage_DC_String_2 |1V |
|Temperature_Powerstage |deg C |
|Voltage_AC_Phase_1 |1V |
|Voltage_AC_Phase_2 |1V |
|Voltage_AC_Phase_3 | 1V |
|Current_AC_Phase_1 |1A |
|Current_AC_Phase_2 |1A |
|Current_AC_Phase_3 |1A |
|PowerReal_PAC_Sum |1W |
|EnergyReal_WAC_Minus_Absolute |1Wh|
|EnergyReal_WAC_Plus_Absolute |1Wh |
|Meter_Location_Current |1 |
|Temperature_Channel_1 |1|
|Temperature_Channel_2 |1 |
|Digital_Channel_1 |1 |
|Digital_Channel_2 |1 |
|Radiation |1 |
|Digital_PowerManagementRelay_Out_1 |1 |
|Hybrid_Operating_State |1|

## Examples

- [GetInverterRealtimeData](#GetInverterRealtimeData)
- [GetArchiveData](#GetArchiveData)


### GetInverterRealtimeData

Get CommonInverterData

```csharp
var data = client.GetCommonInverterData();

Console.WriteLine(data.TotalEnergy);
```

Provide device id and scope

```csharp
var data = client.GetCommonInverterData(2, Scope.System);
```

### GetArchiveData

Get channel `Voltage_AC_Phase` data over the past 24 hours 

```csharp
var channels = new List<Channel> { Channel.Voltage_AC_Phase_1, Channel.Voltage_AC_Phase_2, Channel.Voltage_AC_Phase_3 };

var data = client.GetArchiveData(DateTime.Now.AddDays(-1), DateTime.Now, channels);
```

or between 2 dates

```csharp
var dateFrom = DateTime.Parse("01/08/2019");
var dateTo = DateTime.Parse("05/08/2019");

var data = client.GetArchiveData(dateFrom, dateTo, channels);
```
**Query intervals are restricted to a maximum of 16 days and the number of parallel queries is system wide restricted to 4 clients.**

### Other Examples

See [Program.cs](FroniusSolarClient.Examples/Program.cs) for more examples

