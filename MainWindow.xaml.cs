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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MyViewModel();            
        }


        private void Button_Click(object sender, RoutedEventArgs args)
        {
            // 这里可以获取textBox和myComboBox的值，并传递给Revit命令或保存到某个共享位置供Revit命令访问  
            MessageBox.Show("你好啊,wpf");
        }
    }
}