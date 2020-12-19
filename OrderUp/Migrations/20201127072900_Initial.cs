using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace OrderUp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ingrediento_tipas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(fixedLength: true, maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingrediento_tipas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "klientas",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    adresas = table.Column<string>(maxLength: 255, nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_klientas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "padas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_padas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "picos_tipas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(fixedLength: true, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_picos_tipas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pristatymo_budas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(fixedLength: true, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pristatymo_budas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ingredientai",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    pavadinimas = table.Column<string>(maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    kaina = table.Column<double>(nullable: true, defaultValueSql: null),
                    matas = table.Column<double>(nullable: true, defaultValueSql: null),
                    tipas = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: null),
                    Nuotrauka = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredientai", x => x.id);
                    table.ForeignKey(
                        name: "ingredientai_ibfk_1",
                        column: x => x.tipas,
                        principalTable: "ingrediento_tipas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_klientas_UserId",
                        column: x => x.UserId,
                        principalTable: "klientas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_klientas_UserId",
                        column: x => x.UserId,
                        principalTable: "klientas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_klientas_UserId",
                        column: x => x.UserId,
                        principalTable: "klientas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_klientas_UserId",
                        column: x => x.UserId,
                        principalTable: "klientas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pica",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    pavadinimas = table.Column<string>(maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    kaina = table.Column<double>(nullable: true, defaultValueSql: null),
                    aprasymas = table.Column<string>(maxLength: 255, nullable: true, defaultValueSql: "'NULL'"),
                    padas = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: null),
                    tipas = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: null),
                    Nuotrauka = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pica", x => x.id);
                    table.ForeignKey(
                        name: "pica_ibfk_1",
                        column: x => x.padas,
                        principalTable: "padas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "pica_ibfk_2",
                        column: x => x.tipas,
                        principalTable: "picos_tipas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "uzsakymas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    uzsakymo_data = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: null),
                    kaina = table.Column<double>(nullable: true, defaultValueSql: null),
                    prekiu_kiekis = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: null),
                    pristatymo_budas = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: null),
                    fk_Klientasid = table.Column<string>(type: "varchar(767)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uzsakymas", x => x.id);
                    table.ForeignKey(
                        name: "uzsakymas_ibfk_2",
                        column: x => x.fk_Klientasid,
                        principalTable: "klientas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "uzsakymas_ibfk_1",
                        column: x => x.pristatymo_budas,
                        principalTable: "pristatymo_budas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "picos_ingredientai",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    kiekis = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: null),
                    fk_Ingredientaiid = table.Column<int>(type: "int(11)", nullable: false),
                    FkPicaid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_picos_ingredientai", x => x.id);
                    table.ForeignKey(
                        name: "picos_ingredientai_ibfk_1",
                        column: x => x.fk_Ingredientaiid,
                        principalTable: "ingredientai",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_picos_ingredientai_pica_FkPicaid",
                        column: x => x.FkPicaid,
                        principalTable: "pica",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "uzsakymo_preke",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    kiekis = table.Column<int>(type: "int(11)", nullable: true, defaultValueSql: null),
                    fk_Picaid = table.Column<int>(type: "int(11)", nullable: false),
                    fk_Uzsakymasid = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uzsakymo_preke", x => x.id);
                    table.ForeignKey(
                        name: "uzsakymo_preke_ibfk_1",
                        column: x => x.fk_Picaid,
                        principalTable: "pica",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "uzsakymo_preke_ibfk_3",
                        column: x => x.fk_Uzsakymasid,
                        principalTable: "uzsakymas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "tipas",
                table: "ingredientai",
                column: "tipas");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "klientas",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "klientas",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "padas",
                table: "pica",
                column: "padas");

            migrationBuilder.CreateIndex(
                name: "tipas",
                table: "pica",
                column: "tipas");

            migrationBuilder.CreateIndex(
                name: "fk_Ingredientaiid",
                table: "picos_ingredientai",
                column: "fk_Ingredientaiid");

            migrationBuilder.CreateIndex(
                name: "IX_picos_ingredientai_FkPicaid",
                table: "picos_ingredientai",
                column: "FkPicaid");

            migrationBuilder.CreateIndex(
                name: "fk_Klientasid",
                table: "uzsakymas",
                column: "fk_Klientasid");

            migrationBuilder.CreateIndex(
                name: "pristatymo_budas",
                table: "uzsakymas",
                column: "pristatymo_budas");

            migrationBuilder.CreateIndex(
                name: "fk_Picaid",
                table: "uzsakymo_preke",
                column: "fk_Picaid");

            migrationBuilder.CreateIndex(
                name: "fk_Uzsakymasid",
                table: "uzsakymo_preke",
                column: "fk_Uzsakymasid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "picos_ingredientai");

            migrationBuilder.DropTable(
                name: "uzsakymo_preke");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ingredientai");

            migrationBuilder.DropTable(
                name: "pica");

            migrationBuilder.DropTable(
                name: "uzsakymas");

            migrationBuilder.DropTable(
                name: "ingrediento_tipas");

            migrationBuilder.DropTable(
                name: "padas");

            migrationBuilder.DropTable(
                name: "picos_tipas");

            migrationBuilder.DropTable(
                name: "klientas");

            migrationBuilder.DropTable(
                name: "pristatymo_budas");
        }
    }
}
