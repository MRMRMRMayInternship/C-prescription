using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfProDemo.Views
{
    /// <summary>
    /// DoctorInfoBlock.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DoctorInfoBlock : UserControl
    {
        private Doctor_InfoDataModel doctor;
        private string id;
        public DoctorInfoBlock()
        {
            InitializeComponent();
            id = StaticMethod.ConfigManagement.GetConfigValue(StaticMethod.ConfigManagement.ConfigSettingDoctorKey);
            using (PIPusingWPFModel.PIPEntities pip = new PIPusingWPFModel.PIPEntities())
            {
                try
                {
                    PIPusingWPFModel.Doctor temp = pip.Doctors.Where(a => a.Did.Equals(id)).First();
                    if (temp != null)
                        doctor = new Doctor_InfoDataModel() { ID = id, Department = temp.Department, Name = temp.Name };
                    else doctor = new Doctor_InfoDataModel();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            this.Loaded += DoctorInfoBlock_Loaded;

            this.DoctorName.SetBinding(Label.ContentProperty, new Binding("Name") { Source = doctor, Mode = BindingMode.OneWay });
            this.DoctorID.SetBinding(Label.ContentProperty, new Binding("ID") { Source = doctor, Mode = BindingMode.OneWay });
            this.Department.SetBinding(Label.ContentProperty, new Binding("Department") { Source = doctor, Mode = BindingMode.OneWay });
        }
        public void DoctorInfoBlock_Loaded(object send, RoutedEventArgs args){
        }
    }
    public class Doctor_InfoDataModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private string _Name;
        public string Name
        {
            get { return string.IsNullOrEmpty(_Name) ? string.Empty : _Name; }
            set
            {
                _Name = string.IsNullOrEmpty(value) ? string.Empty : value;
                RaisePropertyChanged("Name");
            }
        }
        private string _Department;
        public string Department
        {
            get { return string.IsNullOrEmpty(_Department) ? string.Empty : _Department; }
            set
            {
                _Department = string.IsNullOrEmpty(value) ? string.Empty : value;
                RaisePropertyChanged("Department");
            }
        }
        private string _ID;
        public string ID
        {
            get { return string.IsNullOrEmpty(_ID) ? string.Empty : _ID; }
            set
            {
                _ID = string.IsNullOrEmpty(value) ? string.Empty : value;
                RaisePropertyChanged("ID");
            }
        }
    }
}
