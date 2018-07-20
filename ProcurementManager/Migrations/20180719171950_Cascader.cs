using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcurementManager.Migrations
{
    public partial class Cascader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Methods",
                columns: table => new
                {
                    MethodsID = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Method = table.Column<string>(maxLength: 50, nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Methods", x => x.MethodsID);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    ContractsID = table.Column<string>(maxLength: 30, nullable: false),
                    Subject = table.Column<string>(maxLength: 150, nullable: false),
                    MethodsID = table.Column<short>(nullable: false),
                    Contractor = table.Column<string>(maxLength: 200, nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    IsFlexible = table.Column<bool>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    DateSigned = table.Column<DateTime>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    ExpectedDate = table.Column<DateTime>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.ContractsID);
                    table.ForeignKey(
                        name: "FK_Contracts_Methods_MethodsID",
                        column: x => x.MethodsID,
                        principalTable: "Methods",
                        principalColumn: "MethodsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractParameters",
                columns: table => new
                {
                    ContractParametersID = table.Column<short>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContractParameter = table.Column<int>(maxLength: 150, nullable: false),
                    ContractsID = table.Column<string>(nullable: false),
                    Percentage = table.Column<byte>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    ExpectedDate = table.Column<DateTime>(nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractParameters", x => x.ContractParametersID);
                    table.ForeignKey(
                        name: "FK_ContractParameters_Contracts_ContractsID",
                        column: x => x.ContractsID,
                        principalTable: "Contracts",
                        principalColumn: "ContractsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Timelines",
                columns: table => new
                {
                    TimelinesID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContractParametersID = table.Column<short>(nullable: false),
                    DateDone = table.Column<DateTime>(nullable: false),
                    Comments = table.Column<string>(maxLength: 50, nullable: true),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timelines", x => x.TimelinesID);
                    table.ForeignKey(
                        name: "FK_Timelines_ContractParameters_ContractParametersID",
                        column: x => x.ContractParametersID,
                        principalTable: "ContractParameters",
                        principalColumn: "ContractParametersID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Methods",
                columns: new[] { "MethodsID", "Concurrency", "Method" },
                values: new object[] { (short)1, null, "National Competitive Tendering" });

            migrationBuilder.InsertData(
                table: "Methods",
                columns: new[] { "MethodsID", "Concurrency", "Method" },
                values: new object[] { (short)2, null, "Sole Sourcing" });

            migrationBuilder.InsertData(
                table: "Methods",
                columns: new[] { "MethodsID", "Concurrency", "Method" },
                values: new object[] { (short)3, null, "Request for quotation" });

            migrationBuilder.InsertData(
                table: "Methods",
                columns: new[] { "MethodsID", "Concurrency", "Method" },
                values: new object[] { (short)4, null, "Price quotation" });

            migrationBuilder.InsertData(
                table: "Methods",
                columns: new[] { "MethodsID", "Concurrency", "Method" },
                values: new object[] { (short)5, null, "Restrictive Tendering" });

            migrationBuilder.InsertData(
                table: "Methods",
                columns: new[] { "MethodsID", "Concurrency", "Method" },
                values: new object[] { (short)6, null, "International Competitive Tendering" });

            migrationBuilder.InsertData(
                table: "Methods",
                columns: new[] { "MethodsID", "Concurrency", "Method" },
                values: new object[] { (short)7, null, "Price quotation" });

            migrationBuilder.CreateIndex(
                name: "IX_ContractParameters_ContractsID",
                table: "ContractParameters",
                column: "ContractsID");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_MethodsID",
                table: "Contracts",
                column: "MethodsID");

            migrationBuilder.CreateIndex(
                name: "IX_Timelines_ContractParametersID",
                table: "Timelines",
                column: "ContractParametersID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Timelines");

            migrationBuilder.DropTable(
                name: "ContractParameters");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Methods");
        }
    }
}
