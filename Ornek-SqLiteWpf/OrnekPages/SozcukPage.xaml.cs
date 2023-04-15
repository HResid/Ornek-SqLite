using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System;
using Ornek_SQLiteModel;

namespace Ornek_SqLiteWpf
{

    /// <summary>
    /// Sozcuk
    /// </summary>
    /// <remarks>
    /// Created: 13.04.2023 06:04, HRe..
    /// </remarks>
    public partial class SozcukPage
    {
        List<Sozcuk> m_Sozcuk = new List<Sozcuk>();

        public SozcukPage()
        {
            InitializeComponent();
            this.Cursor = System.Windows.Input.Cursors.Wait;

            txtSearch.Text = "";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            this.Cursor = System.Windows.Input.Cursors.Wait;

            try
            {

                using (OrnekSQLiteContext db = new OrnekSQLiteContext())
                {
                    m_Sozcuk = db.Sozcuk.ToList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Err-Sozcuk-50");
            }

            DataGrid1.ItemsSource = m_Sozcuk;
            sbiRowCount.Content = m_Sozcuk.ToList().Count.ToString() + " row(s)";

            this.Cursor = System.Windows.Input.Cursors.Arrow;
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            // is item selected
            if (DataGrid1.SelectedItem == null) return;

            // get selected
            Sozcuk ds = (Sozcuk)DataGrid1.SelectedItem;
            sbiWarn.Content = "Selected:" + ds.Id;

            SozcukWin win = new SozcukWin();
            win.Owner = Application.Current.MainWindow;
            win.m_Sozcuk = ds;
            if (win.ShowDialog() == true)
            {
                // update/save on win
                // db.SaveChanges();
                LoadData();
            }
        }

        private void DataGrid1_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Return)
            {
                e.Handled = true;
                btnOpen_Click(sender, null);
            }
            else if (e.Key == System.Windows.Input.Key.Insert)
            {
                e.Handled = true;
                btnNew_Click(sender, e);
            }
            else if (e.Key == System.Windows.Input.Key.F12)
            {
                e.Handled = true;
                btnKarsilikEkle_Click(sender, null);
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            SozcukWin win = new SozcukWin();
            win.Owner = Application.Current.MainWindow;
            win.m_Sozcuk = new Sozcuk();
            if (win.ShowDialog() == true)
            {
                // db.Sozcuk.Add(win.m_Sozcuk);
                // sbiReady.Content = db.SaveChanges().ToString() + " record(s) saved";

                LoadData();
            }
        }

        private void ctxSil_Click(object sender, RoutedEventArgs e)
        {
            Sozcuk ds = (Sozcuk)DataGrid1.SelectedItem;

            if (ds != null)
            {
                if (MessageBox.Show("Are you sure to delete this?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    int ret = 0;

                    try
                    {
                        using (OrnekSQLiteContext db = new OrnekSQLiteContext())
                        {
                            Sozcuk? found = db.Sozcuk.Find(ds.Id);
                            if (found != null)
                            {
                                db.Sozcuk.Remove(found);
                                ret = db.SaveChanges();
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Err-ServisGuzergah-50");
                    }

                    if (ret > 0)
                        LoadData();

                }
            }
            else
            {
                MessageBox.Show("could not delete", "Used", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void ctxDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnKarsilikEkle_Click(object sender, RoutedEventArgs e)
        {
            Sozcuk ds = (Sozcuk)DataGrid1.SelectedItem;

            if (ds != null)
            {

                KarsilikWinEx win = new KarsilikWinEx();
                win.m_Sozcuk = ds;
                win.Owner = Application.Current.MainWindow;
                win.ShowDialog();
            }
        }


    }  // End Class

} // Namespace
