using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IotDemo.Data.Menu;
using IotDemo.Serial.Config;

namespace IotDemo.Model {
    public class AnalogConfigModel {
        public Guid ID { get; set; }                    //唯一ID
        public string Name { get; set; }                //传感器名称
        public uint Port { get; set; }                  //数据来源接口
        //在AppData中的配置数据
        public ADAM4017Converter Helper { get; set; }   //数据换算类型
        public DecisionMode Decision { get; set; }      //逻辑判断选项
        public int MaxValue { get; set; }               //设置最大值
        public int MinValue { get; set; }               //设置最小值
    }
}
