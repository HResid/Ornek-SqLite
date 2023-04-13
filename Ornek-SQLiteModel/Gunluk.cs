using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ornek_SQLiteModel
{
    /// <summary>
    /// gunluk kelime listesi
    /// </summary>
    /// <remarks>
    /// created: 13/04/2023 1402, HRe.. 
    /// </remarks>
    public class Gunluk
    {
        public int Id { get; set; }

        public int DilId { get; set; }
        public int SozcukId { get; set; }
        public DateTime Tarih { get; set; }

    }
}
