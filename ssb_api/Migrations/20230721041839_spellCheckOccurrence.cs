using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ssb_api.Migrations
{
    public partial class spellCheckOccurrence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OccurenceDay",
                table: "BudgetItems",
                newName: "OccurrenceDay");

            migrationBuilder.RenameColumn(
                name: "Occurence",
                table: "BudgetItems",
                newName: "Occurrence");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OccurrenceDay",
                table: "BudgetItems",
                newName: "OccurenceDay");

            migrationBuilder.RenameColumn(
                name: "Occurrence",
                table: "BudgetItems",
                newName: "Occurence");
        }
    }
}
