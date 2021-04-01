namespace IotDemo.Serial.Config {
    /// <summary>
    /// ADAM4017数据类型枚举
    /// </summary>
    public enum ADAM4017Converter {
        Temperature,
        Light,
        Humidity,
        Wind,
        AirPressure,
        CO2,
        AirQuality
    }
    /// <summary>
    /// Zigbee数据类型枚举
    /// </summary>
    public enum ZigbeeConverter {
        SoilTemperatuer,
        WaterTemperature,
        SoilMoisture,
        WaterLevel
    }
    /// <summary>
    /// ADADM4017接口枚举
    /// </summary>
    public enum ADAM4017Port {
        AI0,
        AI1,
        AI2,
        AI3,
        AI4,
        AI5,
        AI6,
        AI7,
    }
    /// <summary>
    /// 数字量开关接口枚举
    /// </summary>
    public enum SwitchPort : byte {
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
    /// <summary>
    /// 数字量接口输入状态枚举
    /// </summary>
    public enum SwitchStatus : byte {
        Open = 0xFF,
        Close = 0x00,
    }
}
