using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public partial class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Type { get; set; }
        public int Role { get; set; }
        public string Username { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Password { get; set; }
        // public byte[] PasswordHash { get; set; }
        // public byte[] PasswordSalt { get; set; }
        public string Civilite { get; set; }
        public string Tel { get; set; }
        public string ImageUrl { get; set; }
        public int IdLocation { get; set; }
        public int? IdMetier { get; set; }

        [ForeignKey("IdLocation")]
        public Location location { get; set; }
        
        [ForeignKey("IdMetier")]
        public Metier metier { get; set; }
        // public ICollection<Catalogue> Catalogue { get; set; }
        // public ICollection<Commentaire> commentaires { get; set; }
        // // public ICollection<Commentaire> CommentaireIdUserNavigation { get; set; }
        // public ICollection<Favorie> favories { get; set; }
        // // public ICollection<Favorie> FavorieIdUserNavigation { get; set; }
        // public ICollection<Likeuser> likeusers { get; set; }
        // public ICollection<Likeuser> LikeuserIdUserNavigation { get; set; }
    }
}
