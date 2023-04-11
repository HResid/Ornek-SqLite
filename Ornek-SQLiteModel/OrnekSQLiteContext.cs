using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Ornek_SQLiteModel
{
    // https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli

    public class OrnekSQLiteContext : DbContext
    {
        // DbContext adi: OrnekSQLiteContext

        private string baglantiMetni = "";
        private string vtYol = string.Empty;

        public OrnekSQLiteContext()
        {
            // vtYol = new VTPath().YerelYol();
            vtYol = new VTPath().BulutYol();
        }

        public OrnekSQLiteContext(string pYol)
        {
            vtYol = pYol;
        }

        public string Baglanti()
        {
            return $"Data Source={vtYol};Cache=Shared;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // get vtYol full path

            baglantiMetni = $"Data Source={vtYol};Cache=Shared;";

            optionsBuilder.UseSqlite(baglantiMetni);
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<KDil> KDil { get; set; }
        public DbSet<Sozcuk> Sozcuk { get; set; }
        public DbSet<Karsilik> Karsilik { get; set; }

        protected override void OnModelCreating(ModelBuilder mbuild)
        {
            base.OnModelCreating(mbuild);

            KDilVarsayilan(mbuild);
            SozcukVarsayilan(mbuild);
        }

        protected void KarsilikVarsayilan(ModelBuilder mbuild)
        {
            mbuild.Entity<Karsilik>().Property(c => c.Aciklama).IsUnicode(false);
            mbuild.Entity<Karsilik>().Property(c => c.OkunusTr).IsUnicode(false);
            mbuild.Entity<Karsilik>().Property(c => c.Anlam1).IsUnicode(false);
            mbuild.Entity<Karsilik>().Property(c => c.Anlam2).IsUnicode(false);
            mbuild.Entity<Karsilik>().Property(c => c.Anlam3).IsUnicode(false);
            mbuild.Entity<Karsilik>().Property(c => c.OkunusEn).IsUnicode(false);
            mbuild.Entity<Karsilik>().Property(c => c.OzelKod).IsUnicode(false);
        }


        protected void SozcukVarsayilan(ModelBuilder mbuild)
        {
            mbuild.Entity<Sozcuk>().Property(c => c.Aciklama).IsUnicode(false);
            mbuild.Entity<Sozcuk>().Property(c => c.Anlam).IsUnicode(false);
            mbuild.Entity<Sozcuk>().Property(c => c.EsAnlam).IsUnicode(false);
            mbuild.Entity<Sozcuk>().Property(c => c.EkNot).IsUnicode(false);

            mbuild.Entity<Sozcuk>().HasData(new Sozcuk
            {
                Id = 1,
                Szid = Guid.NewGuid(),
                Anlam = "Okumak",
                BitOp = 1,
                Aciklama = "bir emirle baslayak",
                EkNot = "",
                EsAnlam = "",
                Kayit = DateTime.Now
            });
        }

        protected void KDilVarsayilan(ModelBuilder mbuild)
        {
            // mbuild.Entity<KDil>().Property(e => e.Id).UseIdentityColumn(1, 1);
            mbuild.Entity<KDil>().Property(c => c.Aciklama).IsUnicode(false);
            mbuild.Entity<KDil>().Property(c => c.TrAdi).IsUnicode(false);
            mbuild.Entity<KDil>().Property(c => c.EnAdi).IsUnicode(false);
            mbuild.Entity<KDil>().Property(c => c.OrAdi).IsUnicode(false);

            mbuild.Entity<KDil>().HasData(new KDil
            {
                Id = 1,
                TrAdi = "ingilizce",
                EnAdi = "English",
                OrAdi = "",
                OrAdiA = "",
                Aciklama = "",
                BitOp = 1,
                Diud = Guid.NewGuid()
            });
            mbuild.Entity<KDil>().HasData(new KDil
            {
                Id = 2,
                TrAdi = "Japonca",
                EnAdi = "Japanese",
                OrAdi = "",
                OrAdiA = "nihongo",
                Aciklama = "nihongo, bunun bir orjinal yazilisi var, bir de latin",
                BitOp = 1,
                Diud = Guid.NewGuid()
            });
            mbuild.Entity<KDil>().HasData(new KDil
            {
                Id = 3,
                TrAdi = "Arapca",
                EnAdi = "Arabic",
                OrAdi = "",
                OrAdiA = "arabiyye",
                Aciklama = "",
                BitOp = 1,
                Diud = Guid.NewGuid()
            });
            mbuild.Entity<KDil>().HasData(new KDil
            {
                Id = 4,
                TrAdi = "Farsca",
                EnAdi = "Farsee",
                OrAdi = "",
                OrAdiA = "Farisi",
                Aciklama = "",
                BitOp = 1,
                Diud = Guid.NewGuid()
            });
            mbuild.Entity<KDil>().HasData(new KDil
            {
                Id = 5,
                TrAdi = "Osmanlica",
                EnAdi = "Osmani",
                OrAdi = "",
                OrAdiA = "",
                Aciklama = "",
                BitOp = 1,
                Diud = Guid.NewGuid()
            });
            mbuild.Entity<KDil>().HasData(new KDil
            {
                Id = 6,
                TrAdi = "Korece",
                EnAdi = "Hongogu",
                OrAdi = "",
                OrAdiA = "",
                Aciklama = "",
                BitOp = 1,
                Diud = Guid.NewGuid()
            });
        }

    }
}