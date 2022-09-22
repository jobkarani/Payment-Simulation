﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payment_Simulation.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionsDTO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionsDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipientAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipientEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipientFinancialInstitution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipientIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipientPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipientPrimaryAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RemitterAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RemitterFinancialInstitution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RemitterIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RemitterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RemitterPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RemitterPrimaryAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount = table.Column<float>(type: "real", nullable: false),
                    channelType = table.Column<int>(type: "int", nullable: false),
                    customerAccountNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    financialInstitution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    originatorConversationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    primaryAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    routeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    systemConversationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    systemTraceAuditNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionsDTO", x => x.Id);
                });
        }
    }
}
