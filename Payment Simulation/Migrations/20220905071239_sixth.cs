using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payment_Simulation.Migrations
{
    public partial class sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipient");

            migrationBuilder.AddColumn<string>(
                name: "Recipient_address",
                table: "Transactions",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Recipient_emailAddress",
                table: "Transactions",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Recipient_financialInstitution",
                table: "Transactions",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Recipient_idNumber",
                table: "Transactions",
                type: "nvarchar(28)",
                maxLength: 28,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Recipient_name",
                table: "Transactions",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Recipient_phoneNumber",
                table: "Transactions",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Recipient_primaryAccountNumber",
                table: "Transactions",
                type: "nvarchar(28)",
                maxLength: 28,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Recipient_address",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Recipient_emailAddress",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Recipient_financialInstitution",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Recipient_idNumber",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Recipient_name",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Recipient_phoneNumber",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Recipient_primaryAccountNumber",
                table: "Transactions");

            migrationBuilder.CreateTable(
                name: "Recipient",
                columns: table => new
                {
                    TransactionsId = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    emailAddress = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    financialInstitution = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    idNumber = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: false),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    primaryAccountNumber = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: false)
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
    }
}
