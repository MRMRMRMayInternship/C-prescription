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
        }
        private void InitializeDrugsInfoListColumnHeaderText()
        {
            
        }
        private void InitializeDrugsInfoList()
        {

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
