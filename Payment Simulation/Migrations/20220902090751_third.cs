using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payment_Simulation.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "customerAccountNo",
                table: "Transactions",
                newName: "Remitter_primaryAccountNumber");

            migrationBuilder.AlterColumn<string>(
                name: "reference",
                table: "Transactions",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remitter_financialInstitution",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remitter_financialInstitution",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "Remitter_primaryAccountNumber",
                table: "Transactions",
                newName: "customerAccountNo");

            migrationBuilder.AlterColumn<string>(
                name: "reference",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldNullable: true);
        }
    }
}
