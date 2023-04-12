using Ornek_SQLiteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ornek_SqLiteCon
{
    public class SozcukMenu
    {

        public SozcukMenu()
        {
            // 
        }

        public void ShowMenu()
        {

            do
            {
                Console.Clear();

                Console.WindowWidth = 110;
                Console.BufferWidth = 120;
                Console.WriteLine("*-----------------------------------------------------------------------------------------------------------*");
                Console.WriteLine("*                                                                                                           *");
                Console.WriteLine("*-----------------------------------------------------------------------------------------------------------*");
                Console.WriteLine("*      - 0-Çıkış  / e-Eski Menu                                                                             *");
                Console.WriteLine("* Ekle - 1-Sozcuk / 2-Karsilik                                                                              *");
                Console.WriteLine("* List - 3-Sozcuk / 4-Karsilik                                                                              *");
                Console.WriteLine("*                                                                                                           *");
                Console.WriteLine("*                                                                                                           *");
                Console.WriteLine("*-----------------------------------------------------------------------------------------------------------*");

                ConsoleKeyInfo ck = Console.ReadKey(true);
                if (ck.Key == ConsoleKey.Escape || ck.Key == ConsoleKey.D0 || ck.Key == ConsoleKey.NumPad0)
                    break;
                else if (ck.Key == ConsoleKey.E || ck.Key == ConsoleKey.A)
                    new DosMenu().Menu();
                else if (ck.Key == ConsoleKey.D3)
                    Sozcukler();

                // else if (ck.Key == ConsoleKey.S )
                // Sozcukler();

            } while (true);

        }


        public void Sozcukler()
        {
            List<Sozcuk> sozcukList = new List<Sozcuk>();
            List<KDil> dilList = new List<KDil>();
            List<Karsilik> karList = new List<Karsilik>();

            using (OrnekSQLiteContext db = new OrnekSQLiteContext())
            {
                sozcukList = db.Sozcuk.Where(x => x.BitOp == 1).OrderByDescending(o => o.Id).ToList();
                dilList = db.KDil.Where(x => x.BitOp == 1).ToList();
                karList = db.Karsilik.Where(x => x.BitOp == 1).OrderByDescending(o => o.Id).ToList();
            }
            if (sozcukList.Count == 0) Console.WriteLine("hic sozcuk yok");

            var topluList = (from soz in sozcukList
                             join kar in karList on soz.Szid equals kar.Szid
                             select new
                             {
                                 Id = soz.Id,
                                 SzId = kar.Szid,
                                 Sozcuk = soz.Anlam,
                                 Anlam1 = kar.Anlam1
                             }
                             ).ToList();


            foreach (var item in topluList)
            {
                Console.WriteLine("{0} - {1} - {2}", item.Id, item.Sozcuk, item.Anlam1);
            }

            Console.Write("Anlamlarini gormek icin numarasini yazin (0 cikis):");
            string sno = Console.ReadLine();
            if (string.IsNullOrEmpty(sno) == false)
            {
                int sid = Convert.ToInt32(sno);
                if (sid > 0)
                {
                    Sozcuk? fsoz = sozcukList.Find(x => x.Id == sid);
                    if (fsoz != null)
                    {
                        // Karsiliklar(fsoz);
                    }
                }
            }

            Console.ReadKey();
        }

        public void KarsilikEkle(Sozcuk soz)
        {
            Karsilik krs = new Karsilik();
            // Sozcuk soz = new Sozcuk();

        tekrar:
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
    }
}
