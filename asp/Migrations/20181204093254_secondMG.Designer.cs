﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using asp.Models;

namespace asp3.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181204093254_secondMG")]
    partial class secondMG
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("asp.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("IdCatalogue");

                    b.Property<string>("ImageUrl");

                    b.HasKey("Id");

                    b.HasIndex("IdCatalogue");

                    b.ToTable("Articles");

                    b.HasData(
                        new { Id = 1, Description = "Exemeple de description", IdCatalogue = 1, ImageUrl = "" },
                        new { Id = 2, Description = "Exemeple de description", IdCatalogue = 2, ImageUrl = "" },
                        new { Id = 3, Description = "Exemeple de description", IdCatalogue = 3, ImageUrl = "" },
                        new { Id = 4, Description = "Exemeple de description", IdCatalogue = 4, ImageUrl = "" },
                        new { Id = 5, Description = "Exemeple de description", IdCatalogue = 5, ImageUrl = "" },
                        new { Id = 6, Description = "Exemeple de description", IdCatalogue = 6, ImageUrl = "" },
                        new { Id = 7, Description = "Exemeple de description", IdCatalogue = 7, ImageUrl = "" },
                        new { Id = 8, Description = "Exemeple de description", IdCatalogue = 8, ImageUrl = "" },
                        new { Id = 9, Description = "Exemeple de description", IdCatalogue = 9, ImageUrl = "" },
                        new { Id = 10, Description = "Exemeple de description", IdCatalogue = 9, ImageUrl = "" },
                        new { Id = 11, Description = "Exemeple de description", IdCatalogue = 9, ImageUrl = "" },
                        new { Id = 12, Description = "Exemeple de description", IdCatalogue = 9, ImageUrl = "" }
                    );
                });

            modelBuilder.Entity("asp.Models.Catalogue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdUser");

                    b.Property<string>("Nom");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Catalogues");

                    b.HasData(
                        new { Id = 1, IdUser = 1, Nom = "Premiere atelier : Menuiserie Bois" },
                        new { Id = 2, IdUser = 2, Nom = "Premiere atelier : Peinture" },
                        new { Id = 3, IdUser = 3, Nom = "Premiere atelier : Menuiserie Aluminum" },
                        new { Id = 4, IdUser = 4, Nom = "Premiere atelier : Décorateur d'intérieur" },
                        new { Id = 5, IdUser = 5, Nom = "Premiere atelier : Piscine / Sauna / Hammam" },
                        new { Id = 6, IdUser = 6, Nom = "Premiere atelier : Plomberie / Sanitaire" },
                        new { Id = 7, IdUser = 7, Nom = "Premiere atelier : Zellige / Céramique" },
                        new { Id = 8, IdUser = 8, Nom = "Premiere atelier : Piscine / Sauna / Hammam" },
                        new { Id = 9, IdUser = 1, Nom = "Deuxieme atelier : blacar" }
                    );
                });

            modelBuilder.Entity("asp.Models.Commentaire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<DateTime>("Date");

                    b.Property<int>("IdOuvrier");

                    b.Property<int>("IdUser");

                    b.HasKey("Id");

                    b.HasIndex("IdOuvrier");

                    b.HasIndex("IdUser");

                    b.ToTable("Commentaires");
                });

            modelBuilder.Entity("asp.Models.Favorie", b =>
                {
                    b.Property<int>("IdOuvrier");

                    b.Property<int>("IdUser");

                    b.HasKey("IdOuvrier", "IdUser");

                    b.HasIndex("IdUser");

                    b.ToTable("Favories");
                });

            modelBuilder.Entity("asp.Models.Likeuser", b =>
                {
                    b.Property<int>("IdOuvrier");

                    b.Property<int>("IdUser");

                    b.Property<int>("Note");

                    b.HasKey("IdOuvrier", "IdUser");

                    b.HasIndex("IdUser");

                    b.ToTable("Likeusers");
                });

            modelBuilder.Entity("asp.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresse");

                    b.Property<bool>("Draggble");

                    b.Property<int>("IdQuartier");

                    b.Property<double>("Lat");

                    b.Property<double>("Lng");

                    b.HasKey("Id");

                    b.HasIndex("IdQuartier");

                    b.ToTable("Locations");

                    b.HasData(
                        new { Id = 1, Adresse = "av france", Draggble = false, IdQuartier = 1, Lat = 33.927251, Lng = -6.887098 },
                        new { Id = 2, Adresse = "hay maamoura", Draggble = false, IdQuartier = 2, Lat = 33.91, Lng = -6.92 },
                        new { Id = 3, Adresse = "av ibis", Draggble = false, IdQuartier = 3, Lat = 35.78, Lng = -5.82 },
                        new { Id = 4, Adresse = "av plage", Draggble = false, IdQuartier = 4, Lat = 30.42, Lng = -9.61 },
                        new { Id = 5, Adresse = "av ministre de communication", Draggble = false, IdQuartier = 5, Lat = 30.42, Lng = -9.61 },
                        new { Id = 6, Adresse = "av molay ali charif", Draggble = false, IdQuartier = 6, Lat = 33.93, Lng = -6.89 },
                        new { Id = 7, Adresse = "av casabarata", Draggble = false, IdQuartier = 7, Lat = 35.76, Lng = -5.85 },
                        new { Id = 8, Adresse = "rue essaouira", Draggble = false, IdQuartier = 8, Lat = 30.41, Lng = -9.59 }
                    );
                });

            modelBuilder.Entity("asp.Models.Metier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nom");

                    b.HasKey("Id");

                    b.ToTable("Metiers");

                    b.HasData(
                        new { Id = 1, Nom = "Menuiserie Bois" },
                        new { Id = 2, Nom = "Peinture" },
                        new { Id = 3, Nom = "Menuiserie Aluminum" },
                        new { Id = 4, Nom = "Décorateur d'intérieur" },
                        new { Id = 5, Nom = "Piscine / Sauna / Hammam" },
                        new { Id = 6, Nom = "Plomberie / Sanitaire" },
                        new { Id = 7, Nom = "Zellige / Céramique" },
                        new { Id = 8, Nom = "Piscine / Sauna / Hammam" }
                    );
                });

            modelBuilder.Entity("asp.Models.Quartier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdVille");

                    b.Property<string>("Nom");

                    b.HasKey("Id");

                    b.HasIndex("IdVille");

                    b.ToTable("Quartiers");

                    b.HasData(
                        new { Id = 1, IdVille = 1, Nom = "Agdal" },
                        new { Id = 2, IdVille = 2, Nom = "Massira 2" },
                        new { Id = 3, IdVille = 3, Nom = "New port" },
                        new { Id = 4, IdVille = 4, Nom = "Marina" },
                        new { Id = 5, IdVille = 1, Nom = "Al 3irfan" },
                        new { Id = 6, IdVille = 2, Nom = "Massira 1" },
                        new { Id = 7, IdVille = 3, Nom = "Tanger medina" },
                        new { Id = 8, IdVille = 4, Nom = "Batoire" }
                    );
                });

            modelBuilder.Entity("asp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Civilite");

                    b.Property<DateTime>("DateNaissance");

                    b.Property<string>("Email");

                    b.Property<int>("IdLocation");

                    b.Property<int?>("IdMetier");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<int>("Role");

                    b.Property<string>("Tel");

                    b.Property<string>("Type");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("IdLocation");

                    b.HasIndex("IdMetier");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = 1, Civilite = "m", DateNaissance = new DateTime(1989, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), Email = "dj-m2x@hotmail.com", IdLocation = 1, IdMetier = 1, ImageUrl = "", LastName = "mourabit", Password = "12345678*", Role = 2008, Tel = "0671265478", Type = "ouvrier", Username = "mohamed" },
                        new { Id = 2, Civilite = "m", DateNaissance = new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), Email = "salama@mail.com", IdLocation = 2, IdMetier = 2, ImageUrl = "", LastName = "salama", Password = "12345678*", Role = 1, Tel = "06-00-00-00-00", Type = "ouvrier", Username = "anas" },
                        new { Id = 3, Civilite = "f", DateNaissance = new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), Email = "elhaddaoui@mail.com", IdLocation = 3, IdMetier = 2, ImageUrl = "", LastName = "elhaddaoui", Password = "12345678*", Role = 2008, Tel = "06-00-00-00-00", Type = "ouvrier", Username = "khadija" },
                        new { Id = 4, Civilite = "m", DateNaissance = new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), Email = "benhamida@mail.com", IdLocation = 4, IdMetier = 2, ImageUrl = "", LastName = "benhamida", Password = "12345678*", Role = 2, Tel = "06-00-00-00-00", Type = "ouvrier", Username = "omar" },
                        new { Id = 5, Civilite = "m", DateNaissance = new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), Email = "ati@mail.com", IdLocation = 5, IdMetier = 2, ImageUrl = "", LastName = "ati", Password = "12345678*", Role = 2, Tel = "06-00-00-00-00", Type = "ouvrier", Username = "issam" },
                        new { Id = 6, Civilite = "m", DateNaissance = new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), Email = "fikri@mail.com", IdLocation = 6, IdMetier = 2, ImageUrl = "", LastName = "fikri", Password = "12345678*", Role = 2, Tel = "06-00-00-00-00", Type = "ouvrier", Username = "ayoub" },
                        new { Id = 7, Civilite = "m", DateNaissance = new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), Email = "mourabit@mail.com", IdLocation = 7, IdMetier = 2, ImageUrl = "", LastName = "mourabit", Password = "12345678*", Role = 2, Tel = "06-00-00-00-00", Type = "ouvrier", Username = "yassin" },
                        new { Id = 8, Civilite = "f", DateNaissance = new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), Email = "biza@mail.com", IdLocation = 8, IdMetier = 2, ImageUrl = "", LastName = "biza", Password = "12345678*", Role = 2, Tel = "06-00-00-00-00", Type = "ouvrier", Username = "soukaina" }
                    );
                });

            modelBuilder.Entity("asp.Models.Ville", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nom");

                    b.HasKey("Id");

                    b.ToTable("Villes");

                    b.HasData(
                        new { Id = 1, Nom = "Rabat" },
                        new { Id = 2, Nom = "Temara" },
                        new { Id = 3, Nom = "Tanger" },
                        new { Id = 4, Nom = "Agadir" }
                    );
                });

            modelBuilder.Entity("asp.Models.Article", b =>
                {
                    b.HasOne("asp.Models.Catalogue", "catalogues")
                        .WithMany("articles")
                        .HasForeignKey("IdCatalogue")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("asp.Models.Catalogue", b =>
                {
                    b.HasOne("asp.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("asp.Models.Commentaire", b =>
                {
                    b.HasOne("asp.Models.User", "ouvrier")
                        .WithMany()
                        .HasForeignKey("IdOuvrier")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("asp.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("asp.Models.Favorie", b =>
                {
                    b.HasOne("asp.Models.User", "ouvrier")
                        .WithMany()
                        .HasForeignKey("IdOuvrier")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("asp.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("asp.Models.Likeuser", b =>
                {
                    b.HasOne("asp.Models.User", "ouvrier")
                        .WithMany()
                        .HasForeignKey("IdOuvrier")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("asp.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("asp.Models.Location", b =>
                {
                    b.HasOne("asp.Models.Quartier", "quartier")
                        .WithMany()
                        .HasForeignKey("IdQuartier")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("asp.Models.Quartier", b =>
                {
                    b.HasOne("asp.Models.Ville", "ville")
                        .WithMany()
                        .HasForeignKey("IdVille")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("asp.Models.User", b =>
                {
                    b.HasOne("asp.Models.Location", "location")
                        .WithMany("users")
                        .HasForeignKey("IdLocation")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("asp.Models.Metier", "metier")
                        .WithMany()
                        .HasForeignKey("IdMetier");
                });
#pragma warning restore 612, 618
        }
    }
}
