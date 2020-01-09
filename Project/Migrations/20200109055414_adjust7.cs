using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class adjust7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "car",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "car_name",
                table: "People",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "car_name",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "car",
                table: "People",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);
        }
    }
}
