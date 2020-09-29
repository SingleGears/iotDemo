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
        public AddAnalog(ref AnalogConfigModel model)
        {
            _data = model;
            InitializeComponent();

            foreach (var i in AppData._HelperModeContext)
                comboBox_HelperMode.Items.Add(i.Key);
            foreach (var i in AppData._DecisionModeContext)
                comboBox_Decision.Items.Add(i.Key);
        }

        private void btn_Close(object sender, RoutedEventArgs e)
        {
            _data = null;
            Close();
        }

        private void btn_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                _data.ID = Guid.NewGuid();
                _data.Port = isMore(Convert.ToUInt32(txt_Port.Text));
                _data.Name = comboBox_HelperMode.Text;
                _data.Helper = AppData._HelperModeContext[comboBox_HelperMode.Text];
                _data.Decision = AppData._DecisionModeContext[comboBox_Decision.Text];
                _data.MaxValue = Convert.ToInt32(txt_Max.Text);
                _data.MinValue = Convert.ToInt32(txt_Min.Text);
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
