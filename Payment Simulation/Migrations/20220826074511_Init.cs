using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payment_Simulation.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    originatorConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    amount = table.Column<float>(type: "real", nullable: false),
                    reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    channelType = table.Column<int>(type: "int", nullable: false),
                    customerAccountNo = table.Column<int>(type: "int", nullable: false),
                    Remitter_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remitter_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remitter_phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remitter_idNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipient",
                columns: table => new
                {
                    TransactionsId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    financialInstitution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    primaryAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipient", x => x.TransactionsId);
                    table.ForeignKey(
                        name: "FK_Recipient_Transactions_TransactionsId",
                        column: x => x.TransactionsId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipient");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
