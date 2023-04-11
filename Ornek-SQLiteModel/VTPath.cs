using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ornek_SQLiteModel
{
    public class VTPath
    {
        private string vtDosya = "SQLite.db";
        private string vtYol = string.Empty;

        public string YerelYol()
        {
            // baglantiMetni = "Data Source=";
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            vtYol = Path.Join(path, "SQLiteStore", vtDosya);
            
            return vtYol;
        }

        public string BulutYol()
        {
            // C:\Users\user\OneDrive
            string? OnePath = Environment.GetEnvironmentVariable("ONEDRIVE");
            string geciciYol = string.Empty;

            if (string.IsNullOrEmpty(OnePath))
            {
                // onedrive yolu alinamadi,
                // belgeler klasorunu kullan
                geciciYol = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            else
            {
                geciciYol = OnePath;
            }

            // klasor kontrolu yapilmayacak
            // c:\users\user\documents\VASpace\SQLite.db
            // c:\users\user\OneDrive\VASpace\SQLite.db
            vtYol = Path.Combine(geciciYol, "VASpace", "Ornek", vtDosya);

            // baglantiMetni = $"Data Source={vtYol};Cache=Shared;";
            return vtYol; 
        }

    }
}
