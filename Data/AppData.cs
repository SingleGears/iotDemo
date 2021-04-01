using IotDemo.Data.Menu;
using IotDemo.Serial.Config;
using System.Collections.Generic;

namespace IotDemo.Data {
    /// <summary>
    /// 窗口资源数据
    /// </summary>
    class AppData {
        public static readonly Dictionary<string, ADAM4017Converter> _HelperModeContext = new Dictionary<string, ADAM4017Converter>
        {
            {"温度",ADAM4017Converter.Temperature },
            {"湿度",ADAM4017Converter.Humidity },
            {"光照",ADAM4017Converter.Light },
            {"风速",ADAM4017Converter.Wind },
            {"二氧化碳",ADAM4017Converter.CO2 },
            {"大气压强",ADAM4017Converter.AirPressure},
            {"空气质量",ADAM4017Converter.AirQuality}
        };
        public static readonly Dictionary<string, DecisionMode> _DecisionModeContext = new Dictionary<string, DecisionMode>
        {
            {"禁用", DecisionMode.Close },
            {"大于", DecisionMode.Greater },
            {"小于", DecisionMode.Less },
            {"范围", DecisionMode.Scope }
        };
    }
}
