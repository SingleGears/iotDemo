using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using IotDemo.Class;
using IotDemo.Model;

namespace IotDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            //获取串口
            new GetSerialNames(comBoBox_SerialNames);
        }

        /// <summary>
        /// 重新获取serial names
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClick_RpeatGetSerialPort(object sender, RoutedEventArgs e)
        {
            new GetSerialNames(comBoBox_SerialNames);
        }

        /// <summary>
        /// 打开串口的事件方法，也是启动所有功能的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClick_OpenSerial(object sender, RoutedEventArgs e)
        {

        }

    }
}
