using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class adjust8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "car_name",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "car",
                table: "People",
                maxLength: 128,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "car",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "car_name",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
