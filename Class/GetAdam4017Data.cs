using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerialPortProvider;

namespace IotDemo.Class
{
    static class GetAdam4017Data
    {
        public static int? GetData(ADAM4117Data data, int port)
        {
            switch (port)
            {
                case 0:
                    return data.Value0;
                case 1:
                    return data.Value1;
                case 2:
                    return data.Value2;
                case 3:
                    return data.Value3;
                case 4:
                    return data.Value4;
                case 5:
                    return data.Value5;
                case 6:
                    return data.Value6;
                case 7:
                    return data.Value7;
                default:
                    return null;
            }
        }
    }
}
