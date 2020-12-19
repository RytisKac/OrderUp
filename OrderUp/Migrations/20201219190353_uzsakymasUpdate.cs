using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderUp.Migrations
{
    public partial class uzsakymasUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "adresas",
                table: "uzsakymas",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "telefonas",
                table: "uzsakymas",
                type: "int(9)",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "adresas",
                table: "uzsakymas");

            migrationBuilder.DropColumn(
                name: "telefonas",
                table: "uzsakymas");
        }
    }
}
