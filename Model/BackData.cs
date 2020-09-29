using IotDemo.Serial;
using IotDemo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IotDemo.Model
{
    public class BackData
    {
        public BackData(ADAM adam)
        {
            _Adam = adam;
            _Clock = new Clock(adam);
        }
        public ADAM _Adam { get; private set; }
        public Dictionary<Guid,UIElement> _AnalogConfigModels { get; set; }
        public readonly Clock _Clock;
    }
}
