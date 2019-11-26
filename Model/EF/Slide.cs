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
        public int SlideID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Link { get; set; }

        public DateTime? DateCreated { get; set; }

        public bool? Status { get; set; }

        public long? AccID { get; set; }

        public virtual Account Account { get; set; }
    }
}
