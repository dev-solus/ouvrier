// using System;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata;

// namespace asp.Models
// {
//     public partial class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
//     {
//         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//             : base(options)
//         {
//         }

//         public virtual DbSet<Personne> Personne { get; set; }

// protected override void OnModelCreating(ModelBuilder modelBuilder)
//         {
//             base.OnModelCreating(modelBuilder);

//         }


//     }
// }
