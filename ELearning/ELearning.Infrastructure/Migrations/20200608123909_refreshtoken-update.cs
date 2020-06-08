using Microsoft.EntityFrameworkCore.Migrations;

namespace ELearning.Infrastructure.Migrations
{
    public partial class refreshtokenupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsValidated",
                table: "RefreshToken");

            migrationBuilder.AddColumn<bool>(
                name: "InValidated",
                table: "RefreshToken",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InValidated",
                table: "RefreshToken");

            migrationBuilder.AddColumn<bool>(
                name: "IsValidated",
                table: "RefreshToken",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
