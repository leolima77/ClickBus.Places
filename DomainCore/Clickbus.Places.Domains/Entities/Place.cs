using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clickbus.Places.Domains.Entities
{
    using BaseEntities;

    [Table("Places")]
    public class Place
    {
        [StringLength(120)]
        public string Name { get; set; }

        [Key]
        [StringLength(120)]
        public string Slug { get; set; }

        [StringLength(120)]
        public string City { get; set; }

        [StringLength(2)]
        public string State { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}