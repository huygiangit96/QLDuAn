using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class NhanVienCCProdetail_ViewModel
    {
        public long MaNV { get; set; }
        public string Ten { get; set; }
        public long MaCV { get; set; }
        public string TenCV { get; set; }
        public int TongCV { get; set; }
        public int? CVStatus { get; set; }
        public long MaVT { get; set; }
        public string ViTri { get; set; }
        public double? HeSo { get; set; }
        public double? SoCong { get; set; }
        public double? TongCong { get; set; }
    }
}
