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
using System.Windows.Automation.Peers;
namespace version1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addUserControl(object sender, RoutedEventArgs e)
        {
            Demo demo = new Demo();
            this.controlContent.Children.Add(demo);
        }

        private void removeUserControl(object sender, RoutedEventArgs e)
        {
            // 现在尝试获得容器gird里面查找是否已经有一个我们生成的control
            #region 这里使用foreach是错误的，因为删除控件后会导致枚举结果错误
            //foreach(var child in controlContent.Children)
            //{
            //    if (child.GetType()==typeof(Demo))
            //    {
            //        Demo demo = new Demo();
            //        demo = (Demo)child;
            //        this.controlContent.Children.Remove(demo);
            //    }
            //}
            #endregion
             
            #region 完成了最简单的界面卸载功能
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(controlContent); i++)
            {
                var child = VisualTreeHelper.GetChild(controlContent, i);
                if (child.GetType() == typeof(Demo))
                {
                    controlContent.Children.Remove((Demo)child);
                }
            }
            #endregion
        }

        /// <summary>
        ///把我们需要的控件进行悬浮处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void floatUserControl(object sender, RoutedEventArgs e)
        {
            Demo demo = new Demo();

            #region 通过把UserControl添加到window的操作完成悬浮的操作？？
            // 后期可以考虑使用线程完成同步进行
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(controlContent); i++)
            {
                var child = VisualTreeHelper.GetChild(controlContent, i);
                if (child.GetType() == typeof(Demo))
                {
                    demo = (Demo)child;
                    controlContent.Children.Remove((Demo)child);
                    Manage manage = new Manage();
                    manage.manage.Children.Add(demo);
                    manage.Show();
                }
            }
            #endregion
        }
    }

}