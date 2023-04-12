/*
10/04/2023 
SQLite Sample
SQLite Ornek
*/

using Ornek_SqLiteCon;
using Ornek_SQLiteModel;

Console.WriteLine("SQLite Örneklerini içeren projedir. Başlangıç, 10.04.2023");

// new DosMenu().Menu();
 new SozcukMenu().ShowMenu();

// string byol = new Ornek_SQLiteModel.VTPath().BulutYol();
// Console.WriteLine(byol);
// 
// string bag;
// OrnekSQLiteContext db = new OrnekSQLiteContext();
// bag = db.Baglanti();
// Console.WriteLine(bag);
// C: \Users\hresid.DEVGEMU\AppData\Local\SQLite.db

//OrnekSQLiteContext db2 = new OrnekSQLiteContext(byol);
//bag = db2.Baglanti();
//Console.WriteLine(bag);

// db2.KDils.ToList().ForEach(x => Console.WriteLine(x.DilAdi));
//try
//{
//    db.KDil.ToList();
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.ToString());
//}


/*
Amaç: Örnek bir SQLite projesi oluşturmak

Adımlar:
- Bir kütüphane projesi içersinde, SQLite veritabanı için gerekli modelleri hazırlayıp,
a. Console
b. Masaüstü
c. Web
olarak ayrı ayrı örnek projeleri eklemek.

Çözüm Dosyası: Ornek-SqLite

Console: Ornek-SQLiteCon

--------------------------------------------------------------
Tüm projeler, yüklü olan;
Microsoft Visual Studio Professional 2022 (64-bit) - Preview
Version 17.6.0 Preview 2.0
ile hazırlanır.
--------------------------------------------------------------

Model Proje: Ornek-SQLiteModel
Veritabani Adi: Ornek-SQLite.db
Yol: /kullanici/Documents klasoru

SQLiteModel'e 
using Microsoft.EntityFrameworkCore;


Nuget Packages
		<PackageReference Include="Microsoft.Data.Sqlite.Core" Version="6.0.7" />
		<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="6.0.7">
			<PrivateAssets>all</PrivateAssets>
			<IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
		</PackageReference>
		<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="6.0.7" />

*/
