﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Payment_Simulation.Data;

#nullable disable

namespace Payment_Simulation.Migrations
{
    [DbContext(typeof(TransactionsSimulation))]
    [Migration("20220920135949_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Payment_Simulation.Models.Transactions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("amount")
                        .HasColumnType("real");

                    b.Property<int>("channelType")
                        .HasColumnType("int");

                    b.Property<double?>("feeAmount")
                        .HasColumnType("float");

                    b.Property<string>("originatorConversationId")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("reference")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("resultCodeDescription")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("routeId")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("systemConversationId")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("trackingNumber")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("transactionStatusDescription")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("Payment_Simulation.Models.Transactions", b =>
                {
                    b.OwnsOne("Payment_Simulation.Models.Recipient", "Recipient", b1 =>
                        {
                            b1.Property<int>("TransactionsId")
                                .HasColumnType("int");

                            b1.Property<string>("address")
                                .IsRequired()
                                .HasMaxLength(128)
                                .HasColumnType("nvarchar(128)");

                            b1.Property<string>("emailAddress")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("nvarchar(64)");

                            b1.Property<string>("financialInstitution")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("nvarchar(64)");

                            b1.Property<string>("idNumber")
                                .IsRequired()
                                .HasMaxLength(28)
                                .HasColumnType("nvarchar(28)");

                            b1.Property<string>("name")
                                .IsRequired()
                                .HasMaxLength(128)
                                .HasColumnType("nvarchar(128)");

                            b1.Property<string>("phoneNumber")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("nvarchar(64)");

                            b1.Property<string>("primaryAccountNumber")
                                .IsRequired()
                                .HasMaxLength(28)
                                .HasColumnType("nvarchar(28)");

                            b1.HasKey("TransactionsId");

                            b1.ToTable("Transactions");

                            b1.WithOwner()
                                .HasForeignKey("TransactionsId");
                        });

                    b.OwnsOne("Payment_Simulation.Models.Remitter", "Remitter", b1 =>
                        {
                            b1.Property<int>("TransactionsId")
                                .HasColumnType("int");

                            b1.Property<string>("address")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("nvarchar(64)");

                            b1.Property<string>("financialInstitution")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("nvarchar(64)");

                            b1.Property<string>("idNumber")
                                .IsRequired()
                                .HasMaxLength(28)
                                .HasColumnType("nvarchar(28)");

                            b1.Property<string>("name")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("nvarchar(64)");

                            b1.Property<string>("phoneNumber")
                                .IsRequired()
                                .HasMaxLength(28)
                                .HasColumnType("nvarchar(28)");

                            b1.Property<string>("primaryAccountNumber")
                                .IsRequired()
                                .HasMaxLength(28)
                                .HasColumnType("nvarchar(28)");

                            b1.HasKey("TransactionsId");

                            b1.ToTable("Transactions");

                            b1.WithOwner()
                                .HasForeignKey("TransactionsId");
                        });

                    b.Navigation("Recipient")
                        .IsRequired();

                    b.Navigation("Remitter")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
