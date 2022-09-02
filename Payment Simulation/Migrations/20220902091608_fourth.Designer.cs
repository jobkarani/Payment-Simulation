﻿// <auto-generated />
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
    [Migration("20220902091608_fourth")]
    partial class fourth
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

                    b.Property<string>("originatorConversationId")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("reference")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("routeId")
                        .HasColumnType("int");

                    b.Property<string>("systemConversationId")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

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
                                .HasMaxLength(64)
                                .HasColumnType("nvarchar(64)");

                            b1.Property<string>("financialInstitution")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

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
