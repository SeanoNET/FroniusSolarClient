# FroniusSolarClient [![Build Status](https://travis-ci.org/SeanoNET/FroniusSolarClient.svg?branch=master)](https://travis-ci.org/SeanoNET/FroniusSolarClient)
A .NET Client wrapper for the [Fronius Solar API](https://www.fronius.com/en/photovoltaics/products/all-products/system-monitoring/open-interfaces/fronius-solar-api-json-) to obtain data from various Fronius devices (inverters, SensorCards, StringControls) in a defined format through a central facility which acts as a proxy(e.g. FroniusDatalogger Web or Fronius Solar web).

## Getting Started

```csharp
using FroniusSolarClient.Entities.SolarAPI.V1;

static void OutputResponseHeader(CommonResponseHeader responseHeader)
{
    Console.WriteLine($"{responseHeader.Status.Code} at {responseHeader.Timestamp}");
}

var client = new SolarClient("IP_ADDRESS", 1, OutputResponseHeader);
```

## Implementation Status

[Realtime Requests](#realtime-requests)

|||
|---|---|
|[GetInverterRealtimeData](#GetInverterRealtimeData)| **100%**|




### Realtime Requests
These requests will be provided where direct access to the realtime data of the devices is possible. This is currently the case for the Fronius Datalogger Web and the Fronius Datamanager.

#### GetInverterRealtimeData
This request does not care about the configured visibility of single inverters. All inverters are reported.

- CumulationInverterData - Values which are cumulated to generate a system overview. 
- CommonInverterData - Values which are provided by all types of Fronius inverters. 
- P3InverterData (3PInverterData) - Values which are provided by 3phase Fronius inverters. 
- MinMaxInverterData - Minimum and Maximum values of various inverter values. 

## Examples

- [GetInverterRealtimeData](#GetInverterRealtimeData)


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

### Other Examples

See [Program.cs](FroniusSolarClient.Examples/Program.cs) for more examples

