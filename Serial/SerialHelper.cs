using System;
using System.IO.Ports;
using System.Threading.Tasks;

namespace IotDemo.Serial {
    /// <summary>
    /// 串口通信处理类
    /// </summary>
    public class SerialHelper : IDisposable {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="com"></param>
        public SerialHelper(string com) : this(com, 9600) { }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="com"></param>
        /// <param name="port"></param>
        public SerialHelper(string com, int port) =>
            _serial = new SerialPort(com, port);
        /// <summary>
        /// 串口状态，判断是否打开
        /// </summary>
        public bool SerialIsOpen => _serial.IsOpen;
        /// <summary>
        /// 串口打开
        /// </summary>
        public void Open() {
            if (!SerialIsOpen)
                _serial.Open();
        }
        /// <summary>
        /// 串口关闭
        /// </summary>
        public void Close() {
            if (SerialIsOpen)
                _serial.Close();
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="buff"></param>
        /// <returns></returns>
        public bool Send(byte[] buff) {
            if (SerialIsOpen) {                        
                _serial.Write(buff, 0, buff.Length);//写入串口数据    
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <returns></returns>
        public byte[] Read() {
            if (SerialIsOpen) {
                int length = _serial.BytesToRead;   //读取串口缓冲区数据长度
                byte[] buff = new byte[length];
                _serial.Read(buff, 0, length);      //读取串口数据
                return buff;
            }
            else
                return null;
        }
        /// <summary>
        /// 暂停一下，保证数据完整性
        /// </summary>
        public async void WaitOne() =>
            await Task.Delay(100);
        /// <summary>
        /// 串口资源释放
        /// </summary>
        public void Dispose() {
            Close();
            GC.SuppressFinalize(this);
        }
        ~SerialHelper() => Dispose();

        private SerialPort _serial;
    }
}
