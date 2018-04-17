using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using Model.ViewModel;

namespace Model.DAO
{
    public class DuAnDAO
    {
        QLDADbContext db = null;

        public DuAnDAO()
        {
            db = new QLDADbContext();
        }

        public List<DuAnViewModel> ListAll()
        {
            var list = (from c in db.DuAns
                        select new DuAnViewModel()
                        {
                            ID = c.MaDA,
                            Ten = c.Ten,
                            TienDo = c.TienDo,
                            TrangThai = c.TrangThai,
                            NgayTao = c.NgayTao,
                            TruongDuAn = c.TruongDuAn,                    
                            //ThanhVien = null
                        }).ToList();
            foreach(var item in list)
            {
                item.ThanhVien = new NhanVienDAO().GetByProjectID(item.ID);
            }
            return list;
        }

        public bool Delete(long id)
        {
            try
            {
                List<ChiTietLichLamViec> list = db.ChiTietLichLamViecs.Where(x => x.MaCV == id).ToList();

                foreach (ChiTietLichLamViec item in list)
                {
                    db.ChiTietLichLamViecs.Remove(item);
                }
                db.SaveChanges();

                db.DuAns.Remove(db.DuAns.Find(id));

                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public DuAnViewModel GetProjectByID(long id)
        {
            var list = (from c in db.DuAns
                        join k in db.KhachHangs
                        on c.MaKH equals k.MaKH
                        where(c.MaDA == id)
                        select new DuAnViewModel()
                        {
                            ID = c.MaDA,
                            Ten = c.Ten,
                            TienDo = c.TienDo,
                            TrangThai = c.TrangThai,
                            NgayBatDau = c.ThoiGianBD,
                            NgayKetThuc = c.ThoiGianKT,
                            MoTa = c.MoTa,
                            KhachHang = k.Ten,
                            TruongDuAn = c.TruongDuAn
                        }).Single();

                list.ThanhVien = new NhanVienDAO().GetByProjectID(list.ID);

            return list;
        }

        public bool Insert_project(DuAn item)
        {
            try
            {
                db.DuAns.Add(item);
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
