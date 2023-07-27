using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank_MVC_App.Migrations
{
    public partial class Creation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    AccountBalance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AllTransactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Benificiary = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllTransactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_AllTransactions_AllUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AllUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AllUsers",
                columns: new[] { "UserId", "AccountBalance", "AccountNumber", "Password", "UserName" },
                values: new object[] { 1, 20000, "000012345674", " ImthegreatAkbar", "Akbar" });

            migrationBuilder.InsertData(
                table: "AllTransactions",
                columns: new[] { "TransactionId", "Amount", "Benificiary", "Date", "UserId" },
                values: new object[] { 1340608262, 10000, "Birbal", new DateTime(2023, 4, 3, 14, 13, 0, 473, DateTimeKind.Local).AddTicks(5978), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AllTransactions_UserId",
                table: "AllTransactions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllTransactions");

            migrationBuilder.DropTable(
                name: "AllUsers");
        }
    }
}
