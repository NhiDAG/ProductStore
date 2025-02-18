﻿// <auto-generated />
using System;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(ProductStoreContext.ProductStore))]
    [Migration("20241025042438_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BussinessObjects.AccountMember", b =>
                {
                    b.Property<string>("MemberId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("MemberPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MemberRole")
                        .HasColumnType("int");

                    b.HasKey("MemberId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            MemberId = "PS0001",
                            EmailAddress = "mem01@gmail.com",
                            FullName = "Nguyen A",
                            MemberPassword = "@1",
                            MemberRole = 1
                        });
                });

            modelBuilder.Entity("BussinessObjects.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Beverages"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Condiments"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Confections"
                        });
                });

            modelBuilder.Entity("BussinessObjects.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<short>("UnitsInStock")
                        .HasColumnType("smallint");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 3,
                            ProductName = "chai",
                            UnitPrice = 18m,
                            UnitsInStock = (short)12
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1,
                            ProductName = "chang",
                            UnitPrice = 19m,
                            UnitsInStock = (short)23
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 2,
                            ProductName = "aniseed",
                            UnitPrice = 10m,
                            UnitsInStock = (short)23
                        });
                });

            modelBuilder.Entity("BussinessObjects.Product", b =>
                {
                    b.HasOne("BussinessObjects.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BussinessObjects.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
