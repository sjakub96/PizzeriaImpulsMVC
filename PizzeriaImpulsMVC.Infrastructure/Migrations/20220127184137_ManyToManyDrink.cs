using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzeriaImpulsMVC.Infrastructure.Migrations
{
    public partial class ManyToManyDrink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrinkSizeDrink");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrinkDrinkSize");

            migrationBuilder.CreateTable(
                name: "DrinkSizeDrink",
                columns: table => new
                {
                    DrinkId = table.Column<int>(type: "int", nullable: false),
                    DrinkSizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkSizeDrink", x => new { x.DrinkId, x.DrinkSizeId });
                    table.ForeignKey(
                        name: "FK_DrinkSizeDrink_Drinks_DrinkId",
                        column: x => x.DrinkId,
                        principalTable: "Drinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrinkSizeDrink_DrinkSizes_DrinkSizeId",
                        column: x => x.DrinkSizeId,
                        principalTable: "DrinkSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrinkSizeDrink_DrinkSizeId",
                table: "DrinkSizeDrink",
                column: "DrinkSizeId");
        }
    }
}
