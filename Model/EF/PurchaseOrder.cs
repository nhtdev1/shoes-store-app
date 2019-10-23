namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PurchaseOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long PoID { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public bool? Status { get; set; }

        public long? AccID { get; set; }
    }
}
