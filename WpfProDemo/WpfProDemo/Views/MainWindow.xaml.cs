using Microsoft.Reporting.WinForms;
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
using System.Windows.Media.Animation;
namespace WpfProDemo.Views
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private LoginPage loginpage;
        private PrescriptionManagementPage pmPage;
        private MenuPage menuPage;
        public MainWindow()
        {
            InitializeComponent();
            InitializePages();
            this.Loaded += MainWindow_Loaded;
        }
        private void InitializePages(){
            loginpage = new LoginPage();
            loginpage.ParentWindow = this;
            pmPage = new PrescriptionManagementPage();
            pmPage.ParentWindow = this;
            menuPage = new MenuPage();
            menuPage.ParentWindow = this;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e){
            myFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            this.myFrame.Content = loginpage;
        }
        public void CallLoginPage()
        {
            this.myFrame.Content = loginpage;
        }
        public void CallPrescriptionManagementPage()
        {
            this.myFrame.Content = pmPage;
        }
        public void CallMenuPage()
        {
            this.myFrame.Content = menuPage;
        }

        private void ExitBtn_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
