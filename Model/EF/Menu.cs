namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MenuID { get; set; }

        [StringLength(50)]
        public string MenuName { get; set; }

        public long? MenuIDParent { get; set; }

        [StringLength(200)]
        public string Link { get; set; }

        public DateTime? DateCreated { get; set; }

        public bool? Status { get; set; }

        public long? AccID { get; set; }
    }
}
