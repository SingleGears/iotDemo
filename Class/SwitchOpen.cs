using SerialPortProvider;

namespace IotDemo.Class
{
    class SwitchOpen
    {
        /// <summary>
        /// 选择打开那个口
        /// </summary>
        /// <param name="adam"></param>
        /// <param name="number"></param>
        public SwitchOpen(ADAM adam, int number)
        {
            switch (number)
            {
                case 0:
                    adam.Switch(Switchs.OnDO0);
                    break;
                case 1:
                    adam.Switch(Switchs.OnDO1);
                    break;
                case 2:
                    adam.Switch(Switchs.OnDO2);
                    break;
                case 3:
                    adam.Switch(Switchs.OnDO3);
                    break;
                case 4:
                    adam.Switch(Switchs.OnDO4);
                    break;
                case 5:
                    adam.Switch(Switchs.OnDO5);
                    break;
                case 6:
                    adam.Switch(Switchs.OnDO6);
                    break;
                case 7:
                    adam.Switch(Switchs.OnDO7);
                    break;
            }
        }
    }
}
