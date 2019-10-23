namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewTopTrending")]
    public partial class ViewTopTrending
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ShoeID { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Price { get; set; }

        [StringLength(300)]
        public string Image { get; set; }

        [StringLength(50)]
        public string ShoeName { get; set; }

        public int? Views { get; set; }
    }
}
