using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzeriaImpulsMVC.Infrastructure.Migrations
{
    public partial class ManyToManyPizzaComponent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaComponent");

            migrationBuilder.DropTable(
                name: "PizzaSizePizza");

            migrationBuilder.DropTable(
                name: "PizzaSizes");

            migrationBuilder.CreateTable(
                name: "ComponentPizza",
                columns: table => new
                {
                    ComponentsId = table.Column<int>(type: "int", nullable: false),
                    PizzasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentPizza", x => new { x.ComponentsId, x.PizzasId });
                    table.ForeignKey(
                        name: "FK_ComponentPizza_Components_ComponentsId",
                        column: x => x.ComponentsId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComponentPizza_Pizzas_PizzasId",
                        column: x => x.PizzasId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComponentPizza_PizzasId",
                table: "ComponentPizza",
                column: "PizzasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponentPizza");

            migrationBuilder.CreateTable(
                name: "PizzaComponent",
                columns: table => new
                {
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    ComponentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaComponent", x => new { x.PizzaId, x.ComponentId });
                    table.ForeignKey(
                        name: "FK_PizzaComponent_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaComponent_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PizzaSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaSizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PizzaSizePizza",
                columns: table => new
                {
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    PizzaSizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaSizePizza", x => new { x.PizzaId, x.PizzaSizeId });
                    table.ForeignKey(
                        name: "FK_PizzaSizePizza_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaSizePizza_PizzaSizes_PizzaSizeId",
                        column: x => x.PizzaSizeId,
                        principalTable: "PizzaSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaComponent_ComponentId",
                table: "PizzaComponent",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaSizePizza_PizzaSizeId",
                table: "PizzaSizePizza",
                column: "PizzaSizeId");
        }
    }
}
