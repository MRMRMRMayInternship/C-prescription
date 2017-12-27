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
        readonly string[] KEYS = { "수정/증가", "약품 ID", "약품 명칭", "충 투약일수", "1일 투약횟수", "1회 투약 량", "용법", "Col8", "Col9" };
        private DataGridViewRow updatingRow = null; 
        private string lastDrugName = null;
        public Models.DoctorClass DoctorInfomation
        {
            set;
            get;
        }
        public PrescriptionInterfaceForm()
        {
            InitializeComponent();
            InitializeDrugNamesComboBox();
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
            this.usageComboBox.Items.AddRange(new string[] {"os", "n" });
        }
        private void InitializeDrugNamesComboBox()
        {
            this.drugNamesComboBox.Items.AddRange(new String[] { "a", "s", "d" });
        }
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

            //drug ID column item
            DataGridViewTextBoxCell drugIDTextBoxCell = new DataGridViewTextBoxCell();
            drugIDTextBoxCell.Value = this.drugIDTextBox.Text;
            newRow.Cells.Add(drugIDTextBoxCell);

            //drug name column item
            DataGridViewComboBoxCell drugNameComboBoxCell = new DataGridViewComboBoxCell();
            for (int i = 0; i < drugNamesComboBox.Items.Count; i++)
                drugNameComboBoxCell.Items.Add(drugNamesComboBox.Items[i].ToString());
            drugNameComboBoxCell.Value = this.drugNamesComboBox.SelectedItem.ToString();
            newRow.Cells.Add(drugNameComboBoxCell);
            //time duration column item
            DataGridViewTextBoxCell timeDurationTextBoxCell = new DataGridViewTextBoxCell();
            timeDurationTextBoxCell.Value = this.timeDurationTextBox.Text;
            newRow.Cells.Add(timeDurationTextBoxCell);
            //times per day column item
            DataGridViewTextBoxCell timesPerDayTextBoxCell = new DataGridViewTextBoxCell();
            timesPerDayTextBoxCell.Value = this.timesPerDayTextBox.Text;
            newRow.Cells.Add(timesPerDayTextBoxCell);
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

        private void callNextPatientButton_Click(object sender, EventArgs e)
        {
            if (this.drugInfoDataGridView.Rows.Count > 0)
            {
                
                DialogResult result = MessageBox.Show("저장되지 않은 처방전이 있습니다.\n저장하겠십니까?", "Saving Form", MessageBoxButtons.YesNoCancel);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    this.drugInfoDataGridView.Rows.Clear();
                }
            }
            else
            {
                Models.PatientClass patient = new Models.PatientClass();
                patient.Name = "홍기동";
                patient.Age = ""+21;
                patient.Birthday = "1996-12-27";
                patient.PatientID = "P100171227150211";
                patient.Sex = "M";
                //patient.SymptomDescription = "unknown";
                loadPatientInfo(patient);
                this.prescriptionIDLabel.Text = String.Format("RX100{0:yyMMddHHmmss}", System.DateTime.Now);
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
        }
        private void insertButton_Click(object sender, EventArgs e)
        {
            if (this.timeDurationTextBox.Text == "" ||
                this.drugNamesComboBox.Text == "" ||
                this.dosagePerTimeTextBox.Text == "" ||
                this.dosageUnitComboBox.Text == "" ||
                this.instructionTextBox.Text == "" ||
                this.usageComboBox.Text == "")
                MessageBox.Show("entry info");
            else 
                insertNewRow();
        }

        private void drugInfoDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            string str = string.Format("row: {0} 의 ",row+1);
            switch (col)
            {
                case 0:
                    {
                        if(this.drugInfoDataGridView.Rows[row].Cells[0].Value.Equals("수정")){
                            if (updatingRow != null)
                            {
                                MessageBox.Show("수정하고 있는 row있습니다.");
                                break;
                            }
                            updatingRow = this.drugInfoDataGridView.Rows[row];
                            for(int i = 3 ; i < this.drugInfoDataGridView.Rows[row].Cells.Count; i++){
                                this.drugInfoDataGridView.Rows[row].Cells[i].ReadOnly = false;
                            }
                            str += "수정 button";
                            MessageBox.Show(str);
                            this.drugInfoDataGridView.Rows[row].Cells[0].Value = "확인";
                        }
                        else
                        {
                            for (int i = 3; i < this.drugInfoDataGridView.Rows[row].Cells.Count; i++)
                            {
                                this.drugInfoDataGridView.Rows[row].Cells[i].ReadOnly = true;
                            }
                            str += "확인 button";
                            MessageBox.Show(str);
                            this.drugInfoDataGridView.Rows[row].Cells[0].Value = "수정";
                            updatingRow = null;   
                        }
                        break;
                    }
                case 1:
                    {
                        str += "삭제 button";
                        MessageBox.Show(str);
                        if(MessageBox.Show("삭제하시겠습니까?","deleting form",MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            this.drugInfoDataGridView.Rows.RemoveAt(row);
                        break;
                    }
                case 3:
                    {
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
            lastDrugName = this.drugNamesComboBox.SelectedItem.ToString();
            this.drugIDTextBox.Text = findDrugIDByDrugName(lastDrugName);
        }
         **/
        private void drugNamesComboBox_LostFocus(object sender, System.EventArgs e)
        {
            for (int i = 0; i < drugNamesComboBox.Items.Count; i++)
            {
                if (drugNamesComboBox.Text.Equals(drugNamesComboBox.Items[i].ToString()))
                {
                    lastDrugName = drugNamesComboBox.Text;
                    throw new System.NotImplementedException();
                }
            }
            MessageBox.Show("error");
            drugNamesComboBox.Text = lastDrugName;
            throw new System.NotImplementedException();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Models.PrescriptionClass prescriptionObj = new Models.PrescriptionClass();
            
            prescriptionObj.PrescriptionID = 
            prescriptionObj.Patient.Name = this.patientNameTextBox.Text;
            prescriptionObj.Patient.Age = this.patientAgeTextBox.Text;
            prescriptionObj.Patient.Sex = this.patientSexTextBox.Text;
            prescriptionObj.Patient.PatientID = this.patientIDTextBox.Text;
            prescriptionObj.Patient.SymptomDescription = this.symptomDescriptionTextBox.Text;
            

            prescriptionObj.Date = this.dateTextBox.Text;
            prescriptionObj.Docotr.Name = this.doctorNameTextBox.Text;
            prescriptionObj.Docotr.ID = this.DoctorIDtextBox.Text;
            prescriptionObj.Docotr.Department = this.depTextBox.Text;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.dateTextBox.Text = String.Format("{0:G}",System.DateTime.Now);
        }
    }
}
