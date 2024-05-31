﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using back_end.Context;

#nullable disable

namespace back_end.Migrations
{
    [DbContext(typeof(WalletContext))]
    [Migration("20240531213000_UpdateDecimalProperties")]
    partial class UpdateDecimalProperties
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("back_end.Models.CashFlow", b =>
                {
                    b.Property<int>("CashFlowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CashFlowId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Expense")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Profit")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("CashFlowId");

                    b.ToTable("CashFlows");
                });

            modelBuilder.Entity("back_end.Models.User", b =>
                {
                    b.Property<int>("NameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NameId"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NameId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("back_end.Models.Wallet", b =>
                {
                    b.Property<int>("WalletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WalletId"));

                    b.Property<int?>("CashFlowId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Investment")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("NameId")
                        .HasColumnType("int");

                    b.Property<string>("WalletName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WalletId");

                    b.HasIndex("CashFlowId");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("back_end.Models.Wallet", b =>
                {
                    b.HasOne("back_end.Models.CashFlow", null)
                        .WithMany("Wallet")
                        .HasForeignKey("CashFlowId");
                });

            modelBuilder.Entity("back_end.Models.CashFlow", b =>
                {
                    b.Navigation("Wallet");
                });
#pragma warning restore 612, 618
        }
    }
}