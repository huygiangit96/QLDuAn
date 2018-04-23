using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using Model.ViewModel;

namespace Model.DAO
{
    public class NhanVienDAO
    {
        QLDADbContext db = null;

        public NhanVienDAO()
        {
            db = new QLDADbContext();
        }

        public NhanVien GetByID(long id)
        {
            return db.NhanViens.SingleOrDefault(x => x.MaNV == id);
        }
        public NhanVien GetByUserName(string username)
        {
            return db.NhanViens.SingleOrDefault(x => x.TaiKhoan == username || x.Email == username);
        }
        public List<NhanVienViewModel> ListAll()
        {
            var list = (from n in db.NhanViens
                        join p in db.PhongBans
                        on n.MaPB equals p.MaPB
                        join v in db.VaiTroes
                        on n.MaVT equals v.MaVT
                        select new NhanVienViewModel()
                        {
                            MaNV = n.MaNV,
                            Ten = n.Ten,
                            DiaChi = n.DiaChi,
                            PhongBan = p.TenPB,
                            VaiTro = v.Ten,
                            SoDT = n.SoDT,
                            SoTK = n.SoTK,
                            TrinhDo = n.TrinhDo,
                            Email = n.Email
                        }).ToList();
            return list;
        }
        public bool Insert(NhanVien item)
        {
            try
            {
                db.NhanViens.Add(item);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(NhanVien item)
        {
            var dbEntry = GetByID(item.MaNV);
            try
            {
                dbEntry.MaPB = item.MaPB;
                dbEntry.MatKhau = item.MatKhau;
                dbEntry.MaVT = item.MaVT;
                dbEntry.SoDT = item.SoDT;
                dbEntry.SoTK = item.SoTK;
                dbEntry.TaiKhoan = item.TaiKhoan;
                dbEntry.Ten = item.Ten;
                dbEntry.TrinhDo = item.TrinhDo;
                dbEntry.Email = item.Email;
                dbEntry.DiaChi = item.DiaChi;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(long item)
        {
            var dbEntry = GetByID(item);
            try
            {
                db.NhanViens.Remove(dbEntry);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void ChangStatus(long id)
        {
            var dbEntry = GetByID(id);
            dbEntry.Status = dbEntry.Status == 0 ? 1 : 0;
        }

        public long Login(string username, string password)
        {
            var dbEntry = db.NhanViens.SingleOrDefault(x => x.TaiKhoan == username || x.Email == username);
            if (dbEntry != null)
            {
                if (dbEntry.MatKhau == password) return dbEntry.MaNV;
            }
            return 0;
        }
        public List<string> GetListCredential(string username)
        {
            var user = db.NhanViens.SingleOrDefault(x => x.TaiKhoan == username || x.Email == username);
            var data = from a in db.NhanVienQuyens
                       join b in db.VaiTroes on a.MaVT equals b.MaVT
                       join c in db.Quyens on a.MaQuyen equals c.MaQuyen
                       where b.MaVT == user.MaVT
                       select new
                       {
                           RoleID = c.TenQuyen,
                           UserGroupID = b.Ten
                       };
            return data.Select(x => x.RoleID).ToList();
        }

        public List<NhanVien> GetByProjectID(long id)
        {
            var list = (from c in db.ChiTietLichLamViecs
                        join cv in db.CongViecs
                        on c.MaCV equals cv.MaCV
                        join n in db.NhanViens
                        on c.MaNV equals n.MaNV
                        where (cv.MaDA == id && c.MaVTri == 1)
                        select n);
            return list.ToList();
        }
        //Chấm công type 1
        public List<long> GetProjbyNV(long id)
        {
            var data = from a in db.ChiTietLichLamViecs
                       join b in db.CongViecs on a.MaCV equals b.MaCV
                       join c in db.DuAns on b.MaDA equals c.MaDA
                       join d in db.NhanViens on a.MaNV equals d.MaNV
                       where a.MaNV == id
                       select b.MaDA;
            return data.Distinct().ToList();
        }
        private double? GetCongNVbyDA(long manv, long mada)
        {
            var data = from a in db.ChiTietLichLamViecs
                       join b in db.CongViecs on a.MaCV equals b.MaCV
                       join c in db.ViTris on a.MaVTri equals c.MaVTri
                       where a.MaNV == manv && b.MaDA == mada && b.Status == 1
                       select b.Cong * c.HeSo;
            if (data == null) return 0;
            return data.ToList().Sum();
        }
        private double? TongCongNV(long manv)
        {
            var data = (from a in db.ChiTietLichLamViecs
                        join b in db.CongViecs on a.MaCV equals b.MaCV
                        join c in db.DuAns on b.MaDA equals c.MaDA
                        join d in db.NhanViens on a.MaNV equals d.MaNV
                        where b.Status == 1 && a.MaNV == manv
                        select new NhanVienCCPro_ViewModel()
                        {
                            MaDA = b.MaDA,
                        }).Distinct().ToList();
            foreach (var item in data)
            {
                item.Cong = this.GetCongNVbyDA(manv, item.MaDA);
            }
            return data.Sum(x => x.Cong);
        }
        public List<NhanVienCCPro_ViewModel> GetProj_CCNone_NV()
        {
            var data = (from a in db.ChiTietLichLamViecs
                        join b in db.CongViecs on a.MaCV equals b.MaCV
                        join c in db.DuAns on b.MaDA equals c.MaDA
                        join d in db.NhanViens on a.MaNV equals d.MaNV
                        where b.Status == 1
                        select new NhanVienCCPro_ViewModel()
                        {
                            MaNV = a.MaNV,
                            Ten = d.Ten,
                            MaDA = b.MaDA,
                            TenDA = c.Ten
                        }).Distinct().ToList();
            var data1 = (from a in db.DuAns
                         join b in db.NhanViens on a.TruongDuAn equals b.MaNV
                         select new NhanVienCCPro_ViewModel()
                         {
                             MaNV = a.TruongDuAn,
                             Ten = b.Ten,
                             MaDA = a.MaDA,
                             TenDA = a.Ten + " (Project Manager)"
                         }).ToList();
            foreach (var item in data1)
            {
                item.Cong = db.CongViecs.Where(x => x.MaDA == item.MaDA).Select(n => n.Cong).Sum() * 0.1;
            }
            data.AddRange(data1);
            var data2 = data.OrderBy(x => x.MaNV).ToList();
            foreach (var item in data2)
            {
                item.TongDA = data.Where(x => x.MaNV == item.MaNV).Count();
                if (item.Cong == null) item.Cong = this.GetCongNVbyDA(item.MaNV, item.MaDA);
                item.TongCong = data.Where(x => x.MaNV == item.MaNV).Select(n => n.Cong).Sum();
            }
            return data2;
        }
        //Chấm công type 2
        public List<NhanVienCCProdetail_ViewModel> GetProj_CC_NV(long mada)
        {
            var data = (from a in db.ChiTietLichLamViecs
                        join b in db.CongViecs on a.MaCV equals b.MaCV
                        join c in db.NhanViens on a.MaNV equals c.MaNV
                        join d in db.ViTris on a.MaVTri equals d.MaVTri
                        where b.MaDA == mada
                        select new NhanVienCCProdetail_ViewModel()
                        {
                            MaNV = a.MaNV,
                            Ten = c.Ten,
                            MaCV = a.MaCV,
                            TenCV = b.Ten,
                            HeSo = d.HeSo,
                            CVStatus = b.Status,
                            MaVT = d.MaVTri,
                            SoCong = b.Cong * d.HeSo,
                            ViTri = d.Ten,
                        }).Distinct().ToList();
            var data1 = (from a in db.DuAns
                         join b in db.NhanViens on a.TruongDuAn equals b.MaNV
                         where a.MaDA == mada
                         select new NhanVienCCProdetail_ViewModel()
                         {
                             MaNV = a.TruongDuAn,
                             Ten = b.Ten,
                             TenCV = "Project Manager",
                             HeSo = 0.1,
                             CVStatus = 1,
                             SoCong = db.CongViecs.Where(x => x.MaDA == a.MaDA).Select(n => n.Cong).Sum() * 0.1,
                             ViTri = "Project Manager"
                         }).ToList();
            data.AddRange(data1);
            var data2 = data.OrderBy(x => x.MaNV).ToList();
            foreach (var item in data2)
            {
                item.TongCong = data.Where(x => x.MaNV == item.MaNV && x.CVStatus == 1).Select(n => n.SoCong).Sum();
                item.TongCV = data.Where(x => x.MaNV == item.MaNV).Select(n => n.MaNV).Count();
            }
            return data2;
        }
    }
}
