using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateproductdetailtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height1",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "Height2",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "Height3",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "Width1",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "Width2",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "Width3",
                table: "ProductDetails");

            migrationBuilder.RenameColumn(
                name: "GripColour3",
                table: "ProductDetails",
                newName: "Width");

            migrationBuilder.RenameColumn(
                name: "GripColour2",
                table: "ProductDetails",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "GripColour1",
                table: "ProductDetails",
                newName: "Height");

            migrationBuilder.RenameColumn(
                name: "BatShape3",
                table: "ProductDetails",
                newName: "HandleType");

            migrationBuilder.RenameColumn(
                name: "BatShape2",
                table: "ProductDetails",
                newName: "HandleThickNess");

            migrationBuilder.RenameColumn(
                name: "BatShape1",
                table: "ProductDetails",
                newName: "HandleShape");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "ProductDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "ProductDetails");

            migrationBuilder.RenameColumn(
                name: "Width",
                table: "ProductDetails",
                newName: "GripColour3");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "ProductDetails",
                newName: "GripColour2");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "ProductDetails",
                newName: "GripColour1");

            migrationBuilder.RenameColumn(
                name: "HandleType",
                table: "ProductDetails",
                newName: "BatShape3");

            migrationBuilder.RenameColumn(
                name: "HandleThickNess",
                table: "ProductDetails",
                newName: "BatShape2");

            migrationBuilder.RenameColumn(
                name: "HandleShape",
                table: "ProductDetails",
                newName: "BatShape1");

            migrationBuilder.AddColumn<double>(
                name: "Height1",
                table: "ProductDetails",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Height2",
                table: "ProductDetails",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Height3",
                table: "ProductDetails",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Width1",
                table: "ProductDetails",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Width2",
                table: "ProductDetails",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Width3",
                table: "ProductDetails",
                type: "float",
                nullable: true);
        }
    }
}
