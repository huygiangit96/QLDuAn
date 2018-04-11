using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class DuAnViewModel
    {
        public string ID { get; set; }
        public string Ten { get; set; }
        public double? TienDo { get; set; }
        public int? TrangThai { get; set; }
        public List<NhanVien> ThanhVien { get; set; }
        public string MoTa { get; set; }
        public string KhachHang { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
    }
}
