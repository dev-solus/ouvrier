using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public partial class Commentaire
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdOuvrier { get; set; }
        public int IdUser { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("IdOuvrier")]
        public User ouvrier { get; set; }

        [ForeignKey("IdUser")]
        public User user { get; set; }
    }
}
