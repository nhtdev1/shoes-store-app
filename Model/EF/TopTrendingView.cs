namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TopTrendingView")]
    public partial class TopTrendingView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ShoeID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Descriptions { get; set; }

        public int? CategoryID { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ColorID { get; set; }

        [StringLength(50)]
        public string ColorName { get; set; }

        public int? ViewNumber { get; set; }

        public int? LikeNumber { get; set; }

        public DateTime? DateCreateColor { get; set; }

        public DateTime? DateCreatePrice { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Price { get; set; }

        [StringLength(200)]
        public string ImageDefault { get; set; }
    }
}
