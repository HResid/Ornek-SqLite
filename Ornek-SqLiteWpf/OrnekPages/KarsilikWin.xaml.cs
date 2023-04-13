using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using Ornek_SQLiteModel;
using xredev.ReCore.ESUtil;

namespace Ornek_SqLiteWpf
{

    ///<summary>Karsilik</summary>
    ///<remarks>Created: 13.04.2023 06:04:05, HResid</remarks>
    public partial class KarsilikWin : Window
    {

        public Karsilik m_Karsilik = new Karsilik();

        public KarsilikWin()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // this.DataContext = m_Karsilik;

            // fill the form
            txtId.Text = m_Karsilik.Id.ToString();
            // txtSzid.Text = m_Karsilik.Szid;
            // txtDiud.Text = m_Karsilik.Diud;
            txtAnlam1.Text = m_Karsilik.Anlam1;
            txtAnlam2.Text = m_Karsilik.Anlam2;
            txtAnlam3.Text = m_Karsilik.Anlam3;
            txtOkunusTr.Text = m_Karsilik.OkunusTr;
            txtOkunusEn.Text = m_Karsilik.OkunusEn;
            txtAciklama.Text = m_Karsilik.Aciklama;
            txtOzelKod.Text = m_Karsilik.OzelKod;
            txtBitOp.Text = m_Karsilik.BitOp.ToString();


        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        ///<summary>Save the current state to the session and database. If this 
        ///   is a new Karsilik, then create the item, or edit for an 
        ///   existing Karsilik.</summary>
        ///<returns>True on success.</returns>
        private Boolean Save()
        {
            Int32 nret = 0;

            // get values from textboxes
            m_Karsilik.Id = Utility.ConvertToInt32(txtId.Text);
            // m_Karsilik.Szid = txtSzid.Text;
            // m_Karsilik.Diud = txtDiud.Text;
            m_Karsilik.Anlam1 = txtAnlam1.Text;
            m_Karsilik.Anlam2 = txtAnlam2.Text;
            m_Karsilik.Anlam3 = txtAnlam3.Text;
            m_Karsilik.OkunusTr = txtOkunusTr.Text;
            m_Karsilik.OkunusEn = txtOkunusEn.Text;
            m_Karsilik.Aciklama = txtAciklama.Text;
            m_Karsilik.OzelKod = txtOzelKod.Text;
            m_Karsilik.BitOp = Utility.ConvertToInt32(txtBitOp.Text);


            try
            {
                // Save changes to the database
                using (OrnekSQLiteContext db = new OrnekSQLiteContext())
                {

                    // guid kontrol: if (m_Karsilik.Uid == Guid.Empty)
                    if (m_Karsilik.Id == 0)
                    {
                        // m_Karsilik.Uid = Guid.NewGuid();
                        // m_Karsilik.Kaydeden = Environment.UserName;
                        // m_Karsilik.KayitTarih = DateTime.Now;
                        db.Karsilik.Add(m_Karsilik);
                    }
                    else
                    {
                        // m_Karsilik.SonDegistiren = Environment.UserName;
                        // m_Karsilik.SonDegisiklik = DateTime.Now;
                        db.Update(m_Karsilik);
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