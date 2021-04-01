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

namespace IotDemo {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            //获取串口
            new GetSerialNames(comBoBox_SerialNames);
        }

        /// <summary>
        /// 重新获取serial names
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClick_RpeatGetSerialPort(object sender, RoutedEventArgs e) {
            new GetSerialNames(comBoBox_SerialNames);
        }

        /// <summary>
        /// 打开串口的事件方法，也是启动所有功能的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClick_OpenSerial(object sender, RoutedEventArgs e) {
            _adam = new ADAM(
                comBoBox_SerialNames.Text,              //串口
                Convert.ToInt32(comBoBox_SerialPort));  //波特率
            _adam.Open();                               //启动
            _data = new BackData(_adam);                //后台注册
        }
        /// <summary>
        /// 添加一个模拟量监听模块的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddAnalogControl(object sender, RoutedEventArgs e) {
            if (_adam != null) {
                var model = new AnalogConfigModel();
                //启动添加用户控件的窗口
                AddAnalog win = new AddAnalog(model);
                win.ShowDialog();
                model = win.GetMode;
                //将用户控件添加到串口中
                if (model != null) {
                    var control = new AnalogModelControl(_data, model);     //用户控件初始化
                    control.DestroyEvent += DestroyAnalogControl;           //注册销毁控件事件
                    view_AnalogContent.Children.Add(control);               //添加控件
                    _data.AnalogConfigModels.Add(model.ID, control);        //控件注册
                }
            }
            else {
                MessageBox.Show("请先打开串口");
            }
        }

        /// <summary>
        /// 销毁子控件委托事件
        /// </summary>
        /// <param name="id"></param>
        private void DestroyAnalogControl(Guid id) {
            UIElement obj;
            //获得用户控件
            if (_data.AnalogConfigModels.TryGetValue(id, out obj)) {    //根据唯一ID获得控件
                view_AnalogContent.Children.Remove(obj);                //删除控件
                _data.AnalogConfigModels.Remove(id);                    //控件注销
            }
        }

        private BackData _data = null;
        private ADAM _adam = null;
    }
}
