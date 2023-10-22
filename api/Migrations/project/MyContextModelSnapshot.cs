﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

#nullable disable

namespace api.Migrations.project
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdCatalogue")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdCatalogue");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "rasoire",
                            IdCatalogue = 1,
                            ImageUrl = "Catalogues/FB_IMG_1515691188716.jpg"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Exemeple de description",
                            IdCatalogue = 2,
                            ImageUrl = ""
                        },
                        new
                        {
                            Id = 3,
                            Description = "Exemeple de description",
                            IdCatalogue = 3,
                            ImageUrl = ""
                        },
                        new
                        {
                            Id = 4,
                            Description = "Exemeple de description",
                            IdCatalogue = 4,
                            ImageUrl = ""
                        },
                        new
                        {
                            Id = 5,
                            Description = "Exemeple de description",
                            IdCatalogue = 7,
                            ImageUrl = "Catalogues/zellige-carreaux.jpg"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Exemeple de description",
                            IdCatalogue = 7,
                            ImageUrl = "Catalogues/1000_large.jpg"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Exemeple de description",
                            IdCatalogue = 7,
                            ImageUrl = "Catalogues/zellige.jpg"
                        },
                        new
                        {
                            Id = 8,
                            Description = "hammam",
                            IdCatalogue = 8,
                            ImageUrl = "Catalogues/spa-sauna-hammam-douche.jpg"
                        },
                        new
                        {
                            Id = 13,
                            Description = "hammam",
                            IdCatalogue = 8,
                            ImageUrl = "Catalogues/auberge-de-l-orangerie.jpg"
                        },
                        new
                        {
                            Id = 14,
                            Description = "hammam",
                            IdCatalogue = 8,
                            ImageUrl = "Catalogues/spa-sauna-hammam-douche1.jpg"
                        },
                        new
                        {
                            Id = 9,
                            Description = "placar 1",
                            IdCatalogue = 9,
                            ImageUrl = "Catalogues/placar.jpg"
                        },
                        new
                        {
                            Id = 10,
                            Description = "placar 2",
                            IdCatalogue = 9,
                            ImageUrl = "Catalogues/placar2.jpg"
                        },
                        new
                        {
                            Id = 11,
                            Description = "placar 3",
                            IdCatalogue = 9,
                            ImageUrl = "Catalogues/placa3.png"
                        });
                });

            modelBuilder.Entity("Models.Catalogue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdUser")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Catalogues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdUser = 1,
                            Nom = "Jardinage"
                        },
                        new
                        {
                            Id = 2,
                            IdUser = 2,
                            Nom = "Premiere atelier : Peinture"
                        },
                        new
                        {
                            Id = 3,
                            IdUser = 3,
                            Nom = "Premiere atelier : Menuiserie Aluminum"
                        },
                        new
                        {
                            Id = 4,
                            IdUser = 4,
                            Nom = "Premiere atelier : Décorateur d'intérieur"
                        },
                        new
                        {
                            Id = 5,
                            IdUser = 5,
                            Nom = "Premiere atelier : Piscine / Sauna / Hammam"
                        },
                        new
                        {
                            Id = 6,
                            IdUser = 6,
                            Nom = "Premiere atelier : Plomberie / Sanitaire"
                        },
                        new
                        {
                            Id = 7,
                            IdUser = 7,
                            Nom = "Premiere atelier : Zellige / Céramique"
                        },
                        new
                        {
                            Id = 8,
                            IdUser = 8,
                            Nom = "Premiere atelier : Piscine / Sauna / Hammam"
                        },
                        new
                        {
                            Id = 9,
                            IdUser = 1,
                            Nom = "Deuxieme atelier : blacar"
                        });
                });

            modelBuilder.Entity("Models.Commentaire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdOuvrier")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdUser")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdOuvrier");

                    b.HasIndex("IdUser");

                    b.ToTable("Commentaires");
                });

            modelBuilder.Entity("Models.Favorie", b =>
                {
                    b.Property<int>("IdOuvrier")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdUser")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdOuvrier", "IdUser");

                    b.HasIndex("IdUser");

                    b.ToTable("Favories");
                });

            modelBuilder.Entity("Models.Likeuser", b =>
                {
                    b.Property<int>("IdOuvrier")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdUser")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Note")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdOuvrier", "IdUser");

                    b.HasIndex("IdUser");

                    b.ToTable("Likeusers");
                });

            modelBuilder.Entity("Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adresse")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Draggble")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdQuartier")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Lat")
                        .HasColumnType("REAL");

                    b.Property<double>("Lng")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("IdQuartier");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adresse = "av france",
                            Draggble = false,
                            IdQuartier = 1,
                            Lat = 33.927250999999998,
                            Lng = -6.8870979999999999
                        },
                        new
                        {
                            Id = 2,
                            Adresse = "hay maamoura",
                            Draggble = false,
                            IdQuartier = 2,
                            Lat = 33.909999999999997,
                            Lng = -6.9199999999999999
                        },
                        new
                        {
                            Id = 3,
                            Adresse = "av ibis",
                            Draggble = false,
                            IdQuartier = 3,
                            Lat = 35.780000000000001,
                            Lng = -5.8200000000000003
                        },
                        new
                        {
                            Id = 4,
                            Adresse = "av plage",
                            Draggble = false,
                            IdQuartier = 4,
                            Lat = 30.420000000000002,
                            Lng = -9.6099999999999994
                        },
                        new
                        {
                            Id = 5,
                            Adresse = "av ministre de communication",
                            Draggble = false,
                            IdQuartier = 5,
                            Lat = 30.420000000000002,
                            Lng = -9.6099999999999994
                        },
                        new
                        {
                            Id = 6,
                            Adresse = "av molay ali charif",
                            Draggble = false,
                            IdQuartier = 6,
                            Lat = 33.93,
                            Lng = -6.8899999999999997
                        },
                        new
                        {
                            Id = 7,
                            Adresse = "av casabarata",
                            Draggble = false,
                            IdQuartier = 7,
                            Lat = 35.759999999999998,
                            Lng = -5.8499999999999996
                        },
                        new
                        {
                            Id = 8,
                            Adresse = "rue essaouira",
                            Draggble = false,
                            IdQuartier = 8,
                            Lat = 30.41,
                            Lng = -9.5899999999999999
                        });
                });

            modelBuilder.Entity("Models.Metier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Metiers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nom = "Menuiserie Bois"
                        },
                        new
                        {
                            Id = 2,
                            Nom = "Peinture"
                        },
                        new
                        {
                            Id = 3,
                            Nom = "Menuiserie Aluminum"
                        },
                        new
                        {
                            Id = 4,
                            Nom = "Décorateur d'intérieur"
                        },
                        new
                        {
                            Id = 5,
                            Nom = "Piscine / Sauna / Hammam"
                        },
                        new
                        {
                            Id = 6,
                            Nom = "Plomberie / Sanitaire"
                        },
                        new
                        {
                            Id = 7,
                            Nom = "Zellige / Céramique"
                        },
                        new
                        {
                            Id = 8,
                            Nom = "Piscine / Sauna / Hammam"
                        });
                });

            modelBuilder.Entity("Models.Quartier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdVille")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdVille");

                    b.ToTable("Quartiers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdVille = 1,
                            Nom = "Agdal"
                        },
                        new
                        {
                            Id = 2,
                            IdVille = 2,
                            Nom = "Massira 2"
                        },
                        new
                        {
                            Id = 3,
                            IdVille = 3,
                            Nom = "New port"
                        },
                        new
                        {
                            Id = 4,
                            IdVille = 4,
                            Nom = "Marina"
                        },
                        new
                        {
                            Id = 5,
                            IdVille = 1,
                            Nom = "Al 3irfan"
                        },
                        new
                        {
                            Id = 6,
                            IdVille = 2,
                            Nom = "Massira 1"
                        },
                        new
                        {
                            Id = 7,
                            IdVille = 3,
                            Nom = "Tanger medina"
                        },
                        new
                        {
                            Id = 8,
                            IdVille = 4,
                            Nom = "Batoire"
                        });
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Civilite")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdLocation")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("IdMetier")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tel")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdLocation");

                    b.HasIndex("IdMetier");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Civilite = "m",
                            DateNaissance = new DateTime(1989, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "dj-m2x@hotmail.com",
                            IdLocation = 1,
                            IdMetier = 1,
                            ImageUrl = "",
                            LastName = "mourabit",
                            Password = "12345678*",
                            Role = 2008,
                            Tel = "0671265478",
                            Type = "ouvrier",
                            Username = "mohamed"
                        },
                        new
                        {
                            Id = 2,
                            Civilite = "m",
                            DateNaissance = new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "salama@mail.com",
                            IdLocation = 2,
                            IdMetier = 2,
                            ImageUrl = "",
                            LastName = "salama",
                            Password = "12345678*",
                            Role = 1,
                            Tel = "06-00-00-00-00",
                            Type = "ouvrier",
                            Username = "anas"
                        },
                        new
                        {
                            Id = 3,
                            Civilite = "f",
                            DateNaissance = new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "elhaddaoui@mail.com",
                            IdLocation = 3,
                            IdMetier = 2,
                            ImageUrl = "",
                            LastName = "elhaddaoui",
                            Password = "12345678*",
                            Role = 2008,
                            Tel = "06-00-00-00-00",
                            Type = "ouvrier",
                            Username = "khadija"
                        },
                        new
                        {
                            Id = 4,
                            Civilite = "m",
                            DateNaissance = new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "benhamida@mail.com",
                            IdLocation = 4,
                            IdMetier = 2,
                            ImageUrl = "",
                            LastName = "benhamida",
                            Password = "12345678*",
                            Role = 2,
                            Tel = "06-00-00-00-00",
                            Type = "ouvrier",
                            Username = "omar"
                        },
                        new
                        {
                            Id = 5,
                            Civilite = "m",
                            DateNaissance = new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ati@mail.com",
                            IdLocation = 5,
                            IdMetier = 2,
                            ImageUrl = "",
                            LastName = "ati",
                            Password = "12345678*",
                            Role = 2,
                            Tel = "06-00-00-00-00",
                            Type = "ouvrier",
                            Username = "issam"
                        },
                        new
                        {
                            Id = 6,
                            Civilite = "m",
                            DateNaissance = new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "fikri@mail.com",
                            IdLocation = 6,
                            IdMetier = 2,
                            ImageUrl = "",
                            LastName = "fikri",
                            Password = "12345678*",
                            Role = 2,
                            Tel = "06-00-00-00-00",
                            Type = "ouvrier",
                            Username = "ayoub"
                        },
                        new
                        {
                            Id = 7,
                            Civilite = "m",
                            DateNaissance = new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mourabit@mail.com",
                            IdLocation = 7,
                            IdMetier = 2,
                            ImageUrl = "",
                            LastName = "mourabit",
                            Password = "12345678*",
                            Role = 2,
                            Tel = "06-00-00-00-00",
                            Type = "ouvrier",
                            Username = "yassin"
                        },
                        new
                        {
                            Id = 8,
                            Civilite = "f",
                            DateNaissance = new DateTime(1995, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "biza@mail.com",
                            IdLocation = 8,
                            IdMetier = 2,
                            ImageUrl = "",
                            LastName = "biza",
                            Password = "12345678*",
                            Role = 2,
                            Tel = "06-00-00-00-00",
                            Type = "ouvrier",
                            Username = "soukaina"
                        });
                });

            modelBuilder.Entity("Models.Ville", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Villes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nom = "Rabat"
                        },
                        new
                        {
                            Id = 2,
                            Nom = "Temara"
                        },
                        new
                        {
                            Id = 3,
                            Nom = "Tanger"
                        },
                        new
                        {
                            Id = 4,
                            Nom = "Agadir"
                        });
                });

            modelBuilder.Entity("Models.Article", b =>
                {
                    b.HasOne("Models.Catalogue", "catalogues")
                        .WithMany("articles")
                        .HasForeignKey("IdCatalogue")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("catalogues");
                });

            modelBuilder.Entity("Models.Catalogue", b =>
                {
                    b.HasOne("Models.User", "user")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Models.Commentaire", b =>
                {
                    b.HasOne("Models.User", "ouvrier")
                        .WithMany()
                        .HasForeignKey("IdOuvrier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.User", "user")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ouvrier");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Models.Favorie", b =>
                {
                    b.HasOne("Models.User", "ouvrier")
                        .WithMany()
                        .HasForeignKey("IdOuvrier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.User", "user")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ouvrier");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Models.Likeuser", b =>
                {
                    b.HasOne("Models.User", "ouvrier")
                        .WithMany()
                        .HasForeignKey("IdOuvrier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.User", "user")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ouvrier");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Models.Location", b =>
                {
                    b.HasOne("Models.Quartier", "quartier")
                        .WithMany()
                        .HasForeignKey("IdQuartier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("quartier");
                });

            modelBuilder.Entity("Models.Quartier", b =>
                {
                    b.HasOne("Models.Ville", "ville")
                        .WithMany()
                        .HasForeignKey("IdVille")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ville");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.HasOne("Models.Location", "location")
                        .WithMany("users")
                        .HasForeignKey("IdLocation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Metier", "metier")
                        .WithMany()
                        .HasForeignKey("IdMetier");

                    b.Navigation("location");

                    b.Navigation("metier");
                });

            modelBuilder.Entity("Models.Catalogue", b =>
                {
                    b.Navigation("articles");
                });

            modelBuilder.Entity("Models.Location", b =>
                {
                    b.Navigation("users");
                });
#pragma warning restore 612, 618
        }
    }
}