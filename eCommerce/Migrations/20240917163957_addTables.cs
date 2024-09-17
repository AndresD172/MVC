using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.Migrations
{
    /// <inheritdoc />
    public partial class addTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoAplicacion",
                table: "Product",
                newName: "TipoAplicacionKey");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Product",
                newName: "CategoryKey");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryKey",
                table: "Product",
                column: "CategoryKey");

            migrationBuilder.CreateIndex(
                name: "IX_Product_TipoAplicacionKey",
                table: "Product",
                column: "TipoAplicacionKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryKey",
                table: "Product",
                column: "CategoryKey",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_TipoAplicacion_TipoAplicacionKey",
                table: "Product",
                column: "TipoAplicacionKey",
                principalTable: "TipoAplicacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryKey",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_TipoAplicacion_TipoAplicacionKey",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryKey",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_TipoAplicacionKey",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "TipoAplicacionKey",
                table: "Product",
                newName: "TipoAplicacion");

            migrationBuilder.RenameColumn(
                name: "CategoryKey",
                table: "Product",
                newName: "CategoryId");
        }
    }
}
