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
            if(dbEntry != null)
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
                       where cv.MaDA == id 
                       select n);
            return list.ToList();
        }
        public List<long> GetProjbyNV(long id)
        {
            var data = from a in db.ChiTietLichLamViecs
                       join b in db.CongViecs on a.MaCV equals b.MaCV
                       join c in db.DuAns on b.MaDA equals c.MaDA
                       join d in db.NhanViens on a.MaNV equals d.MaNV
                       where a.MaNV == id
                       select b.MaDA;
            return data.ToList(); 
        }
    }
}
