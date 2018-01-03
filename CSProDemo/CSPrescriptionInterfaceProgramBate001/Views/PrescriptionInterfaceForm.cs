using CSPrescriptionInterfaceProgramBate001.DAO;
using CSPrescriptionInterfaceProgramBate001.Models;
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
        private bool haveToSave = false;
        private DataGridViewRow updatingRow = null;
        private string lastDrugNameTextBoxText = null;
        private string lastDrugNameTextBoxCellValue = null;
        private DataGridViewButtonCell selectedDrugNameCell = null;
        private System.Configuration.Configuration config;
        private readonly int DrugNameColumnIndex;
        private readonly int DrugIDColumnIndex;
        private readonly int TimeDurationColumnIndex;
        private readonly int TimesPerDayColumnIndex;
        private readonly int MorningCheckBoxColumnIndex;
        private readonly int AfternoonCheckBoxColumnIndex;
        private readonly int EventnoonCheckBoxColumnIndex;
        private readonly int DosagePerTime_ValueColumnIndex;
        private readonly int DosagePerTime_UnitColumnIndex;
        private readonly int UsageColumnIndex;
        private readonly int DrugInstructionColumnIndex;
        public Models.DoctorClass DoctorInfomation
        {
            set;
            get;
        }
        private void SetLanguage()
        {
            
        }
        public PrescriptionInterfaceForm()
        {
            InitializeComponent();

            this.dosagePerTimeTextBox.KeyPress += Controllers.KeyPressEvent.KeyPressOnlyNumberAndPointEventHandle;
            this.timeDurationTextBox.KeyPress += Controllers.KeyPressEvent.KeyPressOnlyNumberEventHandle;
            config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            DrugNameColumnIndex = Convert.ToInt32(config.AppSettings.Settings["DrugNameColumn"].Value);
            DrugIDColumnIndex = Convert.ToInt32(config.AppSettings.Settings["DrugIDColumn"].Value);
            TimeDurationColumnIndex = Convert.ToInt32(config.AppSettings.Settings["TimeDurationColumn"].Value);
            TimesPerDayColumnIndex = Convert.ToInt32(config.AppSettings.Settings["TimesPerDayColumn"].Value);
            MorningCheckBoxColumnIndex = Convert.ToInt32(config.AppSettings.Settings["MorningCheckBoxColumn"].Value);
            AfternoonCheckBoxColumnIndex = Convert.ToInt32(config.AppSettings.Settings["AfternoonCheckBoxColumn"].Value);
            EventnoonCheckBoxColumnIndex = Convert.ToInt32(config.AppSettings.Settings["EveningCheckBoxColumn"].Value);
            DosagePerTime_ValueColumnIndex = Convert.ToInt32(config.AppSettings.Settings["DosagePerTimeValueColumn"].Value);
            DosagePerTime_UnitColumnIndex = Convert.ToInt32(config.AppSettings.Settings["DosageUnitColumn"].Value);
            UsageColumnIndex = Convert.ToInt32(config.AppSettings.Settings["UsageColumn"].Value);
            DrugInstructionColumnIndex = Convert.ToInt32(config.AppSettings.Settings["DrugInstructionColumn"].Value);

            InitializeUsageComboBox();
            InitializeDosageUnitComboBox();
        }
        public void InitializeDoctorInformation()
        {
            this.doctorNameTextBox.Text = DoctorInfomation.Name;
            this.DoctorIDtextBox.Text = DoctorInfomation.ID;
            this.depTextBox.Text = DoctorInfomation.Department;
        }
        private void InitializeUsageComboBox()
        {
            this.usageComboBox.Items.AddRange(Models.CommonData.DefaultValuesSet.UsageComboBoxValues);
        }
        private void InitializeDosageUnitComboBox()
        {
            this.dosageUnitComboBox.Items.AddRange(Models.CommonData.DefaultValuesSet.DosageUnitComboBoxValues);
        }
        /// <summary>
        /// load drug information from gridview row selected 
        /// </summary>
        private void LoadFromUpdatingDateGridViewRowToForm(UpdatingDrugForm form)
        {
            form.DrugIDTextBoxValue = updatingRow.Cells[DrugIDColumnIndex].Value as string;
            form.DrugNameTextBoxValue = updatingRow.Cells[DrugNameColumnIndex].Value as string;
            form.TimeDurationTextBoxValue = updatingRow.Cells[TimeDurationColumnIndex].Value as string;
            form.MorningCheckBoxValue = Convert.ToBoolean((updatingRow.Cells[MorningCheckBoxColumnIndex] as DataGridViewCheckBoxCell).FormattedValue);
            form.AfternoonCheckBoxValue = Convert.ToBoolean((updatingRow.Cells[AfternoonCheckBoxColumnIndex] as DataGridViewCheckBoxCell).FormattedValue);
            form.EveningCheckBoxValue = Convert.ToBoolean((updatingRow.Cells[EventnoonCheckBoxColumnIndex] as DataGridViewCheckBoxCell).FormattedValue);
            form.DosagePerTimeTextBoxValue = updatingRow.Cells[DosagePerTime_ValueColumnIndex].Value as string;
            form.DosageUnitComboBoxValue = updatingRow.Cells[DosagePerTime_UnitColumnIndex].Value as string;
            form.UsageComboBoxValue = updatingRow.Cells[UsageColumnIndex].Value as string;
            form.InstructionTextBoxValue = updatingRow.Cells[DrugInstructionColumnIndex].Value as string;
        }

        /// <summary>
        /// Create A New DataGridView Row to insert
        /// </summary>
        /// <returns>
        /// A New DataGridView Row
        /// </returns>
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
            DataGridViewTextBoxCell drugIDTextBoxCell = new DataGridViewTextBoxCell();
            drugIDTextBoxCell.Value = this.drugIDTextBox.Text;
            newRow.Cells.Add(drugIDTextBoxCell);

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
            DataGridViewTextBoxCell drugNameCell = new DataGridViewTextBoxCell();
            drugNameCell.Value = this.drugNameTextBox.Text;
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
            DataGridViewTextBoxCell dosagePerTimeUnitTextBoxCell = new DataGridViewTextBoxCell();
            dosagePerTimeUnitTextBoxCell.Value = this.dosageUnitComboBox.Text;
            newRow.Cells.Add(dosagePerTimeUnitTextBoxCell);
            //the usage of drug column item
            DataGridViewTextBoxCell usageTextBoxCell = new DataGridViewTextBoxCell();
            usageTextBoxCell.Value = usageComboBox.Text;
            newRow.Cells.Add(usageTextBoxCell);
            //the instruction of drug column item
            DataGridViewTextBoxCell instrucationValueTextBoxCell = new DataGridViewTextBoxCell();
            instrucationValueTextBoxCell.Value = this.instructionTextBox.Text;
            newRow.Cells.Add(instrucationValueTextBoxCell);
            return newRow;
        }
        private DataGridViewRow CreateDateGridViewRowByObject(DrugClass obj)
        {
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
            DataGridViewTextBoxCell drugIDTextBoxCell = new DataGridViewTextBoxCell();
            drugIDTextBoxCell.Value = obj.DrugID;
            newRow.Cells.Add(drugIDTextBoxCell);

            //drug name column item
            DataGridViewTextBoxCell drugNameCell = new DataGridViewTextBoxCell();
            drugNameCell.Value = obj.DrugName;
            newRow.Cells.Add(drugNameCell);

            //time duration column item
            DataGridViewTextBoxCell timeDurationTextBoxCell = new DataGridViewTextBoxCell();
            timeDurationTextBoxCell.Value = Convert.ToString(obj.TimeDuration);
            newRow.Cells.Add(timeDurationTextBoxCell);
            //times per day column item
            DataGridViewTextBoxCell timesPerDayTextBoxCell = new DataGridViewTextBoxCell();
            timesPerDayTextBoxCell.Value = obj.TimesPerDay;
            newRow.Cells.Add(timesPerDayTextBoxCell);
            //아침에 약 먹는 지에 대한 checkbox
            DataGridViewCheckBoxCell MorningCheckBoxCell = new DataGridViewCheckBoxCell();
            MorningCheckBoxCell.Value = obj.WhenMorning;
            newRow.Cells.Add(MorningCheckBoxCell);
            //점심에 약 먹는 지에 대한 checkbox
            DataGridViewCheckBoxCell AfternoonCheckBoxCell = new DataGridViewCheckBoxCell();
            AfternoonCheckBoxCell.Value = obj.WhenAfternoon;
            newRow.Cells.Add(AfternoonCheckBoxCell);
            //저녁에 약 먹는 지에 대한 checkbox
            DataGridViewCheckBoxCell EveningCheckBoxCell = new DataGridViewCheckBoxCell();
            EveningCheckBoxCell.Value = obj.WhenEvening;
            newRow.Cells.Add(EveningCheckBoxCell);
            //the value of dosage per time column item
            DataGridViewTextBoxCell dosagePerTimeValueTextBoxCell = new DataGridViewTextBoxCell();
            dosagePerTimeValueTextBoxCell.Value = Convert.ToString(obj.DosagePerTime_Value);
            newRow.Cells.Add(dosagePerTimeValueTextBoxCell);
            //the unit of dosage per time column item
            DataGridViewTextBoxCell dosagePerTimeUnitTextBoxCell = new DataGridViewTextBoxCell();
            dosagePerTimeUnitTextBoxCell.Value = obj.DosagePerTime_Unit;
            newRow.Cells.Add(dosagePerTimeUnitTextBoxCell);
            //the usage of drug column item
            DataGridViewTextBoxCell usageTextBoxCell = new DataGridViewTextBoxCell();
            usageTextBoxCell.Value = obj.Usage;
            newRow.Cells.Add(usageTextBoxCell);
            //the instruction of drug column item
            DataGridViewTextBoxCell instrucationValueTextBoxCell = new DataGridViewTextBoxCell();
            instrucationValueTextBoxCell.Value = obj.Instruction;
            newRow.Cells.Add(instrucationValueTextBoxCell);
            return newRow;
        }
        /***
         * Check if doctor is doing prescription work, and return T/F
         * By: MRMRMRMAY
         * creation date:17-12-28
         ***/
        private bool IsDoingPrescriptionWork()
        {
            return this.drugNameTextBox.Text != ""
                || this.timeDurationTextBox.Text != "" || this.dosagePerTimeTextBox.Text != ""
                || this.moringCheckBox.Checked || this.afternoonCheckBox.Checked || this.eveningCheckBox.Checked
                || !string.IsNullOrWhiteSpace(this.instructionTextBox.Text) || this.usageComboBox.Text != ""
                || this.prescriptionIDLabel.Text != "" || !string.IsNullOrWhiteSpace(this.symptomDescriptionTextBox.Text);
        }
        /***
         * load next patient information into gui
         ***/
        private void LoadPatientInformation()
        {
            //Models.PatientClass patient = new Models.PatientClass();
            //patient.Name = "홍기동";
            //patient.Age = "" + 21;
            //patient.Birthday = "1996-12-27";
            //patient.PatientID = "P100171227150211";
            //patient.Sex = "M";
            //patient.SymptomDescription = "unknown";
            Models.PatientClass patient = DAO.PatientDB.RandomGetPatient();
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
        /// <summary>
        /// clear controls in the input block
        /// </summary>
        private void ClearInputBlock()
        {
            this.drugNameTextBox.Clear();
            this.drugIDTextBox.Clear();
            this.timeDurationTextBox.Clear();
            this.dosagePerTimeTextBox.Clear();
            this.dosageUnitComboBox.Text = "";
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
            SetVariable();
            if (haveToSave)
            {
                DialogResult result = MessageBox.Show("저장되지 않은 처방전이 있습니다.\n저장하고 다음 환자를 부르겠십니까?\n\"예\"는 저장하고 다음 환자를 부르겠습니다.\n\"아니오\"는 저장하지 않고 다음 환자를 부르겠습니다.\n\"Cancel\"는 아무것도 하지 못합니다.", "Calling Form", MessageBoxButtons.YesNoCancel);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    SavePrescriptionToFile();
                    ClearInputBlock();
                    this.symptomDescriptionTextBox.Clear();
                    this.drugInfoDataGridView.Rows.Clear();
                    ClearVariable();
                    LoadPatientInformation();
                }
                else if(result == System.Windows.Forms.DialogResult.No)
                {
                    ClearInputBlock();
                    this.symptomDescriptionTextBox.Clear();
                    this.drugInfoDataGridView.Rows.Clear();
                    ClearVariable();
                    LoadPatientInformation();
                }
            }
            else if (IsDoingPrescriptionWork())
            {
                DialogResult result = MessageBox.Show("처리하고 있는 처방전이 있습니다.\n저장하지 않고 다음 환자를 부르겠십니까?\n\"예\"는 저장하지 안고 다음 환자를 부르겠습니다.\n\"아니오\"와 \"Cancel\"는 아무것도 하지 못합니다", "Calling Form", MessageBoxButtons.YesNoCancel);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    ClearInputBlock();
                    this.symptomDescriptionTextBox.Clear();
                    this.drugInfoDataGridView.Rows.Clear();
                    ClearVariable();
                    LoadPatientInformation();
                }
            }
            else
            {
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
                this.moringCheckBox.Focus();
            }
            else if (string.IsNullOrWhiteSpace(this.dosagePerTimeTextBox.Text))
            {
                msg = "1회 투약 량을 입력하십시오!";
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
            else if (InsertDrugNameRepetationCheck())
            {
                msg = string.Format("약품 {0} 이미 있습니다", this.drugNameTextBox.Text);
            }
            else if (!string.IsNullOrWhiteSpace(dosagePerTimeTextBox.Text))
            {
                var subStr = dosagePerTimeTextBox.Text.Split('.');
                if (subStr.Count() == 2 && string.IsNullOrWhiteSpace(subStr[1]))
                {
                    msg = "입력한 것은 소수이면 소수점 아래 세째 자리끼지만 입력할 수 있습니다.";
                    this.dosagePerTimeTextBox.Focus();
                }
            }
            if (!string.IsNullOrWhiteSpace(msg))
                MessageBox.Show(msg, "Inserting Form");
            else
            {
                insertNewRow();
                ClearInputBlock();
                haveToSave = true;
            }
        }
        private bool UpdateDrugFormFeedback(string drugName, string drugID, string timeDruation, string timesPerDay, bool morning, bool afternoon, bool evening, string dosagePerTime, string dosageUnit, string usage, string instrucation)
        {
            if (UpdateDrugNameRepetationCheck(drugName))
            {
                string msg = string.Format("{0} drug list에 이미 존재하고 있습니다",drugName);
                MessageBox.Show(msg, "Error Message Dialog Form");
                return false;
            }
            updatingRow.Cells[DrugNameColumnIndex].Value = drugName;
            updatingRow.Cells[DrugIDColumnIndex].Value = drugID;
            updatingRow.Cells[TimeDurationColumnIndex].Value = timeDruation;
            (updatingRow.Cells[MorningCheckBoxColumnIndex] as DataGridViewCheckBoxCell).Value = morning;
            (updatingRow.Cells[AfternoonCheckBoxColumnIndex] as DataGridViewCheckBoxCell).Value = afternoon;
            (updatingRow.Cells[EventnoonCheckBoxColumnIndex] as DataGridViewCheckBoxCell).Value = evening;
            updatingRow.Cells[TimesPerDayColumnIndex].Value = timesPerDay;
            updatingRow.Cells[DosagePerTime_ValueColumnIndex].Value = dosagePerTime;
            updatingRow.Cells[DosagePerTime_UnitColumnIndex].Value = dosageUnit;
            updatingRow.Cells[UsageColumnIndex].Value = usage;
            updatingRow.Cells[DrugInstructionColumnIndex].Value = instrucation;
            return true;
        }
        private void updateBtnEventHandle(int row)
        {
            string str = string.Format("row: {0} 의 ", row + 1);
            updatingRow = this.drugInfoDataGridView.Rows[row];
            UpdatingDrugForm updatingDrugForm = new UpdatingDrugForm();
            LoadFromUpdatingDateGridViewRowToForm(updatingDrugForm);
            updatingDrugForm.updateEventHandle += UpdateDrugFormFeedback;
            var result = updatingDrugForm.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK && !haveToSave)
                haveToSave = true;
            updatingRow = null;
            //str += "수정 button";
            //MessageBox.Show(str);
        }
        private void drugInfoDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            if (row == -1) return;
            if (this.drugInfoDataGridView.Rows.Count == 0||this.drugInfoDataGridView.Rows[row].Cells[col].ReadOnly)
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
                        //string str = string.Format("row: {0} 의 ", row + 1);
                        //str += "삭제 button";
                        //MessageBox.Show(str);
                        if(MessageBox.Show("삭제하시겠습니까?","deleting form",MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            this.drugInfoDataGridView.Rows.RemoveAt(row);
                        if (drugInfoDataGridView.Rows.Count <= 0)
                        {
                            haveToSave = false;
                        }
                        break;
                    }
                case 3:
                    {
                        selectedDrugNameCell = (DataGridViewButtonCell)this.drugInfoDataGridView.Rows[row].Cells[col];
                        lastDrugNameTextBoxCellValue = selectedDrugNameCell.Value.ToString();
                        UpdateDrug();
                        break;
                    }
                //case 5:
                //case 6:
                //case 7:
                //    {
                       
                //        MessageBox.Show(""+this.drugInfoDataGridView.Rows[row].Cells[col].EditedFormattedValue);
                //        break;
                //    }
            }
        }
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
            if (this.drugInfoDataGridView.Rows.Count <= 0) {
                MessageBox.Show("처방 약품을 가입 하십시오", "Saving Form");
            }
            else if (string.IsNullOrWhiteSpace(this.symptomDescriptionTextBox.Text))
            {
                var msg = "진단결과를 입력해주십시오!";
                MessageBox.Show(msg, "Saving Form");
                this.symptomDescriptionTextBox.Focus();
            }
            else if (MessageBox.Show("저장 하시곘습니까?", "Saving", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {

                SavePrescriptionToFile();
            }
        }
        private void SavePrescriptionToFile()
        {
            Models.PrescriptionClass prescriptionObj = new Models.PrescriptionClass();
            prescriptionObj.PrescriptionID = this.prescriptionIDLabel.Text;
            Models.PatientClass patientObj = new Models.PatientClass();
            patientObj.Name = this.patientNameTextBox.Text;
            patientObj.Age = this.patientAgeTextBox.Text;
            patientObj.Sex = this.patientSexTextBox.Text;
            patientObj.PatientID = this.patientIDTextBox.Text;
            patientObj.SymptomDescription = this.symptomDescriptionTextBox.Text;
            prescriptionObj.Patient = patientObj;

            prescriptionObj.Date = String.Format("{0:yyMMddHHmmss}", this.dateTextBox.Text);

            Models.DoctorClass docObj = new Models.DoctorClass();
            docObj.Name = this.doctorNameTextBox.Text;
            docObj.ID = this.DoctorIDtextBox.Text;
            docObj.Department = this.depTextBox.Text;
            prescriptionObj.Doctor = docObj;

            List<Models.DrugClass> drugList = new List<Models.DrugClass>();
            foreach (DataGridViewRow row in drugInfoDataGridView.Rows)
            {
                //DataGridViewRow currentRow = this.drugInfoDataGridView.Rows[row];
                Models.DrugClass drugObj = new Models.DrugClass();
                drugObj.DrugID = row.Cells[DrugIDColumnIndex].Value.ToString();
                drugObj.DrugName = row.Cells[DrugNameColumnIndex].Value.ToString();
                drugObj.TimeDuration = row.Cells[TimeDurationColumnIndex].Value.ToString();
                drugObj.TimesPerDay = row.Cells[TimesPerDayColumnIndex].Value.ToString();
                drugObj.WhenMorning = Convert.ToBoolean(row.Cells[MorningCheckBoxColumnIndex].FormattedValue.ToString());
                drugObj.WhenAfternoon = Convert.ToBoolean(row.Cells[AfternoonCheckBoxColumnIndex].FormattedValue.ToString());
                drugObj.WhenEvening = Convert.ToBoolean(row.Cells[EventnoonCheckBoxColumnIndex].FormattedValue.ToString());
                drugObj.DosagePerTime_Value = row.Cells[DosagePerTime_ValueColumnIndex].Value.ToString();
                drugObj.DosagePerTime_Unit = row.Cells[DosagePerTime_UnitColumnIndex].Value.ToString();
                drugObj.Usage = row.Cells[UsageColumnIndex].Value.ToString();
                drugObj.Instruction = row.Cells[DrugInstructionColumnIndex].Value.ToString();
                drugList.Add(drugObj);
            }
            prescriptionObj.Drugs = drugList;
            DAO.SavePrescriptionInfoAsXMLFile saveXmlFile = new DAO.SavePrescriptionInfoAsXMLFile();
            string fileName = patientObj.PatientID + "_" + prescriptionObj.PrescriptionID + @".xml";
            string filePath = config.AppSettings.Settings[Models.CommonData.DefaultValuesSet.prescriptionPathKey].Value;
            if (!System.IO.Directory.Exists(filePath))
            {
                System.IO.Directory.CreateDirectory(filePath);
            }
            filePath = filePath + @"\" + fileName;
            XmlSerializer.SaveToXml(filePath, prescriptionObj, typeof(PrescriptionClass));
            if (haveToSave)
                haveToSave = false;
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
                if (this.drugNameTextBox.Text.Equals(row.Cells[DrugNameColumnIndex].Value))
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
                else if (value.Equals(row.Cells[DrugNameColumnIndex].Value))
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
        private bool UpdateDrugSearchResult(string value, string ID)
        {
            if (UpdateDrugNameRepetationCheck(value))
            {
                string msg = string.Format("{0} 이미 있습니다.\n 하고 있는 수정처리을 취소하시겠니까?", value);
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
            this.updatingRow.Cells[DrugIDColumnIndex].Value = ID; 
            return true;
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

        private void dosagePerTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            
            TextBox obj = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(obj.Text))
            {
                this.dosageUnitComboBox.Enabled = false;
            }
            else if(!this.dosageUnitComboBox.Enabled)
            {
                this.dosageUnitComboBox.Enabled = true;
            }
        }
        private void LoadPrescriptionAction(Models.PrescriptionClass obj){
            this.DoctorIDtextBox.Text = obj.Doctor.ID;
            this.doctorNameTextBox.Text = obj.Doctor.Name;
            this.patientIDTextBox.Text = obj.Patient.PatientID;
            this.patientNameTextBox.Text = obj.Patient.Name;
            this.patientSexTextBox.Text = obj.Patient.Sex;
            this.symptomDescriptionTextBox.Text = obj.Patient.SymptomDescription;
            this.patientAgeTextBox.Text = obj.Patient.Age;
            this.drugInfoDataGridView.Rows.Clear();
            this.prescriptionIDLabel.Text = obj.PrescriptionID ;
            foreach (DrugClass drug in obj.Drugs)
            {
                drugInfoDataGridView.Rows.Add(CreateDateGridViewRowByObject(drug));
                this.drugInfoDataGridView.RowsAdded += drugInfoDataGridView_RowsAdded;
            }
        }
        private void SetVariable()
        {
            if (isFirstWork)
            {
                this.warningMessageLabel.Visible = false;
                SetDrugInfoInputBlockControlsEnableState();
                SetPatientInfoInputBlockControlsEnableState();
                isFirstWork = false;
            }
        }
        private void loadButton_Click(object sender, EventArgs e)
        {
            if (haveToSave)
            {
                DialogResult result = MessageBox.Show("You have a prescription work need to be saved.\n Are you sure to load other prescription?",
                    "Warning Form", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }
            else if (this.IsDoingPrescriptionWork())
            {
                DialogResult result = MessageBox.Show("You are doing prescription work.\n Are you sure to load other prescription?",
                    "Warning Form", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }
            string dirpath = config.AppSettings.Settings["prescriptionPath"].Value;
            if (!System.IO.Directory.Exists(dirpath) || System.IO.Directory.GetFiles(dirpath).Count() <= 0)
            {
                MessageBox.Show("There is no prescription file.", "loading form");
            }
            else
            {
                PrescriptionFileListForm form = new PrescriptionFileListForm();
                form.LoadPrescriptionEvent += LoadPrescriptionAction;
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ClearInputBlock();
                    ClearVariable();
                    SetVariable();
                }
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            if (IsDoingPrescriptionWork())
            {
                DialogResult result = MessageBox.Show("저장되지 않은 처방전이 있습니다.\n저장하지 않고 EXIT를 하겠십니까?", "Saving Form", MessageBoxButtons.YesNoCancel);
                if (result != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
            }
            this.Close();
        }
    }
}
