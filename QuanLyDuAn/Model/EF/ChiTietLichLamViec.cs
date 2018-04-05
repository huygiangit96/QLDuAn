namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietLichLamViec")]
    public partial class ChiTietLichLamViec
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaCV { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaNV { get; set; }

        [StringLength(50)]
        public string GhiChu { get; set; }

        public DateTime? NgayTao { get; set; }

        public DateTime? NgaySua { get; set; }

        public DateTime? ThoiGianBD { get; set; }

        public DateTime? ThoiGianKT { get; set; }

        [StringLength(150)]
        public string VaiTro { get; set; }

        public double? TienDo { get; set; }

        public int? Status { get; set; }
    }
}
