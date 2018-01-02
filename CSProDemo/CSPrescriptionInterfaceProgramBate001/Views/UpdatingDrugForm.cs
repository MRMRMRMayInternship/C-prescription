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
    public delegate bool UpdateEventHandle(string drugName, string drugID, string timeDruation, string timesPerDay, bool morning, bool afternoon, bool evening, string dosagePerTime, string dosageUnit,string usage, string instrucation);
    public partial class UpdatingDrugForm : Form
    {
        public UpdateEventHandle updateEventHandle;
        public UpdatingDrugForm()
        {
            InitializeComponent();
            this.morningCheckBox.CheckedChanged += checkBoxCheckedChanged;
            this.afternoonCheckBox.CheckedChanged += checkBoxCheckedChanged;
            this.eveningCheckBox.CheckedChanged += checkBoxCheckedChanged;
            this.usageComboBox.Items.AddRange(Models.CommonData.DefaultValuesSet.UsageComboBoxValues);
            this.dosageUnitComboBox.Items.AddRange(Models.CommonData.DefaultValuesSet.DosageUnitComboBoxValues);
        }
        public string DrugIDTextBoxValue
        {
            get { return drugIDTextBox.Text; }
            set { drugIDTextBox.Text = value; }
        }
        public string DrugNameTextBoxValue { 
            get { return drugNameTextBox.Text; } 
            set { this.drugNameTextBox.Text = value; } 
        }
        public string TimeDurationTextBoxValue
        {
            get { return this.timeDurationTextBox.Text; }
            set { this.timeDurationTextBox.Text = value; }
        }
        public string TimesPerDayTextBoxValue
        {
            get { return this.timesPerDayTextBox.Text; }
        }
        public bool MorningCheckBoxValue
        {
            get { return this.morningCheckBox.Checked; }
            set { this.morningCheckBox.Checked = value; }
        }

        public bool AfternoonCheckBoxValue
        {
            get { return this.afternoonCheckBox.Checked; }
            set { this.afternoonCheckBox.Checked = value; }
        }

        public bool EveningCheckBoxValue
        {
            get { return this.eveningCheckBox.Checked; }
            set { this.eveningCheckBox.Checked = value; }
        }
        public string DosagePerTimeTextBoxValue
        {
            get { return this.dosagePerTimeTextBox.Text; }
            set { this.dosagePerTimeTextBox.Text = value; }
        }
        public string UsageComboBoxValue
        {
            get { return this.usageComboBox.Text; }
            set { this.usageComboBox.Text = value; }
        }
        public string DosageUnitComboBoxValue
        {
            get { return this.dosageUnitComboBox.Text; }
            set { this.dosageUnitComboBox.Text = value; }
        }
        public string InstructionTextBoxValue
        {
            get { return this.instructionTextBox.Text; }
            set { this.instructionTextBox.Text = value; }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            string msg = null;

            if (string.IsNullOrWhiteSpace(this.drugNameTextBox.Text))
            {
                msg = "약품을 선택하십시오!";
                this.drugSearchButton.Focus();
            }
            else if (string.IsNullOrWhiteSpace(this.timeDurationTextBox.Text))
            {
                msg = "총 투약 일수를 입력하십시오!";
                this.timeDurationTextBox.Focus();
            }
            else if (string.IsNullOrWhiteSpace(this.timesPerDayTextBox.Text))
            {
                msg = "언제 먹는지에 대해서 check하십시오!";
                this.morningCheckBox.Focus();
            }
            else if (string.IsNullOrWhiteSpace(this.dosagePerTimeTextBox.Text))
            {
                msg = "1일 투약 량을 입력하십시오!";
                this.dosagePerTimeTextBox.Focus();
            }
            else if (string.IsNullOrWhiteSpace(this.dosageUnitComboBox.Text))
            {
                msg = "투약 단위을 선택하십시오!";
                this.dosageUnitComboBox.Focus();
            }
            else if (string.IsNullOrWhiteSpace(this.instructionTextBox.Text))
            {
                msg = "약품 사용에 대한 설명을 입력하십시오!";
                this.instructionTextBox.Focus();
            }
            else if (string.IsNullOrWhiteSpace(this.usageComboBox.Text))
            {
                msg = "약품 사용하는 방법을 선택하십시오!";
                this.usageComboBox.Focus();
            }
            if (!string.IsNullOrWhiteSpace(msg))
                MessageBox.Show(msg, "Inserting Form");
            else if (updateEventHandle(this.DrugNameTextBoxValue, this.DrugIDTextBoxValue, this.TimeDurationTextBoxValue, this.TimesPerDayTextBoxValue,
                this.MorningCheckBoxValue, this.AfternoonCheckBoxValue, this.EveningCheckBoxValue,
                this.DosagePerTimeTextBoxValue, this.DosageUnitComboBoxValue, this.UsageComboBoxValue, this.InstructionTextBoxValue))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }


        private void dosagePerTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox obj = (TextBox)sender;
            if (obj.Text.Equals(""))
            {
                this.dosageUnitComboBox.Enabled = false;
            }
            else if (!this.dosageUnitComboBox.Enabled)
            {
                this.dosageUnitComboBox.Enabled = true;
            }
        }
        private void checkBoxCheckedChanged(object sender, EventArgs e)
        {
            int value = this.timesPerDayTextBox.Text == "" ? 0 : Convert.ToInt32(this.timesPerDayTextBox.Text);
            if (((CheckBox)sender).Checked == true)
            {
                this.timesPerDayTextBox.Text = (++value).ToString();
            }
            else
            {
                value--;
                this.timesPerDayTextBox.Text = value <= 0 ? "" : value.ToString();
            }
        }
        private bool GetNewDrugSearchResult(string nameValue, string ID)
        {
            this.drugNameTextBox.Text = nameValue;
            this.drugIDTextBox.Text = ID;
            return true;
        }
        private void SearchNewDrug()
        {
            DrugSearchForm searchForm = new DrugSearchForm();
            searchForm.SendSelectResult += GetNewDrugSearchResult;
            searchForm.ShowDialog();
        }

        private void drugSearchButton_Click(object sender, EventArgs e)
        {
            SearchNewDrug();
        }


        
    }
}
