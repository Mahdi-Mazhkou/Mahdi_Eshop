﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shoping.DomainModel.Models;

#nullable disable

namespace Shoping.DomainModel.Migrations
{
    [DbContext(typeof(ShopingMashtiMahdiContext))]
    [Migration("20240723161246_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Shoping.DomainModel.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LineAge")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.HasKey("CategoryID");

                    b.HasIndex("ParentID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Shoping.DomainModel.Models.CategoryFeature", b =>
                {
                    b.Property<int>("CategoryFeatureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryFeatureID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("FeatureID")
                        .HasColumnType("int");

                    b.HasKey("CategoryFeatureID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("FeatureID");

                    b.ToTable("CategoryFeatures");
                });

            modelBuilder.Entity("Shoping.DomainModel.Models.Feature", b =>
                {
                    b.Property<int>("FeatureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeatureID"), 1L, 1);

                    b.Property<string>("FeatureName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("FeatureID");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("Shoping.DomainModel.Models.KeyWord", b =>
                {
                    b.Property<int>("KeyWordID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KeyWordID"), 1L, 1);

                    b.Property<string>("KeyWordText")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("KeyWordID");

                    b.ToTable("KeyWords");
                });

            modelBuilder.Entity("Shoping.DomainModel.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"), 1L, 1);

                    b.Property<int>("AddressID")
                        .HasColumnType("int");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderDescription")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.HasKey("OrderID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Shoping.DomainModel.Models.OrderDetails", b =>
                {
                    b.Property<int>("OrderDetailsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailsID"), 1L, 1);

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.Property<int>("UnitPrice")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailsID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Shoping.DomainModel.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("JSONLDInformation")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("MetaDescription")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("MetaKeyword")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("nvarchar(160)");

                    b.Property<string>("PageTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<long>("UnitPrice")
                        .HasColumnType("bigint");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Shoping.DomainModel.Models.ProductFeature", b =>
                {
                    b.Property<int>("ProductFeatureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductFeatureID"), 1L, 1);

                    b.Property<int>("EffectOnUnitPrice")
                        .HasColumnType("int");

                    b.Property<int>("FeatureID")
                        .HasColumnType("int");

                    b.Property<int>("ProductFeatureValue")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("ProductFeatureID");

                    b.HasIndex("FeatureID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductFeatures");
                });

            modelBuilder.Entity("Shoping.DomainModel.Models.ProductKeyword", b =>
                {
                    b.Property<int>("ProductKeywordID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductKeywordID"), 1L, 1);

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("keywordID")
                        .HasColumnType("int");

                    b.HasKey("ProductKeywordID");

                    b.HasIndex("ProductID");

                    b.HasIndex("keywordID");

                    b.ToTable("ProductKeywords");
                });

            modelBuilder.Entity("Shoping.DomainModel.Models.Category", b =>
                {
                    b.HasOne("Shoping.DomainModel.Models.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Shoping.DomainModel.Models.CategoryFeature", b =>
                {
                    b.HasOne("Shoping.DomainModel.Models.Category", "Category")
                        .WithMany("CategoryFeatures")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shoping.DomainModel.Models.Feature", "Feature")
                        .WithMany("CategoryFeatures")
                        .HasForeignKey("FeatureID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Feature");
                });

            modelBuilder.Entity("Shoping.DomainModel.Models.OrderDetails", b =>
                {
                    b.HasOne("Shoping.DomainModel.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Shoping.DomainModel.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Shoping.DomainModel.Models.Product", b =>
                {
                    b.HasOne("Shoping.DomainModel.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Shoping.DomainModel.Models.ProductFeature", b =>
                {
                    b.HasOne("Shoping.DomainModel.Models.Feature", "Feature")
                        .WithMany()
                        .HasForeignKey("FeatureID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shoping.DomainModel.Models.Product", "Product")
                        .WithMany("ProductFeatures")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feature");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Shoping.DomainModel.Models.ProductKeyword", b =>
                {
                    b.HasOne("Shoping.DomainModel.Models.Product", "Product")
                        .WithMany("ProductKeywords")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shoping.DomainModel.Models.KeyWord", "KeyWord")
                        .WithMany("ProductKeywords")
                        .HasForeignKey("keywordID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KeyWord");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Shoping.DomainModel.Models.Category", b =>
                {
                    b.Navigation("CategoryFeatures");

                    b.Navigation("Children");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Shoping.DomainModel.Models.Feature", b =>
                {
                    b.Navigation("CategoryFeatures");
                });

            modelBuilder.Entity("Shoping.DomainModel.Models.KeyWord", b =>
                {
                    b.Navigation("ProductKeywords");
                });

            modelBuilder.Entity("Shoping.DomainModel.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Shoping.DomainModel.Models.Product", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("ProductFeatures");

                    b.Navigation("ProductKeywords");
                });
#pragma warning restore 612, 618
        }
    }
}
