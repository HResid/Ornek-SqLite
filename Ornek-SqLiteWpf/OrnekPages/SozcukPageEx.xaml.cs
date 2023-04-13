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
    /// Created: 13.04.2023 0604, HRe..
    /// Review : 13.04.2023 0758, HRe.. Ex
    /// </remarks>
    public partial class SozcukPageEx
    {
        // List<Sozcuk> m_Sozcukler = new List<Sozcuk>();
        List<SozcukKarsilik> m_sozcukKarsilik = new List<SozcukKarsilik>();

        public SozcukPageEx()
        {
            InitializeComponent();
            this.Cursor = System.Windows.Input.Cursors.Wait;

            txtSearch.Text = "";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataGrid1.Columns.Clear();

            List<KDil> diller = new List<KDil>();

            // dilleri yukle
            using (OrnekSQLiteContext db = new OrnekSQLiteContext())
            {
                diller = db.KDil.Where(x => x.BitOp == 1).ToList();
            }
            cboDiller.DataContext = diller;
            cboDiller.DisplayMemberPath = "TrAdi";
            cboDiller.SelectedValuePath = "Id";
            
            // hard code
            cboDiller.SelectedValue = 1;

            LoadData(1);
        }

        private void LoadData(int dilId)
        {
            this.Cursor = System.Windows.Input.Cursors.Wait;

            try
            {
                //using (OrnekSQLiteContext db = new OrnekSQLiteContext())
                //{
                //    m_Sozcukler = db.Sozcuk.ToList();
                //}

                using (OrnekSQLiteContext db = new OrnekSQLiteContext())
                {
                    m_sozcukKarsilik = (from soz in db.Sozcuk
                                        join kar in db.Karsilik on soz.Uid equals kar.SozcukUid
                                        where kar.DilId == dilId
                                        select new SozcukKarsilik(
                                            soz.Anlam,
                                            kar.Anlam1,
                                            kar.Anlam2,
                                            soz.Id,
                                            kar.Id
                                        )).ToList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Err-Sozcuk-50");
            }

            DataGrid1.ItemsSource = m_sozcukKarsilik;
            sbiRowCount.Content = m_sozcukKarsilik.ToList().Count.ToString() + " row(s)";

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
                LoadData(1);
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
            SozcukWin win = new SozcukWin();
            win.Owner = Application.Current.MainWindow;
            win.m_Sozcuk = new Sozcuk();
            if (win.ShowDialog() == true)
            {
                // db.Sozcuk.Add(win.m_Sozcuk);
                // sbiReady.Content = db.SaveChanges().ToString() + " record(s) saved";

                LoadData(1);
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
                        LoadData(1);

                }
            }
            else
            {
                MessageBox.Show("could not delete", "Used", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadData(1);
        }

        private void ctxDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cboDiller_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoaded)
            {
                // sozcuklerin secilen dildeki karsiligini goster
                if (cboDiller.SelectedItem != null)
                {
                    KDil selDil = (KDil)cboDiller.SelectedItem;

                    LoadData(selDil.Id);
                }
            }
        }
    }  // End Class
} // Namespace
