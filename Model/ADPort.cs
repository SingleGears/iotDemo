using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IotDemo.Model
{
    /// <summary>
    /// 端子号数据模型
    /// </summary>
    class ADPort
    {
        public Port APort = new Port();
        public Port DPort = new Port();
    }

    /// <summary>
    /// 端子号模型
    /// </summary>
    internal struct Port
    {
        private int? _port0;
        private int? _port1;
        private int? _port2;

        //赋值转换 string -> int and int -> int
        public void SetPort0(string value)
        {
            try
            {
                _port0 = Convert.ToInt32(value);
            }
            catch
            {
                _port0 = null;
            }
        }

        public void SetPort0(int value) =>
            _port0 = value;

        public void SetPort1(string value)
        {
            try
            {
                _port1 = Convert.ToInt32(value);
            }
            catch
            {
                _port1 = null;
            }
        }

        public void SetPort1(int value) =>
            _port1 = value;

        public void SetPort2(string value)
        {
            try
            {
                _port2 = Convert.ToInt32(value);
            }
            catch
            {
                _port2 = null;
            }
        }

        public void SetPort2(int value) =>
            _port2 = value;

        //这里输出空数据不做筛选，因为有不规则字符和空白
        public int? GetPort0 { get => _port0; }
        public int? GetPort1 { get => _port1; }
        public int? GetPort2 { get => _port2; }
    }
}
