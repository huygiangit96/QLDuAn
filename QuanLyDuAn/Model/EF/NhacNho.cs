namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhacNho")]
    public partial class NhacNho
    {
        [Key]
        public long MaNN { get; set; }

        public long? MaNV { get; set; }

        public DateTime? ThoiGian { get; set; }

        public int? SoLan { get; set; }

        [StringLength(100)]
        public string TieuDe { get; set; }

        public int? Status { get; set; }

        [StringLength(500)]
        public string NoiDung { get; set; }

        public DateTime? NgayTao { get; set; }

        public long? NguoiNhanID { get; set; }

    }
}
