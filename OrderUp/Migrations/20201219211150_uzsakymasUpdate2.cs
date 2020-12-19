using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderUp.Migrations
{
    public partial class uzsakymasUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<string>(
                name: "vardas_pavarde",
                table: "uzsakymas",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "uzsakymas_ibfk_1",
                table: "uzsakymas");

            migrationBuilder.DropColumn(
                name: "vardas_pavarde",
                table: "uzsakymas");

            migrationBuilder.AlterColumn<int>(
                name: "pristatymo_budas",
                table: "uzsakymas",
                type: "int(11)",
                nullable: true,
                defaultValueSql: "'NULL'",
                oldClrType: typeof(int),
                oldType: "int(11)",
                oldDefaultValueSql: "'NULL'");

            migrationBuilder.AlterColumn<string>(
                name: "adresas",
                table: "uzsakymas",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AddForeignKey(
                name: "uzsakymas_ibfk_1",
                table: "uzsakymas",
                column: "pristatymo_budas",
                principalTable: "pristatymo_budas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
