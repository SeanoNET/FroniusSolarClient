using System;
using System.Collections.Generic;
using System.Text;

namespace FroniusSolarClient.Entities.SolarAPI.V1
{
    public enum Scope
    {
        Device,
        System
    }

    #region ArchiveData

    /// <summary>
    /// Resolution of the data-series
    /// </summary>
    public enum SeriesType
    {
        DailySum,
        Detail
    }

    /// <summary>
    ///  Which kind of device will be queried. Mandatory and accepted only if Scope is not System
    /// </summary>
    public enum DeviceClass
    {
        Inverter,
        SensorCard,
        StringControl,
        Meter,
        Storage,
        OhmPilot
    }

    /// <summary>
    /// Available channels 
    /// </summary>
    public enum Channel
    {
        TimeSpanInSec,
        Digital_PowerManagementRelay_Out_1,
        EnergyReal_WAC_Sum_Produced,
        InverterEvents,
        InverterErrors,
        Current_DC_String_1,
        Current_DC_String_2,
        Voltage_DC_String_1,
        Voltage_DC_String_2,
        Temperature_Powerstage,
        Voltage_AC_Phase_1,
        Voltage_AC_Phase_2,
        Voltage_AC_Phase_3,
        Current_AC_Phase_1,
        Current_AC_Phase_2,
        Current_AC_Phase_3,
        PowerReal_PAC_Sum,
        EnergyReal_WAC_Minus_Absolute,
        EnergyReal_WAC_Plus_Absolute,
        Meter_Location_Current,
        Temperature_Channel_1,
        Temperature_Channel_2,
        Digital_Channel_1,
        Digital_Channel_2,
        Radiation,
        Hybrid_Operating_State
    }

    #endregion
}
