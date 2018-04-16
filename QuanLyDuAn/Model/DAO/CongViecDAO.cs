using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using Model.ViewModel;

namespace Model.DAO
{
    public class CongViecDAO
    {
        QLDADbContext db = null;
        public CongViecDAO()
        {
            db = new QLDADbContext();
        }

        public bool Insert(CongViec item)
        {
            try
            {
                db.CongViecs.Add(item);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public CongViec GetCvIDByNameAndDaID(long mada, string name)
        {
            return db.CongViecs.SingleOrDefault(x => x.MaDA == mada && x.Ten == name);
        }
        public List<CongViec> ListAll()
        {
            return db.CongViecs.ToList();
        }
        public List<LichLamViecView> ListCV()
        {
            var data = from a in db.CongViecs
                       join b in db.DuAns on a.MaDA equals b.MaDA
                       select new LichLamViecView()
                       {
                           MaCV = a.MaCV,
                           TenCV = a.Ten,
                           MaDA = a.MaDA,
                           TenDA = b.Ten,
                           NoiDung = a.NoiDung,
                           ThoiGianBD = a.ThoiGianBD,
                           ThoiGianKT = a.ThoiGianKT,
                           SoCong = a.Cong
                       };
            return data.ToList();
        }
    }
}
