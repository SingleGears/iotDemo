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

using IotDemo.Service;
using IotDemo.Model;
using IotDemo.Windows;
using IotDemo.Control;
using IotDemo.Serial;

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
            _adam = new ADAM(
                comBoBox_SerialNames.Text,
                Convert.ToInt32(comBoBox_SerialPort));
            _adam.Open();
            _data = new BackData(_adam);
        }
        /// <summary>
        /// 添加一个模拟量监听模块的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddAnalogControl(object sender, RoutedEventArgs e)
        {
            if (_adam != null)
            {
                var model = new AnalogConfigModel();
                AddAnalog win = new AddAnalog(ref model);
                win.ShowDialog();
                if (model != null)
                {
                    var control = new AnalogModelControl(_data,model);
                    control.DestroyEvent += DestroyAnalogControl;
                    view_AnalogContent.Children.Add(control);
                    _data._AnalogConfigModels.Add(model.ID, control);
                }
            }
            else
            {
                MessageBox.Show("请先打开串口");
            }
        }

        /// <summary>
        /// 销毁子控件委托事件
        /// </summary>
        /// <param name="id"></param>
        private void DestroyAnalogControl(Guid id)
        {
            UIElement obj;
            if (_data._AnalogConfigModels.TryGetValue(id, out obj))
            {
                view_AnalogContent.Children.Remove(obj);
                _data._AnalogConfigModels.Remove(id);
            }
        }

        private BackData _data = null;
        private ADAM _adam = null;
    }
}
