using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantMvcApp.Migrations
{
    /// <inheritdoc />
    public partial class ImagePathTypeChanget : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Restaurants");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImagePath",
                table: "Restaurants",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Restaurants");

            migrationBuilder.AddColumn<byte>(
                name: "PhotoPath",
                table: "Restaurants",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
