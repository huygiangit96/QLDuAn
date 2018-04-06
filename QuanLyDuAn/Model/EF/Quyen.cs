namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Quyen")]
    public partial class Quyen
    {
        [Key]
        [StringLength(10)]
        public int MaQuyen { get; set; }

        [StringLength(50)]
        public string TenQuyen { get; set; }

        [StringLength(50)]
        public string MoTa { get; set; }
    }
}
