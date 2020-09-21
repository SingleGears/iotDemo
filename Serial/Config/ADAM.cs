using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotDemo.Serial.Config
{
    public enum ADAM4017Converter
    {
        Temperature,
        Light,
        Humidity,
        Wind,
        AirPressure,
        CO2,
        AirQuality
    }
    public enum ZigbeeConverter
    {
        SoilTemperatuer,
        WaterTemperature,
        SoilMoisture,
        WaterLevel
    }
    public enum ADAM
    public enum SwitchPort : byte
    {
        DO0 = 0x10,
        DO1 = 0x11,
        DO2 = 0x12,
        DO3 = 0x13,
        DO4 = 0x14,
        DO5 = 0x15,
        DO6 = 0x16,
        DO7 = 0x17,
        DO8 = 0x18
    }
    public enum SwitchStatus : byte
    {
        Open = 0xFF,
        Close = 0x00,
    }
}
