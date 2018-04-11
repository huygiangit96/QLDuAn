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

        public List<DuAnViewModel> ListAll()
        {
            var list = (from c in db.CongViecs
                        select new DuAnViewModel()
                        {
                            ID = c.MaCV,
                            Ten = c.Ten,
                            TienDo = c.TienDo,
                            TrangThai = c.TrangThai,
                            //ThanhVien = null
                        }).ToList();
            foreach(var item in list)
            {
                item.ThanhVien = new NhanVienDAO().GetByProjectID(item.ID);
            }
            return list;
        }

        public bool Delete(string id)
        {
            try
            {
                List<ChiTietLichLamViec> list = db.ChiTietLichLamViecs.Where(x => x.MaCV == id).ToList();

                foreach (ChiTietLichLamViec item in list)
                {
                    db.ChiTietLichLamViecs.Remove(item);
                }
                db.SaveChanges();

                db.CongViecs.Remove(db.CongViecs.Find(id));

                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public DuAnViewModel GetProjectByID(string id)
        {
            var list = (from c in db.CongViecs
                        join k in db.KhachHangs
                        on c.MaKH equals k.MaKH
                        where(c.MaCV == id)
                        select new DuAnViewModel()
                        {
                            ID = c.MaCV,
                            Ten = c.Ten,
                            TienDo = c.TienDo,
                            TrangThai = c.TrangThai,
                            NgayBatDau = c.ThoiGianBD,
                            NgayKetThuc = c.ThoiGianKT,
                            MoTa = c.MoTa,
                            KhachHang = k.Ten
                        }).Single();

                list.ThanhVien = new NhanVienDAO().GetByProjectID(list.ID);

            return list;
        }

        public List<GhiChuViewModel> GetNoteByProID(string id)
        {
            var list = (from c in db.ChiTietLichLamViecs.OrderBy(x => x.NgayTao)
                        join n in db.NhanViens
                        on c.MaNV equals n.MaNV
                        where (c.MaCV == id)
                        select new GhiChuViewModel()
                        {
                            ID = n.MaNV,
                            Ten = n.Ten,
                            NoiDung = c.GhiChu,
                            NgayTao = c.NgayTao
                        }).ToList();
            return list;
        }
    }
}
