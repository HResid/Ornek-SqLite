using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ornek_SQLiteModel
{
    /// <summary>
    ///  farkli dildeki karsiligi
    /// </summary>
    /// <remarks>
    /// Created: 11.04.2023 14:12, HRe..
    /// </remarks>
    public class Karsilik
    {
        public Karsilik()
        {
                
        }

        public Karsilik(int varsayilanBaslat)
        {
            Anlam1 = "";
            Anlam2 = "";
        }
        /// <summary>
        /// sira takip eden sayi
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Sozcuk Guid (Szid)
        /// </summary>
        public Guid SozcukUid { get; set; }
        /// <summary>
        ///  sorgularda vs. pratik oluyor.
        /// </summary>
        public int SozcukId { get; set; } = 0;
        /// <summary>
        /// Dil Guid
        /// </summary>
        public Guid DilUid { get; set; }
        /// <summary>
        /// sorgularda vs. pratik oluyor.
        /// </summary>
        public int DilId { get; set; } = 0;

        public string Anlam1 { get; set; }
        public string Anlam2 { get; set; }
        public string Anlam3 { get; set; }
        public string OkunusTr { get; set; }
        public string OkunusEn { get; set; }
        public string Aciklama { get; set; }
        public string OzelKod { get; set; }

        /// <summary>
        /// null/0, 1-varsayilan gorunur, 
        /// </summary>
        public int BitOp { get; set; } = 1;

    }
}
