using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcurementManagerUltimate.Migrations
{
    public partial class ConReceipts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Receipt",
                table: "Contracts",
                type: "TEXT",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Receipt",
                table: "Contracts");
        }
    }
}
