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
                            //TienDo = c.TienDo,
                            TrangThai = c.TrangThai,
                            NgayTao = c.NgayTao,
                            TruongDuAn = c.TruongDuAn,                    
                            //ThanhVien = null
                        }).ToList();
            foreach(var item in list)
            {
                item.TienDo = TienDo(item.ID);
                item.ThanhVien = new NhanVienDAO().GetByProjectID(item.ID);

            }
            return list;
        }
        // lay ra bang du an binh thuong
        public List<DuAn> List(int quan)
        {
            return db.DuAns.OrderByDescending(x=>x.NgayTao).Take(quan).ToList();
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
        //Lấy danh sách dự án nhân viên làm trưởng dự án
        public List<long> GetProjLead(long manv)
        {
            var data = from a in db.DuAns
                       where a.TruongDuAn == manv
                       select a.MaDA;
            return data.ToList();
        }
        public List<NhanVienViewModel> GetNVjoinProject(long mada)
        {
            var data = from a in db.CongViecs
                       join b in db.ChiTietLichLamViecs on a.MaCV equals b.MaCV
                       join c in db.NhanViens on b.MaNV equals c.MaNV
                       where a.MaDA == mada
                       select new NhanVienViewModel()
                       {
                           MaNV = b.MaNV,
                           Ten = c.Ten
                       };
            return data.Distinct().ToList();
        }

        public double TienDo(long id)
        {
            int total_cv = db.CongViecs.Where(x => x.MaDA == id).Count();
            int suc_cv = db.CongViecs.Where(x => x.MaDA == id && x.Status == 1).Count();
            return (double)suc_cv / total_cv * 100;
        }
        // truyền vào id của dự án
        public bool Auto_change_tiendo(long id)
        {
            int total_cv = db.CongViecs.Where(x => x.MaDA == id).Count();
            int suc_cv = db.CongViecs.Where(x => x.MaDA == id && x.Status == 1).Count();
            var item = db.DuAns.Find(id); 
            item.TienDo = Convert.ToDouble(suc_cv / total_cv * 100);
            db.SaveChanges();
            return true;
        }
    }
}
