using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class ChiTietLichLamViecDAO
    {
        QLDADbContext db = null;

        public ChiTietLichLamViecDAO()
        {
            db = new QLDADbContext();
        }
        public List<ChiTietLichLamViec> ListAll()
        {
            return db.ChiTietLichLamViecs.ToList();
        }
    }
}
