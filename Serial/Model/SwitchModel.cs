using IotDemo.Serial.Config;

namespace IotDemo.Serial.Model
{
    public class SwitchModel
    {
        public SwitchModel() { }
        public SwitchModel(uint port,bool status)
        {
            PortValue = port;
            StatusBool = status;
        }
        public SwitchModel(byte port,bool status)
        {
            PortByte = port;
            StatusBool = status;
        }
        public SwitchModel(SwitchPort port,SwitchStatus status)
        {
            Port = port;
            Status = status;
        }
        public uint PortValue
        {
            get => (uint)(_portByte % 0x10);
            set
            {
                if (value >= 8)
                    PortByte = 0x18;
                else
                    PortByte = (byte)(0x10 + value);
            }
        }
        public byte PortByte
        {
            get => _portByte;
            set
            {
                if (value >= 0x18)
                {
                    _portByte = 0x18;
                    _port = SwitchPort.DO8;
                }
                else
                {
                    _portByte = value;
                    _port = (SwitchPort)_portByte;
                }
            }
        }
        public SwitchPort Port
        {
            get => _port;
            set
            {
                _port = value;
                _portByte = (byte)value;
            }
        }
        public bool StatusBool
        {
            get => _statusBool;
            set
            {
                if (value)
                {
                    _status = SwitchStatus.Open;
                    _statusBool = value;
                }
                else
                {
                    _status = SwitchStatus.Close;
                    _statusBool = value;
                }
            }
        }
        public SwitchStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                if (value == SwitchStatus.Open)
                    _statusBool = true;
                else
                    _statusBool = false;
            }
        }
        private SwitchPort _port;
        private byte _portByte;
        private bool _statusBool;
        private SwitchStatus _status;
    }
}
