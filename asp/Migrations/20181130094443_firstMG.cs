using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace asp3.Migrations
{
    public partial class firstMG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Metiers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metiers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Villes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quartiers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(nullable: true),
                    IdVille = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quartiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quartiers_Villes_IdVille",
                        column: x => x.IdVille,
                        principalTable: "Villes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Adresse = table.Column<string>(nullable: true),
                    Lat = table.Column<double>(nullable: false),
                    Lng = table.Column<double>(nullable: false),
                    Draggble = table.Column<bool>(nullable: false),
                    IdQuartier = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Quartiers_IdQuartier",
                        column: x => x.IdQuartier,
                        principalTable: "Quartiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DateNaissance = table.Column<DateTime>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Civilite = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    IdLocation = table.Column<int>(nullable: false),
                    IdMetier = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Locations_IdLocation",
                        column: x => x.IdLocation,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Metiers_IdMetier",
                        column: x => x.IdMetier,
                        principalTable: "Metiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Catalogues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(nullable: true),
                    IdUser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalogues_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commentaires",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdOuvrier = table.Column<int>(nullable: false),
                    IdUser = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commentaires_Users_IdOuvrier",
                        column: x => x.IdOuvrier,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commentaires_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favories",
                columns: table => new
                {
                    IdOuvrier = table.Column<int>(nullable: false),
                    IdUser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favories", x => new { x.IdOuvrier, x.IdUser });
                    table.ForeignKey(
                        name: "FK_Favories_Users_IdOuvrier",
                        column: x => x.IdOuvrier,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favories_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likeusers",
                columns: table => new
                {
                    IdOuvrier = table.Column<int>(nullable: false),
                    IdUser = table.Column<int>(nullable: false),
                    Note = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likeusers", x => new { x.IdOuvrier, x.IdUser });
                    table.ForeignKey(
                        name: "FK_Likeusers_Users_IdOuvrier",
                        column: x => x.IdOuvrier,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likeusers_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    IdCatalogue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Catalogues_IdCatalogue",
                        column: x => x.IdCatalogue,
                        principalTable: "Catalogues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Metiers",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "Developpeur" },
                    { 2, "Reseaux" }
                });

            migrationBuilder.InsertData(
                table: "Villes",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "Rabat" },
                    { 2, "Temara" },
                    { 3, "Tanger" },
                    { 4, "Agadir" }
                });

            migrationBuilder.InsertData(
                table: "Quartiers",
                columns: new[] { "Id", "IdVille", "Nom" },
                values: new object[,]
                {
                    { 1, 1, "Agdal" },
                    { 2, 2, "Massira 2" },
                    { 3, 3, "New port" },
                    { 4, 4, "Marina" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Adresse", "Draggble", "IdQuartier", "Lat", "Lng" },
                values: new object[] { 1, "hay maamoura", false, 1, 33.927251, -6.887098 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Civilite", "DateNaissance", "Email", "IdLocation", "IdMetier", "ImageUrl", "LastName", "Password", "Role", "Tel", "Type", "Username" },
                values: new object[] { 1, "m", new DateTime(1989, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "dj-m2x@hotmail.com", 1, 1, "", "mourabit", "12345678*", 2008, "0671265478", "ouvrier", "mohamed" });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_IdCatalogue",
                table: "Articles",
                column: "IdCatalogue");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogues_IdUser",
                table: "Catalogues",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_IdOuvrier",
                table: "Commentaires",
                column: "IdOuvrier");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_IdUser",
                table: "Commentaires",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Favories_IdUser",
                table: "Favories",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Likeusers_IdUser",
                table: "Likeusers",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_IdQuartier",
                table: "Locations",
                column: "IdQuartier");

            migrationBuilder.CreateIndex(
                name: "IX_Quartiers_IdVille",
                table: "Quartiers",
                column: "IdVille");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdLocation",
                table: "Users",
                column: "IdLocation");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdMetier",
                table: "Users",
                column: "IdMetier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Commentaires");

            migrationBuilder.DropTable(
                name: "Favories");

            migrationBuilder.DropTable(
                name: "Likeusers");

            migrationBuilder.DropTable(
                name: "Catalogues");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Metiers");

            migrationBuilder.DropTable(
                name: "Quartiers");

            migrationBuilder.DropTable(
                name: "Villes");
        }
    }
}
