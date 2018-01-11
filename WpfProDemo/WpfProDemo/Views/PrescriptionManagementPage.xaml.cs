using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
    /// GridData操作参考： http://blog.csdn.net/lanshengsheng2012/article/details/16938229
    /// DataBinding : http://blog.csdn.net/mao_mao37/article/details/51242249
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
        /// 载入文件信息通过处方ID
        /// </summary>
        /// <param name="prescriptonID"></param>
        private void LoadFileInfoAction(string prescriptonID)
        {
            try
            {
                Models.PrescriptionClass obj = StaticMethod.PrescriptionListManagement.PrescriptionList.Where(a => a.PrescriptionID.Equals(prescriptonID)).First();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.StackTrace + "\n" + e.Message);
            }
        }
        /// <summary>
        /// 委托:开始载入文件立标
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
            this.PrescriptionListBox.ListItem_DoubleClickedAction += pListItem_DoubleClicked_Handler;
            this.PrescriptionListBox.LoadFileInfoBtn.Click += LoadFileInfoBtn_Click;
            this.PrescriptionListBox.SetMaskLay += SetMaskLayerVisible;
            InitializePrescriptionInfoBlock();
            this.pListBoxMask.FileLoadLinkAction += FileLoadAction;
            pListBoxMask.Visibility = System.Windows.Visibility.Visible;

            this.btnMenu.Click += btnMenu_Click;
        }

        void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            parentWindow.CallMenuPage();
        }
        private void SetMaskLayerVisible(Visibility setting)
        {
            if (this.PrescriptionFileListLoadingProgressMaskLayer.Visibility != setting)
                this.PrescriptionFileListLoadingProgressMaskLayer.Visibility = setting;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void LoadFileInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadFileToInfomationBlockAction((this.PrescriptionListBox.PrescriptionListBox.SelectedItem as PrescriptionFileInfoListItemModel).PrescriptionID);
        }
        /// <summary>
        /// 初始化处方信息区块
        /// </summary>
        private PatientInfoOfPrescription patientInfoSource;
        //private System.Collections.ObjectModel.ObservableCollection<PIPusingWPFModel.Drug> drugsList;
        private void InitializePrescriptionInfoBlock()
        {
            
            patientInfoSource = new PatientInfoOfPrescription(){};
            //drugsList = new System.Collections.ObjectModel.ObservableCollection<PIPusingWPFModel.Drug>();
            this.MyPrescriptionInfoBlock.DiagnosisLabel.IsEnabled = false;
            this.MyPrescriptionInfoBlock.PatientAgeLabel.SetBinding(Label.ContentProperty, new Binding(PatientInfoOfPrescription.PatientAgeBindingPath) { Source = patientInfoSource, Mode = BindingMode.OneWay});
            this.MyPrescriptionInfoBlock.PatientNameLabel.SetBinding(Label.ContentProperty, new Binding(PatientInfoOfPrescription.PatientNameBindingPath) { Source = patientInfoSource, Mode = BindingMode.OneWay });
            this.MyPrescriptionInfoBlock.PatientIdLabel.SetBinding(Label.ContentProperty, new Binding(PatientInfoOfPrescription.PatientIDBindingPath) { Source = patientInfoSource, Mode = BindingMode.OneWay });
            this.MyPrescriptionInfoBlock.PatientSexLabel.SetBinding(Label.ContentProperty, new Binding(PatientInfoOfPrescription.PatientSexBindingPath) { Source = patientInfoSource, Mode = BindingMode.OneWay });
            this.MyPrescriptionInfoBlock.DiagnosisLabel.SetBinding(TextBox.TextProperty, new Binding(PatientInfoOfPrescription.DiagnosisBindingPath) { Source = patientInfoSource, Mode = BindingMode.OneWay });
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prescriptionID"></param>
        private void LoadFileToInfomationBlockAction(string prescriptionID)
        {
            var result = StaticMethod.PrescriptionListManagement.PrescriptionList.Where(a => a.PrescriptionID.Equals(prescriptionID)).First();
            patientInfoSource.PatientName = result.Patient.Name;
            patientInfoSource.PatientID = result.Patient.PatientID;
            patientInfoSource.PatientSex = result.Patient.Sex;
            patientInfoSource.PatientAge = result.Patient.Age;
            patientInfoSource.Diagnosis = result.Patient.SymptomDescription;
            this.MyPrescriptionInfoBlock.PrescriptionIDLabel.Content = prescriptionID;
            using (PIPusingWPFModel.PIPEntities conn = new PIPusingWPFModel.PIPEntities())
            {
                try
                {
                    var queryDrugsList = conn.Drugs.Where(drug => drug.PrescriptionId.Equals(prescriptionID)).ToList();
                    this.MyPrescriptionInfoBlock.DrugsDataGrid.ItemsSource = queryDrugsList;
                }
                catch (Exception e)
                {
                    MessageBox.Show(string.Format("{0} : {1}", e.Message, e.StackTrace));
                }
            }
            MessageBox.Show("Loading ...:");
        }
        /// <summary>
        /// 双击表项目载入文件信息
        /// </summary>
        /// <param name="prescriptionID"></param>
        private void pListItem_DoubleClicked_Handler(string prescriptionID)
        {
            LoadFileToInfomationBlockAction(prescriptionID);
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
        ///// <summary>
        ///// 生成报表
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnReportCreation_Clicked(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        string selectedID = (this.PrescriptionListBox.PrescriptionListBox.SelectedItem as PrescriptionFileInfoListItemModel).PrescriptionID;
        //        SaveInDB(StaticMethod.PrescriptionListManagement.PrescriptionList.Find(a => a.PrescriptionID.Equals(selectedID)));
        //        Views.ReportWindow reportWin = new Views.ReportWindow();
        //        reportWin.LoadData(selectedID);
        //        reportWin.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("btnReport: " + ex.Message);
        //    }
        //}
        /// <summary>
        /// 载入文件按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Clicked(object sender, RoutedEventArgs e)
        {
            
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
