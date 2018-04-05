namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVienQuyen")]
    public partial class NhanVienQuyen
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaNV { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaQuyen { get; set; }

        public DateTime? NgayTao { get; set; }

        public DateTime? NgaySua { get; set; }
    }
}
