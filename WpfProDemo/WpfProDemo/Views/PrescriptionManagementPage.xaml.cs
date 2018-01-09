using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfProDemo.Views
{
    /// <summary>
    /// PrescriptionManagementPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PrescriptionManagementPage : Page
    {
        private MainWindow parentWindow;
        private Models.ViewModels.pListLoadingProgressView.LoadingProgressValue loadingProgressValue;
        public MainWindow ParentWindow
        {
            get
            {
                return this.parentWindow;
            }
            set
            {
                this.parentWindow = value;
            }
        }
        /// <summary>
        /// 构造器
        /// </summary>
        public PrescriptionManagementPage()
        {
            InitializeComponent();
            this.Loaded +=PrescriptionManagementPage_Loaded;
        }
        /// <summary>
        /// 委托:开始载入
        /// </summary>
        private void FileLoadAction()
        {
            this.PrescriptionFileListLoadingProgressMaskLayer.Visibility = System.Windows.Visibility.Visible;
            this.PrescriptionListBox.RunWorker();
        }
        /// <summary>
        /// 页面载入
        /// 初始化后台任务 ，绑定变量与控件，
        /// 赋予委托函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrescriptionManagementPage_Loaded(object sender, RoutedEventArgs e)
        {
            //pListBoxLoaderBackgroundWorker = new BackgroundWorker();
            loadingProgressValue = new Models.ViewModels.pListLoadingProgressView.LoadingProgressValue();
            PrescriptionFileListLoadingProgressMaskLayer.loadingProgressValueLabel.SetBinding(Label.ContentProperty, new Binding("ProgressValue") { Source = loadingProgressValue, Mode = BindingMode.TwoWay });
            PrescriptionFileListLoadingProgressMaskLayer.LoadingBar.SetBinding(ProgressBar.ValueProperty, new Binding("ProgressPercentValue") { Source = loadingProgressValue, Mode = BindingMode.TwoWay });
            this.PrescriptionListBox.loadCompletedAction += this.pListLoadCompleted_Handler;
            this.PrescriptionListBox.loadProgressChangedAction += this.pListLoadProgressChanged_Handler;
            this.PrescriptionListBox.loadStartedAction += this.pListLoaderWorker_Handler;
            this.pListBoxMask.FileLoadLinkAction += FileLoadAction;
        }
        /// <summary>
        /// 委托：完成罗列储存在本地硬盘的处方文件到listbox控件后所执行的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pListLoadCompleted_Handler()
        {
            PrescriptionFileListLoadingProgressMaskLayer.Visibility = System.Windows.Visibility.Collapsed;
        }
        /// <summary>
        /// 委托：当载入进度发生变化时，通过更新绑定对象的值来更新界面中的载入提示文字。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pListLoadProgressChanged_Handler(int value)
        {
            loadingProgressValue.ProgressValue_Changed(value);
        }
        /// <summary>
        /// 委托:执行载入文件时初始化进度对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pListLoaderWorker_Handler(int total)
        {
            loadingProgressValue.TotalValue = total;
            loadingProgressValue.DoingValue = 1;
        }
        private void btnExitApp_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                Uri uri = new System.Uri("LoginWindow.xaml", System.UriKind.Relative);
                MessageBox.Show("Test:" + uri.LocalPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnExit:" + ex.Message);
            }
            this.parentWindow.Close();
        }
        /// <summary>
        /// 生成报表结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrescriptionReportViewer_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e)
        {
        }
        /// <summary>
        /// 生成报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReportCreation_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                Views.ReportWindow reportWin = new Views.ReportWindow();
                reportWin.Owner = this.parentWindow;
                var i = reportWin.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnReport: " + ex.Message);
            }
        }
        /// <summary>
        /// 载入文件按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Clicked(object sender, RoutedEventArgs e)
        {
            
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
        private bool isSpinning = false;
        /// <summary>
        /// 鼠标移入转动按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSpinner_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!isSpinning)
            {
                isSpinning = true;
                DoubleAnimation dblAnim = new DoubleAnimation();
                dblAnim.Completed += (o, s) => { isSpinning = false; };
                dblAnim.From = 0;
                dblAnim.To = 360;
                RotateTransform rt = new RotateTransform();
                btnSpinner.RenderTransform = rt;
                rt.BeginAnimation(RotateTransform.AngleProperty, dblAnim);
            }
        }
        private void btnSpinner_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation dblAnim = new DoubleAnimation();
            dblAnim.From = 1.0;
            dblAnim.To = 0.0;
            btnSpinner.BeginAnimation(Button.OpacityMaskProperty, dblAnim);
        }
    }
}
