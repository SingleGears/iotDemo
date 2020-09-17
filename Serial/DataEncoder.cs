using System.Collections.Generic;
using System.Text;
using IotDemo.Serial.Model;

namespace IotDemo.Serial
{
    public static class DataEncoder
    {
        public static byte[] GetLedBytes(string txt)
        {
            var model = new LedModel(txt);
            return GetLedBytes(model);
        }
        public static byte[] GetLedBytes(LedModel model)
        {
            var hand = new byte[6]
            {
                0xAA,
                0x01,
                0xBB,
                0x51,
                0x54,
                0x00  // data size
            };
            var ledSet = new byte[5]
            {
                (byte)model.Paly,
                model.Speed,
                model.Wait,
                (byte)model.Color,
                0x63
            };

            var bytes = Encoding.GetEncoding("GB2312").GetBytes(model.Text);
            var list = new List<byte>();
            list.AddRange(ledSet);
            list.AddRange(bytes);
            list.ForEach((byte o) =>
            {
                hand[5] += o;
            });
            var code = new List<byte>();
            code.AddRange(hand);
            code.AddRange(list);
            code.Add(0xFF);
            return code.ToArray();

            #region #1
            /*
            byte[] temp = Encoding.GetEncoding("GB2312").GetBytes(text);
            //text_GB.Text = BitConverter.ToString(temp, 0).Replace("-", string.Empty).ToLower();
            byte[] tenp = new byte[11 + temp.Length + 1];
            tenp[0] = 0xAA;
            tenp[1] = 0x01;
            tenp[2] = 0xBB;
            tenp[3] = 0x51;
            tenp[4] = 0x54;
            tenp[5] = 0x00;//数据长度 
            tenp[6] = 0x01;
            tenp[7] = 0x00;
            tenp[8] = 0x00;
            tenp[9] = 0x02;
            tenp[10] = 0x63;
            for (int i = 0; i < temp.Length; i++)
            {
                tenp[i + 11] = temp[i];
            }
            for (int i = 0; i < tenp.Length - 6; i++)
            {
                tenp[5] += tenp[i + 6];
            }
            tenp[11 + temp.Length] = 0xff;
            return tenp;*/
            #endregion
            #region #2
            /*
            byte[] collection = new byte[]
            {
                170,
                1,
                187,
                81,
                84
            };
            byte[] collection2 = new byte[]
            {
                1,
                0,
                0,
                2,
                99
            };
            byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(txt);
            List<byte> list = new List<byte>();
            list.AddRange(collection2);
            list.AddRange(bytes);
            byte totalByte = 0;
            list.ForEach(delegate (byte o)
            {
                totalByte += o;
            });
            List<byte> list2 = new List<byte>();
            list2.AddRange(collection);
            list2.Add(totalByte);
            list2.AddRange(list);
            list2.Add(byte.MaxValue);
            return list2.ToArray();
            */
            #endregion
        }
        public static byte[] GetSwitchBytes(uint port,bool status)
        {
            var model = new SwitchModel(port, status);
            return GetSwitchBytes(model);
        }
        public static byte[] GetSwitchBytes(SwitchModel model)
        {
            var buf = new byte[6]
            {
                0x01,
                0x05,
                0x00,
                (byte)model.Port,
                (byte)model.Status,
                0x00
            };
            var crc = CrcModbus.Get(buf);
            var code = new List<byte>();
            code.AddRange(buf);
            code.AddRange(crc);
            return code.ToArray();
        } 
    }
}
