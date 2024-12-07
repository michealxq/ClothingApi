using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P1API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductImageModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "ProductImages",
                newName: "FilePath");

            migrationBuilder.AddColumn<string>(
                name: "FileDescription",
                table: "ProductImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileExtension",
                table: "ProductImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "ProductImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "FileSizeInBytes",
                table: "ProductImages",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileDescription",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "FileExtension",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "FileSizeInBytes",
                table: "ProductImages");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "ProductImages",
                newName: "ImagePath");
        }
    }
}
