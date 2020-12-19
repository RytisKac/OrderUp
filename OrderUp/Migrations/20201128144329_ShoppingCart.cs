using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace OrderUp.Migrations
{
    public partial class ShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shopping_cart",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    kiekis = table.Column<int>(type: "int(11)", nullable: true),
                    fk_Picaid = table.Column<int>(type: "int(11)", nullable: false),
                    FkKlientasid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopping_cart", x => x.id);
                    table.ForeignKey(
                        name: "shopping_cart_ibfk_3",
                        column: x => x.FkKlientasid,
                        principalTable: "klientas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "shopping_cart_ibfk_1",
                        column: x => x.fk_Picaid,
                        principalTable: "pica",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_shopping_cart_FkKlientasid",
                table: "shopping_cart",
                column: "FkKlientasid");

            migrationBuilder.CreateIndex(
                name: "fk_Picaid",
                table: "shopping_cart",
                column: "fk_Picaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shopping_cart");
        }
    }
}
