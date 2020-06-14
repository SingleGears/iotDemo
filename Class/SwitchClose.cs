using SerialPortProvider;

namespace IotDemo.Class
{
    class SwitchClose
    {
        /// <summary>
        /// 选择关闭那个口
        /// </summary>
        /// <param name="adam"></param>
        /// <param name="number"></param>
        public SwitchClose(ADAM adam, int number)
        {
            switch (number)
            {
                case 0:
                    adam.Switch(Switchs.OffDO0);
                    break;
                case 1:
                    adam.Switch(Switchs.OffDO1);
                    break;
                case 2:
                    adam.Switch(Switchs.OffDO2);
                    break;
                case 3:
                    adam.Switch(Switchs.OffDO3);
                    break;
                case 4:
                    adam.Switch(Switchs.OffDO4);
                    break;
                case 5:
                    adam.Switch(Switchs.OffDO5);
                    break;
                case 6:
                    adam.Switch(Switchs.OffDO6);
                    break;
                case 7:
                    adam.Switch(Switchs.OffDO7);
                    break;
            }
        }
    }
}
