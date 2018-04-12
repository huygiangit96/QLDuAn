namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViTri")]
    public partial class ViTri
    {
        [Key]
        public long MaVTri { get; set; }

        [StringLength(200)]
        public string Ten { get; set; }

        public double? HeSo { get; set; }
    }
}
