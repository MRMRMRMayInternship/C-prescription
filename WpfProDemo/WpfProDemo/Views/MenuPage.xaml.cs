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
    /// MenuPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MenuPage : Page
    {
        private MainWindow parentWindow = null;
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
        public MenuPage()
        {
            InitializeComponent();
        }
        private void PrescriptionManagementBtn_Clicked(object sender, RoutedEventArgs e)
        {
            this.ParentWindow.CallPrescriptionManagementPage();
        }
    }
}
