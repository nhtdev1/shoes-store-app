namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shoe")]
    public partial class Shoe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ShoeID { get; set; }

        [StringLength(50)]
        public string ShoeName { get; set; }

        [StringLength(150)]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? Updated { get; set; }

        public bool? Status { get; set; }

        public long? CategoryID { get; set; }
    }
}
