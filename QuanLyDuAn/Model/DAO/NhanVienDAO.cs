using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class NhanVienDAO
    {
        QLDADbContext db = null;

        public NhanVienDAO()
        {
            db = new QLDADbContext();
        }

        public NhanVien GetByID(string id)
        {
            return db.NhanViens.SingleOrDefault(x => x.MaNV == id);
        }
        public NhanVien GetByUserName(string username)
        {
            return db.NhanViens.SingleOrDefault(x => x.TaiKhoan == username || x.Email == username);
        }
        public List<NhanVien> ListAll()
        {
            return db.NhanViens.ToList();
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
                dbEntry.MaBP = item.MaBP;
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
        public bool Delete(string item)
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
        public void ChangStatus(string id)
        {
            var dbEntry = GetByID(id);
            dbEntry.Status = dbEntry.Status == 0 ? 1 : 0;
        }

        public bool Login(string username, string password)
        {
            var dbEntry = db.NhanViens.SingleOrDefault(x => x.TaiKhoan == username || x.Email == username);
            if(dbEntry != null)
            {
                if (dbEntry.MatKhau == password) return true;
            }
            return false;
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
    }
}
