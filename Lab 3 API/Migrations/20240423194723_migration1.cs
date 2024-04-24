using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab_3_API.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peoples",
                columns: table => new
                {
                    PeopleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HobbyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peoples", x => x.PeopleId);
                });

            migrationBuilder.CreateTable(
                name: "Hobbys",
                columns: table => new
                {
                    HobbyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebpageId = table.Column<int>(type: "int", nullable: false),
                    PeoplesPeopleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbys", x => x.HobbyId);
                    table.ForeignKey(
                        name: "FK_Hobbys_Peoples_PeoplesPeopleId",
                        column: x => x.PeoplesPeopleId,
                        principalTable: "Peoples",
                        principalColumn: "PeopleId");
                });

            migrationBuilder.CreateTable(
                name: "Webpages",
                columns: table => new
                {
                    WebpageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Webpage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HobbysHobbyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Webpages", x => x.WebpageId);
                    table.ForeignKey(
                        name: "FK_Webpages_Hobbys_HobbysHobbyId",
                        column: x => x.HobbysHobbyId,
                        principalTable: "Hobbys",
                        principalColumn: "HobbyId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hobbys_PeoplesPeopleId",
                table: "Hobbys",
                column: "PeoplesPeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_Webpages_HobbysHobbyId",
                table: "Webpages",
                column: "HobbysHobbyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Webpages");

            migrationBuilder.DropTable(
                name: "Hobbys");

            migrationBuilder.DropTable(
                name: "Peoples");
        }
    }
}
