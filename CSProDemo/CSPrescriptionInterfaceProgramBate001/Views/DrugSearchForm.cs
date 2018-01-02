using CSPrescriptionInterfaceProgramBate001.DAO;
using CSPrescriptionInterfaceProgramBate001.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSPrescriptionInterfaceProgramBate001.Views
{
    public delegate bool SendSelectResultDelegate(string value, string IDValue);
    public partial class DrugSearchForm : Form
    {
        public SendSelectResultDelegate SendSelectResult;
        List<DrugClass> drugClasslist;
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
            drugClasslist = XmlSerializer.LoadFromXml(drugsFilePath, typeof(List<DrugClass>)) as List<DrugClass>;
            foreach (Models.DrugClass drug in drugClasslist)
                this.drugsInfoListView.Items.Add(createListItemByClass(drug));
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        //private void button2_Click(object sender, EventArgs e)
        //{

        //    if (SendSelectResult("result" + this.drugNameTextBox.Text))
        //    {
        //        this.DialogResult = System.Windows.Forms.DialogResult.OK;
        //        this.Close();
        //    }
        //}
        
        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (drugsInfoListView.SelectedItems.Count > 0)
            {
                if (SendSelectResult(this.drugsInfoListView.SelectedItems[0].SubItems[0].Text,this.drugsInfoListView.SelectedItems[0].SubItems[1].Text))
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please Select only one drug", "selecting form");
            }
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchListDisplay();
        }
        private void SearchListDisplay()
        {
            this.drugsInfoListView.Items.Clear();
            IEnumerable<DrugClass> resultList =
                from drugClass in drugClasslist
                where drugClass.DrugName.Contains(drugNameTextBox.Text)
                select drugClass;
            foreach (Models.DrugClass drug in resultList)
            {
                this.drugsInfoListView.Items.Add(createListItemByClass(drug));
            }
        }
        private void drugsInfoListView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
