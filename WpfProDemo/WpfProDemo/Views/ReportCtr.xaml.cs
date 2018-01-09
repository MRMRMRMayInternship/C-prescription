using Microsoft.Reporting.WinForms;
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
    /// ReportCtr.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ReportCtr : UserControl
    {
        BackgroundWorker work = new BackgroundWorker();
        public ReportCtr()
        {
            InitializeComponent();
            work.WorkerReportsProgress = true;
            work.WorkerSupportsCancellation = true;
            work.DoWork += DoWork_handle;
            work.ProgressChanged += ProgressChanged_Handler;
            work.RunWorkerCompleted += RunWorkerCompleted_Handler;
            this.Loaded += ReportCtr_Loaded;
            this._reportViewer.RenderingComplete += this.PrescriptionReportViewer_RenderingComplete;
        }

        private void RunWorkerCompleted_Handler(object sender, RunWorkerCompletedEventArgs e)
        {
            maskLayer.Visibility = Visibility.Collapsed;
        }

        private void ProgressChanged_Handler(object sender, ProgressChangedEventArgs e)
        {
            //注意在Dowork函数中要使用 backgroundworker对象.ReportProgress(进度数值)
            //set prograss bar value = e.ProgressPercentage;
        }

        private void DoWork_handle(object sender, DoWorkEventArgs e)
        {
            //1. Query Data object
            System.Data.DataTable dt = new System.Data.DataTable();
            using (PIPusingWPFModel.PIPEntities conn = new PIPusingWPFModel.PIPEntities())
            {
                var result = conn.Drugs.Where(a => a.PrescriptionId.Equals("1")).ToList();
                dt = DAO.ToDataTable.ToDataTableMethod(result);
            }
            //2. Load Data into report
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSource.Name = "DrugDataSet";
            reportDataSource.Value = dt;
            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            _reportViewer.LocalReport.ReportPath = config.AppSettings.Settings["reportPath"].Value;
            _reportViewer.LocalReport.DataSources.Add(reportDataSource);
            _reportViewer.RefreshReport();
            //3. show report
        }
        
        private void ReportCtr_Loaded(object sender, RoutedEventArgs e)
        {
            maskLayer.Visibility = Visibility.Visible;
            if (!work.IsBusy)
                work.RunWorkerAsync();//run the work
        }
        private void PrescriptionReportViewer_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e)
        {
            //maskLayer.Visibility = Visibility.Collapsed;
        }
    }
}
