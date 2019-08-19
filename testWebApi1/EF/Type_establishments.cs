namespace testWebApi1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Type_establishments
    {
        [Key]
        public int id_type_establishment { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }
    }
}
