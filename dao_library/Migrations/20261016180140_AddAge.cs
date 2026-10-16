using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dao_library.Migrations
{
    /// <inheritdoc />
    public partial class AddAge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Trainers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Players");
        }
    }
}
