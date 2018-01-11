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

namespace WpfProDemo.Views
{
    /// <summary>
    /// TitleBar.xaml에 대한 상호 작용 논리
    /// DispatcherTimer: https://www.cnblogs.com/tonyqus/archive/2006/12/21/599334.html
    /// </summary>
    public partial class TitleBar : UserControl
    {
        private System.Windows.Threading.DispatcherTimer timer;
        public TitleBar()
        {
            InitializeComponent();
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            this.Loaded += TitleBar_Loaded;
        }

        private void TitleBar_Loaded(object sender, RoutedEventArgs e)
        {
        }
        private void timer_Tick(object sender, EventArgs args)
        {
            this.NowDate.Content = DateTime.Now.ToString();
        }
    }
}
