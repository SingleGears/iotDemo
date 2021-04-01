using IotDemo.Serial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace IotDemo.Service
{
    public delegate void ClockHelper(object sender,byte[] data);
    public class Clock
    {
        public Clock(ADAM adma)
        {
            _adam = adma;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += _timer_Tick;
        }
        /// <summary>
        /// 添加一个在计时器里处理的事件
        /// </summary>
        /// <param name="fun"></param>
        public void Add(ClockHelper fun)
        {
            _clockEvent += fun;                         //注册事件
            Count++;                                    //事件计数累加
            //注册事件后说明事件组至少有一个事件然后打开计时器，如果已打开就跳过
            if (!_timer.IsEnabled)                      
                _timer.Start();
        }
        /// <summary>
        /// 移除一个处理事件
        /// </summary>
        /// <param name="fun"></param>
        public void Remove(ClockHelper fun)
        {
            _clockEvent -= fun;                         //注销事件
            Count--;                                    //事件计数减1
            //如果事件组内没有事件运行计时器没有意义，就暂停计时器
            if (Count == 0 && _timer.IsEnabled)         
                _timer.Stop();                     
        }
        public int Count { get; private set; } = 0;     //计数添加了多少事件，属性可返回
        private void _timer_Tick(object sender, EventArgs e)
        {
            //判断事件不能为空和串口是否打开
            if (_clockEvent != null && _adam.SerialIsOpen)
            {
                var data = _adam.ReadADAM4017Data();    //读取ADAM源数据
                _clockEvent.Invoke(this,data);          //触发事件组
            }
        }

        private readonly ADAM _adam;   //设备处理
        private readonly DispatcherTimer _timer; //循环计时器
        private event ClockHelper _clockEvent;   //事件
    }
}
