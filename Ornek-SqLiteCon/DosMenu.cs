using Ornek_SQLiteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ornek_SqLiteCon
{
    public class DosMenu
    {

        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Test Menu - {0} - Path:{1}", DateTime.Now, new VTPath().YerelYol());
                Console.WriteLine("1-Diller");
                Console.WriteLine("2-Sozcukler (son 10)");
                Console.WriteLine("3-Sozcuk Ekle");
                Console.WriteLine("4-Karsilik son");
                Console.WriteLine("5-Karsilik Ekle");
                Console.WriteLine("");

                ConsoleKeyInfo ck = Console.ReadKey(true);
                if (ck.Key == ConsoleKey.Escape)
                    break;
                else if (ck.Key == ConsoleKey.D0 || ck.Key == ConsoleKey.NumPad0)
                    break;
                else if (ck.Key == ConsoleKey.D1 || ck.Key == ConsoleKey.NumPad1)
                    DilList();
                else if (ck.Key == ConsoleKey.D2 || ck.Key == ConsoleKey.NumPad2)
                    Sozcukler();
                else if (ck.Key == ConsoleKey.D3 || ck.Key == ConsoleKey.NumPad3)
                    SozcukEkle();
                else if (ck.Key == ConsoleKey.D4 || ck.Key == ConsoleKey.NumPad4)
                    Karsiliklar();
                else if (ck.Key == ConsoleKey.D5 || ck.Key == ConsoleKey.NumPad5)
                    KarsilikEkle();

            } while (true);
        }

        public void KarsilikEkle()
        {
            Karsilik krs = new Karsilik();
            Sozcuk sz = new Sozcuk();

        tekrar:
            Console.WriteLine("Farkli Dilde karsiligi yazilacak olan sozcugu yaziniz");
            Console.Write("Sozcuk:");
            string sozcuk = Console.ReadLine();

            if (string.IsNullOrEmpty(sozcuk))
            {
                Console.WriteLine("yazilmadi");
                Console.ReadKey();
                return;
            }
            using (OrnekSQLiteContext db = new OrnekSQLiteContext())
            {
                List<Sozcuk> bul = db.Sozcuk.Where(x => x.Anlam == sozcuk).ToList();
                if (bul == null || bul.Count == 0)
                {
                    Console.WriteLine("{0} bu sozcugu bulamadik", sozcuk);
                    Console.ReadKey();

                    goto tekrar;
                    // return;
                }
                else
                {
                    sz = bul[0];
                }
            }

            List<KDil> dils = new List<KDil>(); 
            using (OrnekSQLiteContext db = new OrnekSQLiteContext())
            {
                dils = db.KDil.Where(x => x.BitOp == 1).ToList();
            }
            string diller = string.Empty;
            foreach (KDil dil in dils)
            {
                diller = dil.Id.ToString() + dil.TrAdi + " / ";
            }

            dilsec:
            Console.WriteLine(diller);
            Console.WriteLine("{0} bu kelimeyi hangi dil de anlamini yazacaksiniz:", sz.Anlam);
            string selDil = Console.ReadLine();
            KDil? found = null;

            if (string.IsNullOrEmpty(selDil) == false)
            {
                int did = Convert.ToInt32(selDil);

                dils.Where(c => c.Id == did).ToList();
                found = dils.Find(x => x.Id == did);
            }
            if(found == null)
            {
                Console.WriteLine("dili yanlis sectiniz, numarasini yaziniz");
                goto dilsec;
            }

            Console.ReadKey();
            krs.Anlam1 = Console.ReadLine();
        }

        public void Karsiliklar()
        {
            List<Karsilik> list = new List<Karsilik>();

            using (OrnekSQLiteContext db = new OrnekSQLiteContext())
            {
                list = db.Karsilik.Where(x => x.BitOp == 1).OrderByDescending(o => o.Id).ToList();
            }
            foreach (Karsilik item in list)
            {
                Console.WriteLine("{0} - {1}", item.Id, item.Anlam1);
            }

            Console.ReadKey();
        }

        public void SozcukEkle()
        {
            Sozcuk sz = new Sozcuk();

            sz.BitOp = 1;
            sz.Szid = Guid.NewGuid();
            sz.Kayit = DateTime.Now;
            sz.Id = 0;

            Console.Write("Sozcuk:");
            sz.Anlam = Console.ReadLine();
            Console.Write("Ek Not (Mondly; m230411):");
            sz.EkNot = Console.ReadLine();

            int ret;
            try
            {
                using (OrnekSQLiteContext db = new OrnekSQLiteContext())
                {
                    // ayni kelime birden fazla olmamali
                    List<Sozcuk> kontrol = db.Sozcuk.Where(x => x.Anlam == sz.Anlam).ToList();
                    if (kontrol == null || kontrol.Count == 0)
                    {
                        // yok ekle

                        db.Sozcuk.Add(sz);

                        ret = db.SaveChanges();

                        if (ret != 0)
                        {
                            Console.WriteLine("Kaydedildi");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bu sozcuk zaten var");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }


        public void Sozcukler()
        {
            List<Sozcuk> list = new List<Sozcuk>();

            using (OrnekSQLiteContext db = new OrnekSQLiteContext())
            {
                list = db.Sozcuk.Where(x => x.BitOp == 1).OrderByDescending(o => o.Id).ToList();
            }

            foreach (Sozcuk item in list)
            {
                Console.WriteLine("{0} - {1}", item.Id, item.Anlam);
            }

            Console.ReadKey();
        }

        private void DilList()
        {
            List<KDil> list = new List<KDil>();

            using (OrnekSQLiteContext db = new OrnekSQLiteContext())
            {
                list = db.KDil.Where(x => x.BitOp == 1).ToList();
            }

            foreach (KDil item in list)
            {
                Console.WriteLine("{0} - {1}", item.Id, item.TrAdi);
            }

            Console.ReadKey();
        }


    }
}
