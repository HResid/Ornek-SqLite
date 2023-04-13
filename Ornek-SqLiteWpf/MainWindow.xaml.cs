using System.Diagnostics;
using System;
using System.Windows;
using System.Windows.Input;

namespace Ornek_SqLiteWpf
{
    /// <summary>
    /// Ornek-SQ Lite
    /// </summary>
    /// <remarks>
    /// Created: 13/04/2023 0530, HRe.. mubarek ramazan da ugrastigim seylere bak.
    /// sq lite wpf projesi github da.
    /// </remarks>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // check 
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            // sbiVersion.Content = "Version: " + asm.GetName().Version.ToString();
            // sbiVersion.Tag = asm.GetName().Version.ToString();

            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(asm.Location);
            sbiFileVersion.Content = "Rel:" + fvi.FileVersion.ToString();
            sbiFileVersion.Tag = fvi.FileVersion.ToString();

            sbiExePath.Content = asm.Location;
            // lblDefaultPath.Content = "Path:" + CreaShared.DefaultPath();

            sbiMsg.Content = ".NET " + Environment.Version.ToString();

        }

        private void mnuFileExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Q && Keyboard.Modifiers == ModifierKeys.Control)
            {
                e.Handled = true;
                Close();
            }
            else if (e.Key == Key.F1)
            {
                e.Handled = true;
                btnDil_Click(sender, e);
            }
            else if (e.Key == Key.F2)
            {
                e.Handled = true;
                btnSozcukRaw_Click(sender, e);
            }
            else if (e.Key == Key.F3)
            {
                e.Handled = true;
                btnKarsilikRaw_Click(sender, e);
            }

        }

        private void btnDil_Click(object sender, RoutedEventArgs e)
        {
            frame1.Content = new KDilPage();
        }

        private void btnSozcukRaw_Click(object sender, RoutedEventArgs e)
        {
            frame1.Content = new SozcukPage();
        }

        private void btnKarsilikRaw_Click(object sender, RoutedEventArgs e)
        {
            frame1.Content = new KarsilikPage();
        }

        private void btnSozcukKars_Click(object sender, RoutedEventArgs e)
        {
            frame1.Content = new SozcukPageEx();
        }
    }
}
