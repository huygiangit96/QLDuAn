namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BangCong")]
    public partial class BangCong
    {
        [Key]
        [StringLength(10)]
        public string MaCC { get; set; }

        [StringLength(10)]
        public string MaCV { get; set; }

        [StringLength(10)]
        public string MaNV { get; set; }

        [StringLength(50)]
        public string TenChucNang { get; set; }

        public DateTime? NgayBatDau { get; set; }

        public DateTime? NgayKetThuc { get; set; }

        public int? SoGioLam { get; set; }

        public DateTime? NgayTao { get; set; }

        public DateTime? NgaySua { get; set; }
    }
}
