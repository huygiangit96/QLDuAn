namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiCongViec")]
    public partial class LoaiCongViec
    {
        [Key]
        [StringLength(10)]
        public string MaLCV { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        public DateTime? NgayTao { get; set; }

        public DateTime? NgaySua { get; set; }
    }
}
