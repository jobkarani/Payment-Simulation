using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payment_Simulation.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    routeId = table.Column<int>(type: "int", nullable: false),
                    originatorConversationId = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    amount = table.Column<float>(type: "real", nullable: false),
                    reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    channelType = table.Column<int>(type: "int", nullable: false),
                    customerAccountNo = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: false),
                    Remitter_name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Remitter_address = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Remitter_phoneNumber = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: false),
                    Remitter_idNumber = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: false)
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
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    address = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    emailAddress = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    idNumber = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: false),
                    financialInstitution = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipient");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
