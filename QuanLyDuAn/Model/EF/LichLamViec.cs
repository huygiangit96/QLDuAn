namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichLamViec")]
    public partial class LichLamViec
    {
        [Key]
        public long MaLLV { get; set; }

        public long? MaNV { get; set; }

        [StringLength(10)]
        public string TGLam { get; set; }

        public DateTime? NgayTao { get; set; }

        public DateTime? NgaySua { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayLam { get; set; }
    }
}
