using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PdfHandlingPractice.Migrations
{
    /// <inheritdoc />
    public partial class anothercreation1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PdfFiles",
                table: "PdfFiles");

            migrationBuilder.RenameColumn(
                name: "FileId",
                table: "PdfFiles",
                newName: "JobId");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "PdfFiles",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ResumeID",
                table: "PdfFiles",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "VenderName",
                table: "PdfFiles",
                type: "nvarchar(12)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "filePath",
                table: "PdfFiles",
                type: "nvarchar(12)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PdfFiles",
                table: "PdfFiles",
                column: "ResumeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PdfFiles",
                table: "PdfFiles");

            migrationBuilder.DropColumn(
                name: "ResumeID",
                table: "PdfFiles");

            migrationBuilder.DropColumn(
                name: "VenderName",
                table: "PdfFiles");

            migrationBuilder.DropColumn(
                name: "filePath",
                table: "PdfFiles");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "PdfFiles",
                newName: "FileId");

            migrationBuilder.AlterColumn<int>(
                name: "FileId",
                table: "PdfFiles",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PdfFiles",
                table: "PdfFiles",
                column: "FileId");
        }
    }
}
