using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IotDemo.Serial.Config {
    /// <summary>
    /// LED屏控制参数枚举
    /// </summary>
    public enum LedPlay : byte {
        Left = 0x01,
        Up = 0x02,
        Down = 0x03,
        DownCover = 0x04,
        UpCover = 0x05,
        InvertedDisplay = 0x06,
        FlashingDisplay = 0x07,
        Straightway = 0x08
    }
    /// <summary>
    /// LED屏颜色枚举，只有一种色灯的屏不支持
    /// </summary>
    public enum LedColor : byte {
        Red = 0,
        Green = 1,
        Yellow = 2
    }

}
