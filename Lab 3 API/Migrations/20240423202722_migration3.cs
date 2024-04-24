using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab_3_API.Migrations
{
    /// <inheritdoc />
    public partial class migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HobbyID",
                table: "Peoples");

            migrationBuilder.DropColumn(
                name: "WebpageId",
                table: "Hobbys");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HobbyID",
                table: "Peoples",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WebpageId",
                table: "Hobbys",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
