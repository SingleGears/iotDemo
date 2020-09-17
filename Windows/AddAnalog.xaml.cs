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

namespace IotDemo.Windows
{
    /// <summary>
    /// AddAnalog.xaml 的交互逻辑
    /// </summary>
    public partial class AddAnalog : Window
    {
        readonly string[] _helperModeContext =
        {
            "温度",
            "湿度",
            "光照",
            "风速",
            "水位",
            "水温",
            "二氧化碳",
            "大气压强",
            "空气质量",
            "土壤温度",
            "土壤湿度"
        };
        readonly string[] _decisionModeContext =
        {
            "禁用",
            "大于",
            "小于",
            "范围"
        };
        public AddAnalog()
        {
            InitializeComponent();


            foreach (var i in _helperModeContext)
                comboBox_HelperMode.Items.Add(i);
            foreach (var i in _decisionModeContext)
                comboBox_Decision.Items.Add(i);
        }
    }
}
