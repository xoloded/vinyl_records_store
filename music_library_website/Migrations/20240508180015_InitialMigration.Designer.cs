﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using music_library_website.Data;

#nullable disable

namespace music_library_website.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240508180015_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("music_library_website.Data.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypesOfMusic")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("music_library_website.Data.Models.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("music_library_website.Data.Models.OrderDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<long>("VinylRecordId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("VinylRecordId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("music_library_website.Data.Models.ShopCartItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ShopCartId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("VinylRecordId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("VinylRecordId");

                    b.ToTable("ShopCartItems");
                });

            modelBuilder.Entity("music_library_website.Data.Models.VinylRecord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Album")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Singer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearOfRelease")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("VinylRecords");
                });

            modelBuilder.Entity("music_library_website.Data.Models.OrderDetail", b =>
                {
                    b.HasOne("music_library_website.Data.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("music_library_website.Data.Models.VinylRecord", "VinylRecord")
                        .WithMany()
                        .HasForeignKey("VinylRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("VinylRecord");
                });

            modelBuilder.Entity("music_library_website.Data.Models.ShopCartItem", b =>
                {
                    b.HasOne("music_library_website.Data.Models.VinylRecord", "VinylRecord")
                        .WithMany()
                        .HasForeignKey("VinylRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VinylRecord");
                });

            modelBuilder.Entity("music_library_website.Data.Models.VinylRecord", b =>
                {
                    b.HasOne("music_library_website.Data.Models.Category", "Category")
                        .WithMany("VinylRecords")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("music_library_website.Data.Models.Category", b =>
                {
                    b.Navigation("VinylRecords");
                });

            modelBuilder.Entity("music_library_website.Data.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
