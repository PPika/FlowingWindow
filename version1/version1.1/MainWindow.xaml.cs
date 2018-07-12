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

namespace version1._1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        UC uc;
        private int i = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 通过按钮点击完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// 1——创建一个新的item
        /// 2——将item添加到tabcontrol中
        /// 3——将usercontrol添加到item中
        /// 4——设置item的各种参数
        /// </remarks>
        private void bt_Click(object sender, RoutedEventArgs e)
        {
            TabItem tabItem = new TabItem();
            tabItem.Header ="ti"+i.ToString();
            tab.Items.Add(tabItem);
            uc = new UC();
            uc.box.Text = i.ToString();
            tabItem.Content = uc;
            tab.SelectedIndex = i+1;
            i++;
            tabItem.MouseDoubleClick += TabItem_MouseDoubleClick;

        }

        private void TabItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           
            TabItem s = (TabItem)sender;
            Manage manage = new Manage();
            UC uC = new UC();
            uC = (UC)s.Content;
            tab.Items.Remove(s);
            if (uC.Parent != null) uC.Parent.SetValue(ContentPresenter.ContentProperty, null);
            manage.manage.Children.Add(uC);
            manage.Show();
            

        }


    }
}
