using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public partial class Favorie
    {
        public int IdOuvrier { get; set; }
        public int IdUser { get; set; }

        [ForeignKey("IdOuvrier")]
        public User ouvrier { get; set; }

        [ForeignKey("IdUser")]
        public User user { get; set; }
    }
}
