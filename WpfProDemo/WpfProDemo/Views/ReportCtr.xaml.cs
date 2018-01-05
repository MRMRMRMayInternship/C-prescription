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
    /// ReportCtr.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ReportCtr : UserControl
    {
        public ReportCtr()
        {
            InitializeComponent();
            this.Loaded += ReportCtr_Loaded;
            this._reportViewer.RenderingComplete += this.PrescriptionReportViewer_RenderingComplete;
        }
        private void ReportCtr_Loaded(object sender, RoutedEventArgs e)
        {
            maskLayer.Visibility = Visibility.Visible;
            //1. Query Data object
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("AccountId", typeof(string));
            dt.Columns.Add("AccountPw", typeof(string));

            System.Data.DataRow dr = dt.NewRow();
            dr["Id"] = 123123123;
            dr["AccountId"] = "Jon Skeet";
            dr["AccountPw"] = "72.0m";

            dt.Rows.Add(dr);
            //2. Load Data into report
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSource.Name = "AccountDataSet";
            reportDataSource.Value = dt;
            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            _reportViewer.LocalReport.ReportPath = config.AppSettings.Settings["reportPath"].Value;
            _reportViewer.LocalReport.DataSources.Add(reportDataSource);
            _reportViewer.RefreshReport();
            //3. show report
        }
        private void PrescriptionReportViewer_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e)
        {
            maskLayer.Visibility = Visibility.Collapsed;
        }
    }
}
