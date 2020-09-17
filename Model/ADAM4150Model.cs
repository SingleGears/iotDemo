using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotDemo.Model
{
    class ADAM4150Model:ADAM_Model
    {
        bool _switch = false;

        public ADAM4150Model(int port) : base(port)
        {

        }
        public bool Switch
        {
            set => _switch = value;
        }
        public bool isTrigger() => _switch;
    }
}
