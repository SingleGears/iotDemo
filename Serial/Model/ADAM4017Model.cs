using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IotDemo.Serial.Config;

namespace IotDemo.Serial.Model
{
    class ADAM4017Model
    {
        public ADAM4017Model(ADAM4017Port port, ADAM4017Converter converter) : this((uint)port, converter)
        { }
        public ADAM4017Model(uint port, ADAM4017Converter converter)
        {
            if (port > 7)
                port = 7;
            Port = (ADAM4017Port)port;
            PortValue = (int)port;
            Converter = converter;
        }
        public ADAM4017Port Port { get; set; }
        public int PortValue { get; }
        public ADAM4017Converter Converter { get; set; }
    }
}
