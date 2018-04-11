namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [Key]
        public long MaNV { get; set; }

        public long? MaPB { get; set; }

        public long? MaVT { get; set; }

        public long? MaBP { get; set; }

        [StringLength(150)]
        public string Ten { get; set; }

        [StringLength(200)]
        public string TaiKhoan { get; set; }

        [StringLength(200)]
        public string MatKhau { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        [StringLength(20)]
        public string SoTK { get; set; }

        [StringLength(15)]
        public string SoDT { get; set; }

        [StringLength(200)]
        public string TrinhDo { get; set; }

        public int? Status { get; set; }

        [StringLength(150)]
        public string Email { get; set; }
    }
}
