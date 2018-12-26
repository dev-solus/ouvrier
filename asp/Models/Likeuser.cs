using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp.Models
{
    public partial class Likeuser
    {
        public int IdOuvrier { get; set; }
        public int IdUser { get; set; }
        public int Note { get; set; }

        [ForeignKey("IdOuvrier")]
        public User ouvrier { get; set; }

        [ForeignKey("IdUser")]
        public User user { get; set; }
    }
}
