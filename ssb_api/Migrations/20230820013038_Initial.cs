using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ssb_api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BudgetItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occurrence = table.Column<int>(type: "int", nullable: false),
                    OccurrenceDay = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BudgetEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetEvents_BudgetItems_ItemId",
                        column: x => x.ItemId,
                        principalTable: "BudgetItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BudgetItems",
                columns: new[] { "Id", "Amount", "Description", "Name", "Occurrence", "OccurrenceDay" },
                values: new object[,]
                {
                    { 1, 0m, null, "Utility", 0, null },
                    { 2, 1500m, "Level 9000 Apartments", "Rent", 1, 1 },
                    { 3, 40m, "Chell or Chevron", "Gas", 2, 4 },
                    { 4, 100m, "T-Mobile Family Plan", "Cell Phone", 1, 15 }
                });

            migrationBuilder.InsertData(
                table: "BudgetEvents",
                columns: new[] { "Id", "Balance", "Date", "Description", "DueDate", "IsPaid", "ItemId", "Name", "Note" },
                values: new object[] { 1, 100m, new DateTime(2023, 9, 16, 18, 30, 38, 433, DateTimeKind.Local).AddTicks(1428), "T-Mobile Family Plan", new DateTime(2023, 9, 16, 18, 30, 38, 433, DateTimeKind.Local).AddTicks(1441), false, 4, "Cell Phone - September 2023", "Cell phone event note" });

            migrationBuilder.InsertData(
                table: "BudgetEvents",
                columns: new[] { "Id", "Balance", "Date", "Description", "DueDate", "IsPaid", "ItemId", "Name", "Note" },
                values: new object[] { 2, 200m, new DateTime(2023, 9, 18, 18, 30, 38, 433, DateTimeKind.Local).AddTicks(1443), null, new DateTime(2023, 9, 18, 18, 30, 38, 433, DateTimeKind.Local).AddTicks(1444), false, 1, "School books Fall 23", "This event has no item reference" });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetEvents_ItemId",
                table: "BudgetEvents",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetEvents");

            migrationBuilder.DropTable(
                name: "BudgetItems");
        }
    }
}
