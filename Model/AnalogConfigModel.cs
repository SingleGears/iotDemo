using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IotDemo.Data.Menu;
using IotDemo.Serial.Config;

namespace IotDemo.Model
{
    public class AnalogConfigModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public uint Port { get; set; }
        //在AppData中的配置数据
        public ADAM4017Converter Helper { get; set; }
        public DecisionMode Decision { get; set; }
        public int MaxValue { get; set; }
        public int MinValue { get; set; }
    }
}
