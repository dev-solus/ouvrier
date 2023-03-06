using System;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    public static class DataSeeding
    {
        public static void AddVilles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ville>().HasData(new Ville[]{
                new Ville {Id = 1,Nom = "Rabat"},
                new Ville {Id = 2,Nom = "Temara"},
                new Ville {Id = 3,Nom = "Tanger"},
                new Ville {Id = 4,Nom = "Agadir"},
            });
        }

        public static void AddQuartiers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quartier>().HasData(new Quartier[]{
                new Quartier {Id = 1,IdVille = 1,Nom = "Agdal"},
                new Quartier {Id = 2,IdVille = 2,Nom = "Massira 2"},
                new Quartier {Id = 3,IdVille = 3,Nom = "New port"},
                new Quartier {Id = 4,IdVille = 4,Nom = "Marina"},
                new Quartier {Id = 5,IdVille = 1,Nom = "Al 3irfan"},
                new Quartier {Id = 6,IdVille = 2,Nom = "Massira 1"},
                new Quartier {Id = 7,IdVille = 3,Nom = "Tanger medina"},
                new Quartier {Id = 8,IdVille = 4,Nom = "Batoire"},
            });
        }

        public static void AddMetiers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Metier>().HasData(new Metier[] {
                new Metier{Id = 1, Nom = "Menuiserie Bois"},
                new Metier{Id = 2, Nom = "Peinture"},
                new Metier{Id = 3, Nom = "Menuiserie Aluminum"},
                new Metier{Id = 4, Nom = "Décorateur d'intérieur"},
                new Metier{Id = 5, Nom = "Piscine / Sauna / Hammam"},
                new Metier{Id = 6, Nom = "Plomberie / Sanitaire"},
                new Metier{Id = 7, Nom = "Zellige / Céramique"},
                new Metier{Id = 8, Nom = "Piscine / Sauna / Hammam"},
            });
        }

        public static void AddLocations(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasData(new Location[] {
                new Location
                {
                    Id = 1,
                    Adresse = "av france",
                    Draggble = false,
                    IdQuartier = 1,
                    Lat = 33.927251,
                    Lng = -6.887098
                },
                new Location
                {
                    Id = 2,
                    Adresse = "hay maamoura",
                    Draggble = false,
                    IdQuartier = 2,
                    Lat = 33.91,
                    Lng = -6.92
                },
                new Location
                {
                    Id = 3,
                    Adresse = "av ibis",
                    Draggble = false,
                    IdQuartier = 3,
                    Lat = 35.78,
                    Lng = -5.82
                },
                new Location
                {
                    Id = 4,
                    Adresse = "av plage",
                    Draggble = false,
                    IdQuartier = 4,
                    Lat = 30.42,
                    Lng = -9.61
                },
                new Location
                {
                    Id = 5,
                    Adresse = "av ministre de communication",
                    Draggble = false,
                    IdQuartier = 5,
                    Lat = 30.42,
                    Lng = -9.61
                },
                new Location
                {
                    Id = 6,
                    Adresse = "av molay ali charif",
                    Draggble = false,
                    IdQuartier = 6,
                    Lat = 33.93,
                    Lng = -6.89
                },
                new Location
                {
                    Id = 7,
                    Adresse = "av casabarata",
                    Draggble = false,
                    IdQuartier = 7,
                    Lat = 35.76,
                    Lng = -5.85
                },
                new Location
                {
                    Id = 8,
                    Adresse = "rue essaouira",
                    Draggble = false,
                    IdQuartier = 8,
                    Lat = 30.41,
                    Lng = -9.59
                },
            });
        }

        public static void AddUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[] {
                new User
                {
                    Id = 1,
                    Type = "ouvrier",
                    Role = 2008,
                    Username = "mohamed",
                    LastName = "mourabit",
                    Email = "dj-m2x@hotmail.com",
                    DateNaissance = DateTime.Parse("1989-01-11"),
                    Password = "12345678*",
                    Civilite = "m",
                    Tel = "0671265478",
                    ImageUrl = "",
                    IdLocation = 1,
                    IdMetier = 1,
                },
                new User
                {
                    Id = 2,
                    Type = "ouvrier",
                    Role = 1,
                    Username = "anas",
                    LastName = "salama",
                    Email = "salama@mail.com",
                    DateNaissance = DateTime.Parse("1995-01-03"),
                    Password = "12345678*",
                    Civilite = "m",
                    Tel = "06-00-00-00-00",
                    ImageUrl = "",
                    IdLocation = 2,
                    IdMetier = 2,
                },
                new User
                {
                    Id = 3,
                    Type = "ouvrier",
                    Role = 2008,
                    Username = "khadija",
                    LastName = "elhaddaoui",
                    Email = "elhaddaoui@mail.com",
                    DateNaissance = DateTime.Parse("1995-01-03"),
                    Password = "12345678*",
                    Civilite = "f",
                    Tel = "06-00-00-00-00",
                    ImageUrl = "",
                    IdLocation = 3,
                    IdMetier = 2,
                },
                new User
                {
                    Id = 4,
                    Type = "ouvrier",
                    Role = 2,
                    Username = "omar",
                    LastName = "benhamida",
                    Email = "benhamida@mail.com",
                    DateNaissance = DateTime.Parse("1995-01-03"),
                    Password = "12345678*",
                    Civilite = "m",
                    Tel = "06-00-00-00-00",
                    ImageUrl = "",
                    IdLocation = 4,
                    IdMetier = 2,
                },
                new User
                {
                    Id = 5,
                    Type = "ouvrier",
                    Role = 2,
                    Username = "issam",
                    LastName = "ati",
                    Email = "ati@mail.com",
                    DateNaissance = DateTime.Parse("1995-01-03"),
                    Password = "12345678*",
                    Civilite = "m",
                    Tel = "06-00-00-00-00",
                    ImageUrl = "",
                    IdLocation = 5,
                    IdMetier = 2,
                },
                new User
                {
                    Id = 6,
                    Type = "ouvrier",
                    Role = 2,
                    Username = "ayoub",
                    LastName = "fikri",
                    Email = "fikri@mail.com",
                    DateNaissance = DateTime.Parse("1995-01-03"),
                    Password = "12345678*",
                    Civilite = "m",
                    Tel = "06-00-00-00-00",
                    ImageUrl = "",
                    IdLocation = 6,
                    IdMetier = 2,
                },
                new User
                {
                    Id = 7,
                    Type = "ouvrier",
                    Role = 2,
                    Username = "yassin",
                    LastName = "mourabit",
                    Email = "mourabit@mail.com",
                    DateNaissance = DateTime.Parse("1995-01-03"),
                    Password = "12345678*",
                    Civilite = "m",
                    Tel = "06-00-00-00-00",
                    ImageUrl = "",
                    IdLocation = 7,
                    IdMetier = 2,
                },
                new User
                {
                    Id = 8,
                    Type = "ouvrier",
                    Role = 2,
                    Username = "soukaina",
                    LastName = "biza",
                    Email = "biza@mail.com",
                    DateNaissance = DateTime.Parse("1995-01-03"),
                    Password = "12345678*",
                    Civilite = "f",
                    Tel = "06-00-00-00-00",
                    ImageUrl = "",
                    IdLocation = 8,
                    IdMetier = 2,
                },
            });
        }

        public static void AddCatalogues(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalogue>().HasData(new Catalogue[]{
                new Catalogue { Id = 1, Nom = "Jardinage", IdUser = 1 },
                new Catalogue { Id = 2, Nom = "Premiere atelier : Peinture", IdUser = 2 },
                new Catalogue { Id = 3, Nom = "Premiere atelier : Menuiserie Aluminum", IdUser = 3 },
                new Catalogue { Id = 4, Nom = "Premiere atelier : Décorateur d'intérieur", IdUser = 4 },
                new Catalogue { Id = 5, Nom = "Premiere atelier : Piscine / Sauna / Hammam", IdUser = 5 },
                new Catalogue { Id = 6, Nom = "Premiere atelier : Plomberie / Sanitaire", IdUser = 6 },
                new Catalogue { Id = 7, Nom = "Premiere atelier : Zellige / Céramique", IdUser = 7 },
                new Catalogue { Id = 8, Nom = "Premiere atelier : Piscine / Sauna / Hammam", IdUser = 8 },
                new Catalogue { Id = 9, Nom = "Deuxieme atelier : blacar", IdUser = 1 },
            });
        }

        public static void AddArticles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasData(new Article[]{
                // cat 1
                new Article { Id = 1, Description = "rasoire", ImageUrl = "Catalogues/FB_IMG_1515691188716.jpg", IdCatalogue = 1 },
                // cat
                new Article { Id = 2, Description = "Exemeple de description", ImageUrl = "", IdCatalogue = 2 },
                new Article { Id = 3, Description = "Exemeple de description", ImageUrl = "", IdCatalogue = 3 },
                new Article { Id = 4, Description = "Exemeple de description", ImageUrl = "", IdCatalogue = 4 },
                //  Catalogue 7
                new Article { Id = 5, Description = "Exemeple de description", ImageUrl = "Catalogues/zellige-carreaux.jpg", IdCatalogue = 7 },
                new Article { Id = 6, Description = "Exemeple de description", ImageUrl = "Catalogues/1000_large.jpg", IdCatalogue = 7 },
                new Article { Id = 7, Description = "Exemeple de description", ImageUrl = "Catalogues/zellige.jpg", IdCatalogue = 7 },
                // cat 8
                new Article { Id = 8, Description = "hammam", ImageUrl = "Catalogues/spa-sauna-hammam-douche.jpg", IdCatalogue = 8 },
                new Article { Id = 13, Description = "hammam", ImageUrl = "Catalogues/auberge-de-l-orangerie.jpg", IdCatalogue = 8 },
                new Article { Id = 14, Description = "hammam", ImageUrl = "Catalogues/spa-sauna-hammam-douche1.jpg", IdCatalogue = 8 },
                // catalogue 9
                new Article { Id = 9, Description = "placar 1", ImageUrl = "Catalogues/placar.jpg", IdCatalogue = 9 },
                new Article { Id = 10, Description = "placar 2", ImageUrl = "Catalogues/placar2.jpg", IdCatalogue = 9 },
                new Article { Id = 11, Description = "placar 3", ImageUrl = "Catalogues/placa3.png", IdCatalogue = 9 },
                
            });
        }
    }
}