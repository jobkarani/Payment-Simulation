﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Payment_Simulation.Data;

#nullable disable

namespace Payment_Simulation.Migrations
{
    [DbContext(typeof(TransactionsSimulation))]
    partial class TransactionsSimulationModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("customerAccountNo")
                        .HasColumnType("int");

                    b.Property<Guid>("originatorConversationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("reference")
                        .HasColumnType("nvarchar(max)");

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
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("emailAddress")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("financialInstitution")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("idNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("phoneNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("primaryAccountNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("TransactionsId");

                            b1.ToTable("Recipient");

                            b1.WithOwner()
                                .HasForeignKey("TransactionsId");
                        });

                    b.OwnsOne("Payment_Simulation.Models.Remitter", "Remitter", b1 =>
                        {
                            b1.Property<int>("TransactionsId")
                                .HasColumnType("int");

                            b1.Property<string>("address")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("idNumber")
                                .HasColumnType("int");

                            b1.Property<string>("name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("phoneNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

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
