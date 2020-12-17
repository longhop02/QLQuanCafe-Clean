using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddCustomerAndIngredient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerName = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    CustomerPhoneNumber = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    CustomerAddress = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    CustomerEmail = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IngredientName = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    IngredientSupplier = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    IngredientPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    IngredientQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    IngredientUnit = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    IngredientType = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Ingredients");
        }
    }
}
