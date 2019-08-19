namespace testWebApi1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Teachers
    {
        [Key]
        public int id_teacher { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

    }
}
