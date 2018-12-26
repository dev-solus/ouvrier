using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp.Models
{
    public partial class Quartier
    {
        // public Quartier()
        // {
        //     Location = new HashSet<Location>();
        // }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nom { get; set; }
        public int IdVille { get; set; }
        
        [ForeignKey("IdVille")]
        public Ville ville { get; set; }
        // public ICollection<Location> Location { get; set; }
    }
}
