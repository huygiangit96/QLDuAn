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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MaNV { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MaCV { get; set; }

        public DateTime? ThoiGianBD { get; set; }

        public DateTime? ThoiGianKT { get; set; }

        [StringLength(150)]
        public string ViTri { get; set; }

        public int? Status { get; set; }
    }
}
