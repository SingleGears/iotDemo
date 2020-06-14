using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Controls;

namespace IotDemo.Class
{
    class GetSerialNames
    {
        public GetSerialNames(ComboBox obj)
        {
            var list = SerialPort.GetPortNames();
            obj.Items.Clear();
            foreach(var t in list)
            {
                obj.Items.Add(t);
            }
        }
    }
}
