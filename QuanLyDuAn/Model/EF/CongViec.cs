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
        public long MaCV { get; set; }

        public long MaDA { get; set; }

        [StringLength(200)]
        public string Ten { get; set; }

        public int? Status { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        public int? Cong { get; set; }
        public DateTime? ThoiGianBD { get; set; }

        public DateTime? ThoiGianKT { get; set; }
    }
}
