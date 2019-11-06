namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PriceOfShoesView")]
    public partial class PriceOfShoesView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ColorID { get; set; }

        public DateTime? DateCreated { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Value { get; set; }
    }
}
