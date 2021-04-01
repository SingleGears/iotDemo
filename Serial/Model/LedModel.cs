using IotDemo.Serial.Config;
namespace IotDemo.Serial.Model {
    /// <summary>
    /// LED屏通信数据
    /// </summary>
    public class LedModel {
        public LedModel() { }
        //构造函数赋文本值
        public LedModel(string txt) => _txt = txt;
        //播放方向，默认向左
        public LedPlay Paly { get; set; } = LedPlay.Left;
        //速度，默认0
        public byte Speed {
            get => _speed;
            set {
                if (value > 7)
                    _speed = 7;
                else
                    _speed = value;
            }
        }
        //停留时间，默认0
        public byte Wait {
            get => _wait;
            set {
                if (value > 99)
                    _wait = 99;
                else
                    _wait = value;
            }
        }
        //颜色，默认红色
        public LedColor Color { get; set; } = LedColor.Red;
        //文本，默认 “NULL”
        public string Text {
            get => _txt;
            set {
                if (!string.IsNullOrWhiteSpace(value))
                    _txt = value;
            }
        }

        private byte _speed = 0;
        private byte _wait = 0;
        private string _txt = " NULL ";
    }
}
