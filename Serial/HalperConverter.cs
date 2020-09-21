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
