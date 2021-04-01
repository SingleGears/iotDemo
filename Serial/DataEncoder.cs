using System.Collections.Generic;
using System.Text;
using IotDemo.Serial.Model;

namespace IotDemo.Serial
{
    /// <summary>
    /// 协议码生成类
    /// </summary>
    public static class DataEncoder
    {
        /// <summary>
        /// LED屏协议码生成
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static byte[] GetLedBytes(string txt)
        {
            var model = new LedModel(txt);
            return GetLedBytes(model);
        }
        /// <summary>
        /// LED屏协议码生成，以数据模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static byte[] GetLedBytes(LedModel model)
        {
            //协议头
            var hand = new byte[6]
            {
                0xAA,
                0x01,
                0xBB,
                0x51,
                0x54,
                0x00  // data size
            };
            //数据位
            var ledSet = new byte[5]
            {
                (byte)model.Paly,
                model.Speed,
                model.Wait,
                (byte)model.Color,
                0x63
            };
            //文本转义编码
            var bytes = Encoding.GetEncoding("GB2312").GetBytes(model.Text);
            //数据位拼装
            var list = new List<byte>();
            list.AddRange(ledSet);
            list.AddRange(bytes);
            //校验码计算，协议规定
            list.ForEach((byte o) =>
            {
                hand[5] += o;
            });
            //开始协议码拼装
            var code = new List<byte>();
            code.AddRange(hand); //协议头
            code.AddRange(list); //数据位
            code.Add(0xFF);      //协议结尾
            return code.ToArray(); //转换为数组

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
        /// <summary>
        /// 数字量开关协议码生成
        /// </summary>
        /// <param name="port"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static byte[] GetSwitchBytes(uint port,bool status)
        {
            var model = new SwitchModel(port, status);
            return GetSwitchBytes(model);
        }
        /// <summary>
        /// 数字量开关协议码生成，以数据模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static byte[] GetSwitchBytes(SwitchModel model)
        {
            //协议头
            var buf = new byte[6]
            {
                0x01,
                0x05,
                0x00,
                (byte)model.Port,
                (byte)model.Status,
                0x00
            };
            var crc = CrcModbus.Get(buf);       //校验码
            //协议码拼装
            var code = new List<byte>();
            code.AddRange(buf);
            code.AddRange(crc);
            return code.ToArray();
        } 
        /// <summary>
        /// 模拟量请求数据协议码
        /// </summary>
        /// <returns></returns>
        public static byte[] GetADAM4017Bytes()
        {
            return new byte[8]
            {
                0x03,
                0x03,
                0x00,
                0x00,
                0x00,
                0x08,
                0x45,
                0xEE
            };
        }
        /// <summary>
        /// 数字量请求数据协议码
        /// </summary>
        /// <returns></returns>
        public static byte[] GetADAM4150Bytes()
        {
            return new byte[8]
            {
                0x01,
                0x01,
                0x00,
                0x00,
                0x00,
                0x07,
                0x7D,
                0xC8
            };
        }
    }
}
