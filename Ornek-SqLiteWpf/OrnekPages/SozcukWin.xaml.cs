using Ornek_SQLiteModel;
using System;
using System.Linq;
using System.Windows;
using xredev.ReCore.ESUtil;

namespace Ornek_SqLiteWpf
{

    ///<summary>Sozcuk</summary>
    ///<remarks>Created: 13.04.2023 06:04:02, HResid</remarks>
    public partial class SozcukWin : Window
    {

        public Sozcuk m_Sozcuk = new Sozcuk();

        public SozcukWin()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // this.DataContext = m_Sozcuk;

            // fill the form
            txtId.Text = m_Sozcuk.Id.ToString();
            txtAnlam.Text = m_Sozcuk.Anlam;
            txtAnlam.Tag = m_Sozcuk.Anlam;

            txtEsAnlam.Text = m_Sozcuk.EsAnlam;
            txtAciklama.Text = m_Sozcuk.Aciklama;
            txtEkNot.Text = m_Sozcuk.EkNot;
            // txtSzid.Text = m_Sozcuk.Szid;
            txtBitOp.Text = m_Sozcuk.BitOp.ToString();
            // txtKayit.Text = m_Sozcuk.Kayit;

            txtAnlam.Focus();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        ///<summary>Save the current state to the session and database. If this 
        ///   is a new Sozcuk, then create the item, or edit for an 
        ///   existing Sozcuk.</summary>
        ///<returns>True on success.</returns>
        private Boolean Save()
        {
            Int32 nret = 0;

            // get values from textboxes
            // m_Sozcuk.Id = Utility.ConvertToInt32(txtId.Text);
            m_Sozcuk.Anlam = txtAnlam.Text;
            m_Sozcuk.EsAnlam = txtEsAnlam.Text;
            m_Sozcuk.Aciklama = txtAciklama.Text;
            m_Sozcuk.EkNot = txtEkNot.Text;
            // m_Sozcuk.Szid = txtSzid.Text;
            m_Sozcuk.BitOp = Utility.ConvertToInt32(txtBitOp.Text);
            //m_Sozcuk.Kayit = txtKayit.Text;


            try
            {
                // Save changes to the database
                using (OrnekSQLiteContext db = new OrnekSQLiteContext())
                {

                    // guid kontrol: if (m_Sozcuk.Uid == Guid.Empty)
                    if (m_Sozcuk.Id == 0)
                    {
                        m_Sozcuk.Uid = Guid.NewGuid();
                        // m_Sozcuk.Kaydeden = Environment.UserName;
                        m_Sozcuk.Kayit = DateTime.Now;
                        db.Sozcuk.Add(m_Sozcuk);
                    }
                    else
                    {
                        // m_Sozcuk.SonDegistiren = Environment.UserName;
                        // m_Sozcuk.SonDegisiklik = DateTime.Now;
                        db.Update(m_Sozcuk);
                    }

                    nret = db.SaveChanges();
                    // If .ErrorText.Length > 0 Then MessageBox.Show(.ErrorText, "Err", MessageBoxButton.OK)
                }
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message + "\nShow Inner?", "SAW-89", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    MessageBox.Show(ex.InnerException?.Message, "Inner-94", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            return Convert.ToBoolean(nret);
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (Save())
            {
                this.DialogResult = true;
            }
        }

        private void txtAnlam_LostFocus(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
            {
                // daha once girilmis mi?
                bool kontrolEt = false;
                // yeni bir sozcuk eklenmeye calisiliyor
                if (m_Sozcuk.Id == 0)
                {
                    // kontrol et
                    kontrolEt = true;
                }
                // var olan, degistirildiyse, kontrol et
                else if (m_Sozcuk.Anlam != txtAnlam.Text)
                {
                    kontrolEt = true;
                }
                if (kontrolEt)
                {
                    using (OrnekSQLiteContext db = new OrnekSQLiteContext())
                    {
                        Sozcuk? soz = db.Sozcuk.Where(x => x.Anlam == txtAnlam.Text).FirstOrDefault();
                        if (soz != null)
                        {
                            // aha varmis
                            MessageBox.Show("bu sozcuk girilmis\n" + soz.Id.ToString());
                        }
                    }
                }
            }
        }
    }
} // namespace