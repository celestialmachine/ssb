using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ssb_api.Migrations
{
    public partial class Event : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BudgetEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    BudgetItemId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_BudgetEvents_BudgetItems_BudgetItemId",
                        column: x => x.BudgetItemId,
                        principalTable: "BudgetItems",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "BudgetEvents",
                columns: new[] { "Id", "Balance", "BudgetItemId", "Date", "DueDate", "IsPaid", "ItemId", "Note" },
                values: new object[] { 1, 100m, null, new DateTime(2023, 9, 16, 16, 34, 12, 568, DateTimeKind.Local).AddTicks(1308), new DateTime(2023, 9, 16, 16, 34, 12, 568, DateTimeKind.Local).AddTicks(1322), false, 1, "Cell phone event note" });

            migrationBuilder.InsertData(
                table: "BudgetEvents",
                columns: new[] { "Id", "Balance", "BudgetItemId", "Date", "DueDate", "IsPaid", "ItemId", "Note" },
                values: new object[] { 2, 200m, null, new DateTime(2023, 9, 18, 16, 34, 12, 568, DateTimeKind.Local).AddTicks(1323), new DateTime(2023, 9, 18, 16, 34, 12, 568, DateTimeKind.Local).AddTicks(1324), false, null, "This event has no item reference" });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetEvents_BudgetItemId",
                table: "BudgetEvents",
                column: "BudgetItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetEvents");
        }
    }
}
