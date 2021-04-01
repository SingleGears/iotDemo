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
using System.Windows.Shapes;

using IotDemo.Data;
using IotDemo.Model;

namespace IotDemo.Windows
{
    /// <summary>
    /// AddAnalog.xaml 的交互逻辑
    /// </summary>
    public partial class AddAnalog : Window
    {
        AnalogConfigModel _data;
        public AddAnalog(AnalogConfigModel model)
        {
            _data = model;
            InitializeComponent();

            //加载显示的资源，资源有对应的枚举，在AppDate类注册
            foreach (var i in AppData._HelperModeContext)
                comboBox_HelperMode.Items.Add(i.Key);
            foreach (var i in AppData._DecisionModeContext)
                comboBox_Decision.Items.Add(i.Key);
        }
        /// <summary>
        /// 返回模型
        /// </summary>
        public AnalogConfigModel GetMode { get; }
        private void btn_Close(object sender, RoutedEventArgs e)
        {
            _data = null;
            this.DialogResult = false;
            Close();
        }

        private void btn_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                _data.ID = Guid.NewGuid();                                              //生成唯一ID
                _data.Port = isMore(Convert.ToUInt32(txt_Port.Text));                   //数据接口
                _data.Name = comboBox_HelperMode.Text;                                  //传感器名
                _data.Helper = AppData._HelperModeContext[comboBox_HelperMode.Text];    //换算类型
                _data.Decision = AppData._DecisionModeContext[comboBox_Decision.Text];  //逻辑判断
                _data.MaxValue = Convert.ToInt32(txt_Max.Text);                         //最大值
                _data.MinValue = Convert.ToInt32(txt_Min.Text);                         //最小值
                this.DialogResult = true;
                Close();
            }
            catch(Exception exc) 
            {
                MessageBox.Show(exc.Message);
            }
        }
        private uint isMore(uint port)
        {
            if (port > 7)
                throw new Exception(nameof(isMore) + "Port More,Port: 0~7");
            else
                return port;
        }
    }
}
