using IotDemo.Serial;
using IotDemo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IotDemo.Model {
    public class BackData {
        /// <summary>
        /// 用空控件间传递控制数据
        /// </summary>
        /// <param name="adam"></param>
        public BackData(ADAM adam) {
            Adam = adam;
            Timer = new Clock(adam);
        }
        public ADAM Adam { get; private set; }
        public Dictionary<Guid, UIElement> AnalogConfigModels { get; set; }
        public readonly Clock Timer;
    }
}
