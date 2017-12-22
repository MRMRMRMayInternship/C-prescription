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
    /***
     * Main Form class
     * function:    1. insert record                        ----    WORK:   private void insertListItem(RX rx) && NEWBTN   :   private void button1_Click_1(object sender, EventArgs e)
     *              2. delete items selected                ----    WORK:                                         DELBTn   :   private void button3_Click(object sender, EventArgs e)
     *              3. update item selected, only one       ----    private void button2_Click(object sender, EventArgs e)
     *              4. submit and update file infomation if old patient, otherwise create new file.
     * 
     ***/
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
        private void SetListViewColumn() // seting listview item column width
        {

            foreach(string title in keys){
                this.listView1.Columns.Add(title, title, 150, HorizontalAlignment.Center,null);
            }
            this.listView1.Columns[keys[keys.Length - 1]].Width = -2;
            /***
             * way2
            this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
             * 
             * */
        }
        //private void UpdateListViewColumnWidth()
        //{
        //    foreach (string title in keys)
        //    {
        //        this.listView1.Columns[title].Width = -1;
        //    }
        //}
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
        private ListViewItem createListItem(RX rx)//create an item
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
            return item;
        }
        private RX loadItem()
        {
            RX rx = new RX();
            ListViewItem item = selected[0];
            ListViewItem.ListViewSubItemCollection sub = item.SubItems;
            for (int i = 0; i < sub.Count; i++)
            {
                rx[i] = sub[i].Text;
            }
            return rx;
        }
        private void insertListItem(RX rx) //get information from NewInfo form and insert it into listview.
        {
            ListViewItem item = createListItem(rx);
            this.listView1.Items.Add(item);
            //UpdateListViewColumnWidth();
        }
        private void button1_Click_1(object sender, EventArgs e)    //new
        {
            InfoView newObj = new InfoView();
            // register insert Event
            newObj.Event += new CSProDemo.ListItemEvent(insertListItem);
            newObj.ShowDialog();
            if (newObj.DialogResult == System.Windows.Forms.DialogResult.OK)
            {

            }
            else if (newObj.DialogResult == System.Windows.Forms.DialogResult.Cancel)
            {

            }
           // this.Close();

        }
        private void updateListItem(RX rx)
        {
            int index = this.listView1.Items.IndexOf(selected[0]);
            this.listView1.Items.RemoveAt(index);
            ListViewItem item = createListItem(rx);
            this.listView1.Items.Insert(index, item); 
            //UpdateListViewColumnWidth();
        }
        private void button2_Click(object sender, EventArgs e)  //updata event
        {
            if (selected != null && selected.Count != 0)
            {
                InfoView oldObj = new InfoView();
                // register insert Event
                oldObj.Event += new CSProDemo.ListItemEvent(updateListItem);
                oldObj.LoadEvent(null);
                oldObj.ShowDialog();
                if (oldObj.DialogResult == System.Windows.Forms.DialogResult.OK)
                {

                }
                else if (oldObj.DialogResult == System.Windows.Forms.DialogResult.Cancel)
                {

                }
            }
            else
            {
                DialogResult result = MessageBox.Show("please select only one item", "Form update", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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
