using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrugManageSystemBate001
{
    public partial class Form1 : Form
    {
        private ListViewItem item = null;
        public Form1()
        {
            InitializeComponent();
            if (!System.IO.File.Exists(@".\drugs.xml")) { return; }
            System.IO.FileStream fs = new System.IO.FileStream(@".\drugs.xml", System.IO.FileMode.Open);
            DrugsClass drugs = new DrugsClass();
            System.Runtime.Serialization.DataContractSerializer sr = new System.Runtime.Serialization.DataContractSerializer(drugs.GetType());
            DrugsClass list = sr.ReadObject(fs) as DrugsClass;
            if (list != null)
            {
                foreach (DrugClass drug in list.Drugs)
                {
                    listView1.Items.Add(createListItemByClass(drug));
                }
            }
        }
        private ListViewItem createListItemByClass(DrugClass drug)
        {
            ListViewItem item = new ListViewItem();
            item.SubItems.Clear();
            item.SubItems[0].Text = drug.DrugName;
            item.SubItems.Add(drug.DrugID);
            item.SubItems.Add(drug.Price.ToString());
            item.SubItems.Add(drug.Creation);
            return item;
        }
        private ListViewItem createListItem()//create an item
        {
            ListViewItem item = new ListViewItem();
            System.Random r = new System.Random((int)Convert.ToInt32(String.Format("{0:HHmmss}", System.DateTime.Now)));
            item.SubItems.Clear();
            item.SubItems[0].Text = textBox1.Text;
            item.SubItems.Add(String.Format("D001{0:yyMMddHHmmss}",System.DateTime.Now));
            item.SubItems.Add(r.Next(1000,50000).ToString());
            item.SubItems.Add(dateTimePicker1.Value.ToString());
            return item;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Add(createListItem());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<DrugClass> list = new List<DrugClass>();
            foreach (ListViewItem item in listView1.Items)
            {
                DrugClass drugObj = new DrugClass();
                drugObj.DrugName = item.SubItems[0].Text;
                drugObj.DrugID = item.SubItems[1].Text;
                drugObj.Price = Convert.ToInt32(item.SubItems[2].Text);
                drugObj.Creation = item.SubItems[3].Text;
                list.Add(drugObj);
            }
            DrugsClass drugs = new DrugsClass();
            drugs.Drugs = list;
            System.IO.FileStream fs = new System.IO.FileStream(@".\drugs.xml", System.IO.FileMode.OpenOrCreate);
            System.Runtime.Serialization.DataContractSerializer sr = new System.Runtime.Serialization.DataContractSerializer(drugs.GetType());
            sr.WriteObject(fs, drugs);
            fs.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
