using IotDemo.Serial.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IotDemo.Serial
{
    class ADAM : SerialHelper
    {
        public ADAM(string com) : base(com)
        {
        }

        public ADAM(string com, int port) : base(com, port)
        {
        }
        public byte[] ReadADAM4017Data() =>
            ReadADAM4017Data(DataEncoder.GetADAM4017Bytes());
        public byte[] ReadADAM4017Data(byte[] code)
        {
            Send(code);
            WaitOne();
            return Read();
        }
        public byte[] ReadADAM4150Data() =>
            ReadADAM4017Data(DataEncoder.GetADAM4150Bytes());
        public byte[] ReadADAM4150Data(byte[] code)
        {
            Send(code);
            WaitOne();
            return Read();
        }
        public double GetValue(int port, int min, int max) =>
            HalperConverter.ADAMConvertValue(port, min, max);
        public double GetValue(ADAM4017Model model)
        {
            switch (model.Converter)
            {
                case Config.ADAM4017Converter.Temperature:
                    return HalperConverter.ADAMConvertValue(GetValue(model.PortValue), -10, 60);
                case Config.ADAM4017Converter.Humidity:
                    return HalperConverter.ADAMConvertValue(GetValue(model.PortValue), 50, 100);
                case Config.ADAM4017Converter.Light:
                    return HalperConverter.ADAMConvertValue(GetValue(model.PortValue), 0, 20000);
                case Config.ADAM4017Converter.Wind:
                    return HalperConverter.ADAMConvertValue(GetValue(model.PortValue), 0, 70);
                case Config.ADAM4017Converter.AirPressure:
                    return HalperConverter.ADAMConvertValue(GetValue(model.PortValue), 0, 110);
                case Config.ADAM4017Converter.CO2:
                    return HalperConverter.ADAMConvertValue(GetValue(model.PortValue), 0, 5000);
                case Config.ADAM4017Converter.AirQuality:
                    return (double)GetValue(model) / 100.0;
                default:
                    throw new Exception(nameof(GetValue)+"Error");
            }
        }
        private int GetValue(int port)
        {
            var data = ReadADAM4017Data();
            return (int)BitConverter.ToUInt16(this.DataSplit(data, port), 0);
        }

        private byte[] DataSplit(byte[] data,int channel)
        {
            channel *= 2;
            channel += 3;
            return new byte[]
            {
                data[channel + 1],
                data[channel]
            };
        }
    }
}
