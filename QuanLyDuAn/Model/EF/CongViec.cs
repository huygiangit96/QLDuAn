namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CongViec")]
    public partial class CongViec
    {
        [Key]
        [StringLength(10)]
        public string MaCV { get; set; }

        [StringLength(50)]
        public string MaKH { get; set; }

        [StringLength(150)]
        public string Ten { get; set; }

        public DateTime? ThoiGianBD { get; set; }

        public DateTime? ThoiGianKT { get; set; }

        public double? TienDo { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(250)]
        public string TaiLieu { get; set; }

        public int? TrangThai { get; set; }

        [StringLength(10)]
        public string MaLCV { get; set; }

        public DateTime? NgayTao { get; set; }

        public DateTime? NgaySua { get; set; }

        [StringLength(500)]
        public string MoTa { get; set; }
    }
}
