using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSPrescriptionInterfaceProgramBate001.Views
{
    public delegate void LoadPrescriptionAction(Models.PrescriptionClass obj);
    public partial class PrescriptionFileListForm : Form
    {
        public LoadPrescriptionAction LoadPrescriptionEvent;
        private readonly string dirpath;
        private readonly string[] fileList;
        private List<Models.PrescriptionClass> prescriptionList;
        
        public PrescriptionFileListForm()
        {
            InitializeComponent();
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            dirpath = config.AppSettings.Settings["prescriptionPath"].Value;
            fileList = System.IO.Directory.GetFiles(dirpath);
            LoadingPrescriptionFiles();
            InitializeFileListView();
        }
        private void LoadingPrescriptionFiles()
        {
            prescriptionList = new List<Models.PrescriptionClass>();
            foreach (string file in fileList)
            {
                Models.PrescriptionClass obj = DAO.XmlSerializer.LoadFromXml(file, typeof(Models.PrescriptionClass)) as Models.PrescriptionClass;
                prescriptionList.Add(obj);
            }
        }
        private ListViewItem CreateViewItemByClass(Models.PrescriptionClass sourceObj)
        {
            ListViewItem newItem = new ListViewItem();
            newItem.SubItems.Clear();
            newItem.SubItems[0].Text = sourceObj.PrescriptionID;
            newItem.SubItems.Add(sourceObj.Patient.Name);
            newItem.SubItems.Add(sourceObj.Date);
            return newItem;
        }
        private void InitializeFileListView()
        {
            foreach (Models.PrescriptionClass prescription in prescriptionList)
            {
                this.fileListView.Items.Add(CreateViewItemByClass(prescription));
            }
        }
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (this.fileListView.SelectedItems.Count > 0)
            {
                int index = this.fileListView.SelectedIndices[0];
                LoadPrescriptionEvent(prescriptionList[index]);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
