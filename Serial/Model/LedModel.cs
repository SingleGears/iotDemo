using IotDemo.Serial.Config;
namespace IotDemo.Serial.Model
{
    public class LedModel
    {
        public LedModel() { }
        public LedModel(string txt) => _txt = txt;
        public LedPlay Paly { get; set; } = LedPlay.Left;
        public byte Speed
        {
            get => _speed;
            set
            {
                if (value > 7)
                    _speed = 7;
                else
                    _speed = value;
            }
        }
        public byte Wait
        {
            get => _wait;
            set
            {
                if (value > 99)
                    _wait = 99;
                else
                    _wait = value;
            }
        }
        public LedColor Color { get; set; } = LedColor.Red;
        public string Text
        {
            get => _txt;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _txt = value;
            }
        }

        private byte _speed = 0;
        private byte _wait = 0;
        private string _txt = " NULL ";
    }
}
