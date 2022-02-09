using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzeriaImpulsMVC.Infrastructure.Migrations
{
    public partial class DeleteDrinkSizes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrinkDrinkSize");

            migrationBuilder.DropTable(
                name: "DrinkSizes");

            migrationBuilder.AddColumn<decimal>(
                name: "Size",
                table: "Drinks",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Drinks");

            migrationBuilder.CreateTable(
                name: "DrinkSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkSizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrinkDrinkSize",
                columns: table => new
                {
                    DrinkSizesId = table.Column<int>(type: "int", nullable: false),
                    DrinksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkDrinkSize", x => new { x.DrinkSizesId, x.DrinksId });
                    table.ForeignKey(
                        name: "FK_DrinkDrinkSize_Drinks_DrinksId",
                        column: x => x.DrinksId,
                        principalTable: "Drinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrinkDrinkSize_DrinkSizes_DrinkSizesId",
                        column: x => x.DrinkSizesId,
                        principalTable: "DrinkSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrinkDrinkSize_DrinksId",
                table: "DrinkDrinkSize",
                column: "DrinksId");
        }
    }
}
