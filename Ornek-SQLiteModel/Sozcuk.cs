﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ornek_SQLiteModel
{
    /// <summary>
    /// Sozluk - 
    /// </summary>
    /// <remarks>
    /// Created: 11.04.2023 14:07, HRe..
    /// </remarks>
    public class Sozcuk
    {
        public int Id { get; set; }
        public string Anlam { get; set; }
        public string EsAnlam { get; set; }
        public string Aciklama { get; set; }
        public string EkNot { get; set; }
        // Szid idi
        public Guid? Uid { get; set; }

        /// <summary>
        /// null/0, 1-varsayilan gorunur, 
        /// </summary>
        public int BitOp { get; set; } = 1;

        public DateTime Kayit { get; set; } = DateTime.Now;

        public string Seri { get; set; }
        public int? Sira { get; set; }
        public string EkNo { get; set; }

    }
}
