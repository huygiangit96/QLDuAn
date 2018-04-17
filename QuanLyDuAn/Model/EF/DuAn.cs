namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DuAn")]
    public partial class DuAn
    {
        [Key]
        public long MaDA { get; set; }

        public long? MaKH { get; set; }

        [StringLength(150)]
        public string Ten { get; set; }

        public DateTime? ThoiGianBD { get; set; }

        public DateTime? ThoiGianKT { get; set; }

        public double? TienDo { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [Column(TypeName = "ntext")]
        public string TaiLieu { get; set; }

        public int? TrangThai { get; set; }

        public DateTime? NgayTao { get; set; }

        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }

        public long TruongDuAn { get; set; }
    }
}
