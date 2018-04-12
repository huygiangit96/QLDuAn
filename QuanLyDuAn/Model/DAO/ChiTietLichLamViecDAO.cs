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

        public bool Insert_EmpID_ProID(long emp_id, long pro_id)
        {
            try
            {
                ChiTietLichLamViec check = db.ChiTietLichLamViecs.Where(x => x.MaNV == emp_id && x.MaCV == pro_id).SingleOrDefault();
                if(check == null)
                {
                    ChiTietLichLamViec item = new ChiTietLichLamViec();

                    item.MaNV = emp_id;
                    item.MaCV = pro_id;
                    item.NgayTao = DateTime.Today;
                    db.ChiTietLichLamViecs.Add(item);
                    db.SaveChanges();
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
