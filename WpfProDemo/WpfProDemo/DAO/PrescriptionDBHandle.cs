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
        private static CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-US");


        public static bool InsertPrescriptionFromXML(Models.PrescriptionClass obj)
        {
            using (PIPusingWPFModel.PIPEntities conn = new PIPusingWPFModel.PIPEntities())
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
                    MessageBox.Show("InsertPrescriptionFromXML:" + e.Message +"\n" + e.StackTrace);
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 根据处方ID删除处方
        /// </summary>
        /// <param name="prescriptionID"></param>
        /// <returns></returns>
        public static bool DeletePrescriptionByPrescriptionID(string prescriptionID)
        {
            using(PIPusingWPFModel.PIPEntities conn = new PIPusingWPFModel.PIPEntities()){
                try{
                    conn.Prescriptions.Remove(conn.Prescriptions.Where(p=>p.PrescriptionId.Equals(prescriptionID)).FirstOrDefault());
                    conn.SaveChanges();
                }catch(Exception ex){
                    return false;
                }
                return true;
            }
        }
        /// <summary>
        /// 转换药品类型
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="drug"></param>
        /// <returns></returns>
        private static PIPusingWPFModel.Drug xmlDrugObjToDBDrugObj(Models.PrescriptionClass obj,Models.DrugClass drug){
            return new PIPusingWPFModel.Drug()
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
        }
        /// <summary>
        /// 根据处方ID来删除处方药品
        /// </summary>
        /// <param name="prescriptionId"></param>
        /// <returns></returns>
        public static bool DeleteDrugByPrescriptionID(string prescriptionId)
        {
            using (PIPusingWPFModel.PIPEntities conn = new PIPusingWPFModel.PIPEntities())
            {
                try
                {
                    var delDrugObjCollection = conn.Drugs.Where(a => a.PrescriptionId.Equals(prescriptionId)).ToList();
                    conn.Drugs.RemoveRange(delDrugObjCollection);
                    conn.SaveChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }
                return true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool InsertDrugsByList(List<PIPusingWPFModel.Drug> list){
            using(PIPusingWPFModel.PIPEntities conn = new PIPusingWPFModel.PIPEntities()){
                try{
                    conn.Drugs.AddRange(list);
                    conn.SaveChanges();
                }catch(Exception ex){
                    return false;
                }
                return true;
            }
        }
        /// <summary>
        /// 同时更新药品及处方信息
        /// </summary>
        /// <param name="obj"></param>
        public static void UpdatePrescriptionAndDrugsTogether(Models.PrescriptionClass obj)
        {
            if (!InsertPrescriptionFromXML(obj))
                throw new Exception("InsertPrescriptionFromXML");
            List<PIPusingWPFModel.Drug> list = new List<PIPusingWPFModel.Drug>();
            foreach (var drug in obj.Drugs)
            {
                var AttachDrugObj = xmlDrugObjToDBDrugObj(obj, drug);
                list.Add(AttachDrugObj);
            }
            if (!InsertDrugsByList(list))
                throw new Exception("InsertDrugsByList");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool SaveInDB(Models.PrescriptionClass obj)
        {
            PIPusingWPFModel.Prescription result;
            using (PIPusingWPFModel.PIPEntities conn = new PIPusingWPFModel.PIPEntities())
            {
                try
                {
                    result = conn.Prescriptions.Where(a => a.PrescriptionId.Equals(obj.PrescriptionID)).FirstOrDefault();
                }
                catch (Exception e)
                {
                    //MessageBox.Show("Query : " + e.Message);
                    return false;
                }
            }
            //如果已经存在但有修改的地方，则先删除
            if (result != null)
            {
                var resultDate = Convert.ToDateTime(result.Date);
                var targetDate = Convert.ToDateTime(obj.Date);
                if (resultDate.Equals(targetDate))
                {
                    return true;
                }
                else
                {
                    try
                    {
                        if (!DeletePrescriptionByPrescriptionID(obj.PrescriptionID)) throw new Exception("DeletePrescriptionByPrescriptionID");
                        if (!DeleteDrugByPrescriptionID(obj.PrescriptionID)) throw new Exception("DeleteDrugByPrescriptionID");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("1:" + e.Message);
                        return false;
                    }
                }
            }
            try
            {
                UpdatePrescriptionAndDrugsTogether(obj);
            }
            catch (Exception e)
            {
                MessageBox.Show("3:" + e.Message);
                return false;
            }
            return true;

        }
    }
}
