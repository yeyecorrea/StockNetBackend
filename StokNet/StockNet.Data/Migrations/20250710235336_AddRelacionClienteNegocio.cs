using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRelacionClienteNegocio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NegocioId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_NegocioId",
                table: "Clientes",
                column: "NegocioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Negocios_NegocioId",
                table: "Clientes",
                column: "NegocioId",
                principalTable: "Negocios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Negocios_NegocioId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_NegocioId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "NegocioId",
                table: "Clientes");
        }
    }
}
