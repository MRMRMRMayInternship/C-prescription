using CSPrescriptionInterfaceProgramBate001.DAO;
using CSPrescriptionInterfaceProgramBate001.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSPrescriptionInterfaceProgramBate001.Views
{
    public delegate bool SendSelectResultDelegate(string value);
    public partial class DrugSearchForm : Form
    {
        public SendSelectResultDelegate SendSelectResult;
        public DrugSearchForm()
        {
            InitializeComponent();
            InitializeDrugsInfoList();
        }
        private void InitializeDrugsInfoListColumnHeaderText()
        {
            
        }
        private ListViewItem createListItemByClass(Models.DrugClass drug)
        {
            ListViewItem item = new ListViewItem();
            item.SubItems.Clear();
            item.SubItems[0].Text = drug.DrugName;
            item.SubItems.Add(drug.DrugID);
            item.SubItems.Add(drug.Price.ToString());
            item.SubItems.Add(drug.Creation);
            return item;
        }
        private void InitializeDrugsInfoList()
        {
            
            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            string drugsFilePath = config.AppSettings.Settings[@Models.CommonData.DefaultValuesSet.DrugsFilePathKey].Value;

            List<DrugClass> list = XmlSerializer.LoadFromXml(drugsFilePath, typeof(List<DrugClass>)) as List<DrugClass>;
            foreach (Models.DrugClass drug in list)
                this.drugsInfoListView.Items.Add(createListItemByClass(drug));
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (SendSelectResult("result" + this.drugNameTextBox.Text))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}
