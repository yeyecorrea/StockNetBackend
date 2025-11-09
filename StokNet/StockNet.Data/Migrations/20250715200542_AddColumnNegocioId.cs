using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnNegocioId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NegocioId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NegocioId",
                table: "AspNetUsers");
        }
    }
}
