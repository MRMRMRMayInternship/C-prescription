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
            Models.DrugsClass list = new Models.DrugsClass();
            System.IO.FileStream fs = new System.IO.FileStream(@".\drugs.xml",System.IO.FileMode.Open);
            
            System.Runtime.Serialization.DataContractSerializer rs = new System.Runtime.Serialization.DataContractSerializer(list.GetType());
            list = (Models.DrugsClass)rs.ReadObject(fs);
            foreach (Models.DrugClass drug in list.Drugs)
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
