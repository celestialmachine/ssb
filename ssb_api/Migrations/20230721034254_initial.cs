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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occurence = table.Column<int>(type: "int", nullable: false),
                    OccurenceDay = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BudgetItems",
                columns: new[] { "Id", "Amount", "Description", "Name", "Occurence", "OccurenceDay" },
                values: new object[] { 1, 100m, "T-Mobile Family Plan", "Cell Phone", 1, 15 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetItems");
        }
    }
}
