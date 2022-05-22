﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Product_CRUD.Models;

namespace Product_CRUD.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Product_CRUD.Models.Entities.Category", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("CategoryId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = (short)1,
                            CategoryName = "Drzewka owocowe"
                        },
                        new
                        {
                            Id = (short)2,
                            CategoryName = "Kwiaty"
                        },
                        new
                        {
                            Id = (short)3,
                            CategoryName = "Nasiona warzyw"
                        });
                });

            modelBuilder.Entity("Product_CRUD.Models.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProductId");

                    b.Property<short>("CategoryId")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("NetPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<byte>("TaxId")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TaxId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("24a60996-2b6c-446c-855f-2bf882cf52e4"),
                            CategoryId = (short)1,
                            Name = "Wiśnia",
                            NetPrice = 37.22m,
                            TaxId = (byte)4
                        },
                        new
                        {
                            Id = new Guid("d757b920-4105-489c-9d09-53cf55a0cff5"),
                            CategoryId = (short)1,
                            Name = "Jabłoń",
                            NetPrice = 13.57m,
                            TaxId = (byte)4
                        },
                        new
                        {
                            Id = new Guid("c84e03b1-f997-4693-83c3-99935cd96df2"),
                            CategoryId = (short)3,
                            Name = "Rzodkiewka",
                            NetPrice = 7.22m,
                            TaxId = (byte)4
                        },
                        new
                        {
                            Id = new Guid("0776955f-87b7-46f8-838a-f8d61cc2d343"),
                            CategoryId = (short)3,
                            Name = "Marchew",
                            NetPrice = 1.23m,
                            TaxId = (byte)4
                        },
                        new
                        {
                            Id = new Guid("360940e7-aafc-4f27-9984-1b136c9fa016"),
                            CategoryId = (short)2,
                            Name = "Mak",
                            NetPrice = 37.22m,
                            TaxId = (byte)4
                        },
                        new
                        {
                            Id = new Guid("19ff2003-0eb9-48d7-a248-95920b8f63c6"),
                            CategoryId = (short)1,
                            Name = "Śliwka",
                            NetPrice = 35.23m,
                            TaxId = (byte)4
                        });
                });

            modelBuilder.Entity("Product_CRUD.Models.Entities.Tax", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint")
                        .HasColumnName("TaxId");

                    b.Property<string>("DisplayValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Value")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Taxes");

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            DisplayValue = "23%",
                            Value = 1.23m
                        },
                        new
                        {
                            Id = (byte)2,
                            DisplayValue = "8%",
                            Value = 1.08m
                        },
                        new
                        {
                            Id = (byte)3,
                            DisplayValue = "5%",
                            Value = 1.05m
                        },
                        new
                        {
                            Id = (byte)4,
                            DisplayValue = "0%",
                            Value = 1.00m
                        });
                });

            modelBuilder.Entity("Product_CRUD.Models.Entities.Product", b =>
                {
                    b.HasOne("Product_CRUD.Models.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Product_CRUD.Models.Entities.Tax", "Tax")
                        .WithMany()
                        .HasForeignKey("TaxId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Tax");
                });

            modelBuilder.Entity("Product_CRUD.Models.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
