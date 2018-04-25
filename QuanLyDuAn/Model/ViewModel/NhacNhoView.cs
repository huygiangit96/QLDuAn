using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class NhacNhoView
    {
        public long MaNN { get; set; }
        public long? MaNV { get; set; }
        public string Ten { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public DateTime? NgayTao { get; set; }
        public long? NguoiNhanID { get; set; }
        public long ReplyID { get; set; }
        public string NguoiNhan { get; set; }
        public int? Status { get; set; }
    }
}
