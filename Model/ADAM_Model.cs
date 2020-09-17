using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotDemo.Model
{
    class ADAM_Model
    {
        readonly int _port;

        public ADAM_Model(int port) =>
            _port = port;

        public int Port
        {
            get => _port;
        }
    }
}
