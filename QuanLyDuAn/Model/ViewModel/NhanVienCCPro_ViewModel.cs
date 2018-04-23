using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class NhanVienCCPro_ViewModel
    {
        public long MaNV { get; set; }
        public string Ten { get; set; }
        public long MaDA { get; set; }
        public string TenDA { get; set; }
        public int TongDA { get; set; }
        public int? Cong { get; set; }
    }
}
