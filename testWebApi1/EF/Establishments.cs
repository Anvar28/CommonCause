namespace testWebApi1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Establishments
    {
        [Key]
        public int id_establishment { get; set; }

        [Required]
        [StringLength(500)]
        public string name { get; set; }

        public int id_type { get; set; }

        public int id_city { get; set; }

        [Required]
        [StringLength(1000)]
        public string contact_info { get; set; }
	}
}
