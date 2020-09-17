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
using SerialPortProvider;

namespace IotDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        ADAM _adam;
        GetTextBoxValue _getTextBoxValue;
        GetAValue _getAValue;

        public MainWindow()
        {
            InitializeComponent();

            //获取串口
            new GetSerialNames(comBoBox_SerialNames);

            #region PortNumber
            //收集所有的需要填写端子号的TextBox__all of the PortNumber controls
            TextBoxControls.APort0 = textBox_PortNumb_A_0;
            TextBoxControls.APort1 = textBox_PortNumb_A_1;
            TextBoxControls.APort2 = textBox_PortNumb_A_2;

            TextBoxControls.DPort0 = textBox_PortNumb_D_0;
            TextBoxControls.DPort1 = textBox_PortNumb_D_1;
            TextBoxControls.DPort2 = textBox_PortNumb_D_2;

            TextBoxControls.MinValue0 = textBox_MinVlaue_A_0;
            TextBoxControls.MinValue1 = textBox_MinVlaue_A_1;
            TextBoxControls.MinValue2 = textBox_MinVlaue_A_2;

            TextBoxControls.MaxValue0 = textBox_MaxVlaue_A_0;
            TextBoxControls.MaxValue1 = textBox_MaxVlaue_A_1;
            TextBoxControls.MaxValue2 = textBox_MaxVlaue_A_2;
            #endregion
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
            ///************启动串口*******************//
            if (comBoBox_SerialNames.Text == "")
            {
                MessageBox.Show("串口不能为空");
                return;
            }
            if (comBoBox_SerialPort.Text != "")
            {
                _adam = new ADAM(comBoBox_SerialNames.Text,
                    Convert.ToInt32(comBoBox_SerialPort.Text));
            }
            else
            {
                _adam = new ADAM(comBoBox_SerialNames.Text);
            }
            _adam.Connect();
            ///*************************************//

            //禁用串口操作，启动端子口操作
            groupBox_SerialSetting.IsEnabled = false;
            groupBox_ASettinf.IsEnabled = true;
            groupBox_DSetting.IsEnabled = true;


            _getTextBoxValue = new GetTextBoxValue();
            _getTextBoxValue.Start();

            _getAValue = new GetAValue(_adam, _getTextBoxValue.GetPort);//在方法里判断为了null

            _getAValue.TextBlock0 = textBlock_DataShow_A_0;
            _getAValue.TextBlock1 = textBlock_DataShow_A_1;
            _getAValue.TextBlock2 = textBlock_DataShow_A_2;

            _getAValue.Start();
        }

        //private ADPort getPort()
        //{

        //}

        /// <summary>
        /// 数字量开光控制方法--开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClick_SwitchOpen(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (_getTextBoxValue == null)
            {
                MessageBox.Show("error!!!");
                return;
            }
            ADPort port = _getTextBoxValue.GetPort;

            if (btn.Name == btn_SwitchOpen_D_0.Name)
            {
                if (fun(port.DPort.GetPort0))
                {
                    btn_SwitchClose_D_0.IsEnabled = true;
                    btn_SwitchOpen_D_0.IsEnabled = false;
                    new SwitchOpen(_adam, (int)port.DPort.GetPort0);
                }
            }
            if (btn.Name == btn_SwitchOpen_D_1.Name)
            {
                if (fun(port.DPort.GetPort1))
                {
                    btn_SwitchClose_D_1.IsEnabled = true;
                    btn_SwitchOpen_D_1.IsEnabled = false;
                    new SwitchOpen(_adam, (int)port.DPort.GetPort1);
                }
            }
            if (btn.Name == btn_SwitchOpen_D_2.Name)
            {
                if (fun(port.DPort.GetPort2))
                {
                    btn_SwitchClose_D_2.IsEnabled = true;
                    btn_SwitchOpen_D_2.IsEnabled = false;
                    new SwitchOpen(_adam, (int)port.DPort.GetPort2);
                }
            }

            //内嵌方法
            bool fun(int? data)
            {
                if (data != null)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("值无效");
                    return false;
                }
            }
        }
        /// <summary>
        /// 数字量开光控制方法--关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClick_SwitchClose(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (_getTextBoxValue == null)
            {
                MessageBox.Show("error!!!");
                return;
            }
            ADPort port = _getTextBoxValue.GetPort;

            if (btn.Name == btn_SwitchClose_D_0.Name)
            {
                if (fun(port.DPort.GetPort0))
                {
                    btn_SwitchClose_D_0.IsEnabled = false;
                    btn_SwitchOpen_D_0.IsEnabled = true;
                    new SwitchClose(_adam, (int)port.DPort.GetPort0);
                }
            }
            if (btn.Name == btn_SwitchClose_D_1.Name)
            {
                if (fun(port.DPort.GetPort1))
                {
                    btn_SwitchClose_D_1.IsEnabled = false;
                    btn_SwitchOpen_D_1.IsEnabled = true;
                    new SwitchClose(_adam, (int)port.DPort.GetPort1);
                }
            }
            if (btn.Name == btn_SwitchClose_D_2.Name)
            {
                if (fun(port.DPort.GetPort2))
                {
                    btn_SwitchClose_D_2.IsEnabled = false;
                    btn_SwitchOpen_D_2.IsEnabled = true;
                    new SwitchClose(_adam, (int)port.DPort.GetPort2);
                }
            }

            //内嵌方法
            bool fun(int? data)
            {
                if (data != null)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("值无效");
                    return false;
                }
            }
        }
    }
}
