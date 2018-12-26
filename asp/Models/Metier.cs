using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp.Models
{
    public partial class Metier
    {
        // public Metier()
        // {
        //     User = new HashSet<User>();
        // }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nom { get; set; }

        // public ICollection<User> User { get; set; }
    }
}
