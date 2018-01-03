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
    /***
     * write by MRMRMRMAY
     * creation date : 17-12-22 4:19 PM
     * detail: login form
     * function : login and check
     ***/
    public delegate void FeedbackAction(Models.DoctorClass obj);
    public partial class LoginForm : Form
    {
        public FeedbackAction FeedbackEventHandle;
        List<Models.DoctorClass> doctorList;
        public LoginForm()
        {
            InitializeComponent();
            this.textBox2.KeyPress+=Controllers.KeyPressEvent.KeyPressOnlyNumberAndLetterEventHandle;
            this.textBox2.PasswordChar = '*';
            this.textBox1.KeyPress += Controllers.KeyPressEvent.KeyPressOnlyNumberAndLetterEventHandle;
            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            string filePath = config.AppSettings.Settings["accountFilePath"].Value;
            doctorList = DAO.XmlSerializer.LoadFromXml(filePath, typeof(List<Models.DoctorClass>)) as List<Models.DoctorClass>;
            
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
            IEnumerable<Models.DoctorClass> resultList =
                from result in doctorList
                where result.ID.Equals(this.textBox1.Text) && result.Password.Equals(this.textBox2.Text)
                select result;
            if (resultList.Count() > 0)
            {
                Models.DoctorClass obj = resultList.ToArray().GetValue(0) as Models.DoctorClass;
                FeedbackEventHandle(obj);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                DialogResult r = MessageBox.Show("The ID or password entried is invalid, please entry angin.", "Checking Form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
