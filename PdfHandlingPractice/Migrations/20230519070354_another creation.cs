using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PdfHandlingPractice.Migrations
{
    /// <inheritdoc />
    public partial class anothercreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "PdfFiles",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "PdfFiles");
        }
    }
}
