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
        private string _PrescriptionID;
        private System.Data.DataTable drugTable = new System.Data.DataTable();
        private System.Data.DataTable patientTable = new System.Data.DataTable();
        private System.Data.DataTable prescriptionTable = new System.Data.DataTable();
        private System.Data.DataTable doctorTable = new System.Data.DataTable();
        public string PrescriptionID
        {
            get
            {
                return _PrescriptionID;
            }
            set
            {
                _PrescriptionID = value;
            }
        }
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
        ~ReportCtr()
        {
            GC.SuppressFinalize(work);
            GC.SuppressFinalize(drugTable);
            GC.SuppressFinalize(patientTable);
            GC.SuppressFinalize(prescriptionTable);
            GC.SuppressFinalize(doctorTable);
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
            
            using (PIPusingWPFModel.PIPEntities conn = new PIPusingWPFModel.PIPEntities())
            {
                var prescriptionResult = conn.Prescriptions.Where(a => a.PrescriptionId.Equals(PrescriptionID)).First();
                prescriptionTable = DAO.ToDataTable.ToDataTableMethodForObject(prescriptionResult);
                var patientResult = conn.Patients.Where(a => a.PatientId.Equals(prescriptionResult.PatientId)).First();
                patientTable = DAO.ToDataTable.ToDataTableMethodForObject(patientResult);
                var doctorResult = conn.Doctors.Where(a => a.Did.Equals(prescriptionResult.Did)).First();
                doctorTable = DAO.ToDataTable.ToDataTableMethodForObject(doctorResult);
                var result = conn.Drugs.Where(a => a.PrescriptionId.Equals(PrescriptionID)).ToList();
                drugTable = DAO.ToDataTable.ToDataTableMethodForList(result);
            }
            
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSource.Name = "DrugsDataSet";
            reportDataSource.Value = drugTable;
            
            //2. Load Data into report
            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            _reportViewer.LocalReport.ReportPath = config.AppSettings.Settings["reportPath"].Value;
            
            //增加资源
            _reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource() { Name = "PatientDataSet", Value = patientTable });

            _reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource() { Name = "DoctorDataSet", Value = doctorTable });

            _reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource() { Name = "PrescriptionDataSet", Value = prescriptionTable });

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
