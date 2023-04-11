using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ornek_SQLiteModel
{
    /// <summary>
    /// Karsilik/Anlam dili
    /// </summary>
    /// <remarks>
    /// Created: 11/04/2023 14:05, HRe.. 
    /// </remarks>
    public class KDil
    {
        /// <summary>
        /// sira takip eden numara
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// sozcuk anlaminin verilecegi dil adi:
        /// ingilizce, arapca, japonca gibi
        /// </summary>
        public string TrAdi { get; set; }
        public string EnAdi { get; set; }
        /// <summary>
        /// dilin orjinali: english, german
        /// </summary>
        public string OrAdi { get; set; }
        /// <summary>
        /// latin alfabesi
        /// </summary>
        public string OrAdiA { get; set; }

        /// <summary>
        /// varsa ek aciklama
        /// </summary>
        public string Aciklama { get; set; }
        /// <summary>
        /// unique identifier
        /// [PrimaryKey("Diud")]
        /// </summary>
        public Guid Diud { get; set; }

        /// <summary>
        /// null/0, 1-varsayilan gorunur, 
        /// </summary>
        public int BitOp { get; set; } = 1;

    }
}
