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
    /// PrescriptonListBoxMaskLayer.xaml에 대한 상호 작용 논리
    /// </summary>
    public delegate void FileLoadLinkEvent();
    public partial class PrescriptionListBoxMaskLayer : UserControl
    {
        public FileLoadLinkEvent FileLoadLinkAction;
        public PrescriptionListBoxMaskLayer()
        {
            InitializeComponent();
            this.Loaded +=PrescriptionListBoxMaskLayer_Loaded;
        }

        private void PrescriptionListBoxMaskLayer_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadFileLink.Click += FileLoadLink_Clicked;
        }
        public void FileLoadLink_Clicked(object sender, RoutedEventArgs e){
            this.Visibility = System.Windows.Visibility.Collapsed;
            FileLoadLinkAction();
        }
    }
}
