namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewShoeDetail")]
    public partial class ViewShoeDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ShoeID { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Price { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SizeNumber { get; set; }

        [StringLength(300)]
        public string Image { get; set; }

        [StringLength(50)]
        public string ShoeName { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public bool? Status { get; set; }

        public int? Likes { get; set; }
    }
}
