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
    //declear lambdar
    public delegate void ListItemEvent(RX rx);
    public delegate void UpdateListItem(RX rx);
    public partial class InfoView : Form
    {
        // implement insert event
        public event ListItemEvent Event;
        public InfoView()
        {
            InitializeComponent();
        }
        public void LoadEvent(RX rx)
        {
            this.textBox1.Text = rx.Col1;
            this.textBox2.Text = rx.Col2;
            this.textBox3.Text = rx.Col3;
            this.textBox4.Text = rx.Col4;
            this.textBox5.Text = rx.Col5;
            this.textBox6.Text = rx.Col6;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string exp = @"[a-zA-Z]";
            string str = txt.Text;
            if (str.Length > 0)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch("" + str[str.Length - 1], exp)){
                    //;       
                }
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string exp = @"[a-zA-Z]";
            if (System.Text.RegularExpressions.Regex.IsMatch("" + e.KeyChar, exp))
            {
                e.Handled = true;
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // SAVE_BTN
        {
            RX obj = new RX();
            obj.Col1 = this.textBox1.Text;
            obj.Col2 = this.textBox2.Text;
            obj.Col3 = this.textBox3.Text;
            obj.Col4 = this.textBox4.Text;
            obj.Col5 = this.textBox5.Text;
            obj.Col6 = this.textBox6.Text;
            Event(obj);
            //MessageBox.Show(str);
            //this.Close();
        }

        private void button2_Click(object sender, EventArgs e) //CANCEL BTN
        {
            //this.Close();
        }
    }
}
