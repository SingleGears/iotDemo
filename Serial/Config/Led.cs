using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotDemo.Serial.Config.Led
{
    public enum Play : byte
    {
        Left = 0x01,
        Up = 0x02,
        Down = 0x03,
        DownCover = 0x04,
        UpCover = 0x05,
        InvertedDisplay = 0x06,
        FlashingDisplay = 0x07,
        Straightway = 0x08
    }
    public enum Color : byte
    {
        Red = 0,
        Green = 1,
        Yellow = 2
    }

}
