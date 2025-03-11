using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantMvcApp.Migrations
{
    /// <inheritdoc />
    public partial class PhotoAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Restaurants");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
