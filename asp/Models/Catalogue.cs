using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp.Models
{
    public partial class Catalogue
    {
        // public Catalogue()
        // {
        //     articles = new HashSet<Article>();
        // }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nom { get; set; }
        public int IdUser { get; set; }

        [ForeignKey("IdUser")]
        public User user { get; set; }
        public ICollection<Article> articles { get; set; }
    }
}
