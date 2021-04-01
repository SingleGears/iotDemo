using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Controls;

namespace IotDemo.Service
{
    class GetSerialNames
    {
        /// <summary>
        /// 获取本机串口组
        /// </summary>
        /// <param name="combo"></param>
        public GetSerialNames(ComboBox combo)
        {
            var list = SerialPort.GetPortNames();
            combo.Items.Clear();
            foreach(var t in list)
            {
                combo.Items.Add(t);
            }
        }
    }
}
