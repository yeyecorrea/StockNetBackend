using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class addrelacionentrenegocioyusuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Negocios",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Negocios_ApplicationUserId",
                table: "Negocios",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Negocios_AspNetUsers_ApplicationUserId",
                table: "Negocios",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Negocios_AspNetUsers_ApplicationUserId",
                table: "Negocios");

            migrationBuilder.DropIndex(
                name: "IX_Negocios_ApplicationUserId",
                table: "Negocios");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Negocios");
        }
    }
}
