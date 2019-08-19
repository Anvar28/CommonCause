namespace testWebApi1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lessons
    {
        [Key]
        [Column(Order = 0)]
        public int id_lesson { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_establishment { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_group { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_topic { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime begin_lesson { get; set; }

        public DateTime? end_lesson { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_teacher { get; set; }

        public bool? status { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(1000)]
        public string descript { get; set; }

        public virtual Establishments establishments { get; set; }

        public virtual Groups groups { get; set; }

        public virtual Teachers teachers { get; set; }

        public virtual Topics topics { get; set; }
    }
}
