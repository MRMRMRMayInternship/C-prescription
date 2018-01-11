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
    public delegate void ListItem_DoubleClickedEvent(string selectedItemID);
    public delegate void LoadEvent();
    public delegate void SetMaskLayAction(System.Windows.Visibility setting);
    /// <summary>
    /// PrescriptionFileListBox.xaml에 대한 상호 작용 논리
    /// 参考资料：https://www.lookmw.cn/doc/uejyni.html
    /// </summary>
    public partial class PrescriptionFileListBox : UserControl
    {
        public LoadCompletedEvent loadCompletedAction;
        public LoadProgressChangedEvent loadProgressChangedAction;
        public LoadStartedEvent loadStartedAction;
        public ListItem_DoubleClickedEvent ListItem_DoubleClickedAction;
        public LoadEvent LoadCancelAction;
        public SetMaskLayAction SetMaskLay;
        private BackgroundWorker worker = new BackgroundWorker();
        private ObservableCollection<PrescriptionFileInfoListItemModel> _ListBoxItems;
        private List<PrescriptionFileInfoListItemModel> updateList;
        private string selectedItemID;
        private string path;
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
            this.Loaded += PrescriptionFileListBox_Loaded;
        }
        /// <summary>
        /// 控件载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrescriptionFileListBox_Loaded(object sender, RoutedEventArgs e)
        {
            PrescriptionListBox.PreviewMouseDoubleClick += PrescriptionListBox_PreviewMouseDoubleClick;
            MySearchButton.SearchButton.Click += SearchBtn_Clicked;
            SearchTextBoxClearBtn.Click += SearchTextBoxClearBtn_Click;
            MyUpdateButton.UpdateBtn.Click += UpdateBtn_Click;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(pListLoaderWorker);
            worker.ProgressChanged += pListLoadProgressChanged_Handler;
            worker.RunWorkerCompleted += pListLoadCompleted_Handler;
        }

        void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            RunWorker();
        }
        /// <summary>
        /// 清理搜索框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBoxClearBtn_Click(object sender, RoutedEventArgs e)
        {
            this.SearchTextBox.Clear();
            PrescriptionListBox.ItemsSource = _ListBoxItems;
        }
        /// <summary>
        /// 搜索功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void SearchBtn_Clicked(object sender, RoutedEventArgs args)
        {
            try
            {
                var input = this.SearchTextBox.Text;
                var result = string.IsNullOrWhiteSpace(input) ? 
                    _ListBoxItems.ToList() : 
                    _ListBoxItems.Where(obj=>obj.PatientName.ToUpper().Contains(input) || 
                        obj.PatientName.ToLower().Contains(input) 
                        ).ToList();
                if(result.Count <= 0); //出现遮蔽层
                PrescriptionListBox.ItemsSource = result;
            }
            catch (Exception e)
            {
                MessageBox.Show("SearchBtn: " + e.Message);
            }
        }
        private void PrescriptionListBox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                selectedItemID = (this.PrescriptionListBox.SelectedItem as PrescriptionFileInfoListItemModel).PrescriptionID;
                
                //string pID = selectedItem.PrescriptionID;
                if (MessageBox.Show(selectedItemID, "Double Selecting", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                    ListItem_DoubleClickedAction(selectedItemID);
                }
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

            PrescriptionListBox.ItemsSource = _ListBoxItems;
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
            List<string> fList = System.IO.Directory.GetFiles(@path).ToList();
            int total = fList.Count();
            string msg = total <= 0 ? "There is no file" : string.Empty;
            
            if (!string.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg);
                worker.CancelAsync();
                //this.LoadCancelAction();
                return;
            }

            //loadingProgressValue.TotalValue = total;
            //loadingProgressValue.DoingValue = 1;
            loadStartedAction(total);

            Dispatcher.Invoke(new Action(() =>
            {
                SetMaskLay(System.Windows.Visibility.Visible);
            }));
            try
            {
                updateList = new List<PrescriptionFileInfoListItemModel>();
                for (int i = 1; i <= total; i++)
                {
                    Models.PrescriptionClass prescription = DAO.XmlSerializer.LoadFromXml(fList[i - 1], typeof(Models.PrescriptionClass)) as Models.PrescriptionClass;
                    var temp = new PrescriptionFileInfoListItemModel() { PrescriptionID = prescription.PrescriptionID, PatientName = prescription.Patient.Name, CreationDate = prescription.Date };
                    //直接修改source也等于直接修改UI，从而导致异常。解决方案就是使用调解委托。
                    //第一次是全部载入进静态链表
                    if (!StaticMethod.PrescriptionListManagement.PrescriptionList.Contains(prescription))
                    {
                        StaticMethod.PrescriptionListManagement.PrescriptionList.Add(prescription);
                        DAO.PrescriptionDBHandle.SaveInDB(prescription);
                    }
                    if (ListBoxItems.Where(obj=>obj.CreationDate.Equals(temp.CreationDate)).FirstOrDefault()==null)
                    {
                        Dispatcher.Invoke(new Action(() =>
                        {
                            ListBoxItems.Add(temp);
                        }));
                    }
                    worker.ReportProgress(i);
                    System.Threading.Thread.Sleep(100);
                }
                //this.PrescriptionListBox.ItemsSource = _ListBoxItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show("pListLoaderWorker : "+ex.Message);
            }
        }

        public void RunWorker()
        {
            _ListBoxItems = new ObservableCollection<PrescriptionFileInfoListItemModel>();
            path = StaticMethod.ConfigManagement.GetConfigValue(StaticMethod.ConfigManagement.ConfigSettingPIPFilesPathKey);
            string msg = System.IO.Directory.Exists(path) ? string.Empty : "There is no dir";
            if (!string.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg);
                return;
            }
            worker.RunWorkerAsync();
        }

        //public void InitializeListBoxItem()
        //{
        //    System.Collections.ObjectModel.ObservableCollection<PrescriptionFileInfoListItemModel> listBoxItems = new System.Collections.ObjectModel.ObservableCollection<PrescriptionFileInfoListItemModel>(){
        //    new PrescriptionFileInfoListItemModel(){PrescriptionID="123",PatientName="123",CreationDate="123"},
        //    new PrescriptionFileInfoListItemModel(){PrescriptionID="123",PatientName="123",CreationDate="123"},
        //    new PrescriptionFileInfoListItemModel(){PrescriptionID="123",PatientName="123",CreationDate="123"}
        //    };
        //    this.PrescriptionListBox.ItemsSource = listBoxItems;
        //}
    }
    public class PrescriptionFileInfoListItemModel
    {
        public string PrescriptionID { get; set; }
        public string PatientName { get; set; }
        public string CreationDate { get; set; }
    }

}
