namespace testWebApi1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Regions
    {
        [Key]
        public int id_region { get; set; }

        public int? id_parent { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

    }
}
