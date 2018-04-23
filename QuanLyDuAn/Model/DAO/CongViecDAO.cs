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
        public List<LichLamViecView> ListCV(long manv)
        {
            var data = from a in db.CongViecs
                       join b in db.DuAns on a.MaDA equals b.MaDA
                       where b.TruongDuAn == manv
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

            if (manv != 0)
            {
                var data1 = from a in db.CongViecs
                           join b in db.DuAns on a.MaDA equals b.MaDA
                           join c in db.ChiTietLichLamViecs on a.MaCV equals c.MaCV
                           where c.MaNV == manv
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
                data1.ToList().AddRange(data.ToList());
                return data1.ToList();
            }

                var data2 = from a in db.CongViecs
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
            return data2.ToList();
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
                            TrangThai = c.Status
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
        public bool Edit_CV(CongViec item)
        {
            var dbEntry = db.CongViecs.SingleOrDefault(x => x.MaCV == item.MaCV);
            try
            {
                dbEntry.NoiDung = item.NoiDung;
                dbEntry.Ten = item.Ten;
                dbEntry.ThoiGianBD = item.ThoiGianBD;
                dbEntry.ThoiGianKT = item.ThoiGianKT;
                dbEntry.Cong = item.Cong;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Change_status(long id)
        {
            try
            {
                var item = db.CongViecs.Find(id);
                item.Status = item.Status == 0 ? 1 : 0;
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
