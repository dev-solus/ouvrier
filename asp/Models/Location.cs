using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp.Models
{
    public partial class Location
    {
        // public Location()
        // {
        //     users = new HashSet<User>();
        // }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Adresse { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public bool Draggble { get; set; }
        public int IdQuartier { get; set; }

        [ForeignKey("IdQuartier")]
        public Quartier quartier { get; set; }
        public ICollection<User> users { get; set; }
    }
}
