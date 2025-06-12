using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateordertabledatiltable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_ProductId",
                table: "ProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_CartDetails_ProductId",
                table: "CartDetails");

            migrationBuilder.AlterColumn<bool>(
                name: "Archived",
                table: "ShoppingCart",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "ProductDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Name", "OrderID" },
                values: new object[] { "BAT", null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Name", "OrderID" },
                values: new object[] { "PAD", null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Name", "OrderID" },
                values: new object[] { "Glups", null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "OrderID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "OrderID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "OrderID",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderID",
                table: "Products",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_OrderID",
                table: "ProductDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductId",
                table: "ProductDetails",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_OrderID",
                table: "Categories",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_ProductId",
                table: "CartDetails",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Orders_OrderID",
                table: "Categories",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Orders_OrderID",
                table: "ProductDetails",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderID",
                table: "Products",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Orders_OrderID",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Orders_OrderID",
                table: "ProductDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_OrderID",
                table: "ProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_ProductId",
                table: "ProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_Categories_OrderID",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_CartDetails_ProductId",
                table: "CartDetails");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "Categories");

            migrationBuilder.AlterColumn<bool>(
                name: "Archived",
                table: "ShoppingCart",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "Name",
                value: "Sports");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "Name",
                value: "Fruits");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "Name",
                value: "Vehicle");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductId",
                table: "ProductDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_ProductId",
                table: "CartDetails",
                column: "ProductId");
        }
    }
}
