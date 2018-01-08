﻿using System;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfProDemo.Views
{
    /// <summary>
    /// PrescriptionManagementPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PrescriptionManagementPage : Page
    {
        private MainWindow parentWindow;
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
        public PrescriptionManagementPage()
        {
            InitializeComponent();
        }
        private void btnExitApp_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                Uri uri = new System.Uri("LoginWindow.xaml", System.UriKind.Relative);
                MessageBox.Show("Test:" + uri.LocalPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnExit:" + ex.Message);
            }
            this.parentWindow.Close();
        }
        private void PrescriptionReportViewer_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e)
        {
        }
        private void btnReportCreation_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                Views.ReportWindow reportWin = new Views.ReportWindow();
                reportWin.Owner = this.parentWindow;
                var i = reportWin.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnReport: " + ex.Message);
            }
        }
        private void btnLoad_Clicked(object sender, RoutedEventArgs e)
        {

        }
        private void MouseEnterExitArea(object sender, RoutedEventArgs args)
        {
            StatBarText.Text = "Exit the Application";
        }
        private void MouseEnterToolsHintsArea(object sender, RoutedEventArgs args)
        {
            StatBarText.Text = "Show Spelling Suggestions";
        }
        private void MouseLeaveArea(object sender, RoutedEventArgs args)
        {
            StatBarText.Text = "Ready";
        }
        private bool isSpinning = false;
        private void btnSpinner_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!isSpinning)
            {
                isSpinning = true;
                DoubleAnimation dblAnim = new DoubleAnimation();
                dblAnim.Completed += (o, s) => { isSpinning = false; };
                dblAnim.From = 0;
                dblAnim.To = 360;
                RotateTransform rt = new RotateTransform();
                btnSpinner.RenderTransform = rt;
                rt.BeginAnimation(RotateTransform.AngleProperty, dblAnim);
            }
        }
        private void btnSpinner_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation dblAnim = new DoubleAnimation();
            dblAnim.From = 1.0;
            dblAnim.To = 0.0;
            btnSpinner.BeginAnimation(Button.OpacityMaskProperty, dblAnim);
        }
    }
}
