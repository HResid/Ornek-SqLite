using Ornek_SQLiteModel;

namespace Ornek_SqLiteCon
{
    /// <summary>
    /// Test/Console Menu
    /// </summary>
    /// <remarks>
    /// Created: 10/04/2023 
    /// Review : 11/04/2023
    /// Review : 12/04/2023 0955, HRe.. checking...
    /// </remarks>
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
                Console.WriteLine("3-Karsilik son");
                Console.WriteLine("");
                Console.WriteLine("4-Sozcuk Ekle    5-Karsilik Ekle");
                Console.WriteLine("");
                Console.WriteLine("9-Sozcuk Sil");
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
                    Karsiliklar();

                else if (ck.Key == ConsoleKey.D4 || ck.Key == ConsoleKey.NumPad4)
                    SozcukEkle();
                else if (ck.Key == ConsoleKey.D5 || ck.Key == ConsoleKey.NumPad5)
                    KarsilikEkle();

                else if (ck.Key == ConsoleKey.D9 || ck.Key == ConsoleKey.NumPad9)
                    SozcukSil();

            } while (true);
        }

        private void SozcukSil()
        {

            Console.WriteLine("Sozcuk, baska dillerdeki karsiliklariyla beraber silinecek");
            Console.Write("Silinecek Sozcuk Yaziniz:");
            string sozcuk = Console.ReadLine();

            if (string.IsNullOrEmpty(sozcuk) == false)
            {
                int ret = 0;
                using (OrnekSQLiteContext db = new OrnekSQLiteContext())
                {
                    List<Sozcuk> sozcuks = new List<Sozcuk>();
                    // sozcuks = db.Sozcuk.Where(x => x.Anlam == sozcuk).ToList();
                    sozcuks = db.Sozcuk.Where(x => x.Anlam.ToUpper() == sozcuk.ToUpper()).ToList();
                    // DbContext.Entity.Where(i => i.TextField.Contains("Store", StringComparison.InvariantCultureIgnoreCase))
                    // sozcuks = db.Sozcuk.Where(x => x.Anlam.Contains(sozcuk, StringComparison.OrdinalIgnoreCase)).ToList();

                    // bulundu mu?
                    if (sozcuks != null && sozcuks.Count > 0)
                    {
                        Console.Write("{0} adet sozcuk bulundu, silmek istiyor musunuz? e/h:", sozcuks.Count);

                        if (Console.ReadKey().Key == ConsoleKey.E)
                        {
                            // db.Database.ExecuteSql()
                            List<Karsilik> karsiliks = db.Karsilik.Where(x => x.Szid == sozcuks[0].Szid).ToList();

                            db.Karsilik.RemoveRange(karsiliks);
                            db.Sozcuk.RemoveRange(sozcuks);

                            ret = db.SaveChanges();

                        }
                        else Console.WriteLine("sozcuk bulunamadi");
                    }
                }

                if (ret > 0) Console.WriteLine("kayitlar silindi. {0}", ret);
                else Console.WriteLine("silinemedi");


            }
            else
            {
                Console.WriteLine("Sozcuk girmediniz, cikilacak");
            }

            Console.ReadKey();
        }

        public void KarsilikEkle()
        {
            Karsilik krs = new Karsilik();
            Sozcuk soz = new Sozcuk();

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
                    soz = bul[0];
                }
            }

            List<KDil> dils = new List<KDil>();
            using (OrnekSQLiteContext db = new OrnekSQLiteContext())
            {
                dils = db.KDil.Where(x => x.BitOp == 1).ToList();
            }
            string diller = "0-cikis";
            foreach (KDil dil in dils)
            {
                diller += " / " + dil.Id.ToString() + "-" + dil.TrAdi;
            }

        dilsec:
            Console.WriteLine(diller);
            Console.WriteLine("{0} bu kelimeyi hangi dil de anlamini yazacaksiniz:", soz.Anlam);
            string selDil = Console.ReadLine();
            KDil? found = null;

            if (string.IsNullOrEmpty(selDil) == false)
            {
                int did = Convert.ToInt32(selDil);

                if (did == 0)
                    return;

                dils.Where(c => c.Id == did).ToList();
                found = dils.Find(x => x.Id == did);
            }
            if (found == null)
            {
                Console.WriteLine("dili yanlis sectiniz, numarasini yaziniz");
                goto dilsec;
            }

            krs.Diud = found.Diud;
            krs.BitOp = 1;
            krs.Szid = soz.Szid;

            Console.Write("Anlam1:");
            krs.Anlam1 = Console.ReadLine();
            Console.Write("Anlam2:");
            krs.Anlam2 = Console.ReadLine();
            Console.Write("En Okunus:");
            krs.OkunusEn = Console.ReadLine();
            Console.Write("Aciklama:");
            krs.Aciklama = Console.ReadLine();

            int ret = 0;
            using (OrnekSQLiteContext db = new OrnekSQLiteContext())
            {
                db.Karsilik.Add(krs);
                ret = db.SaveChanges();
            }

            if (ret == 0)
            {
                Console.WriteLine("kaydedilemedi");
            }
            else
            {
                Console.WriteLine("kaydedildi");
            }
            Console.ReadKey();

        }

        public void Karsiliklar()
        {
            List<Karsilik> list = new List<Karsilik>();

            using (OrnekSQLiteContext db = new OrnekSQLiteContext())
            {
                list = db.Karsilik.Where(x => x.BitOp == 1).OrderByDescending(o => o.Id).ToList();
            }

            if (list.Count == 0) Console.WriteLine("hic karsilik yok");

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

            if (string.IsNullOrEmpty(sz.Anlam) == true)
            {
                Console.WriteLine("bos gecildi, cikiliyor..");
            }
            else
            {
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
            if (list.Count == 0) Console.WriteLine("hic sozcuk yok");
            foreach (Sozcuk item in list)
            {
                Console.WriteLine("{0} - {1}", item.Id, item.Anlam);
            }

            Console.Write("Anlamlarini gormek icin numarasini yazin (0 cikis):");
            string sno = Console.ReadLine();
            if (string.IsNullOrEmpty(sno) == false)
            {
                int sid = Convert.ToInt32(sno);
                if (sid > 0)
                {
                    Sozcuk? fsoz = list.Find(x => x.Id == sid);
                    if (fsoz != null)
                    {
                        Karsiliklar(fsoz);
                    }
                }
            }

            Console.ReadKey();
        }

        public void Karsiliklar(Sozcuk sozcuk)
        {
            List<Karsilik> list = new List<Karsilik>();

            using (OrnekSQLiteContext db = new OrnekSQLiteContext())
            {
                list = db.Karsilik.Where(x => x.BitOp == 1 && x.Szid == sozcuk.Szid).OrderByDescending(o => o.Id).ToList();
            }

            if (list.Count == 0) Console.WriteLine("hic karsilik yok");

            foreach (Karsilik item in list)
            {
                Console.WriteLine("{0} - {1}", item.Id, item.Anlam1);
            }

            // Console.ReadKey();
        }


        public void Sozcukler1()
        {
            List<Sozcuk> list = new List<Sozcuk>();

            using (OrnekSQLiteContext db = new OrnekSQLiteContext())
            {
                list = db.Sozcuk.Where(x => x.BitOp == 1).OrderByDescending(o => o.Id).ToList();
            }
            if (list.Count == 0) Console.WriteLine("hic sozcuk yok");
            foreach (Sozcuk item in list)
            {
                Console.WriteLine("{0} - {1}", item.Id, item.Anlam);
            }

            // ConsoleKeyInfo kin = Console.ReadKey();

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
