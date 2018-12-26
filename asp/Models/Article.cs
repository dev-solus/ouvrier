using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp.Models
{
    public partial class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int IdCatalogue { get; set; }

        [ForeignKey("IdCatalogue")]
        public Catalogue catalogues { get; set; }
    }
}
