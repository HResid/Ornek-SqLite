using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ornek_SQLiteModel.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Karsilik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Szid = table.Column<Guid>(type: "TEXT", nullable: true),
                    Diud = table.Column<Guid>(type: "TEXT", nullable: true),
                    Anlam1 = table.Column<string>(type: "TEXT", nullable: true),
                    Anlam2 = table.Column<string>(type: "TEXT", nullable: true),
                    Anlam3 = table.Column<string>(type: "TEXT", nullable: true),
                    OkunusTr = table.Column<string>(type: "TEXT", nullable: true),
                    OkunusEn = table.Column<string>(type: "TEXT", nullable: true),
                    Aciklama = table.Column<string>(type: "TEXT", nullable: true),
                    OzelKod = table.Column<string>(type: "TEXT", nullable: true),
                    BitOp = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karsilik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KDil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TrAdi = table.Column<string>(type: "TEXT", unicode: false, nullable: true),
                    EnAdi = table.Column<string>(type: "TEXT", unicode: false, nullable: true),
                    OrAdi = table.Column<string>(type: "TEXT", unicode: false, nullable: true),
                    OrAdiA = table.Column<string>(type: "TEXT", nullable: true),
                    Aciklama = table.Column<string>(type: "TEXT", unicode: false, nullable: true),
                    Diud = table.Column<Guid>(type: "TEXT", nullable: false),
                    BitOp = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KDil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sozcuk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Anlam = table.Column<string>(type: "TEXT", unicode: false, nullable: true),
                    EsAnlam = table.Column<string>(type: "TEXT", unicode: false, nullable: true),
                    Aciklama = table.Column<string>(type: "TEXT", unicode: false, nullable: true),
                    EkNot = table.Column<string>(type: "TEXT", unicode: false, nullable: true),
                    Szid = table.Column<Guid>(type: "TEXT", nullable: true),
                    BitOp = table.Column<int>(type: "INTEGER", nullable: false),
                    Kayit = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sozcuk", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "KDil",
                columns: new[] { "Id", "Aciklama", "BitOp", "Diud", "EnAdi", "OrAdi", "OrAdiA", "TrAdi" },
                values: new object[,]
                {
                    { 1, "", 1, new Guid("54e37c59-e509-41a8-9c96-3dff948f43a0"), "English", "", "", "ingilizce" },
                    { 2, "nihongo, bunun bir orjinal yazilisi var, bir de latin", 1, new Guid("be895ac0-bb1e-4af2-b6c9-08382b24a3fc"), "Japanese", "", "nihongo", "Japonca" },
                    { 3, "", 1, new Guid("dc1f81f0-5e8a-448d-ac2b-d12f3c20ad67"), "Arabic", "", "arabiyye", "Arapca" },
                    { 4, "", 1, new Guid("0eb970da-669c-4a37-8d57-45450f5054c7"), "Farsee", "", "Farisi", "Farsca" },
                    { 5, "", 1, new Guid("40d65417-9433-460d-af52-4fc0424e7db9"), "Osmani", "", "", "Osmanlica" },
                    { 6, "", 1, new Guid("d8042675-dcd0-4023-a1b3-03b84d78a129"), "Hongogu", "", "", "Korece" }
                });

            migrationBuilder.InsertData(
                table: "Sozcuk",
                columns: new[] { "Id", "Aciklama", "Anlam", "BitOp", "EkNot", "EsAnlam", "Kayit", "Szid" },
                values: new object[] { 1, "bir emirle baslayak", "Okumak", 1, "", "", new DateTime(2023, 4, 11, 18, 18, 2, 930, DateTimeKind.Local).AddTicks(1880), new Guid("afb58bcd-a5e7-402a-b17e-e557766b431d") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Karsilik");

            migrationBuilder.DropTable(
                name: "KDil");

            migrationBuilder.DropTable(
                name: "Sozcuk");
        }
    }
}
