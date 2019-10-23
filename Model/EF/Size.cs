namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Size")]
    public partial class Size
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SizeID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Number { get; set; }

        public bool? Status { get; set; }
    }
}
