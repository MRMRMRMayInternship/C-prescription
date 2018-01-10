using System;
using System.Collections.Generic;
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
    /// LoginPage.xaml에 대한 상호 작용 논리
    /// 对于app.config的读写参考： http://blog.xieyc.com/csharp-read-and-write-configuration-file-app-config/
    /// </summary>
    public partial class LoginPage : Page
    {
        private DAO.LoginEventHandle loginEventHandle = new DAO.LoginEventHandle();
        private MainWindow parentWindow = null;
        private System.Configuration.Configuration config;
        public MainWindow ParentWindow
        {
            get
            {
                return this.parentWindow;
            }
            set
            {
                this.parentWindow = value;
            }
        }
        public LoginPage()
        {
            InitializeComponent();
            config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
        }
        private void BtnExit_Clicked(object sender, RoutedEventArgs e)
        {
            this.parentWindow.Close();
        }
        private bool CheckIdAndPassword()
        {
            return true;
            bool isValid = false;
            var id = idTextBox.Text;
            var pw = pwTextBox.Password;
            if (!string.IsNullOrWhiteSpace(id) && !string.IsNullOrWhiteSpace(pw))
                isValid = loginEventHandle.IsValid(id, pw);
            return isValid;
        }
        private void BtnLogin_Clicked(object sender, RoutedEventArgs e)
        {
            if (CheckIdAndPassword())
            {
                //this.idTextBox.Clear();
                //this.pwTextBox.Clear();
                //var id = idTextBox.Text;
                var id = "root";
                try {
                    StaticMethod.ConfigManagement.SetConfigValue(StaticMethod.ConfigManagement.ConfigSettingDoctorKey, id).ToString();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.ParentWindow.CallMenuPage();
            }
            else
            {
                System.Windows.MessageBox.Show("login error");
            }
        }
    }
}
