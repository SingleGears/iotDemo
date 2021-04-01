using IotDemo.Serial.Config;

namespace IotDemo.Serial.Model {
    /// <summary>
    /// 数字量通信数据
    /// </summary>
    public class SwitchModel {
        /// <summary>
        /// 构造方法初始化
        /// </summary>
        public SwitchModel() { }
        /// <summary>
        /// 构造方法初始化
        /// </summary>
        /// <param name="port"></param>
        /// <param name="status"></param>
        public SwitchModel(uint port, bool status) {
            PortValue = port;
            StatusBool = status;
        }
        /// <summary>
        /// 构造方法初始化
        /// </summary>
        /// <param name="port"></param>
        /// <param name="status"></param>
        public SwitchModel(byte port, bool status) {
            PortByte = port;
            StatusBool = status;
        }
        /// <summary>
        /// 构造方法初始化
        /// </summary>
        /// <param name="port"></param>
        /// <param name="status"></param>
        public SwitchModel(SwitchPort port, SwitchStatus status) {
            Port = port;
            Status = status;
        }
        /// <summary>
        /// 数字量接口值表示
        /// </summary>
        public uint PortValue {
            get => (uint)(_portByte % 0x10);
            set {
                if (value >= 8)
                    PortByte = 0x18;
                else
                    PortByte = (byte)(0x10 + value);
            }
        }
        /// <summary>
        /// 接口十六进制地址表示
        /// </summary>
        public byte PortByte {
            get => _portByte;
            set {
                if (value >= 0x18) {
                    _portByte = 0x18;
                    _port = SwitchPort.DO8;
                }
                else {
                    _portByte = value;
                    _port = (SwitchPort)_portByte;
                }
            }
        }
        /// <summary>
        /// 数字量接口
        /// </summary>
        public SwitchPort Port {
            get => _port;
            set {
                _port = value;
                _portByte = (byte)value;
            }
        }
        /// <summary>
        /// 接口状态bool值
        /// </summary>
        public bool StatusBool {
            get => _statusBool;
            set {
                if (value) {
                    _status = SwitchStatus.Open;
                    _statusBool = value;
                }
                else {
                    _status = SwitchStatus.Close;
                    _statusBool = value;
                }
            }
        }
        /// <summary>
        /// 接口状态
        /// </summary>
        public SwitchStatus Status {
            get => _status;
            set {
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
