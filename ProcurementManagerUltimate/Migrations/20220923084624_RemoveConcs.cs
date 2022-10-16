using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcurementManagerUltimate.Migrations
{
    public partial class RemoveConcs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Concurrency",
                table: "Timelines");

            migrationBuilder.DropColumn(
                name: "Concurrency",
                table: "Sources");

            migrationBuilder.DropColumn(
                name: "Concurrency",
                table: "Methods");

            migrationBuilder.DropColumn(
                name: "Concurrency",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Concurrency",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "Concurrency",
                table: "ContractParameters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Concurrency",
                table: "Timelines",
                type: "BLOB",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Concurrency",
                table: "Sources",
                type: "BLOB",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Concurrency",
                table: "Methods",
                type: "BLOB",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Concurrency",
                table: "Items",
                type: "BLOB",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Concurrency",
                table: "Contracts",
                type: "BLOB",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Concurrency",
                table: "ContractParameters",
                type: "BLOB",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
