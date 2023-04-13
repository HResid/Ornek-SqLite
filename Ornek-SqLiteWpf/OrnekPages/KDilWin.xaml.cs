using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using Ornek_SQLiteModel;

namespace Ornek_SqLiteWpf
{

    ///<summary>KDil</summary>
    ///<remarks>Created: 13.04.2023 05:50:19, HResid</remarks>
    public partial class KDilWin : Window
    {

        public KDil m_KDil = new KDil();

        public KDilWin()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // this.DataContext = m_KDil;

            // fill the form
            txtId.Text = m_KDil.Id.ToString();
            txtTrAdi.Text = m_KDil.TrAdi;
            txtEnAdi.Text = m_KDil.EnAdi;
            txtOrAdi.Text = m_KDil.OrAdi;
            txtOrAdiA.Text = m_KDil.OrAdiA;
            txtAciklama.Text = m_KDil.Aciklama;
            // txtDiud.Text = m_KDil.Diud;
            txtBitOp.Text = m_KDil.BitOp.ToString();


        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        ///<summary>Save the current state to the session and database. If this 
        ///   is a new KDil, then create the item, or edit for an 
        ///   existing KDil.</summary>
        ///<returns>True on success.</returns>
        private Boolean Save()
        {
            Int32 nret = 0;

            // get values from textboxes
            // m_KDil.Id = Utility.ConvertToInt32(txtId.Text);
            m_KDil.TrAdi = txtTrAdi.Text;
            m_KDil.EnAdi = txtEnAdi.Text;
            m_KDil.OrAdi = txtOrAdi.Text;
            m_KDil.OrAdiA = txtOrAdiA.Text;
            m_KDil.Aciklama = txtAciklama.Text;
            // m_KDil.Diud = txtDiud.Text;
            // m_KDil.BitOp = Utility.ConvertToInt32(txtBitOp.Text);


            try
            {
                // Save changes to the database
                using (OrnekSQLiteContext db = new OrnekSQLiteContext())
                {

                    // guid kontrol: if (m_KDil.Uid == Guid.Empty)
                    if (m_KDil.Id == 0)
                    {
                        // m_KDil.Uid = Guid.NewGuid();
                        // m_KDil.Kaydeden = Environment.UserName;
                        // m_KDil.KayitTarih = DateTime.Now;
                        db.KDil.Add(m_KDil);
                    }
                    else
                    {
                        // m_KDil.SonDegistiren = Environment.UserName;
                        // m_KDil.SonDegisiklik = DateTime.Now;
                        db.Update(m_KDil);
                    }

                    nret = db.SaveChanges();
                    // If .ErrorText.Length > 0 Then MessageBox.Show(.ErrorText, "Err", MessageBoxButton.OK)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SAW-89");
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

    }
} // namespace
