﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ssb_api.Models;

#nullable disable

namespace ssb_api.Migrations
{
    [DbContext(typeof(BudgetContext))]
    partial class BudgetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
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

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("BudgetEvents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Balance = 100m,
                            Date = new DateTime(2023, 9, 16, 18, 30, 38, 433, DateTimeKind.Local).AddTicks(1428),
                            Description = "T-Mobile Family Plan",
                            DueDate = new DateTime(2023, 9, 16, 18, 30, 38, 433, DateTimeKind.Local).AddTicks(1441),
                            IsPaid = false,
                            ItemId = 4,
                            Name = "Cell Phone - September 2023",
                            Note = "Cell phone event note"
                        },
                        new
                        {
                            Id = 2,
                            Balance = 200m,
                            Date = new DateTime(2023, 9, 18, 18, 30, 38, 433, DateTimeKind.Local).AddTicks(1443),
                            DueDate = new DateTime(2023, 9, 18, 18, 30, 38, 433, DateTimeKind.Local).AddTicks(1444),
                            IsPaid = false,
                            ItemId = 1,
                            Name = "School books Fall 23",
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
                            Amount = 0m,
                            Name = "Utility",
                            Occurrence = 0
                        },
                        new
                        {
                            Id = 2,
                            Amount = 1500m,
                            Description = "Level 9000 Apartments",
                            Name = "Rent",
                            Occurrence = 1,
                            OccurrenceDay = 1
                        },
                        new
                        {
                            Id = 3,
                            Amount = 40m,
                            Description = "Chell or Chevron",
                            Name = "Gas",
                            Occurrence = 2,
                            OccurrenceDay = 4
                        },
                        new
                        {
                            Id = 4,
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
                        .WithMany("Events")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BudgetItem");
                });

            modelBuilder.Entity("ssb_api.Models.BudgetItem", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
