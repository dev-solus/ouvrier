using Microsoft.EntityFrameworkCore.Migrations;

namespace asp3.Migrations
{
    public partial class tirthMG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "rasoire", "Catalogues/FB_IMG_1515691188716.jpg" });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "IdCatalogue", "ImageUrl" },
                values: new object[] { 7, "Catalogues/zellige-carreaux.jpg" });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "IdCatalogue", "ImageUrl" },
                values: new object[] { 7, "Catalogues/1000_large.jpg" });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "Catalogues/zellige.jpg");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "hammam", "Catalogues/spa-sauna-hammam-douche.jpg" });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "placar 1", "Catalogues/placar.jpg" });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "placar 2", "Catalogues/placar2.jpg" });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "placar 3", "Catalogues/placa3.png" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Description", "IdCatalogue", "ImageUrl" },
                values: new object[,]
                {
                    { 13, "hammam", 8, "Catalogues/auberge-de-l-orangerie.jpg" },
                    { 14, "hammam", 8, "Catalogues/spa-sauna-hammam-douche1.jpg" }
                });

            migrationBuilder.UpdateData(
                table: "Catalogues",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nom",
                value: "Jardinage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Exemeple de description", "" });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "IdCatalogue", "ImageUrl" },
                values: new object[] { 5, "" });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "IdCatalogue", "ImageUrl" },
                values: new object[] { 6, "" });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Exemeple de description", "" });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Exemeple de description", "" });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Exemeple de description", "" });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Exemeple de description", "" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Description", "IdCatalogue", "ImageUrl" },
                values: new object[] { 12, "Exemeple de description", 9, "" });

            migrationBuilder.UpdateData(
                table: "Catalogues",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nom",
                value: "Premiere atelier : Menuiserie Bois");
        }
    }
}
