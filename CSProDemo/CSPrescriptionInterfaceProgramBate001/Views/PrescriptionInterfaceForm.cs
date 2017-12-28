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
    public partial class PrescriptionInterfaceForm : Form
    {
        private bool isFirstWork = true;
        readonly Dictionary<string, int> DataGridViewCellDic;
        readonly string[] KEYS = { "수정/증가", "약품 ID", "약품 명칭", "충 투약일수", "1일 투약횟수", "1회 투약 량", "용법", "Col8", "Col9" };
        private DataGridViewRow updatingRow = null;
        private string lastDrugNameTextBoxText = null;
        private string lastDrugNameTextBoxCellValue = null;
        private DataGridViewButtonCell selectedDrugNameCell = null;
        public Models.DoctorClass DoctorInfomation
        {
            set;
            get;
        }
        public PrescriptionInterfaceForm()
        {
            InitializeComponent();
            InitializeUsageComboBox();
            InitializeDosageUnitComboBox();
            DataGridViewCellDic = new Dictionary<string, int>();
            DataGridViewCellDic.Add("drugName", 2);
            DataGridViewCellDic.Add("timeDuration", 3);
            DataGridViewCellDic.Add("timesPerDay", 4);
            DataGridViewCellDic.Add("whenMorning", 5);
            DataGridViewCellDic.Add("whenAfternoon", 6);
            DataGridViewCellDic.Add("whenEvening", 7);
            DataGridViewCellDic.Add("dosagePerTimeValue", 8);
            DataGridViewCellDic.Add("dosagePerTimeUnit", 9);
            DataGridViewCellDic.Add("usage", 10);
            DataGridViewCellDic.Add("instruction", 11);
        }
        public void InitializeDoctorInformation()
        {
            this.doctorNameTextBox.Text = DoctorInfomation.Name;
            this.DoctorIDtextBox.Text = DoctorInfomation.ID;
            this.depTextBox.Text = DoctorInfomation.Department;
        }
        private void InitializeUsageComboBox()
        {
            this.usageComboBox.Items.AddRange(new string[] {"내복", "외용", "정맥 주사"});
        }
        //private void InitializeDrugNamesComboBox()
        //{
        //    this.drugNamesComboBox.Items.AddRange(new String[] { "a", "s", "d" });
        //}
        private void InitializeDosageUnitComboBox()
        {
            this.dosageUnitComboBox.Items.AddRange(new String[] { "ml", "l", "개" });
        }
        private DataGridViewRow CreateDateGridViewRow(){
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.Cells.Clear();
            //update button column item
            DataGridViewButtonCell updateBtnCell = new DataGridViewButtonCell();
            updateBtnCell.Value = "수정";
            updateBtnCell.Style.SelectionBackColor = Color.White;
            newRow.Cells.Add(updateBtnCell);
            //delete button column item
            DataGridViewButtonCell delBtnCell = new DataGridViewButtonCell();
            delBtnCell.Value = "삭제";
            newRow.Cells.Add(delBtnCell);

            ////drug ID column item
            //DataGridViewTextBoxCell drugIDTextBoxCell = new DataGridViewTextBoxCell();
            //drugIDTextBoxCell.Value = this.drugIDTextBox.Text;
            //newRow.Cells.Add(drugIDTextBoxCell);

            //drug name column item
            /***
             * drug name column (comboBox version) backup; 
             ***    code part   ***
            //for (int i = 0; i < drugNamesComboBox.Items.Count; i++)
            //DataGridViewComboBoxCell drugNameComboBoxCell = new DataGridViewComboBoxCell();
            //    drugNameComboBoxCell.Items.Add(drugNamesComboBox.Items[i].ToString());
            //drugNameComboBoxCell.Value = this.drugNamesComboBox.SelectedItem.ToString();
            //newRow.Cells.Add(drugNameComboBoxCell);
            ***/
            DataGridViewButtonCell drugNameCell = new DataGridViewButtonCell();
            drugNameCell.Value = this.drugNameTextBox.Text;
            drugNameCell.FlatStyle = FlatStyle.Popup;
            newRow.Cells.Add(drugNameCell);
            
            //time duration column item
            DataGridViewTextBoxCell timeDurationTextBoxCell = new DataGridViewTextBoxCell();
            timeDurationTextBoxCell.Value = this.timeDurationTextBox.Text;
            newRow.Cells.Add(timeDurationTextBoxCell);
            //times per day column item
            DataGridViewTextBoxCell timesPerDayTextBoxCell = new DataGridViewTextBoxCell();
            timesPerDayTextBoxCell.Value = this.timesPerDayTextBox.Text;
            newRow.Cells.Add(timesPerDayTextBoxCell);
            //아침에 약 먹는 지에 대한 checkbox
            DataGridViewCheckBoxCell MorningCheckBoxCell = new DataGridViewCheckBoxCell();
            MorningCheckBoxCell.Value = this.moringCheckBox.Checked;
            newRow.Cells.Add(MorningCheckBoxCell);
            //점심에 약 먹는 지에 대한 checkbox
            DataGridViewCheckBoxCell AfternoonCheckBoxCell = new DataGridViewCheckBoxCell();
            AfternoonCheckBoxCell.Value = this.afternoonCheckBox.Checked;
            newRow.Cells.Add(AfternoonCheckBoxCell);
            //저녁에 약 먹는 지에 대한 checkbox
            DataGridViewCheckBoxCell EveningCheckBoxCell = new DataGridViewCheckBoxCell();
            EveningCheckBoxCell.Value = this.eveningCheckBox.Checked;
            newRow.Cells.Add(EveningCheckBoxCell);
            //the value of dosage per time column item
            DataGridViewTextBoxCell dosagePerTimeValueTextBoxCell = new DataGridViewTextBoxCell();
            dosagePerTimeValueTextBoxCell.Value = this.dosagePerTimeTextBox.Text;
            newRow.Cells.Add(dosagePerTimeValueTextBoxCell);
            //the unit of dosage per time column item
            DataGridViewComboBoxCell dosagePerTimeUnitComboBoxCell = new DataGridViewComboBoxCell();
            for (int i = 0; i < this.dosageUnitComboBox.Items.Count; i++)
                dosagePerTimeUnitComboBoxCell.Items.Add(this.dosageUnitComboBox.Items[i].ToString());
            dosagePerTimeUnitComboBoxCell.Value = this.dosageUnitComboBox.Text;
            newRow.Cells.Add(dosagePerTimeUnitComboBoxCell);
            //the usage of drug column item
            DataGridViewComboBoxCell usageComboBoxCell = new DataGridViewComboBoxCell();
            for (int i = 0; i < usageComboBox.Items.Count; i++ )
                usageComboBoxCell.Items.Add(usageComboBox.Items[i].ToString());
            usageComboBoxCell.Value = usageComboBox.Text;
            newRow.Cells.Add(usageComboBoxCell);
            //the instruction of drug column item
            DataGridViewTextBoxCell instrucationValueTextBoxCell = new DataGridViewTextBoxCell();
            instrucationValueTextBoxCell.Value = this.instructionTextBox.Text;
            newRow.Cells.Add(instrucationValueTextBoxCell);
            return newRow;
        }
        /***
         * some textBox be allow to entry only number;
         ***/
        private void KeyPressOnlyNumberEventHandle(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string exp = @"[0-9]|[\b]";
            if (!System.Text.RegularExpressions.Regex.IsMatch("" + e.KeyChar, exp))
            {
                e.Handled = true;
            }
        }
        /***
         * Method Name : KeyPressOnlyNumberAndLetterEventHandle
         * Detail: some textBoxs be only allowed to entry number and letter;
         * By : MRMRMRMAY
         * Creation date: 17-12-28
         ***/
        private void KeyPressOnlyNumberAndLetterEventHandle(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string exp = @"[0-9a-zA-Z]|[\b]";
            if (!System.Text.RegularExpressions.Regex.IsMatch("" + e.KeyChar, exp))
            {
                e.Handled = true;
            }
        }
        /***
         * some textBox be allow to entry only letter;
         ***/
        private void KeyPressOnlyLetterEventHandle(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string exp = @"[a-zA-Z]|[\b]";
            if (!System.Text.RegularExpressions.Regex.IsMatch("" + e.KeyChar, exp))
            {
                e.Handled = true;
            }
        }
        /***
         * Check if doctor is doing prescription work, and return T/F
         * By: MRMRMRMAY
         * creation date:17-12-28
         ***/
        private bool isDoingPrescriptionWork()
        {
            return this.drugInfoDataGridView.Rows.Count > 0 || this.drugNameTextBox.Text != ""
                || this.timeDurationTextBox.Text != "" || this.dosagePerTimeTextBox.Text != ""
                || this.moringCheckBox.Checked || this.afternoonCheckBox.Checked || this.eveningCheckBox.Checked
                || this.instructionTextBox.Text != "" || this.usageComboBox.Text != "";
        }
        /***
         * load next patient information into gui
         ***/
        private void LoadPatientInformation()
        {
            Models.PatientClass patient = new Models.PatientClass();
            patient.Name = "홍기동";
            patient.Age = "" + 21;
            patient.Birthday = "1996-12-27";
            patient.PatientID = "P100171227150211";
            patient.Sex = "M";
            //patient.SymptomDescription = "unknown";
            loadPatientInfo(patient);
            this.prescriptionIDLabel.Text = String.Format("RX100{0:yyMMddHHmmss}", System.DateTime.Now);
        }
        private void SetDrugInfoInputBlockControlsEnableState()
        {
            this.drugSearchButton.Enabled = true;
            this.timeDurationTextBox.Enabled = true ;
            this.dosagePerTimeTextBox.Enabled = true;
            this.moringCheckBox.Enabled = true;
            this.afternoonCheckBox.Enabled = true;
            this.eveningCheckBox.Enabled = true;
            this.instructionTextBox.Enabled = true;
            this.usageComboBox.Enabled = true;
            this.insertButton.Enabled = true;

        }
        private void SetPatientInfoInputBlockControlsEnableState()
        {
            this.symptomDescriptionTextBox.Enabled = true;
        }
        private void ClearInputBlock()
        {
            this.drugNameTextBox.Clear();
            this.timeDurationTextBox.Clear();
            this.dosagePerTimeTextBox.Clear();
            this.timesPerDayTextBox.Clear();
            this.moringCheckBox.CheckState = CheckState.Unchecked;
            this.afternoonCheckBox.CheckState = CheckState.Unchecked;
            this.eveningCheckBox.CheckState = CheckState.Unchecked;
            this.instructionTextBox.Clear();
            this.usageComboBox.Text ="";
        }
        private void ClearVariable()
        {
            updatingRow = null;
            lastDrugNameTextBoxText = null;
            lastDrugNameTextBoxCellValue = null;
            selectedDrugNameCell = null;
        }
        private void callNextPatientButton_Click(object sender, EventArgs e)
        {
            if (isDoingPrescriptionWork())
            {
                
                DialogResult result = MessageBox.Show("저장되지 않은 처방전이 있습니다.\n저장하겠십니까?", "Saving Form", MessageBoxButtons.YesNoCancel);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    ClearInputBlock();
                    this.drugInfoDataGridView.Rows.Clear();
                    ClearVariable();
                    LoadPatientInformation();
                }
            }
            else
            {
                if (isFirstWork)
                {
                    SetDrugInfoInputBlockControlsEnableState();
                    SetPatientInfoInputBlockControlsEnableState();
                    isFirstWork = false;
                }
                ClearVariable();
                LoadPatientInformation();
                
            }
        }
        /***
         * checkbox value changed event
         * writer :  mrmrmrmay
         * creation date:17-12-28
         ***/
        private void checkBoxCheckedChanged(object sender, EventArgs e)
        {
            int value = this.timesPerDayTextBox.Text == "" ? 0:Convert.ToInt32(this.timesPerDayTextBox.Text);
            if (((CheckBox)sender).Checked == true)
            {
                this.timesPerDayTextBox.Text = (++value).ToString();
            }
            else
            {
                value--;
                this.timesPerDayTextBox.Text =  value<=0 ? "": value.ToString();
            }
        }

        private void loadPatientInfo(Models.PatientClass patient)
        {
            patientNameTextBox.Text = patient.Name;
            patientAgeTextBox.Text = patient.Age;
            patientSexTextBox.Text = patient.Sex;
            patientIDTextBox.Text = patient.PatientID;
            //symptomDescriptionTextBox.Text = patient.SymptomDescription;
        }
        private void insertNewRow()
        {
            this.drugInfoDataGridView.Rows.Add(CreateDateGridViewRow());
            this.drugInfoDataGridView.RowsAdded +=  drugInfoDataGridView_RowsAdded;    
        }
        private void drugInfoDataGridView_RowsAdded(object sender, EventArgs e)
        {
            int currentRow = this.drugInfoDataGridView.RowCount - 1;
            for (int i = 2; i < drugInfoDataGridView.Rows[currentRow].Cells.Count; i++)
            {
                drugInfoDataGridView.Rows[currentRow].Cells[i].ReadOnly = true;
            }
        }
        private void insertButton_Click(object sender, EventArgs e)
        {
            if (this.timeDurationTextBox.Text == "" ||
                this.drugNameTextBox.Text == "" ||
                this.dosagePerTimeTextBox.Text == "" ||
                this.dosageUnitComboBox.Text == "" ||
                this.instructionTextBox.Text == "" ||
                this.usageComboBox.Text == "")
                MessageBox.Show("entry info");
            else if (InsertDrugNameRepetationCheck())
            {
                string msg = string.Format("약품 {0} 이미 있습니다", this.drugNameTextBox.Text);
                MessageBox.Show(msg,"Inserting Form");
            }
            else
            {
                insertNewRow();
                ClearInputBlock();
            }
        }
        private void updateBtnEventHandle(int row){
            string str = string.Format("row: {0} 의 ", row + 1);
            if (this.drugInfoDataGridView.Rows[row].Cells[0].Value.Equals("수정"))
            {
                if (updatingRow != null)
                {
                    MessageBox.Show("수정하고 있는 row있습니다.");
                    return;
                }
                updatingRow = this.drugInfoDataGridView.Rows[row];
                for (int i = 2; i < updatingRow.Cells.Count; i++)
                {
                    this.drugInfoDataGridView.Rows[row].Cells[i].ReadOnly = false;
                }
                str += "수정 button";
                MessageBox.Show(str);
                updatingRow.Cells[0].Value = "확인";
            }
            else
            {

                for (int i = 2; i < updatingRow.Cells.Count; i++)
                {
                    this.drugInfoDataGridView.Rows[row].Cells[i].ReadOnly = true;
                }
                str += "확인 button";
                MessageBox.Show(str);
                updatingRow.Cells[0].Value = "수정";
                updatingRow = null;
            }
        }
        private void drugInfoDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            if (this.drugInfoDataGridView.Rows[row].Cells[col].ReadOnly)
                return;
            
            switch (col)
            {
                case 0:
                    {
                        updateBtnEventHandle(row);
                        break;
                    }
                case 1:
                    {
                        string str = string.Format("row: {0} 의 ", row + 1);
                        str += "삭제 button";
                        MessageBox.Show(str);
                        if(MessageBox.Show("삭제하시겠습니까?","deleting form",MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            this.drugInfoDataGridView.Rows.RemoveAt(row);
                        break;
                    }
                case 2:
                    {
                        selectedDrugNameCell = (DataGridViewButtonCell)this.drugInfoDataGridView.Rows[row].Cells[col];
                        lastDrugNameTextBoxCellValue = selectedDrugNameCell.Value.ToString();
                        UpdateDrug();
                        break;
                    }
                case 5:
                case 6:
                case 7:
                    {
                        
                        //int value = Convert.ToInt32(this.drugInfoDataGridView.Rows[row].Cells[4].Value);
                        //value += (((DataGridViewCheckBoxCell)this.drugInfoDataGridView.Rows[row].Cells[col]).Value == true ? +1 : -1);
                        //this.drugInfoDataGridView.Rows[row].Cells[5].Value = value.ToString();
                        MessageBox.Show(""+this.drugInfoDataGridView.Rows[row].Cells[col].EditedFormattedValue);
                        break;
                    }
            }
        }
        /*** do not need to do it now
         * 
        private string findDrugIDByDrugName(string drugName){
            return drugName;
        }
         
        private void drugNamesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            lastDrugNameTextBoxText = this.drugNamesComboBox.SelectedItem.ToString();
            this.drugIDTextBox.Text = findDrugIDByDrugName(lastDrugNameTextBoxText);
        }
         **/
        private void drugNamesComboBox_LostFocus(object sender, System.EventArgs e)
        {
            for (int i = 0; i < drugNamesComboBox.Items.Count; i++)
            {
                if (drugNamesComboBox.Text.Equals(drugNamesComboBox.Items[i].ToString()))
                {
                    lastDrugNameTextBoxText = drugNamesComboBox.Text;
                    throw new System.NotImplementedException();
                }
            }
            MessageBox.Show("error");
            drugNamesComboBox.Text = lastDrugNameTextBoxText;
            throw new System.NotImplementedException();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.drugInfoDataGridView.Rows.Count == 0) {
                MessageBox.Show("처방 약품을 가입 하십시오","Saving Form");
                return;
            }
            Models.PrescriptionClass prescriptionObj = new Models.PrescriptionClass();
            prescriptionObj.PrescriptionID = this.prescriptionIDLabel.Text;
            Models.PatientClass patientObj = new Models.PatientClass();
            patientObj.Name = this.patientNameTextBox.Text;
            patientObj.Age = this.patientAgeTextBox.Text;
            patientObj.Sex = this.patientSexTextBox.Text;
            patientObj.PatientID = this.patientIDTextBox.Text;
            patientObj.SymptomDescription = this.symptomDescriptionTextBox.Text;
            prescriptionObj.Patient = patientObj;

            prescriptionObj.Date = String.Format("{0:yyMMddHHmmss}",this.dateTextBox.Text);

            Models.DoctorClass docObj = new Models.DoctorClass();
            docObj.Name = this.doctorNameTextBox.Text;
            docObj.ID = this.DoctorIDtextBox.Text;
            docObj.Department = this.depTextBox.Text;
            prescriptionObj.Docotr = docObj;

            List<Models.DrugClass> drugList = new List<Models.DrugClass>();
            foreach (DataGridViewRow row in drugInfoDataGridView.Rows)
            {
                //DataGridViewRow currentRow = this.drugInfoDataGridView.Rows[row];
                Models.DrugClass drugObj = new Models.DrugClass();
                drugObj.DrugName = row.Cells[this.DataGridViewCellDic["drugName"]].Value.ToString();
                drugObj.TimeDuration = Convert.ToInt32(row.Cells[this.DataGridViewCellDic["timeDuration"]].Value.ToString());
                drugObj.TimesPerDay = Convert.ToInt32(row.Cells[this.DataGridViewCellDic["timesPerDay"]].Value.ToString());
                drugObj.WhenMorning = Convert.ToBoolean(row.Cells[this.DataGridViewCellDic["whenMorning"]].FormattedValue.ToString());
                drugObj.WhenAfternoon = Convert.ToBoolean(row.Cells[this.DataGridViewCellDic["whenAfternoon"]].FormattedValue.ToString());
                drugObj.WhenEvening = Convert.ToBoolean(row.Cells[this.DataGridViewCellDic["whenEvening"]].FormattedValue.ToString());
                drugObj.DosagePerTime_Value = Convert.ToInt32(row.Cells[this.DataGridViewCellDic["dosagePerTimeValue"]].Value);
                drugObj.DosagePerTime_Unit = row.Cells[this.DataGridViewCellDic["dosagePerTimeUnit"]].Value.ToString();
                drugObj.Usage = row.Cells[this.DataGridViewCellDic["usage"]].Value.ToString();
                drugObj.Instruction = row.Cells[this.DataGridViewCellDic["instruction"]].Value.ToString();
                drugList.Add(drugObj);
            }
            prescriptionObj.Drugs = drugList;
            Controllers.SavePrescriptionInfoAsXMLFile saveXmlFile = new Controllers.SavePrescriptionInfoAsXMLFile();
            saveXmlFile.SaveAsXMLFile(prescriptionObj);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.dateTextBox.Text = String.Format("{0:G}",System.DateTime.Now);
        }
        private void SearchUpdateDrug()
        {
            DrugSearchForm searchForm = new DrugSearchForm();
            searchForm.SendSelectResult += UpdateDrugSearchResult;
            searchForm.ShowDialog();
        }
        /***
         * Name: InsertDrugNameRepetationCheck
         * By: MRMRMRMAY
         * Detail:
         * when doctor insert new drug into drug information datagridview, this function will be called;
         * if there almost is the same drug in drug information datagridview, it will return true. Otherwise, false.
         * Creation Date:2017-12-28
         ***/
        private bool InsertDrugNameRepetationCheck()
        {
            foreach(DataGridViewRow row in drugInfoDataGridView.Rows){
                if (this.drugNameTextBox.Text.Equals(row.Cells[DataGridViewCellDic["drugName"]].Value))
                {
                    return true;
                }
            }
            return false;
        }
        private bool UpdateDrugNameRepetationCheck(string value)
        {
            foreach (DataGridViewRow row in drugInfoDataGridView.Rows)
            {
                if (updatingRow == row)
                {
                    continue;
                }
                else if (value.Equals(row.Cells[DataGridViewCellDic["drugName"]].Value))
                {
                    return true;
                }
            }
            return false;
        }
        private void UpdateDrug()
        {
            DrugSearchForm searchForm = new DrugSearchForm();
            searchForm.SendSelectResult = UpdateDrugSearchResult;
            searchForm.ShowDialog();
        }
        private bool UpdateDrugSearchResult(string value)
        {
            if (UpdateDrugNameRepetationCheck(value))
            {
                string msg = string.Format("{0} 이미 있습니다.\n 하고 있는 수정처리을 취소하겠십니까?", value);
                if (MessageBox.Show(msg, "Updating Form", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            this.selectedDrugNameCell.Value = value;
            return true;
        }
        private bool GetNewDrugSearchResult(string value)
        {
            this.drugNameTextBox.Text = value;
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

        private void dosagePerTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox obj = (TextBox)sender;
            if (obj.Text.Equals(""))
            {
                this.dosageUnitComboBox.Enabled = false;
            }
            else if(!this.dosageUnitComboBox.Enabled)
            {
                this.dosageUnitComboBox.Enabled = true;
            }
        }
    }
}
