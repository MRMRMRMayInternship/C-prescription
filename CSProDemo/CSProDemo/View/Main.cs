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
namespace CSProDemo.View
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
        //readonly string[] KEYS = { "P_ID", "P_NAME", "M_NAME", "M_ID", "CountOneDay", "CountOnce", "TimesOneDay", "Days", "How"};
        readonly string[] KEYS = { "Col1", "Col2", "Col3", "Col4", "Col5", "Col6", "Col7", "Col8", "Col9" };
        private ListView.SelectedListViewItemCollection selected;
        public Main()
        {
            InitializeComponent();
            SetListViewColumn();
        }
        //doctor ID
        public string SetTextView1 { set { this.textBox1.Text = value; } }
        private void SetListViewColumn() // seting listview item column width
        {

            foreach(string title in KEYS){
                this.listView1.Columns.Add(title, title, 150, HorizontalAlignment.Center,null);
            }
            this.listView1.Columns[KEYS[KEYS.Length - 1]].Width = -2;
            /***
             * way2
            this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
             * 
             * */
        }
        //private void UpdateListViewColumnWidth()
        //{
        //    foreach (string title in KEYS)
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
            item.SubItems[0].Text = rx[0];
            item.SubItems.Add(rx[1]);
            item.SubItems.Add(rx[2]);
            item.SubItems.Add(rx[3]);
            item.SubItems.Add(rx[4]);
            item.SubItems.Add(rx[5]);
            item.SubItems.Add(rx[0]);
            item.SubItems.Add(rx[0]);
            item.SubItems.Add(rx[0]);
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
        private void button1_Click_1(object sender, EventArgs e)    //insert a new item
        {
            InfoView newObj = new InfoView();
            // register insert Event
            newObj.Event += new CSProDemo.View.ListItemEvent(insertListItem);
            newObj.ShowDialog();
            if (newObj.DialogResult == System.Windows.Forms.DialogResult.OK)
            {

            }
            else if (newObj.DialogResult == System.Windows.Forms.DialogResult.Cancel)
            {

            }
            if (selected != null && selected.Count>0 ){
                selected.Clear();
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
                oldObj.Event += new CSProDemo.View.ListItemEvent(updateListItem);
                oldObj.LoadEvent(loadItem());
                oldObj.ShowDialog();
                if (oldObj.DialogResult == System.Windows.Forms.DialogResult.OK)
                {

                }
                else if (oldObj.DialogResult == System.Windows.Forms.DialogResult.Cancel)
                {

                }
                selected.Clear();
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
                if (result == System.Windows.Forms.DialogResult.No) {
                }
                else
                    foreach (ListViewItem item in selected)
                        listView1.Items.Remove(item);
                selected.Clear();
            }
            else
                System.Windows.Forms.MessageBox.Show("please select an item");
        }

        private void button5_Click(object sender, EventArgs e) // submit
        {
            /***
             * create json data
             * formate "환자의ID_처방전의ID":[{"key1":"val1", "key2":"val2"},{},{}]
             * RX class         :   {"key":"val"}
             * List<RX class>   :   [{},{}]
             * HashTable        :   "환자의 ID_처방전의 ID" : [{},{}]
             * creation date : 2017-12-22 2:39PM;
             ***/
            System.Collections.Hashtable hash = new System.Collections.Hashtable();
            foreach (ListViewItem item in this.listView1.Items)
            {
                RX obj = new RX();
                obj.Col1 = item.SubItems[0].Text;
                obj.Col2 = item.SubItems[1].Text;
                obj.Col3 = item.SubItems[2].Text;
                obj.Col4 = item.SubItems[3].Text;
                obj.Col5 = item.SubItems[4].Text;
                obj.Col6 = item.SubItems[5].Text;
                if(hash != null && hash.ContainsKey(obj.Col1+"_"+obj.Col2) != false){
                    ((List<RX>)hash[obj.Col1 + "_" + obj.Col2]).Add(obj);
                }else{
                    List<RX> newList = new List<RX>();
                    newList.Add(obj);
                    hash.Add(obj.Col1+"_"+obj.Col2, newList);
                }
            }
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            var json = js.Serialize(hash);
            MessageBox.Show(json.ToString());
            //traverse keys 
            System.Collections.IDictionaryEnumerator ie = hash.GetEnumerator();
            /***
             * create new files and save information
             * formate "환자의ID_처방전의ID.txt"
             * creation date : 2017-12-22 2:39PM;
             ***/
            while (ie.MoveNext())
            {
                //MessageBox.Show((string)ie.Key);
                string[] substr = (ie.Key as string).Split('_').ToArray();
                string dirName = @".\"+substr[0];
                string fileName = dirName+@"\"+substr[1]+".txt";
                /***
                 * create new file
                 ***/
                if (System.IO.Directory.Exists(@dirName) != true)
                {
                    //MessageBox.Show(@dirName);
                    System.IO.Directory.CreateDirectory(dirName);
                }
                System.IO.FileStream fs = System.IO.File.OpenWrite(@fileName);
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fs,System.Text.Encoding.UTF8);
                sw.Write(js.Serialize(hash[ie.Key]).ToString());
                sw.Flush();
                sw.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
