using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab_3_API.Migrations
{
    /// <inheritdoc />
    public partial class migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hobbys_Peoples_PeoplesPeopleId",
                table: "Hobbys");

            migrationBuilder.AddColumn<int>(
                name: "PeoplesPeopleId",
                table: "Webpages",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PeoplesPeopleId",
                table: "Hobbys",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Webpages_PeoplesPeopleId",
                table: "Webpages",
                column: "PeoplesPeopleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hobbys_Peoples_PeoplesPeopleId",
                table: "Hobbys",
                column: "PeoplesPeopleId",
                principalTable: "Peoples",
                principalColumn: "PeopleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Webpages_Peoples_PeoplesPeopleId",
                table: "Webpages",
                column: "PeoplesPeopleId",
                principalTable: "Peoples",
                principalColumn: "PeopleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hobbys_Peoples_PeoplesPeopleId",
                table: "Hobbys");

            migrationBuilder.DropForeignKey(
                name: "FK_Webpages_Peoples_PeoplesPeopleId",
                table: "Webpages");

            migrationBuilder.DropIndex(
                name: "IX_Webpages_PeoplesPeopleId",
                table: "Webpages");

            migrationBuilder.DropColumn(
                name: "PeoplesPeopleId",
                table: "Webpages");

            migrationBuilder.AlterColumn<int>(
                name: "PeoplesPeopleId",
                table: "Hobbys",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Hobbys_Peoples_PeoplesPeopleId",
                table: "Hobbys",
                column: "PeoplesPeopleId",
                principalTable: "Peoples",
                principalColumn: "PeopleId");
        }
    }
}
