using Microsoft.Reporting.WinForms;
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
using System.Windows.Media.Animation;
using System.Globalization;
namespace WpfProDemo.Views
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// 改变按钮风格参考：
    /// 1. http://blog.csdn.net/yb305/article/details/43566083 WPF Button 鼠标移入、移除、选中状态的改变
    /// 2. http://blog.csdn.net/youqingyike/article/details/47276193 WPF C# Button 加载图片，背景图片
    /// 改变区域
    /// 1. https://msdn.microsoft.com/zh-cn/library/system.globalization.cultureinfo.aspx
    /// 2. CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-US"); https://www.cnblogs.com/Pickuper/articles/2058880.html
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 登陆界面实例
        /// </summary>
        private LoginPage loginpage;
        /// <summary>
        /// 处方管理实例
        /// </summary>
        private PrescriptionManagementPage pmPage;
        /// <summary>
        /// 菜单页面实例
        /// </summary>
        private MenuPage menuPage;
        /// <summary>
        /// 构造函数
        /// </summary>
        public MainWindow()
        {
            
            InitializeComponent();
            //InitializePages();
            this.Loaded += MainWindow_Loaded;
            this.Closed += MainWindow_Closed;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
        }
        //private void InitializePages(){
        //    loginpage = new LoginPage();
        //    loginpage.ParentWindow = this;
        //    pmPage = new PrescriptionManagementPage();
        //    pmPage.ParentWindow = this;
        //    menuPage = new MenuPage();
        //    menuPage.ParentWindow = this;
        //}
        /// <summary>
        /// 主窗口渲染事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e){
            myFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            CallLoginPage();
            this.MyTitleBar.BtnExit.Click += ExitBtn_Clicked;
            this.MyTitleBar.MouseLeftButtonDown += WindowMove;
            this.MyTitleBar.MouseEnter += TitleBar_MouseEnterArea;
            this.MyTitleBar.MouseLeave += this.MouseLeaveArea;

        }
        /// <summary>
        /// 拖动鼠标移动窗口
        /// 参考： http://blog.csdn.net/zjcxhswill/article/details/38646525
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowMove(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        /// <summary>
        /// 鼠标移入标题栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void TitleBar_MouseEnterArea(object sender, RoutedEventArgs args)
        {
            StatBarText.Text = "Title Bar Area";
        }
        /// <summary>
        /// 鼠标移入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void MouseEnterExitArea(object sender, RoutedEventArgs args)
        {
            StatBarText.Text = "Exit the Application";
        }
        /// <summary>
        /// 鼠标移入工具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void MouseEnterToolsHintsArea(object sender, RoutedEventArgs args)
        {
            StatBarText.Text = "Show Spelling Suggestions";
        }
        /// <summary>
        /// 鼠标移出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void MouseLeaveArea(object sender, RoutedEventArgs args)
        {
            StatBarText.Text = "Ready";
        }
        /// <summary>
        /// 转入登陆页面
        /// </summary>
        public void CallLoginPage()
        {
            this.myFrame.Content = new LoginPage() { ParentWindow = this};
        }
        /// <summary>
        /// 转入处方管理页面
        /// </summary>
        public void CallPrescriptionManagementPage()
        {
            this.myFrame.Content = new PrescriptionManagementPage() { ParentWindow = this };
        }
        /// <summary>
        /// 转入菜单页面
        /// </summary>
        public void CallMenuPage()
        {
            this.myFrame.Content = new MenuPage() { ParentWindow = this};
        }
        /// <summary>
        /// 退出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Clicked(object sender, RoutedEventArgs e)
        {
           this.Close();
        }
    }
}
