using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSProDemo.Model;
namespace CSProDemo
{
    public partial class Main : Form
    {
        //private const System.Collections.Hashtable column = new System.Collections.Hashtable();
        readonly string[] keys = { "P_ID", "P_NAME", "M_NAME", "M_ID", "CountOneDay", "CountOnce", "TimesOneDay", "Days", "How"};
        private ListView.SelectedListViewItemCollection selected;
        public Main()
        {
            InitializeComponent();
            SetListViewColumn();
        }
        private void SetListViewColumn()
        {
            foreach(string title in keys){
                this.listView1.Columns.Add(title, -2, HorizontalAlignment.Center);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (selected != null && selected.Count != 0)
            //    selected.Clear();
            selected = this.listView1.SelectedItems;  
            
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }
        private void insertListItem(RX rx)
        {
            ListViewItem item = new ListViewItem();
            item.SubItems.Clear();
            item.SubItems[0].Text = rx.Col1;
            item.SubItems.Add(rx.Col2);
            item.SubItems.Add(rx.Col3);
            item.SubItems.Add(rx.Col4);
            item.SubItems.Add(rx.Col5);
            item.SubItems.Add(rx.Col6);

            item.SubItems.Add(rx.Col1);
            item.SubItems.Add(rx.Col1);
            item.SubItems.Add(rx.Col1);
            
            this.listView1.Items.Add(item);                

        }
        private void button1_Click_1(object sender, EventArgs e)    //new
        {
            NewInfo newObj = new NewInfo();
            // register insert Event
            newObj.InsertEvent += new CSProDemo.InsertListItem(insertListItem);
            newObj.ShowDialog();
            if (newObj.DialogResult == System.Windows.Forms.DialogResult.OK)
            {

            }
            else if (newObj.DialogResult == System.Windows.Forms.DialogResult.Cancel)
            {

            }
           // this.Close();

        }

        private void button2_Click(object sender, EventArgs e)  //updata event
        {

        }

        private void button3_Click(object sender, EventArgs e) //delete event
        {
            if (selected != null && selected.Count > 0)
            {
                System.Windows.Forms.DialogResult result = MessageBox .Show("Are you sure to delete it?","Form Deleting",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.No) { }
                else
                    foreach (ListViewItem item in selected)
                        listView1.Items.Remove(item);
            }
            else
                System.Windows.Forms.MessageBox.Show("please select an item");
        }
    }
}
