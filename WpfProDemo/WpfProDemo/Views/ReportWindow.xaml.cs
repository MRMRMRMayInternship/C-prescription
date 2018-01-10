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
using System.Windows.Shapes;

namespace WpfProDemo.Views
{
    /// <summary>
    /// ReportWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow()
        {
            InitializeComponent();
            this.Closed += ReportWindow_Closed;
        }
        public void LoadData(string prescriptionID){
            this.ReportViewer.PrescriptionID = prescriptionID;
        }
        private void ReportWindow_Closed(object sender, EventArgs e)
        {
            //this.ReportViewer._reportViewer.DataBindings.Clear();
            //this.ReportViewer._reportViewer.Clear();
            //this.ReportViewer._reportViewer.Dispose();
        }
    }
}
