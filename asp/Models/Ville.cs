using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp.Models
{
    public partial class Ville
    {
        // public Ville()
        // {
        //     Quartier = new HashSet<Quartier>();
        // }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nom { get; set; }

        // public ICollection<Quartier> quartiers { get; set; }
    }
}
