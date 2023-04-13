using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System;
using Ornek_SQLiteModel;

namespace Ornek_SqLiteWpf
{

    /// <summary>
    /// Karsilik
    /// </summary>
    /// <remarks>
    /// Created: 13.04.2023 06:04, HRe..
    /// </remarks>
    public partial class KarsilikPage
    {
        List<Karsilik> m_Karsilik = new List<Karsilik>();

        public KarsilikPage()
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
                    m_Karsilik = db.Karsilik.ToList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Err-Karsilik-50");
            }

            DataGrid1.ItemsSource = m_Karsilik;
            sbiRowCount.Content = m_Karsilik.ToList().Count.ToString() + " row(s)";

            this.Cursor = System.Windows.Input.Cursors.Arrow;
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            // is item selected
            if (DataGrid1.SelectedItem == null) return;

            // get selected
            Karsilik ds = (Karsilik)DataGrid1.SelectedItem;
            sbiWarn.Content = "Selected:" + ds.Id;

            KarsilikWin win = new KarsilikWin();
            win.Owner = Application.Current.MainWindow;
            win.m_Karsilik = ds;
            if (win.ShowDialog() == true)
            {
                // update/save on win
                // db.SaveChanges();
                LoadData();
            }
        }

        private void btnOpen2_Click(object sender, RoutedEventArgs e)
        {
            // is item selected
            if (DataGrid1.SelectedItem == null) return;

            // get selected
            Karsilik ds = (Karsilik)DataGrid1.SelectedItem;
            sbiWarn.Content = "Selected:" + ds.Id;

            KarsilikWinEx win = new KarsilikWinEx();
            win.Owner = Application.Current.MainWindow;
            win.m_Karsilik = ds;
            if (win.ShowDialog() == true)
            {
                // update/save on win
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
                btnNew_Click(sender, null);
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            KarsilikWin win = new KarsilikWin();
            win.Owner = Application.Current.MainWindow;
            win.m_Karsilik = new Karsilik();
            if (win.ShowDialog() == true)
            {
                // db.Karsilik.Add(win.m_Karsilik);
                // sbiReady.Content = db.SaveChanges().ToString() + " record(s) saved";

                LoadData();
            }
        }

        private void ctxSil_Click(object sender, RoutedEventArgs e)
        {
            Karsilik ds = (Karsilik)DataGrid1.SelectedItem;

            if (ds != null)
            {
                if (MessageBox.Show("Are you sure to delete this?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    int ret = 0;

                    try
                    {
                        using (OrnekSQLiteContext db = new OrnekSQLiteContext())
                        {
                            Karsilik? found = db.Karsilik.Find(ds.Id);
                            if (found != null)
                            {
                                db.Karsilik.Remove(found);
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
    }  // End Class

} // Namespace
