using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ssb_api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BudgetItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occurrence = table.Column<int>(type: "int", nullable: false),
                    OccurrenceDay = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetItems", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "BudgetEvents",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    BudgetItemItemId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_BudgetEvents", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_BudgetEvents_BudgetItems_BudgetItemItemId",
                        column: x => x.BudgetItemItemId,
                        principalTable: "BudgetItems",
                        principalColumn: "ItemId");
                });

            migrationBuilder.InsertData(
                table: "BudgetEvents",
                columns: new[] { "EventId", "Balance", "BudgetItemItemId", "Date", "Description", "DueDate", "IsPaid", "ItemId", "Name", "Note" },
                values: new object[] { 2, 200m, null, new DateTime(2023, 9, 21, 20, 54, 4, 83, DateTimeKind.Local).AddTicks(466), null, new DateTime(2023, 9, 21, 20, 54, 4, 83, DateTimeKind.Local).AddTicks(481), false, 1, "School books Fall 23", "This event has no item reference" });

            migrationBuilder.InsertData(
                table: "BudgetItems",
                columns: new[] { "ItemId", "Amount", "Description", "Name", "Occurrence", "OccurrenceDay" },
                values: new object[] { 1, 0m, null, "Utility", 0, null });

            migrationBuilder.InsertData(
                table: "BudgetItems",
                columns: new[] { "ItemId", "Amount", "Description", "Name", "Occurrence", "OccurrenceDay" },
                values: new object[] { 2, 1500m, "Level 9000 Apartments", "Rent", 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetEvents_BudgetItemItemId",
                table: "BudgetEvents",
                column: "BudgetItemItemId");
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
