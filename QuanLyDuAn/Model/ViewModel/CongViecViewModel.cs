using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class CongViecViewModel
    {
        public long ID { get; set; }
        public string Ten { get; set; }
        public string NoiDung { get; set; }
        public string Leader { get; set; }
        public DateTime? TgBatDau { get; set; }
        public DateTime? TgKetThuc { get; set; }
        public int? Cong { get; set; }
    }
}
