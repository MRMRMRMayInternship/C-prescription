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
using System.Windows.Shapes;

namespace WpfProDemo.Views
{
    /// <summary>
    /// LoginWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginWindow : Window
    {
        private DAO.LoginEventHandle loginEventHandle = new DAO.LoginEventHandle();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnExit_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private bool CheckIdAndPassword()
        {
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
                //MainWindow mainWindow = new MainWindow();
                //mainWindow.Owner = this;
                Window mainWindow = new Window();
                
                this.Hide();
                var isLogout = mainWindow.ShowDialog();
                this.idTextBox.Clear();
                this.pwTextBox.Clear();
                this.Show();
            }
            else
            {
                System.Windows.MessageBox.Show("login error");
            }
        }
    }
}
