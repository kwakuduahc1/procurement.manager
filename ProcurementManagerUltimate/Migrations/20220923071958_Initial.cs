using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcurementManagerUltimate.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemsID = table.Column<short>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Item = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Unit = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Concurrency = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemsID);
                });

            migrationBuilder.CreateTable(
                name: "Methods",
                columns: table => new
                {
                    MethodsID = table.Column<short>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Method = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Concurrency = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Methods", x => x.MethodsID);
                });

            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    SourcesID = table.Column<short>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Source = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Concurrency = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.SourcesID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierID = table.Column<short>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Supplier = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    TIN = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    ContractsID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Reference = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    ItemsID = table.Column<short>(type: "INTEGER", nullable: false),
                    SourcesID = table.Column<short>(type: "INTEGER", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    MethodsID = table.Column<short>(type: "INTEGER", nullable: false),
                    SuppliersID = table.Column<short>(type: "INTEGER", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    Quantity = table.Column<double>(type: "REAL", nullable: false),
                    IsFlexible = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateSigned = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsMinor = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExpectedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Concurrency = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.ContractsID);
                    table.ForeignKey(
                        name: "FK_Contracts_Items_ItemsID",
                        column: x => x.ItemsID,
                        principalTable: "Items",
                        principalColumn: "ItemsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Methods_MethodsID",
                        column: x => x.MethodsID,
                        principalTable: "Methods",
                        principalColumn: "MethodsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Sources_SourcesID",
                        column: x => x.SourcesID,
                        principalTable: "Sources",
                        principalColumn: "SourcesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Suppliers_SuppliersID",
                        column: x => x.SuppliersID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractParameters",
                columns: table => new
                {
                    ContractParametersID = table.Column<short>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Parameter = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Reference = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Percentage = table.Column<byte>(type: "INTEGER", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    IsCompleted = table.Column<byte>(type: "INTEGER", nullable: false),
                    ExpectedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Concurrency = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true),
                    ContractsID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractParameters", x => x.ContractParametersID);
                    table.ForeignKey(
                        name: "FK_ContractParameters_Contracts_ContractsID",
                        column: x => x.ContractsID,
                        principalTable: "Contracts",
                        principalColumn: "ContractsID");
                });

            migrationBuilder.CreateTable(
                name: "Timelines",
                columns: table => new
                {
                    TimelinesID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContractParametersID = table.Column<short>(type: "INTEGER", nullable: false),
                    DateDone = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Comments = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Concurrency = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
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
                table: "Items",
                columns: new[] { "ItemsID", "Item", "Unit" },
                values: new object[] { (short)1, "Maize", "Bag" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemsID", "Item", "Unit" },
                values: new object[] { (short)2, "Rice", "Bag" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemsID", "Item", "Unit" },
                values: new object[] { (short)3, "Millet", "Bag" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemsID", "Item", "Unit" },
                values: new object[] { (short)4, "Desktop Computer (Set)", "pcs" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemsID", "Item", "Unit" },
                values: new object[] { (short)5, "Laptop Computer", "pcs" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemsID", "Item", "Unit" },
                values: new object[] { (short)6, "Office furniture", "pcs" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemsID", "Item", "Unit" },
                values: new object[] { (short)7, "Printer", "pcs" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemsID", "Item", "Unit" },
                values: new object[] { (short)8, "Vehicle", "unit" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemsID", "Item", "Unit" },
                values: new object[] { (short)9, "Software", "n/a" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemsID", "Item", "Unit" },
                values: new object[] { (short)10, "Service", "n/a" });

            migrationBuilder.InsertData(
                table: "Methods",
                columns: new[] { "MethodsID", "Method" },
                values: new object[] { (short)1, "National Competitive Tendering" });

            migrationBuilder.InsertData(
                table: "Methods",
                columns: new[] { "MethodsID", "Method" },
                values: new object[] { (short)2, "Sole Sourcing" });

            migrationBuilder.InsertData(
                table: "Methods",
                columns: new[] { "MethodsID", "Method" },
                values: new object[] { (short)3, "Single sourcing" });

            migrationBuilder.InsertData(
                table: "Methods",
                columns: new[] { "MethodsID", "Method" },
                values: new object[] { (short)4, "Restrictive Tendering" });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "SourcesID", "Source" },
                values: new object[] { (short)1, "IGF" });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "SourcesID", "Source" },
                values: new object[] { (short)2, "District Assembly" });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "SourcesID", "Source" },
                values: new object[] { (short)3, "Grants and Loans" });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "SourcesID", "Source" },
                values: new object[] { (short)4, "GOG Funding" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContractParameters_ContractsID",
                table: "ContractParameters",
                column: "ContractsID");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ItemsID",
                table: "Contracts",
                column: "ItemsID");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_MethodsID",
                table: "Contracts",
                column: "MethodsID");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_SourcesID",
                table: "Contracts",
                column: "SourcesID");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_SuppliersID",
                table: "Contracts",
                column: "SuppliersID");

            migrationBuilder.CreateIndex(
                name: "IX_Timelines_ContractParametersID",
                table: "Timelines",
                column: "ContractParametersID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Timelines");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ContractParameters");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Methods");

            migrationBuilder.DropTable(
                name: "Sources");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
