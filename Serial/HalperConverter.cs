using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotDemo.Serial
{
    internal static class HalperConverter
    {
        public static double ADAMConvertValue(int sensorValue, int mixRange, int maxRange)
        {
            return (double)(maxRange - mixRange) / 65535.0 * (double)sensorValue + (double)mixRange;
        }
        public static double ADAMConvertValue(int value,Config.ADAM4017Converter helper)
        {
            switch (helper)
            {
                case Config.ADAM4017Converter.Temperature:
                    return HalperConverter.ADAMConvertValue(value, -10, 60);
                case Config.ADAM4017Converter.Humidity:     
                    return HalperConverter.ADAMConvertValue(value, 50, 100);
                case Config.ADAM4017Converter.Light:        
                    return HalperConverter.ADAMConvertValue(value, 0, 20000);
                case Config.ADAM4017Converter.Wind:         
                    return HalperConverter.ADAMConvertValue(value, 0, 70);
                case Config.ADAM4017Converter.AirPressure:  
                    return HalperConverter.ADAMConvertValue(value, 0, 110);
                case Config.ADAM4017Converter.CO2:          
                    return HalperConverter.ADAMConvertValue(value, 0, 5000);
                case Config.ADAM4017Converter.AirQuality:
                    return value / 100.0;
                default:
                    throw new Exception(nameof(ADAMConvertValue) + "Error");
            }
        }
        public static double ZigBeeConvertValue(int value, int maxRange, int mixRange)
        {
            double num = (double)(value * 3300 / 1023) / 150.0;
            if (num <= 4.0)
            {
                num = 4.0;
            }
            return (num - 4.0) / 16.0 * (double)maxRange + (double)mixRange;
        }
    }
}
