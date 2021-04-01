using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IotDemo.Serial.Config;

namespace IotDemo.Serial.Model {
    /// <summary>
    /// 模拟量设备数据
    /// </summary>
    public class ADAM4017Model {
        /// <summary>
        /// 构造方法重载
        /// </summary>
        /// <param name="port"></param>
        /// <param name="converter"></param>
        public ADAM4017Model(ADAM4017Port port, ADAM4017Converter converter) : this((uint)port, converter) { }
        /// <summary>
        /// 设备启动参数厨师化
        /// </summary>
        /// <param name="port"></param>
        /// <param name="converter"></param>
        public ADAM4017Model(uint port, ADAM4017Converter converter) {
            if (port > 7)               //设备没有大于7的接口
                port = 7;
            Port = (ADAM4017Port)port;
            PortValue = (int)port;
            Converter = converter;
        }
        //枚举接口
        public ADAM4017Port Port { get; set; }
        //值表示接口
        public int PortValue { get; }
        //接口采集值换算类型的标注
        public ADAM4017Converter Converter { get; set; }
    }
}
