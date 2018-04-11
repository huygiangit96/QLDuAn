namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhongBan")]
    public partial class PhongBan
    {
        [Key]
        public long MaPB { get; set; }

        [StringLength(250)]
        public string TenPB { get; set; }

        [StringLength(15)]
        public string SoDT { get; set; }

        [StringLength(500)]
        public string DiaChi { get; set; }

        [StringLength(250)]
        public string MoTa { get; set; }

        public DateTime? NgayTao { get; set; }

        public DateTime? NgaySua { get; set; }
    }
}
