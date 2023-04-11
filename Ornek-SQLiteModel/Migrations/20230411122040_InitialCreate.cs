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
                    { 1, "", 1, new Guid("e7959028-d362-4a2a-b446-9bbd64e881eb"), "English", "", "", "ingilizce" },
                    { 2, "nihongo, bunun bir orjinal yazilisi var, bir de latin", 1, new Guid("ff8e3459-1131-4371-b750-7fa4f93d8145"), "Japanese", "", "nihongo", "Japonca" },
                    { 3, "", 1, new Guid("34d4d9f0-323f-4d3b-8e58-758ea412a199"), "Arabic", "", "arabiyye", "Arapca" },
                    { 4, "", 1, new Guid("ba1d84f5-36e5-4002-a5a7-f9d78910ef5b"), "Farsee", "", "Farisi", "Farsca" },
                    { 5, "", 1, new Guid("c8b91209-f985-4aaf-96a3-ac015b74dc4b"), "Osmani", "", "", "Osmanlica" },
                    { 6, "", 1, new Guid("74232524-0fd0-4b5d-a1ad-4404d5e0a18b"), "Hongogu", "", "", "Korece" }
                });

            migrationBuilder.InsertData(
                table: "Sozcuk",
                columns: new[] { "Id", "Aciklama", "Anlam", "BitOp", "EkNot", "EsAnlam", "Kayit", "Szid" },
                values: new object[] { 1, "bir emirle baslayak", "Okumak", 1, "", "", new DateTime(2023, 4, 11, 15, 20, 39, 995, DateTimeKind.Local).AddTicks(3428), new Guid("d77bfd1f-ad1a-4eaa-8ecc-b258fba42014") });
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
