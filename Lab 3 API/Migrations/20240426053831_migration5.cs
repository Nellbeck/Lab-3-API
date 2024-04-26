using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab_3_API.Migrations
{
    /// <inheritdoc />
    public partial class migration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Webpages_Hobbys_HobbysHobbyId",
                table: "Webpages");

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
                name: "HobbysHobbyId",
                table: "Webpages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Webpages_Hobbys_HobbysHobbyId",
                table: "Webpages",
                column: "HobbysHobbyId",
                principalTable: "Hobbys",
                principalColumn: "HobbyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Webpages_Hobbys_HobbysHobbyId",
                table: "Webpages");

            migrationBuilder.AlterColumn<int>(
                name: "HobbysHobbyId",
                table: "Webpages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PeoplesPeopleId",
                table: "Webpages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Webpages_PeoplesPeopleId",
                table: "Webpages",
                column: "PeoplesPeopleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Webpages_Hobbys_HobbysHobbyId",
                table: "Webpages",
                column: "HobbysHobbyId",
                principalTable: "Hobbys",
                principalColumn: "HobbyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Webpages_Peoples_PeoplesPeopleId",
                table: "Webpages",
                column: "PeoplesPeopleId",
                principalTable: "Peoples",
                principalColumn: "PeopleId");
        }
    }
}
