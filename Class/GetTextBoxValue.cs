using IotDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace IotDemo.Class
{
    class GetTextBoxValue
    {
        private DispatcherTimer _timer = new DispatcherTimer();
        private ADPort _dataPort = new ADPort();
        
        public GetTextBoxValue()
        {
            timer();
        }

        public void Start()=>
            _timer.Start();
        public void Stop() =>
            _timer.Stop();

        public ADPort GetPort { get => _dataPort; }

        private void timer()
        {
            _timer.Interval = TimeSpan.FromMilliseconds(200);
            _timer.Tick += _timer_Tick;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            _dataPort.APort.SetPort0(TextBoxControls.APort0.Text);
            _dataPort.APort.SetPort1(TextBoxControls.APort1.Text);
            _dataPort.APort.SetPort2(TextBoxControls.APort2.Text);

            _dataPort.DPort.SetPort0(TextBoxControls.DPort0.Text);
            _dataPort.DPort.SetPort1(TextBoxControls.DPort1.Text);
            _dataPort.DPort.SetPort2(TextBoxControls.DPort2.Text);
        }

    }
}
