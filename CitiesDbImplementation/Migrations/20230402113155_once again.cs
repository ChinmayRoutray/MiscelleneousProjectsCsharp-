using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitiesDbImplementation.Migrations
{
    public partial class onceagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllCities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CityCapital = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllCities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "AllInterests",
                columns: table => new
                {
                    InterestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllInterests", x => x.InterestId);
                    table.ForeignKey(
                        name: "FK_AllInterests_AllCities_CityId",
                        column: x => x.CityId,
                        principalTable: "AllCities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AllCities",
                columns: new[] { "CityId", "CityCapital", "CityName" },
                values: new object[] { 1, "Delhi", "Delhi" });

            migrationBuilder.InsertData(
                table: "AllCities",
                columns: new[] { "CityId", "CityCapital", "CityName" },
                values: new object[] { 2, "Goregaon", "Mumbai" });

            migrationBuilder.InsertData(
                table: "AllCities",
                columns: new[] { "CityId", "CityCapital", "CityName" },
                values: new object[] { 4, "Rasulgarh", "Bhubaneswar" });

            migrationBuilder.InsertData(
                table: "AllInterests",
                columns: new[] { "InterestId", "CityId", "Description" },
                values: new object[,]
                {
                    { 1, 1, "Red Fort" },
                    { 2, 1, "India Gate" },
                    { 3, 1, "Qutub Minar" },
                    { 4, 2, "Aksa Beach" },
                    { 5, 2, "Dana Pani Beach" },
                    { 6, 2, "CSMT" },
                    { 7, 4, "Planetorium" },
                    { 8, 4, "Science Park" },
                    { 9, 4, "Dhauli Giri" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllInterests_CityId",
                table: "AllInterests",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllInterests");

            migrationBuilder.DropTable(
                name: "AllCities");
        }
    }
}
