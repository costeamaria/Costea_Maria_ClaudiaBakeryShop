﻿// <auto-generated />
using System;
using Costea_Maria_ClaudiaBakeryShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Costea_Maria_ClaudiaBakeryShop.Migrations
{
    [DbContext(typeof(Costea_Maria_ClaudiaBakeryShopContext))]
    partial class Costea_Maria_ClaudiaBakeryShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Costea_Maria_ClaudiaBakeryShop.Models.Adress", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("AdressName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Adress");
                });

            modelBuilder.Entity("Costea_Maria_ClaudiaBakeryShop.Models.Cart", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("MemberID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MemberID");

                    b.HasIndex("ProductID");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("Costea_Maria_ClaudiaBakeryShop.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Costea_Maria_ClaudiaBakeryShop.Models.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Costea_Maria_ClaudiaBakeryShop.Models.Member", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("Costea_Maria_ClaudiaBakeryShop.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("AdressID")
                        .HasColumnType("int");

                    b.Property<int?>("CityID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.Property<int?>("QuantityID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AdressID");

                    b.HasIndex("CityID");

                    b.HasIndex("QuantityID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Costea_Maria_ClaudiaBakeryShop.Models.ProductCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("Costea_Maria_ClaudiaBakeryShop.Models.Quantity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("QuantityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Quantity");
                });

            modelBuilder.Entity("Costea_Maria_ClaudiaBakeryShop.Models.Cart", b =>
                {
                    b.HasOne("Costea_Maria_ClaudiaBakeryShop.Models.Member", "Member")
                        .WithMany("Carts")
                        .HasForeignKey("MemberID");

                    b.HasOne("Costea_Maria_ClaudiaBakeryShop.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID");

                    b.Navigation("Member");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Costea_Maria_ClaudiaBakeryShop.Models.Product", b =>
                {
                    b.HasOne("Costea_Maria_ClaudiaBakeryShop.Models.Adress", "Adress")
                        .WithMany("Products")
                        .HasForeignKey("AdressID");

                    b.HasOne("Costea_Maria_ClaudiaBakeryShop.Models.City", "City")
                        .WithMany("Products")
                        .HasForeignKey("CityID");

                    b.HasOne("Costea_Maria_ClaudiaBakeryShop.Models.Quantity", "Quantity")
                        .WithMany("Products")
                        .HasForeignKey("QuantityID");

                    b.Navigation("Adress");

                    b.Navigation("City");

                    b.Navigation("Quantity");
                });

            modelBuilder.Entity("Costea_Maria_ClaudiaBakeryShop.Models.ProductCategory", b =>
                {
                    b.HasOne("Costea_Maria_ClaudiaBakeryShop.Models.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Costea_Maria_ClaudiaBakeryShop.Models.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Costea_Maria_ClaudiaBakeryShop.Models.Adress", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Costea_Maria_ClaudiaBakeryShop.Models.Category", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("Costea_Maria_ClaudiaBakeryShop.Models.City", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Costea_Maria_ClaudiaBakeryShop.Models.Member", b =>
                {
                    b.Navigation("Carts");
                });

            modelBuilder.Entity("Costea_Maria_ClaudiaBakeryShop.Models.Product", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("Costea_Maria_ClaudiaBakeryShop.Models.Quantity", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
