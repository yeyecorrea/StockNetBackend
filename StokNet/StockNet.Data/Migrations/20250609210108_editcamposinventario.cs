using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class editcamposinventario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CostoTotal",
                table: "Inventarios",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "InventarioFinal",
                table: "Inventarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostoTotal",
                table: "Inventarios");

            migrationBuilder.DropColumn(
                name: "InventarioFinal",
                table: "Inventarios");
        }
    }
}
