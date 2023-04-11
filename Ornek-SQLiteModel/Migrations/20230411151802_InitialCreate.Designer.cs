﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ornek_SQLiteModel;

#nullable disable

namespace Ornek_SQLiteModel.Migrations
{
    [DbContext(typeof(OrnekSQLiteContext))]
    [Migration("20230411151802_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Diud = new Guid("54e37c59-e509-41a8-9c96-3dff948f43a0"),
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
                            Diud = new Guid("be895ac0-bb1e-4af2-b6c9-08382b24a3fc"),
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
                            Diud = new Guid("dc1f81f0-5e8a-448d-ac2b-d12f3c20ad67"),
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
                            Diud = new Guid("0eb970da-669c-4a37-8d57-45450f5054c7"),
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
                            Diud = new Guid("40d65417-9433-460d-af52-4fc0424e7db9"),
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
                            Diud = new Guid("d8042675-dcd0-4023-a1b3-03b84d78a129"),
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
                            Kayit = new DateTime(2023, 4, 11, 18, 18, 2, 930, DateTimeKind.Local).AddTicks(1880),
                            Szid = new Guid("afb58bcd-a5e7-402a-b17e-e557766b431d")
                        });
                });
#pragma warning restore 612, 618
        }
    }
}