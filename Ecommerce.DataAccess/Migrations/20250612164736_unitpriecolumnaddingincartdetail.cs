using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class unitpriecolumnaddingincartdetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "UnitPrice",
                table: "CartDetails",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "ShoppingCartID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "ShoppingCartID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "ShoppingCartID",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShoppingCartID",
                table: "Products",
                column: "ShoppingCartID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShoppingCart_ShoppingCartID",
                table: "Products",
                column: "ShoppingCartID",
                principalTable: "ShoppingCart",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShoppingCart_ShoppingCartID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShoppingCartID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShoppingCartID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "CartDetails");
        }
    }
}
