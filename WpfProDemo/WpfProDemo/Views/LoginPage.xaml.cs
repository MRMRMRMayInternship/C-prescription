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
            this.Loaded += LoginPage_Loaded;
            this.pwTextBox.PreviewTextInput += PreviewTextInput_Handle;
            this.idTextBox.PreviewTextInput += PreviewTextInput_Handle;
            this.idTextBox.KeyDown += idTextBox_KeyDown;
            this.pwTextBox.KeyDown += pwTextBox_KeyDown;
        }

        void pwTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
                BtnLogin_Clicked(null, null);
        }

        void idTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
                pwTextBox.Focus();
        }

        private void PreviewTextInput_Handle(object sender, TextCompositionEventArgs e)
        {
            string exp = @"[1-9a-zA-Z]|[\b]";
            if (!System.Text.RegularExpressions.Regex.IsMatch("" + e.Text, exp))
            {
                e.Handled = true;
            }
        }

        void LoginPage_Loaded(object sender, RoutedEventArgs e)
        {
            
            if(pwTextBox.Password.Count() > 0)
                this.pwTextBox.Clear();
            if(idTextBox.Text.Count() > 0)
                this.idTextBox.Clear();
            this.idTextBox.Focus();
        }
        private void BtnExit_Clicked(object sender, RoutedEventArgs e)
        {
            this.parentWindow.Close();
        }
        private bool CheckIdAndPassword(string id, string pw)
        {
            //return true;
            bool isValid = false;
            if (!string.IsNullOrWhiteSpace(id) && !string.IsNullOrWhiteSpace(pw))
                isValid = DAO.LoginEventHandle.IsValid(id, pw);
            return isValid;
        }
        private void BtnLogin_Clicked(object sender, RoutedEventArgs e)
        {
            var id = idTextBox.Text;
            var pw = pwTextBox.Password;
            if (CheckIdAndPassword(id,pw))
            {
                //var id = "root";
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
                idTextBox.Focus();
                System.Windows.MessageBox.Show("login error");
            }
        }
    }
}
