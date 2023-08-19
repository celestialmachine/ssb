﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ssb_api.Models;

#nullable disable

namespace ssb_api.Migrations
{
    [DbContext(typeof(BudgetContext))]
    [Migration("20230819233412_Event")]
    partial class Event
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ssb_api.Models.BudgetEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Balance")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("BudgetItemId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BudgetItemId");

                    b.ToTable("BudgetEvents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Balance = 100m,
                            Date = new DateTime(2023, 9, 16, 16, 34, 12, 568, DateTimeKind.Local).AddTicks(1308),
                            DueDate = new DateTime(2023, 9, 16, 16, 34, 12, 568, DateTimeKind.Local).AddTicks(1322),
                            IsPaid = false,
                            ItemId = 1,
                            Note = "Cell phone event note"
                        },
                        new
                        {
                            Id = 2,
                            Balance = 200m,
                            Date = new DateTime(2023, 9, 18, 16, 34, 12, 568, DateTimeKind.Local).AddTicks(1323),
                            DueDate = new DateTime(2023, 9, 18, 16, 34, 12, 568, DateTimeKind.Local).AddTicks(1324),
                            IsPaid = false,
                            Note = "This event has no item reference"
                        });
                });

            modelBuilder.Entity("ssb_api.Models.BudgetItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Occurrence")
                        .HasColumnType("int");

                    b.Property<int?>("OccurrenceDay")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BudgetItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 100m,
                            Description = "T-Mobile Family Plan",
                            Name = "Cell Phone",
                            Occurrence = 1,
                            OccurrenceDay = 15
                        });
                });

            modelBuilder.Entity("ssb_api.Models.BudgetEvent", b =>
                {
                    b.HasOne("ssb_api.Models.BudgetItem", "BudgetItem")
                        .WithMany()
                        .HasForeignKey("BudgetItemId");

                    b.Navigation("BudgetItem");
                });
#pragma warning restore 612, 618
        }
    }
}
