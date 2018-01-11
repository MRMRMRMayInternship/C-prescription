using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfProDemo.DAO
{
    public static class PrescriptionDBHandle
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool SaveInDB(Models.PrescriptionClass obj)
        {
            using (PIPusingWPFModel.PIPEntities conn = new PIPusingWPFModel.PIPEntities())
            {
                CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-US");
                PIPusingWPFModel.Prescription result;
                try
                {
                    result = conn.Prescriptions.Where(a => a.PrescriptionId.Equals(obj.PrescriptionID)).FirstOrDefault();
                }
                catch (Exception e)
                {
                    //MessageBox.Show("Query : " + e.Message);
                    return false;
                }
                if (result != null)
                {
                    var resultDate = Convert.ToDateTime(result.Date);
                    var targetDate = Convert.ToDateTime(obj.Date);
                    if (resultDate.Equals(targetDate))
                    {
                        return true;
                    }
                    try
                    {
                        var delDrugObjCollection = conn.Drugs.Where(a => a.PrescriptionId.Equals(result.PrescriptionId)).ToList();
                        conn.Prescriptions.Remove(result);
                        conn.Drugs.RemoveRange(delDrugObjCollection);
                        conn.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("1:" + e.Message);
                        return false;
                    }
                }
                else
                {
                    var AttachPreObj = new PIPusingWPFModel.Prescription()
                    {
                        PrescriptionId = obj.PrescriptionID,
                        PatientId = obj.Patient.PatientID,
                        Did = obj.Doctor.ID,
                        Date = Convert.ToDateTime(obj.Date).ToString(cultureInfo),
                        Status = false,
                        Diagnosis = obj.Patient.SymptomDescription,
                        Doctor = conn.Doctors.Where(a => a.Did.Equals(obj.Doctor.ID)).FirstOrDefault(),
                        Patient = conn.Patients.Where(a => a.PatientId.Equals(obj.Patient.PatientID)).FirstOrDefault()
                    };
                    try
                    {
                        conn.Prescriptions.Add(AttachPreObj);
                        conn.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("2:" + e.Message);
                        return false;
                    }
                    List<PIPusingWPFModel.Drug> list = new List<PIPusingWPFModel.Drug>();
                    foreach (var drug in obj.Drugs)
                    {
                        var AttachDrugObj = new PIPusingWPFModel.Drug()
                        {
                            PrescriptionId = obj.PrescriptionID,
                            DrugName = drug.DrugName,
                            DosagePerTime = drug.DosagePerTime_Value + drug.DosagePerTime_Unit,
                            Instruction = drug.Instruction,
                            TimeDuration = drug.TimeDuration,
                            TimesPerDay = drug.TimesPerDay,
                            Usage = drug.Usage,
                            WhenAfternoon = drug.WhenAfternoon ? "√" : "x",
                            WhenEvening = drug.WhenEvening ? "√" : "x",
                            WhenMorning = drug.WhenMorning ? "√" : "x"
                        };
                        list.Add(AttachDrugObj);
                    }
                    try
                    {
                        conn.Drugs.AddRange(list);
                        conn.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("3:" + e.Message);
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
