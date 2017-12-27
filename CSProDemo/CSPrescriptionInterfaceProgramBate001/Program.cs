using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSPrescriptionInterfaceProgramBate001
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Views.PrescriptionInterfaceForm prescriptionInterfaceForm = new Views.PrescriptionInterfaceForm();
            Models.DoctorClass doctor = new Models.DoctorClass();
            doctor.Name = "신라";
            doctor.ID = "D100171227173011";
            doctor.Department = "내과";
            doctor.Age = null;
            doctor.Birthday = null;
            doctor.Sex = null;
            doctor.ResidentRegistrationNumber = null;
            doctor.Password = null;
            prescriptionInterfaceForm.DoctorInfomation = doctor;
            prescriptionInterfaceForm.InitializeDoctorInformation();
            //prescriptionInterfaceForm.DoctorInfomation = doctor;
            Application.Run(prescriptionInterfaceForm);
        }
    }
}
