using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payment_Simulation.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateCreated = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    routeId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    systemConversationId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    originatorConversationId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    amount = table.Column<float>(type: "real", nullable: false),
                    reference = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    channelType = table.Column<int>(type: "int", nullable: false),
                    resultCodeDescription = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    feeAmount = table.Column<double>(type: "float", nullable: false),
                    statusDescription = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    trackingNumber = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Remitter_name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Remitter_address = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Remitter_phoneNumber = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: false),
                    Remitter_idNumber = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: false),
                    Remitter_financialInstitution = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Remitter_primaryAccountNumber = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: false),
                    Recipient_name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Recipient_address = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Recipient_emailAddress = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Recipient_phoneNumber = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Recipient_idNumber = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: false),
                    Recipient_financialInstitution = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Recipient_primaryAccountNumber = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
