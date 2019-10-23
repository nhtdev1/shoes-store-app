namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SlideID { get; set; }

        [StringLength(50)]
        public string SlideName { get; set; }

        [StringLength(50)]
        public string Metatitle { get; set; }

        [StringLength(200)]
        public string Link { get; set; }

        public DateTime? DateCreated { get; set; }

        public bool? Status { get; set; }
    }
}
