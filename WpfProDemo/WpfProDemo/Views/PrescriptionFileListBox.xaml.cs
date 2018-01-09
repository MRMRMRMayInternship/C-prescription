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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
namespace WpfProDemo.Views
{
    public delegate void LoadCompletedEvent();
    public delegate void LoadProgressChangedEvent(int value);
    public delegate void LoadStartedEvent(int total);
    /// <summary>
    /// PrescriptionFileListBox.xaml에 대한 상호 작용 논리
    /// 参考资料：https://www.lookmw.cn/doc/uejyni.html
    /// </summary>
    public partial class PrescriptionFileListBox : UserControl
    {
        public LoadCompletedEvent loadCompletedAction;
        public LoadProgressChangedEvent loadProgressChangedAction;
        public LoadStartedEvent loadStartedAction;
        private BackgroundWorker worker = new BackgroundWorker();
        private ObservableCollection<PrescriptionFileInfoListItemModel> _ListBoxItems;
        private List<PrescriptionFileInfoListItemModel> updateList;
        private ObservableCollection<PrescriptionFileInfoListItemModel> ListBoxItems
        {
            get
            {
                return _ListBoxItems;
            }
            set
            {
                _ListBoxItems = value;
            }
        }
        public PrescriptionFileListBox()
        {
            InitializeComponent();
            _ListBoxItems =  new ObservableCollection<PrescriptionFileInfoListItemModel>();
            this.Loaded += PrescriptionFileListBox_Loaded;
        }

        private void PrescriptionFileListBox_Loaded(object sender, RoutedEventArgs e)
        {
            PrescriptionListBox.ItemsSource = _ListBoxItems;
            PrescriptionListBox.MouseDoubleClick += PrescriptionListBox_MouseDoubleClick;
            

            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(pListLoaderWorker);
            worker.ProgressChanged += pListLoadProgressChanged_Handler;
            worker.RunWorkerCompleted += pListLoadCompleted_Handler;
        }

        private void PrescriptionListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var str = e.Device.Target.GetType().ToString();
                MessageBox.Show(str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 完成罗列储存在本地硬盘的处方文件到listbox控件后所执行的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pListLoadCompleted_Handler(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Complete Loading");
            loadCompletedAction();
            
            //PrescriptionFileListLoadingProgressMaskLayer.Visibility = System.Windows.Visibility.Collapsed;
        }
        /// <summary>
        /// 进度返回处理:当载入进度发生变化时，通过更新绑定对象的值来更新界面中的载入提示文字。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pListLoadProgressChanged_Handler(object sender, ProgressChangedEventArgs e)
        {
            //loadingProgressValue.ProgressValue_Changed(e.ProgressPercentage);
            loadProgressChangedAction(e.ProgressPercentage);
        }
        /// <summary>
        /// 业务逻辑处理:执行载入文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pListLoaderWorker(object sender, DoWorkEventArgs e)
        {
            //获得处方文件数量
            int total = 10;
            //loadingProgressValue.TotalValue = total;
            //loadingProgressValue.DoingValue = 1;
            loadStartedAction(total);
            try
            {
                updateList = new List<PrescriptionFileInfoListItemModel>();
                for (int i = 1; i <= total; i++)
                {
                    var temp = new PrescriptionFileInfoListItemModel() { PrescriptionID = "123", PatientName = "123", CreationDate = "123" };
                    //直接修改source也等于直接修改UI，从而导致异常。解决方案就是使用调解委托。
                    Dispatcher.Invoke(new Action(() =>
                    {
                        ListBoxItems.Add(temp);
                    }));
                    worker.ReportProgress(i);
                    System.Threading.Thread.Sleep(100);
                }
                //this.PrescriptionListBox.ItemsSource = _ListBoxItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void RunWorker()
        {
            worker.RunWorkerAsync();
        }

        public void InitializeListBoxItem()
        {
            System.Collections.ObjectModel.ObservableCollection<PrescriptionFileInfoListItemModel> listBoxItems = new System.Collections.ObjectModel.ObservableCollection<PrescriptionFileInfoListItemModel>(){
            new PrescriptionFileInfoListItemModel(){PrescriptionID="123",PatientName="123",CreationDate="123"},
            new PrescriptionFileInfoListItemModel(){PrescriptionID="123",PatientName="123",CreationDate="123"},
            new PrescriptionFileInfoListItemModel(){PrescriptionID="123",PatientName="123",CreationDate="123"}
            };
            this.PrescriptionListBox.ItemsSource = listBoxItems;
        }
    }
    public class PrescriptionFileInfoListItemModel
    {
        public string PrescriptionID { get; set; }
        public string PatientName { get; set; }
        public string CreationDate { get; set; }
    }

}
