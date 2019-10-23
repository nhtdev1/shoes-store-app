namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Color")]
    public partial class Color
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ColorID { get; set; }

        [StringLength(50)]
        public string ColorName { get; set; }

        [StringLength(200)]
        public string ImageColor { get; set; }

        public bool? Status { get; set; }
    }
}
