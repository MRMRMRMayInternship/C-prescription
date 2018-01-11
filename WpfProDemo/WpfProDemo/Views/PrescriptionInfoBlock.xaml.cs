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
namespace WpfProDemo.Views
{
    /// <summary>
    /// PrescriptionInfoBlock.xaml에 대한 상호 작용 논리
    /// WPF的DataGrid自动绑定数据库时最后的空列到底要怎么消除: https://zhidao.baidu.com/question/1927091204144099467.html
    /// WPF DataGrid 控件默认空白行无法显示 :http://blog.csdn.net/stephensuo/article/details/45001431
    /// wpf datagrid 的单元格内容超出列宽度 https://www.cnblogs.com/JohnnyBao/p/4864012.html
    /// </summary>
    public partial class PrescriptionInfoBlock : UserControl
    {
        public PrescriptionInfoBlock()
        {
            InitializeComponent(); 
            this.ReportBtn.Click += this.btnReportCreation_Clicked;
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
                string selectedID = this.PrescriptionIDLabel.Content as string;
                if (!selectedID.Contains("RX"))
                    throw new Exception("No item Selected");
                Views.ReportWindow reportWin = new Views.ReportWindow();
                reportWin.LoadData(selectedID);
                reportWin.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnReport: " + ex.Message);
            }
        }
    }
    public class PatientInfoOfPrescription : INotifyPropertyChanged
    {
        public const string PatientAgeBindingPath = "PatientAge";
        public const string PatientNameBindingPath = "PatientName";
        public const string PatientSexBindingPath = "PatientSex";
        public const string PatientIDBindingPath = "PatientID";
        public const string DiagnosisBindingPath = "Diagnosis";
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private string _PatientName = string.Empty;
        public string PatientName
        {
            get
            {
                return _PatientName;
            }
            set
            {
                _PatientName = value;
                RaisePropertyChanged(PatientNameBindingPath);
            }
        }
        private string _PatientAge = string.Empty;
        public string PatientAge
        {
            get
            {
                return _PatientAge;
            }
            set
            {
                _PatientAge = value;
                RaisePropertyChanged(PatientAgeBindingPath);
            }
        }
        private string _PatientSex = string.Empty;
        public string PatientSex
        {
            get
            {
                return _PatientSex;
            }
            set
            {
                _PatientSex = value;
                RaisePropertyChanged(PatientSexBindingPath);
            }
        }
        private string _PatientID = string.Empty;
        public string PatientID
        {
            get
            {
                return _PatientID;
            }
            set
            {
                _PatientID = value;
                RaisePropertyChanged(PatientIDBindingPath);
            }
        }
        private string _Diagnosis = string.Empty;
        public string Diagnosis
        {
            get
            {
                return _Diagnosis;
            }
            set
            {
                _Diagnosis = value;
                RaisePropertyChanged(DiagnosisBindingPath);
            }
        }
    }
}
