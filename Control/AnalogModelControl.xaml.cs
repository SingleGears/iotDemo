using IotDemo.Model;
using IotDemo.Serial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
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

namespace IotDemo.Control {
    /// <summary>
    /// 用户控件的唯一ID
    /// </summary>
    /// <param name="id"></param>
    public delegate void DestroyHelper(Guid id);
    /// <summary>
    /// AnalogModelControl.xaml 的交互逻辑
    /// </summary>
    public partial class AnalogModelControl : UserControl {

        public event DestroyHelper DestroyEvent;
        public AnalogModelControl(BackData back, AnalogConfigModel model) {
            this._model = model;
            this._backData = back;
            InitializeComponent();
            _backData.Timer.Add(GetValue);
            text_id.Text = model.Name;
            text_port.Text = model.Port.ToString();
        }
        /// <summary>
        /// 插入计时器处理事件的实现代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="byteData"></param>
        private void GetValue(object sender, byte[] byteData) {
            var data = _backData.Adam.GetData(byteData, (int)_model.Port);
            var value = HalperConverter.ADAMConvertValue(data, _model.Helper);
            text_value.Text = value.ToString("f2");
        }
        /// <summary>
        /// 销毁用户控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Destroy(object sender, RoutedEventArgs e) {
            if (DestroyEvent != null) {
                _backData.Timer.Remove(GetValue);
                DestroyEvent.Invoke(_model.ID);
            }
        }
        private readonly AnalogConfigModel _model;
        private readonly BackData _backData;
    }
}
