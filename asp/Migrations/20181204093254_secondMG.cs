using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace asp3.Migrations
{
    public partial class secondMG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Catalogues",
                columns: new[] { "Id", "IdUser", "Nom" },
                values: new object[,]
                {
                    { 1, 1, "Premiere atelier : Menuiserie Bois" },
                    { 9, 1, "Deuxieme atelier : blacar" }
                });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Adresse",
                value: "av france");

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Adresse", "Draggble", "IdQuartier", "Lat", "Lng" },
                values: new object[,]
                {
                    { 2, "hay maamoura", false, 2, 33.91, -6.92 },
                    { 3, "av ibis", false, 3, 35.78, -5.82 },
                    { 4, "av plage", false, 4, 30.42, -9.61 }
                });

            migrationBuilder.UpdateData(
                table: "Metiers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nom",
                value: "Menuiserie Bois");

            migrationBuilder.UpdateData(
                table: "Metiers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nom",
                value: "Peinture");

            migrationBuilder.InsertData(
                table: "Metiers",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 8, "Piscine / Sauna / Hammam" },
                    { 7, "Zellige / Céramique" },
                    { 6, "Plomberie / Sanitaire" },
                    { 3, "Menuiserie Aluminum" },
                    { 4, "Décorateur d'intérieur" },
                    { 5, "Piscine / Sauna / Hammam" }
                });

            migrationBuilder.InsertData(
                table: "Quartiers",
                columns: new[] { "Id", "IdVille", "Nom" },
                values: new object[,]
                {
                    { 7, 3, "Tanger medina" },
                    { 5, 1, "Al 3irfan" },
                    { 6, 2, "Massira 1" },
                    { 8, 4, "Batoire" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Description", "IdCatalogue", "ImageUrl" },
                values: new object[,]
                {
                    { 1, "Exemeple de description", 1, "" },
                    { 9, "Exemeple de description", 9, "" },
                    { 10, "Exemeple de description", 9, "" },
                    { 11, "Exemeple de description", 9, "" },
                    { 12, "Exemeple de description", 9, "" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Adresse", "Draggble", "IdQuartier", "Lat", "Lng" },
                values: new object[,]
                {
                    { 5, "av ministre de communication", false, 5, 30.42, -9.61 },
                    { 6, "av molay ali charif", false, 6, 33.93, -6.89 },
                    { 7, "av casabarata", false, 7, 35.76, -5.85 },
                    { 8, "rue essaouira", false, 8, 30.41, -9.59 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Civilite", "DateNaissance", "Email", "IdLocation", "IdMetier", "ImageUrl", "LastName", "Password", "Role", "Tel", "Type", "Username" },
                values: new object[,]
                {
                    { 2, "m", new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "salama@mail.com", 2, 2, "", "salama", "12345678*", 1, "06-00-00-00-00", "ouvrier", "anas" },
                    { 3, "f", new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "elhaddaoui@mail.com", 3, 2, "", "elhaddaoui", "12345678*", 2008, "06-00-00-00-00", "ouvrier", "khadija" },
                    { 4, "m", new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "benhamida@mail.com", 4, 2, "", "benhamida", "12345678*", 2, "06-00-00-00-00", "ouvrier", "omar" }
                });

            migrationBuilder.InsertData(
                table: "Catalogues",
                columns: new[] { "Id", "IdUser", "Nom" },
                values: new object[,]
                {
                    { 2, 2, "Premiere atelier : Peinture" },
                    { 3, 3, "Premiere atelier : Menuiserie Aluminum" },
                    { 4, 4, "Premiere atelier : Décorateur d'intérieur" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Civilite", "DateNaissance", "Email", "IdLocation", "IdMetier", "ImageUrl", "LastName", "Password", "Role", "Tel", "Type", "Username" },
                values: new object[,]
                {
                    { 5, "m", new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ati@mail.com", 5, 2, "", "ati", "12345678*", 2, "06-00-00-00-00", "ouvrier", "issam" },
                    { 6, "m", new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "fikri@mail.com", 6, 2, "", "fikri", "12345678*", 2, "06-00-00-00-00", "ouvrier", "ayoub" },
                    { 7, "m", new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "mourabit@mail.com", 7, 2, "", "mourabit", "12345678*", 2, "06-00-00-00-00", "ouvrier", "yassin" },
                    { 8, "f", new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "biza@mail.com", 8, 2, "", "biza", "12345678*", 2, "06-00-00-00-00", "ouvrier", "soukaina" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Description", "IdCatalogue", "ImageUrl" },
                values: new object[,]
                {
                    { 2, "Exemeple de description", 2, "" },
                    { 3, "Exemeple de description", 3, "" },
                    { 4, "Exemeple de description", 4, "" }
                });

            migrationBuilder.InsertData(
                table: "Catalogues",
                columns: new[] { "Id", "IdUser", "Nom" },
                values: new object[,]
                {
                    { 5, 5, "Premiere atelier : Piscine / Sauna / Hammam" },
                    { 6, 6, "Premiere atelier : Plomberie / Sanitaire" },
                    { 7, 7, "Premiere atelier : Zellige / Céramique" },
                    { 8, 8, "Premiere atelier : Piscine / Sauna / Hammam" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Description", "IdCatalogue", "ImageUrl" },
                values: new object[,]
                {
                    { 5, "Exemeple de description", 5, "" },
                    { 6, "Exemeple de description", 6, "" },
                    { 7, "Exemeple de description", 7, "" },
                    { 8, "Exemeple de description", 8, "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Metiers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Metiers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Metiers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Metiers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Metiers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Metiers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Catalogues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Catalogues",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Catalogues",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Catalogues",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Catalogues",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Catalogues",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Catalogues",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Catalogues",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Catalogues",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Quartiers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Quartiers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Quartiers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Quartiers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Adresse",
                value: "hay maamoura");

            migrationBuilder.UpdateData(
                table: "Metiers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nom",
                value: "Developpeur");

            migrationBuilder.UpdateData(
                table: "Metiers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nom",
                value: "Reseaux");
        }
    }
}
