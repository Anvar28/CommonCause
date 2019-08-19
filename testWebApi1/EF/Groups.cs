namespace testWebApi1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Groups
    {
        [Key]
        public int id_group { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        public int id_establishment { get; set; }

        //public virtual Establishments establishments { get; set; }

    }
}
