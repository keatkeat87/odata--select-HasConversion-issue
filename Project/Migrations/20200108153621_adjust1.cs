using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class adjust1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "car",
                table: "People",
                maxLength: 128,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "car",
                table: "People");
        }
    }
}
