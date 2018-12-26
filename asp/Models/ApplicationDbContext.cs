﻿using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace asp.Models
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Catalogue> Catalogues { get; set; }
        public DbSet<Commentaire> Commentaires { get; set; }
        public DbSet<Likeuser> Likeusers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Metier> Metiers { get; set; }
        public DbSet<Quartier> Quartiers { get; set; }
        public DbSet<Favorie> Favories { get; set; }
        public DbSet<Ville> Villes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Likeuser>().HasKey(sc => new { sc.IdOuvrier, sc.IdUser });
            modelBuilder.Entity<Favorie>().HasKey(sc => new { sc.IdOuvrier, sc.IdUser });
           // data seeding
            modelBuilder.AddVilles();
            modelBuilder.AddQuartiers();
            modelBuilder.AddLocations();
            modelBuilder.AddMetiers();
            modelBuilder.AddUsers();
            modelBuilder.AddCatalogues();
            modelBuilder.AddArticles();

            // scafolding to db
            // dotnet ef migrations add secondMG
            // dotnet ef database update
            // dotnet ef migrations remove
            // dotnet ef database update LastGoodMigration
            // dotnet ef migrations script
        }
    }
}
