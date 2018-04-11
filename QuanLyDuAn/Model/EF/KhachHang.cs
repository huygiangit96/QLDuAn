namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [Key]
        public long MaKH { get; set; }

        [StringLength(150)]
        public string Ten { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        [StringLength(20)]
        public string SoTK { get; set; }

        [StringLength(15)]
        public string SoDT { get; set; }

        public DateTime? NgayTao { get; set; }

        public DateTime? NgaySua { get; set; }
    }
}
