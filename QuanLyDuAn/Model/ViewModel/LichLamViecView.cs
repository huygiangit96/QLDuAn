using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class LichLamViecView
    {
        public long MaCV { get; set; }
        public string TenCV { get; set; }
        public long MaDA { get; set; }
        public string TenDA { get; set; }
        public string NoiDung { get; set; }
        public DateTime? ThoiGianBD { get; set; }
        public DateTime? ThoiGianKT { get; set; }
        public int? SoCong { get; set; }

    }
}
