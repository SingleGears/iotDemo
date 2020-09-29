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
        public void Add(ClockHelper fun)
        {
            _clockEvent += fun;
            Count++;
            if (!_timer.IsEnabled)
                _timer.Start();
        }
        public void Remove(ClockHelper fun)
        {
            _clockEvent -= fun;
            Count--;
            if(Count == 0 && _timer.IsEnabled)
                _timer.Stop();
        }
        public int Count { get; private set; } = 0;
        private void _timer_Tick(object sender, EventArgs e)
        {
            if (_clockEvent != null && _adam.SerialIsOpen)
            {
                var data = _adam.ReadADAM4017Data();
                _clockEvent.Invoke(this,data);
            }
        }

        private readonly ADAM _adam;
        private readonly DispatcherTimer _timer;
        private event ClockHelper _clockEvent;
    }
}
