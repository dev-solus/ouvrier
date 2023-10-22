using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations.project
{
    /// <inheritdoc />
    public partial class addroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Metiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metiers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Villes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quartiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: true),
                    IdVille = table.Column<int>(type: "INTEGER", nullable: false)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Adresse = table.Column<string>(type: "TEXT", nullable: true),
                    Lat = table.Column<double>(type: "REAL", nullable: false),
                    Lng = table.Column<double>(type: "REAL", nullable: false),
                    Draggble = table.Column<bool>(type: "INTEGER", nullable: false),
                    IdQuartier = table.Column<int>(type: "INTEGER", nullable: false)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Role = table.Column<int>(type: "INTEGER", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Civilite = table.Column<string>(type: "TEXT", nullable: true),
                    Tel = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    IdLocation = table.Column<int>(type: "INTEGER", nullable: false),
                    IdMetier = table.Column<int>(type: "INTEGER", nullable: true)
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
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Catalogues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: true),
                    IdUser = table.Column<int>(type: "INTEGER", nullable: false)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdOuvrier = table.Column<int>(type: "INTEGER", nullable: false),
                    IdUser = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
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
                    IdOuvrier = table.Column<int>(type: "INTEGER", nullable: false),
                    IdUser = table.Column<int>(type: "INTEGER", nullable: false)
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
                    IdOuvrier = table.Column<int>(type: "INTEGER", nullable: false),
                    IdUser = table.Column<int>(type: "INTEGER", nullable: false),
                    Note = table.Column<int>(type: "INTEGER", nullable: false)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    IdCatalogue = table.Column<int>(type: "INTEGER", nullable: false)
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
                    { 1, "Menuiserie Bois" },
                    { 2, "Peinture" },
                    { 3, "Menuiserie Aluminum" },
                    { 4, "Décorateur d'intérieur" },
                    { 5, "Piscine / Sauna / Hammam" },
                    { 6, "Plomberie / Sanitaire" },
                    { 7, "Zellige / Céramique" },
                    { 8, "Piscine / Sauna / Hammam" }
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
                    { 4, 4, "Marina" },
                    { 5, 1, "Al 3irfan" },
                    { 6, 2, "Massira 1" },
                    { 7, 3, "Tanger medina" },
                    { 8, 4, "Batoire" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Adresse", "Draggble", "IdQuartier", "Lat", "Lng" },
                values: new object[,]
                {
                    { 1, "av france", false, 1, 33.927250999999998, -6.8870979999999999 },
                    { 2, "hay maamoura", false, 2, 33.909999999999997, -6.9199999999999999 },
                    { 3, "av ibis", false, 3, 35.780000000000001, -5.8200000000000003 },
                    { 4, "av plage", false, 4, 30.420000000000002, -9.6099999999999994 },
                    { 5, "av ministre de communication", false, 5, 30.420000000000002, -9.6099999999999994 },
                    { 6, "av molay ali charif", false, 6, 33.93, -6.8899999999999997 },
                    { 7, "av casabarata", false, 7, 35.759999999999998, -5.8499999999999996 },
                    { 8, "rue essaouira", false, 8, 30.41, -9.5899999999999999 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Civilite", "DateNaissance", "Email", "IdLocation", "IdMetier", "ImageUrl", "LastName", "Password", "Role", "Tel", "Type", "Username" },
                values: new object[,]
                {
                    { 1, "m", new DateTime(1989, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "dj-m2x@hotmail.com", 1, 1, "", "mourabit", "12345678*", 2008, "0671265478", "ouvrier", "mohamed" },
                    { 2, "m", new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "salama@mail.com", 2, 2, "", "salama", "12345678*", 1, "06-00-00-00-00", "ouvrier", "anas" },
                    { 3, "f", new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "elhaddaoui@mail.com", 3, 2, "", "elhaddaoui", "12345678*", 2008, "06-00-00-00-00", "ouvrier", "khadija" },
                    { 4, "m", new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "benhamida@mail.com", 4, 2, "", "benhamida", "12345678*", 2, "06-00-00-00-00", "ouvrier", "omar" },
                    { 5, "m", new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ati@mail.com", 5, 2, "", "ati", "12345678*", 2, "06-00-00-00-00", "ouvrier", "issam" },
                    { 6, "m", new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "fikri@mail.com", 6, 2, "", "fikri", "12345678*", 2, "06-00-00-00-00", "ouvrier", "ayoub" },
                    { 7, "m", new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "mourabit@mail.com", 7, 2, "", "mourabit", "12345678*", 2, "06-00-00-00-00", "ouvrier", "yassin" },
                    { 8, "f", new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "biza@mail.com", 8, 2, "", "biza", "12345678*", 2, "06-00-00-00-00", "ouvrier", "soukaina" }
                });

            migrationBuilder.InsertData(
                table: "Catalogues",
                columns: new[] { "Id", "IdUser", "Nom" },
                values: new object[,]
                {
                    { 1, 1, "Jardinage" },
                    { 2, 2, "Premiere atelier : Peinture" },
                    { 3, 3, "Premiere atelier : Menuiserie Aluminum" },
                    { 4, 4, "Premiere atelier : Décorateur d'intérieur" },
                    { 5, 5, "Premiere atelier : Piscine / Sauna / Hammam" },
                    { 6, 6, "Premiere atelier : Plomberie / Sanitaire" },
                    { 7, 7, "Premiere atelier : Zellige / Céramique" },
                    { 8, 8, "Premiere atelier : Piscine / Sauna / Hammam" },
                    { 9, 1, "Deuxieme atelier : blacar" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Description", "IdCatalogue", "ImageUrl" },
                values: new object[,]
                {
                    { 1, "rasoire", 1, "Catalogues/FB_IMG_1515691188716.jpg" },
                    { 2, "Exemeple de description", 2, "" },
                    { 3, "Exemeple de description", 3, "" },
                    { 4, "Exemeple de description", 4, "" },
                    { 5, "Exemeple de description", 7, "Catalogues/zellige-carreaux.jpg" },
                    { 6, "Exemeple de description", 7, "Catalogues/1000_large.jpg" },
                    { 7, "Exemeple de description", 7, "Catalogues/zellige.jpg" },
                    { 8, "hammam", 8, "Catalogues/spa-sauna-hammam-douche.jpg" },
                    { 9, "placar 1", 9, "Catalogues/placar.jpg" },
                    { 10, "placar 2", 9, "Catalogues/placar2.jpg" },
                    { 11, "placar 3", 9, "Catalogues/placa3.png" },
                    { 13, "hammam", 8, "Catalogues/auberge-de-l-orangerie.jpg" },
                    { 14, "hammam", 8, "Catalogues/spa-sauna-hammam-douche1.jpg" }
                });

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

        /// <inheritdoc />
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
