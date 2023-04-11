﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ornek_SQLiteModel;

#nullable disable

namespace Ornek_SQLiteModel.Migrations
{
    [DbContext(typeof(OrnekSQLiteContext))]
    partial class OrnekSQLiteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("Ornek_SQLiteModel.KDil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Aciklama")
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<int>("BitOp")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("Diud")
                        .HasColumnType("TEXT");

                    b.Property<string>("EnAdi")
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<string>("OrAdi")
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<string>("OrAdiA")
                        .HasColumnType("TEXT");

                    b.Property<string>("TrAdi")
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("KDil");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Aciklama = "",
                            BitOp = 1,
                            Diud = new Guid("e7959028-d362-4a2a-b446-9bbd64e881eb"),
                            EnAdi = "English",
                            OrAdi = "",
                            OrAdiA = "",
                            TrAdi = "ingilizce"
                        },
                        new
                        {
                            Id = 2,
                            Aciklama = "nihongo, bunun bir orjinal yazilisi var, bir de latin",
                            BitOp = 1,
                            Diud = new Guid("ff8e3459-1131-4371-b750-7fa4f93d8145"),
                            EnAdi = "Japanese",
                            OrAdi = "",
                            OrAdiA = "nihongo",
                            TrAdi = "Japonca"
                        },
                        new
                        {
                            Id = 3,
                            Aciklama = "",
                            BitOp = 1,
                            Diud = new Guid("34d4d9f0-323f-4d3b-8e58-758ea412a199"),
                            EnAdi = "Arabic",
                            OrAdi = "",
                            OrAdiA = "arabiyye",
                            TrAdi = "Arapca"
                        },
                        new
                        {
                            Id = 4,
                            Aciklama = "",
                            BitOp = 1,
                            Diud = new Guid("ba1d84f5-36e5-4002-a5a7-f9d78910ef5b"),
                            EnAdi = "Farsee",
                            OrAdi = "",
                            OrAdiA = "Farisi",
                            TrAdi = "Farsca"
                        },
                        new
                        {
                            Id = 5,
                            Aciklama = "",
                            BitOp = 1,
                            Diud = new Guid("c8b91209-f985-4aaf-96a3-ac015b74dc4b"),
                            EnAdi = "Osmani",
                            OrAdi = "",
                            OrAdiA = "",
                            TrAdi = "Osmanlica"
                        },
                        new
                        {
                            Id = 6,
                            Aciklama = "",
                            BitOp = 1,
                            Diud = new Guid("74232524-0fd0-4b5d-a1ad-4404d5e0a18b"),
                            EnAdi = "Hongogu",
                            OrAdi = "",
                            OrAdiA = "",
                            TrAdi = "Korece"
                        });
                });

            modelBuilder.Entity("Ornek_SQLiteModel.Karsilik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Aciklama")
                        .HasColumnType("TEXT");

                    b.Property<string>("Anlam1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Anlam2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Anlam3")
                        .HasColumnType("TEXT");

                    b.Property<int>("BitOp")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("Diud")
                        .HasColumnType("TEXT");

                    b.Property<string>("OkunusEn")
                        .HasColumnType("TEXT");

                    b.Property<string>("OkunusTr")
                        .HasColumnType("TEXT");

                    b.Property<string>("OzelKod")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("Szid")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Karsilik");
                });

            modelBuilder.Entity("Ornek_SQLiteModel.Sozcuk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Aciklama")
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<string>("Anlam")
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<int>("BitOp")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EkNot")
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<string>("EsAnlam")
                        .IsUnicode(false)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Kayit")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("Szid")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sozcuk");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Aciklama = "bir emirle baslayak",
                            Anlam = "Okumak",
                            BitOp = 1,
                            EkNot = "",
                            EsAnlam = "",
                            Kayit = new DateTime(2023, 4, 11, 15, 20, 39, 995, DateTimeKind.Local).AddTicks(3428),
                            Szid = new Guid("d77bfd1f-ad1a-4eaa-8ecc-b258fba42014")
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
