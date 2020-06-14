using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using IotDemo.Model;
using SerialPortProvider;

namespace IotDemo.Class
{
    class GetAValue
    {
        ADAM _adam;
        DispatcherTimer _timer = new DispatcherTimer();
        ADPort _port;

        public TextBlock TextBlock0 { set; private get; }
        public TextBlock TextBlock1 { set; private get; }
        public TextBlock TextBlock2 { set; private get; }


        public GetAValue(ADAM adam, ADPort port)
        {
            _adam = adam;
            _port = port;
            timer();
        }

        public void Start() =>
            _timer.Start();
        public void Stop() =>
            _timer.Stop();

        private void timer()
        {
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += _timer_Tick;
        }

        /// <summary>
        /// 定时器方法，转换并显示数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _timer_Tick(object sender, EventArgs e)
        {
            if (_adam != null)
            {
                ADAM4117Data data = _adam.ReadADAM4117Data();

                if (data != null)
                {
                    //重复代码，需要改进
                    if (TextBlock0 != null)
                    {
                        //判断端口有效性
                        if (_port.APort.GetPort0 != null)
                        {
                            int? temp = GetAdam4017Data.GetData(data, (int)_port.APort.GetPort0);
                            if (temp != null)
                            {
                                //后续通过ini文件配置算法
                                TextBlock0.Text = ConvertHelper.Temperature((int)temp).ToString();
                            }
                        }
                        else
                        {
                            TextBlock0.Text = "0.0";
                        }
                    }
                    if (TextBlock1 != null)
                    {
                        if (_port.APort.GetPort1 != null)
                        {
                            int? temp = GetAdam4017Data.GetData(data, (int)_port.APort.GetPort1);
                            if (temp != null)
                            {
                                TextBlock1.Text = ConvertHelper.Humidity((int)temp).ToString();
                            }
                        }
                        else
                        {
                            TextBlock1.Text = "0.0";
                        }
                    }
                    if (TextBlock2 != null)
                    {
                        if (_port.APort.GetPort2 != null)
                        {
                            int? temp = GetAdam4017Data.GetData(data, (int)_port.APort.GetPort2);
                            if (temp != null)
                            {
                                TextBlock2.Text = ConvertHelper.Light((int)temp).ToString();
                            }
                        }
                        else
                        {
                            TextBlock2.Text = "0.0";
                        }
                    }
                }
            }
        }
    }
}
