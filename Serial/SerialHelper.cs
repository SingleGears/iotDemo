using System;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;

namespace IotDemo.Serial
{
    public class SerialHelper : IDisposable
    {
        public SerialHelper(string com) : this(com, 9600) { }

        public SerialHelper(string com,int port)=>
            _serial = new SerialPort(com,port);

        public bool SerialIsOpen => _serial.IsOpen;
        public void Open()
        {
            if(!SerialIsOpen)
            _serial.Open();
        }
        public void Close()
        {
            if(SerialIsOpen)
            _serial.Close();
        }
        public bool Send(byte[] buff)
        {
            if (SerialIsOpen)
            {
                _serial.Write(buff, 0, buff.Length);
                return true;
            }
            else
                return false;
        }
        public byte[] Read()
        {
            if (SerialIsOpen)
            {
                int length = _serial.BytesToRead;
                byte[] buff = new byte[length];
                _serial.Read(buff, 0, length);
                return buff;
            }
            else
                return null;
        }
        public async void WaitOne()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(100);
            });
        }

        public void Dispose()
        {
            Close();
            GC.SuppressFinalize(this);
        }
        ~SerialHelper() => Dispose();

        private SerialPort _serial; 
    }
}
