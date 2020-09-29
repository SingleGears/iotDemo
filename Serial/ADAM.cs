using IotDemo.Serial.Config;
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
    public class ADAM : SerialHelper
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
            return HalperConverter.ADAMConvertValue(GetData(model.PortValue), model.Converter);
        }
        /// <summary>
        /// 获取值，无换算
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public int GetData(int port)
        {
            var data = ReadADAM4017Data();
            return (int)BitConverter.ToUInt16(this.DataSplit(data, port), 0);
        }
        public int GetData(byte[] data, int port) =>
            (int)BitConverter.ToUInt16(this.DataSplit(data, port), 0);

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
