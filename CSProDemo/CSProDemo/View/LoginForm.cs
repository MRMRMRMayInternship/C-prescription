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
            if(result == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }
        /***
         * LOGIN button action
         ***/
        private void button1_Click(object sender, EventArgs e)
        {
            bool isSuccess = false;
            if (!isSuccess)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("The ID or password entried is invalid, please entry angin.","Checking Form",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
