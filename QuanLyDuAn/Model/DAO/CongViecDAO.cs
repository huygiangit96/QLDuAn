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
        public List<CongViecViewModel> GetByProID(long id)
        {
            var list = (from c in db.CongViecs
                        join d in db.DuAns
                        on c.MaDA equals d.MaDA
                        join ct in db.ChiTietLichLamViecs
                        on c.MaCV equals ct.MaCV
                        join n in db.NhanViens
                        on ct.MaNV equals n.MaNV
                        where (ct.MaVTri == 1)
                        select new CongViecViewModel
                        {
                            ID = c.MaCV,
                            Ten = c.Ten,
                            NoiDung = c.NoiDung,
                            Leader = n.Ten,
                            Cong = c.Cong,
                            TgBatDau = c.ThoiGianBD,
                            TgKetThuc = c.ThoiGianKT,

                        }).ToList();
            return list;
        }
        public long Insert_CV(CongViec item)
        {
            try
            {
                db.CongViecs.Add(item);
                db.SaveChanges();
                return item.MaCV;
            }
            catch
            {
                return 0;
            }
        }
        public bool Delete_CV(long id)
        {
            try
            {
                // xóa chi tiết lịch làm việc
                List<ChiTietLichLamViec> list = db.ChiTietLichLamViecs.Where(x => x.MaCV == id).ToList();
                foreach (ChiTietLichLamViec c in list)
                {
                    db.ChiTietLichLamViecs.Remove(c);
                    db.SaveChanges();
                }

                //xóa công việc
                db.CongViecs.Remove(db.CongViecs.Find(id));
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
