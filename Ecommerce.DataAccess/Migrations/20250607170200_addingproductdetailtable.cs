using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addingproductdetailtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Width1 = table.Column<double>(type: "float", nullable: true),
                    Width2 = table.Column<double>(type: "float", nullable: true),
                    Width3 = table.Column<double>(type: "float", nullable: true),
                    Height1 = table.Column<double>(type: "float", nullable: true),
                    Height2 = table.Column<double>(type: "float", nullable: true),
                    Height3 = table.Column<double>(type: "float", nullable: true),
                    GripColour1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GripColour2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GripColour3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatShape1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatShape2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatShape3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDetails");
        }
    }
}
