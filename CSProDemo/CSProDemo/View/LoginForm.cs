using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSProDemo.View
{
    /***
     * write by MRMRMRMAY
     * creation date : 17-12-22 4:19 PM
     * detail: login form
     * function : login and check
     ***/
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        /***
         * exit button action
         ***/
        private void button2_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure to exit?";
            DialogResult result = MessageBox.Show(msg, ":FORM CLOSING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
        }
        /***
         * LOGIN button action
         ***/
        private void button1_Click(object sender, EventArgs e)
        {
            bool isSuccess = false;
            if (!isSuccess)
            {
                System.IO.FileStream fs = new System.IO.FileStream(@".\account.txt",System.IO.FileMode.OpenOrCreate);
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, Encoding.UTF8);
                DAO.JsonOP jsonOP = new DAO.JsonOP();
                var json = jsonOP.GetJson((new Model.Common.Account(){ID = this.textBox1.Text, Password = this.textBox2.Text}));
                sw.Write(json.ToString());
                sw.Flush();
                sw.Close();
                fs.Close();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                DialogResult r =  MessageBox.Show("The ID or password entried is invalid, please entry angin.","Checking Form",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
