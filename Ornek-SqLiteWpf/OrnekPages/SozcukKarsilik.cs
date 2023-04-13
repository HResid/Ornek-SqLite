using System;

namespace Ornek_SqLiteWpf
{
    internal class SozcukKarsilik
    {
        public string Sozcuk { get; set; }
        public string? Anlam1 { get; set; }
        public string? Anlam2 { get; set; }
        public int SozcukId { get; set; }
        public int KarsilikId { get; set; }

        public SozcukKarsilik()
        {
            
        }
        public SozcukKarsilik(string sozcuk, string anlam1, string anlam2, int sozcukId, int karsilikId)
        {
            Sozcuk = sozcuk;
            Anlam1 = anlam1;
            Anlam2 = anlam2;
            SozcukId = sozcukId;
            KarsilikId = karsilikId;
        }

        public override bool Equals(object? obj)
        {
            return obj is SozcukKarsilik other &&
                   Sozcuk == other.Sozcuk &&
                   Anlam1 == other.Anlam1 &&
                   Anlam2 == other.Anlam2 &&
                   SozcukId == other.SozcukId &&
                   KarsilikId == other.KarsilikId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Sozcuk, Anlam1, Anlam2, SozcukId, KarsilikId);
        }
    }
} // Namespace
