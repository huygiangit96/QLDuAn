using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class GhiChuViewModel
    {
        public long ID { get; set; }
        public string Ten { get; set; }
        public string NoiDung { get; set; }
        public DateTime? NgayTao { get; set; }
    }
}
