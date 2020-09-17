namespace IotDemo.Serial
{
    public class Led : SerialHelper
    {
        public Led(string com) : base(com)
        {
        }

        public Led(string com, int port) : base(com, port)
        {
        }
        public bool Show(string txt) {
            var code = DataEncoder.GetLedBytes(txt);
            return base.Send(code);
        }
    }
}
