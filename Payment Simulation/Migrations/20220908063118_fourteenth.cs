using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payment_Simulation.Migrations
{
    public partial class fourteenth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "trackingNumber",
                table: "Transactions",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "trackingNumber",
                table: "Transactions");
        }
    }
}
