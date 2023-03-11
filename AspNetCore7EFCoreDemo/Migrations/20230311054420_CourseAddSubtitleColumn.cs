using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCore7EFCoreDemo.Migrations
{
    /// <inheritdoc />
    public partial class CourseAddSubtitleColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subtitle",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subtitle",
                table: "Course");
        }
    }
}
