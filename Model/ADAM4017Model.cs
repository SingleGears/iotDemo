using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IotDemo.Class;
using SerialPortProvider;

namespace IotDemo.Model
{
    enum HelperMode
    {
        AirPressure,
        AirQuality,
        CO2,
        Humidity,
        Light,
        SoilMoistrue,
        SoilTemperatuer,
        Temperature,
        WaterLevel,
        WaterTemperature,
        Wind
    }
    class ADAM4017Model : ADAM_Model
    {
        //bool _judge = false;
        //double _down = 0;
        //double _up = 0;

        //禁用，最大，最小，范围

        //public bool isJudge() => _judge;

        //public double DownValue
        //{

        //}
        int _value = 0;

        public ADAM4017Model(int port) : base(port) { }

        public int Value
        {
            get => _value;
            set => _value = value;
        }

        public double GetData(HelperMode mode)
        {
            switch (mode)
            {
                case HelperMode.AirPressure:
                    return ConvertHelper.AirPressure(_value);
                case HelperMode.AirQuality:
                    return ConvertHelper.AirQuality(_value);
                case HelperMode.CO2:
                    return ConvertHelper.CO2(_value);
                case HelperMode.Humidity:
                    return ConvertHelper.Light(_value);
                case HelperMode.SoilMoistrue:
                    return ConvertHelper.SoilMoisture(_value);
                case HelperMode.SoilTemperatuer:
                    return ConvertHelper.SoilTemperatuer(_value);
                case HelperMode.Temperature:
                    return ConvertHelper.Temperature(_value);
                case HelperMode.WaterLevel:
                    return ConvertHelper.WaterLevel(_value);
                case HelperMode.WaterTemperature:
                    return ConvertHelper.WaterTemperature(_value);
                case HelperMode.Wind:
                    return ConvertHelper.Wind(_value);
                default:
                    return 0.0;
            }
        }
    }
}
